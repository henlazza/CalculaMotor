using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppCalculaMotor.Modelo;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void instanciarMotorPassandoCilindrada()
        {
            var motor = new Motor(1600, null, null, 4);
            var teste1 = Math.Round(motor.Cilindrada);
        }

        [TestMethod]
        public void instanciarMotorCalculandoCilindrada()
        {
            //var motor = new Motor(null, 2, 10, 4);
            var motor = new Motor(null,15,2.27,4);
            var teste2 = Math.Round(motor.Cilindrada);
        }

        [TestMethod]
        public void instanciarMotorCalculandoTaxaEstatica()
        {
            var motor = new Motor(1600, 4, 100, null);
            var teste3 = motor.TaxaEstatica;
        }

        [TestMethod]
        public void instanciarMotorCalculandoVolumeCamara()
        {
            var motor = new Motor(1600,4,7);
            var teste4 = Math.Round(motor.VolumeCamara);
        }

        [TestMethod]
        public void instanciarMotorCalculandoTaxaDinamica()
        {
            var motor = new Motor(7,0.8);
            var teste5 = Math.Round(motor.TaxaDinamica);
        }

        [TestMethod]
        public void instanciarMotorCalculandoPressaoTurboTaxaDinamicaIdeal()
        {
            var motor = new Motor(7);
            var teste6 = Math.Round(motor.PressaoTurbo);
        }

        [TestMethod]
        public void instanciarMotorCalculandoTaxaEstaticaComPressaoTurboTaxaDinamicaIdeal()
        {
            var motor = new Motor(0.8);
            var teste6 = motor.TaxaEstatica;
        }
    }
}
