using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Detalle_MC_Hipoteca
    {
        int codigoCancelacion;

        public int CodigoCancelacion
        {
            get { return codigoCancelacion; }
            set { codigoCancelacion = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }

        string montoDevolucion;

        public string MontoDevolucion
        {
            get { return montoDevolucion; }
            set { montoDevolucion = value; }
        }

        string motivoDevolucion;

        public string MotivoDevolucion
        {
            get { return motivoDevolucion; }
            set { motivoDevolucion = value; }
        }

        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
