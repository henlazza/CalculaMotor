using System;
using System.Collections.Generic;
using System.Text;

namespace AppCalculaMotor.Modelo
{
    public class Motor
    {
        //Refatorar o código tendo 1 contrutor que recebe como parametro todas as propriedades da Classe. Usaremos as funções de calculos conforme os parametros do construtor.

        public Motor(double? cilindrada, double? diametrocilindro, double? cursopistao, int numerocilindros)
        {
            if(cilindrada == null && diametrocilindro != null && cursopistao != null){
                DiametroCilindro = diametrocilindro;
                CursoPistao = cursopistao;
                NumeroCilindros = numerocilindros;

                Cilindrada = CalcularCilindrada(Convert.ToDouble(DiametroCilindro), Convert.ToDouble(CursoPistao), Convert.ToInt32(NumeroCilindros));
            }
            else if(cilindrada != null)
            {
                Cilindrada = Convert.ToDouble(cilindrada);
            }

            NumeroCilindros = numerocilindros;

        }

        public Motor(double cilindrada, int numerocilindros ,double volumecamara, int? taxaestatica)
        {
            if(TaxaEstatica != null)
            {
                TaxaEstatica = taxaestatica;
            }
            else
            {
                double cilindradaIndividual = cilindrada / Convert.ToDouble(numerocilindros);
                TaxaEstatica = CalcularTaxaEstatica(volumecamara, cilindradaIndividual);
            }
        }

        public Motor(double cilindrada, int numerocilindros, int taxaestatica)
        {
            double cilindradaIndividual = cilindrada / numerocilindros;
            VolumeCamara = CalcularVolumeCamara(cilindradaIndividual, taxaestatica);
        }

        public Motor(int taxaestatica, double pressaoturbo)
        {
            TaxaDinamica = CalcularTaxaDinamica(taxaestatica, pressaoturbo);
        }

        public Motor(int taxaestatica)
        {
            PressaoTurbo = CalcularTurboComTaxaDinamicaIdeal(taxaestatica);
        }

        public Motor(double pressaoturbo)
        {
            TaxaEstatica = CalcularTaxaEstaticaComPressaoTurboTaxaDinamicaIdeal(pressaoturbo);
        }

        public double? TaxaEstatica { get; private set; }
        public double TaxaDinamica { get; set; }
        public double? DiametroCilindro { get; set; }
        public double? CursoPistao { get; set; }
        public int NumeroCilindros { get; set; }
        public double Cilindrada { get; private set; }
        public double VolumeCamara { get; private set; }
        public double PressaoTurbo { get; private set; }

        public double CalcularCilindrada(double DiametroCilindro, double CursoPistao, int NumeroCilindros)
        {
            return Math.Pow((DiametroCilindro / 2),2) * Math.PI * Convert.ToDouble(CursoPistao) * NumeroCilindros;
        }

        public int CalcularTaxaEstatica(double volumecamara, double cilindradaindividual)
        {
            return Convert.ToInt32(Math.Round((cilindradaindividual + volumecamara) / volumecamara));
        }

        public double CalcularVolumeCamara(double cilindradaindividual, double taxaestatica)
        {
            return cilindradaindividual / (taxaestatica - 1);
        }

        public double CalcularTaxaDinamica(int taxaestatica, double pressaoturbo)
        {
            return taxaestatica * (pressaoturbo + 1);
        }

        public double CalcularTurboComTaxaDinamicaIdeal(int taxaestatica)
        {
            int taxadinamicaideal = 20;
            return (taxadinamicaideal - taxaestatica)/taxaestatica;
        }

        public double CalcularTaxaEstaticaComPressaoTurboTaxaDinamicaIdeal(double pressaoturbo)
        {
            int taxadinamicaideal = 20;
            return Math.Round(taxadinamicaideal / (pressaoturbo + 1));
        }

        public double CalcularAjusteAlturaCilindro(double diametro, double volume)
        {
            return (Math.Pow((diametro / 2), 2) * Math.PI) / volume;
        }

        public double CalcularAjusteParaTaxacaoMotor(double taxadesejada, double volumecamaraatual, double cilindradaindividual, double diametrocamara)
        {
            double volumecamaranecessario = CalcularVolumeCamara(cilindradaindividual, taxadesejada);
            double diferencavolumecamara = volumecamaraatual - volumecamaranecessario;

            return CalcularAjusteAlturaCilindro(diametrocamara, diferencavolumecamara);
        }
    }

}
