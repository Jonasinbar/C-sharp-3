using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using IlanApp.ServiceReference1;
using System.ComponentModel;



namespace IlanApp
{
    public partial class MainPage : ContentPage
    {
        ServiceClient srv;
        public MainPage()
        {
            InitializeComponent();
            srv = new ServiceClient();
            //   srv.LogoutTblCompleted += Srv_LogoutTblCompleted;  no need , becouse is a void function
            srv.FreeTablesCompleted += Srv_FreeTablesCompleted;
            srv.FreeTablesAsync();

            //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/picker/populating-itemssource

        }

        private void Srv_FreeTablesCompleted(object sender, FreeTablesCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string msg = null;

                if (e.Error != null) { msg = e.Error.Message; }
                else if (e.Cancelled) { msg = "Request was cancelled."; }
                else
                {
                    Table1List list = e.Result as Table1List;
                    this.TableNumPicker.ItemsSource = list;
                   
                }

                //Navigation.InsertPageBefore(new MenuPage(), this);
                //await Navigation.PopAsync();

                //this.textBox1.Text = msg;
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Table1 tbl = this.TableNumPicker.SelectedItem as Table1;
            App.Tbl = tbl;
            srv.LoginTblAsync(tbl);
            //  srv.LoginTblAsync(tableNumTxt.Text);

            // Commande commande = new Commande();
            App.Commande = new Commande();
            App.Commande.MenuList = new MenuCommandeList();

            Navigation.InsertPageBefore(new MenuPage(), this);
            await Navigation.PopAsync();
        }

        private async void TableNum_Changed(object sender, EventArgs e)
        {
            this.selectBtn.IsEnabled = (this.TableNumPicker.SelectedItem!=null);
            //Table1 tbl = this.TableNumPicker.SelectedItem as Table1;
            //srv.LoginTblAsync(tbl);
            //Navigation.InsertPageBefore(new MainPage(), this);
            //await Navigation.PopAsync();
        }

        /*
        private void Srv_LoginTblCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string msg = null;
                
                if (e.Error != null) { msg = e.Error.Message; }
                else if (e.Cancelled) { msg = "Request was cancelled."; }
                else
                {
                    App.Tbl = e.Result as Table1;
                    if (App.Tbl != null)
                    {
                        Navigation.InsertPageBefore(new MainPage(), this);
                        await Navigation.PopAsync();
                    }
                    else
                    {
                     //   messageLabel.Text = "Login failed";

                    }
                }
                
                Navigation.InsertPageBefore(new MenuPage(), this);
                await Navigation.PopAsync();

                //this.textBox1.Text = msg;
            });
        }
        */

    }
}
