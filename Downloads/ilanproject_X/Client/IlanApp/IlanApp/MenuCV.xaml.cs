using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IlanApp.ServiceReference1;

namespace IlanApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuCV : ContentView
	{
        private int quantity;
        public int Quantity { get => this.menu.Quantity; set => this.menu.Quantity = value; }

        MenuCommande menu;
        public MenuCommande Menu { get => this.menu; set => this.menu = value; }

        BorderConverter borderConv = new BorderConverter();

        public MenuCV ()
		{
			InitializeComponent ();
		}
        public MenuCV(MenuCommande menu)
        {
            this.menu = menu;
            InitializeComponent();
            //  grid.GestureRecognizers.Add((new TapGestureRecognizer((view) => OnGridClicked())));
            if (Menu.Status.Id != (int)Statu.Init)
            {
                this.minusButton.IsEnabled = true;
                this.plusButton.IsEnabled = true;
                this.Slider.IsEnabled = true;
            }
            this.BindingContext = this.Menu;
        }

        public void OnGridClicked()
        {
            int yy = 9;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            int yy = 9;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            this.frame.BorderColor = (Color) borderConv.Convert(this.menu, null, null, null) ;
        }

        private void Plus_clicked(object sender, EventArgs e)
        {
            this.Quantity++;
            this.Slider.Value = this.Quantity;
           // Slider_ValueChanged(null,null);
        }

        private void Minus_clicked(object sender, EventArgs e)
        {
            this.Quantity--;
            this.Quantity = Math.Max(0, this.Quantity);
            this.Slider.Value = this.Quantity;
        }
    }
}