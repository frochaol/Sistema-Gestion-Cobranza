using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Trabajador
    {
        int codigoTipoTrabajador;

        public int CodigoTipoTrabajador
        {
            get { return codigoTipoTrabajador; }
            set { codigoTipoTrabajador = value; }
        }
        string nombreCompleto;

        public string NombreCompleto
        {
            get { return nombreTrabajador + "  " + apellidoPaterno + "  " + apellidoMaterno; }
            set { nombreCompleto = value; }
        }
        string contra;

        public string Contra
        {
            get { return contra; }
            set { contra = value; }
        }
        int dniTrabajador;

        public int DniTrabajador
        {
            get { return dniTrabajador; }
            set { dniTrabajador = value; }
        }

        int dniTrabajadorNuevo;

        public int DniTrabajadorNuevo
        {
            get { return dniTrabajadorNuevo; }
            set { dniTrabajadorNuevo = value; }
        }

        string nombreTrabajador;

        public string NombreTrabajador
        {
            get { return nombreTrabajador; }
            set { nombreTrabajador = value; }
        }

        string apellidoPaterno;

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }

        string apellidoMaterno;

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }
    }
}
