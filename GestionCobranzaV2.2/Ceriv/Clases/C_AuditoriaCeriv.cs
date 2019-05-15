using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_AuditoriaCeriv
    {
        DateTime fechaModificacion;

        public DateTime FechaModificacion
        {
            get { return fechaModificacion; }
            set { fechaModificacion = value; }
        }
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        string campo;

        public string Campo
        {
            get { return campo; }
            set { campo = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }
        int dniTrabajador;

        public int DniTrabajador
        {
          get { return dniTrabajador; }
          set { dniTrabajador = value; }
        }
        string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }



    }
}
