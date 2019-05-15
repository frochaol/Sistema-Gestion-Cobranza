using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_TipoProceso
    {
        int codigoProceso;

        public int CodigoProceso
        {
            get { return codigoProceso; }
            set { codigoProceso = value; }
        }
        string nombreProceso;

        public string NombreProceso
        {
            get { return nombreProceso; }
            set { nombreProceso = value; }
        }
    }
}
