using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IlanApp.ServiceReference1;
using System.Diagnostics;

namespace IlanApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        MenuCommandeList fullList;
        List<MenuCommande> list;
        StatusList statusList;
        ServiceClient srv;
        List<CheckedTypeMenu> typeList= new List<CheckedTypeMenu>  ();


        public MenuPage ()
		{
            InitializeComponent();

            srv = new ServiceClient();
            srv.GetAllStatusCompleted += Srv_GetAllStatusCompleted;
            srv.GetAllStatusAsync();

            srv.GetAllTypeMenuCompleted += Srv_GetAllTypeMenuCompleted;
            srv.GetAllTypeMenuAsync();

            srv.GetAllMenuCompleted += Srv_GetAllMenuCompleted;
            srv.GetAllMenuAsync();

            srv.CmdRegisterCompleted += Srv_CmdRegisterCompleted;

        }

     
        private void Srv_GetAllStatusCompleted(object sender, GetAllStatusCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string msg = null;

                if (e.Error != null) { msg = e.Error.Message; }
                else if (e.Cancelled) { msg = "Request was cancelled."; }
                else
                {
                    statusList = e.Result as StatusList;
                    Debug.WriteLine("*** statusList :"+ statusList.Count);
                }
            });
        }

        private void Srv_GetAllTypeMenuCompleted(object sender, GetAllTypeMenuCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string msg = null;

                if (e.Error != null) { msg = e.Error.Message; }
                else if (e.Cancelled) { msg = "Request was cancelled."; }
                else
                {
                    TypeMenuList tyMnuLst = e.Result as TypeMenuList;
                    foreach (TypeMenu t in tyMnuLst)
                        typeList.Add(new CheckedTypeMenu() { check = true, Type = t });
                    TypelstView.ItemsSource = typeList;
                    Debug.WriteLine("*** TypeList :" + typeList.Count);
                }
            });
        }

        private void Srv_GetAllMenuCompleted(object sender, GetAllMenuCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string msg = null;

                if (e.Error != null) { msg = e.Error.Message; }
                else if (e.Cancelled) { msg = "Request was cancelled."; }
                else
                {
                    MnuList list = e.Result as MnuList;
                    Debug.WriteLine("*** menuList :" + list.Count);
                    fullList = new MenuCommandeList();
                    //  Debug.WriteLine("*** statusList :" + statusList.Count);
                    Status initStatus = new Status() { Id = (int)Statu.Init }; // dummy object
                    foreach (Mnu mnu in list)
                        fullList.Add(new MenuCommande() { Mnu = mnu , Status= initStatus }); 
                    this.list = fullList.ToList();
                    Debug.WriteLine("*** full menuList :" + fullList.Count);
                    refreshDisplay();
                }
            });
        }

        private void refreshDisplay()
        {
            Debug.WriteLine("*** refreshDisplay ***"+list.Count);
            this.wrapLayout.Children.Clear();
            foreach (MenuCommande menu in list)
            {
                MenuCV cv = new MenuCV(menu);
                this.wrapLayout.Children.Add(cv);
            }
        }

        private void Filter_Toggled(object sender, ToggledEventArgs e)
        {
            if (sender is Xamarin.Forms.Switch)
            {
                //the Auto Binding not working for Switch element
                Xamarin.Forms.Switch sw = sender as Xamarin.Forms.Switch;

                CheckedTypeMenu tyItem = sw.BindingContext as CheckedTypeMenu;
                if (tyItem !=null) tyItem.check = sw.IsToggled;
            }


            //if (Gluten.IsToggled)                                              // linq  create a new Object
            //    list = fullList.Where(item => item.Mnu.Glutan ).ToList();

            list = new List<MenuCommande>();
            Debug.WriteLine("*** filter: ***  gluten: " + this.Gluten.IsToggled + "   Vegan " + this.Vegan.IsToggled);
            foreach (MenuCommande item in fullList)
            {
                //Debug.WriteLine("*** Gluten ***" + item.Mnu.Glutan + " Vegan " + item.Mnu.Vegan);
                if ((!this.Gluten.IsToggled || (this.Gluten.IsToggled == item.Mnu.Glutan)) &&
                     ((!this.Vegan.IsToggled || (this.Vegan.IsToggled == item.Mnu.Vegan))))
                list.Add(item);
            }
            Debug.WriteLine("*** filter: ***  gluten: " + this.Gluten.IsToggled + "   Vegan " + this.Vegan.IsToggled);


            //list = fullList.Where(item => item.Mnu.Glutan == this.Gluten.IsToggled &&
            //                             item.Mnu.Vegan == this.Vegan.IsToggled).ToList();
            //https://stackoverflow.com/questions/37389027/use-linq-to-get-items-in-one-list-that-are-in-another-list
            //var result = peopleList1.Where(p => peopleList2.Any(p2 => p2.ID == p.ID));
            list = list.Where(item => typeList.Any(t => t.check && t.Type.Id == item.Mnu.TypeMenu.Id)).ToList();

            Debug.WriteLine("*** Filter_Toggled ***" + list.Count+" from "+fullList.Count);
            refreshDisplay();
        }

      
        private void Order_Clicked(object sender, EventArgs e)
        {
            foreach (MenuCommande menu in  fullList)
            {
                if (menu.Quantity > 0)
                {
                    if (!App.Commande.MenuList.Contains(menu))  // new in Commande
                    {
                        menu.Tbl = App.Tbl;
                        //   menu.Status
                        var status = this.statusList.Select(s => s.Id == (int)Statu.InOrder);
                        App.Commande.MenuList.Add(menu);
                    }
                    
                }
                else
                {
                    App.Commande.MenuList.Remove(menu);  // remove from Commande
                }

            }

             srv.CmdRegisterAsync(App.Tbl, App.Commande);
        }

        private void Srv_CmdRegisterCompleted(object sender, CmdRegisterCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string msg = null;

                if (e.Error != null) { msg = e.Error.Message; }
                else if (e.Cancelled) { msg = "Request was cancelled."; }
                else
                {
                    App.Commande.Id =(int) e.Result;
                  
                }
            });
        }


        private void callWaiter_Clicked(object sender, EventArgs e)
        {
            srv.CallWaiterAsync(App.Tbl);
        }

    
        private async void Pay_Clicked(object sender, EventArgs e)
        {
            srv.CmdPayByTblAsync(App.Tbl);

            await Navigation.PushAsync(new PayPage());
        }
    }

    public class CheckedTypeMenu
    {
        public bool check { set; get; }
        public TypeMenu Type { set; get; }
    }
}