using System;
using System.Collections.Generic;
using System.Text;

namespace AppCalculaMotor.Modelo
{
    public class Motor
    {
        public int TaxaEstatica { get; set; }

        public int TaxaDinamica { get; set; }

        public virtual Cilindrada Cilindrada { get; set; }
}

}
