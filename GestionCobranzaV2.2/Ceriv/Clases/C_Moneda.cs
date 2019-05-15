using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Moneda
    {
        int codigoMoneda;

        public int CodigoMoneda
        {
            get { return codigoMoneda; }
            set { codigoMoneda = value; }
        }
        string nombreMoneda;

        public string NombreMoneda
        {
            get { return nombreMoneda; }
            set { nombreMoneda = value; }
        }
    }
}
