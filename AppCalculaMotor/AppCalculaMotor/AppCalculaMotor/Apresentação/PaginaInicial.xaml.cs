using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCalculaMotor.Apresentação
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaInicial : ContentPage
	{
		public PaginaInicial ()
		{
			InitializeComponent ();
		}

        private void CalcularTaxaEstatica(object sender, EventArgs args)
        {
            //App.Current.MainPage = new Apresentação.PaginaCalcularTaxaEstatica();
            Navigation.PushAsync(new Apresentação.PaginaCalcularTaxaEstatica());
        }

    }
}