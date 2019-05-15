using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Juzgado
    {
        int codigoJuzgado;

        public int CodigoJuzgado
        {
            get { return codigoJuzgado; }
            set { codigoJuzgado = value; }
        }
        string nombreJuzgado;

        public string NombreJuzgado
        {
            get { return nombreJuzgado; }
            set { nombreJuzgado = value; }
        }
    }
}
