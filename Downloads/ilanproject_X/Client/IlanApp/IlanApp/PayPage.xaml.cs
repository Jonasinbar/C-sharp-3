using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlanApp.ServiceReference1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IlanApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PayPage : ContentPage
	{
        ServiceClient srv = new ServiceClient ();
		public PayPage ()
		{
            InitializeComponent();
            srv.CmdPayByTblCompleted += Srv_CmdPayByTblCompleted;

            //srv.GetMenuCommandeByTableCompleted += GetMenuCommandeByTableCompleted;
            lstView.ItemsSource = App.Commande.MenuList;
            //http://www.csharp-examples.net/linq-sum/
            App.Commande.Price = App.Commande.MenuList.Sum(cm => cm.Quantity* cm.Mnu.Price);
            this.total.Text = $"שח {App.Commande.Price.ToString("N2")}";
            srv.GetMenuCommandeByTableAsync(App.Tbl);

            this.BindingContext = App.Commande;

           
        }

      

        //private void GetMenuCommandeByTableCompleted(object arg1, GetMenuCommandeByTableCompletedEventArgs arg2)
        //{
        //    throw new NotImplementedException();
        //}

        private void Pay_Clicked(object sender, EventArgs e)
        {
            srv.CmdPayByTblAsync(App.Tbl);
        }

        private async void Srv_CmdPayByTblCompleted(object sender, CmdPayByTblCompletedEventArgs e)
        {
            DisplayAlert("", "Thank you for eating at our Restornt. \nSee yoe soon.", "OK");
            //Navigation.InsertPageBefore(new MenuPage(), this);
            //await Navigation.PopAsync();
            //var navPage = page.Parent as NavigationPage;
            //navPage.PopAsync();

            await Navigation.PopAsync();
        }
    }
}