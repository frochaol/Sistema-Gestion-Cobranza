using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_CambioModelo
    {
        string nombreCompleto;

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }
        string doiCliente;

        public string DoiCliente
        {
            get { return doiCliente; }
            set { doiCliente = value; }
        }
        string operacion;

        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        string nombreCartera;

        public string NombreCartera
        {
            get { return nombreCartera; }
            set { nombreCartera = value; }
        }
        string nombreEstudio;

        public string NombreEstudio
        {
            get { return nombreEstudio; }
            set { nombreEstudio = value; }
        }
        string tipoSolucion;

        public string TipoSolucion
        {
            get { return tipoSolucion; }
            set { tipoSolucion = value; }
        }
        string observacionTramite;

        public string ObservacionTramite
        {
            get { return observacionTramite; }
            set { observacionTramite = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }

    }
}
