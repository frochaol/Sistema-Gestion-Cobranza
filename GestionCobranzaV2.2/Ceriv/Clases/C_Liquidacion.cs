using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Liquidacion
    {
        string doiCliente;

        public string DoiCliente
        {
            get { return doiCliente; }
            set { doiCliente = value; }
        }

        string nombreCliente;

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }


        string nombreModelo;

        public string NombreModelo
        {
            get { return nombreModelo; }
            set { nombreModelo = value; }
        }


        string nombrecartera;

        public string Nombrecartera
        {
            get { return nombrecartera; }
            set { nombrecartera = value; }
        }

        string cuenta_bt;

        public string Cuenta_bt
        {
            get { return cuenta_bt; }
            set { cuenta_bt = value; }
        }

        string cdr;

        public string Cdr
        {
            get { return cdr; }
            set { cdr = value; }
        }
    }
}
