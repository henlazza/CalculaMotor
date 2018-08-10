using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCalculaMotor.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCalculaMotor.Apresentação
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaCalcularTaxaEstatica : ContentPage
	{
		public PaginaCalcularTaxaEstatica ()
		{
			InitializeComponent ();
            BotaoCalcularTE.Clicked += CalcularTaxaEstatica;
		}

        private void CalcularTaxaEstatica(object sender, EventArgs args)
        {
            Motor Motor = new Motor(Convert.ToDouble(Cilindrada.Text), Convert.ToInt32(NumCilindros.Text), Convert.ToDouble(VolCamara.Text),null);
            var _taxaestatica = Motor.TaxaEstatica;
            Resultado.Text = "Taxa Estática = " + _taxaestatica;
        }
	}
}