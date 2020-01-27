using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IlanApp.ServiceReference1;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace IlanApp
{
    public partial class App : Application
    {
        public static Table1 Tbl { get; set; }
        public static Commande Commande { get; set; }
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            //if (Tbl == null)
            //{
                MainPage = new NavigationPage(new MainPage());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new MenuPage(Commande));
            //}
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
