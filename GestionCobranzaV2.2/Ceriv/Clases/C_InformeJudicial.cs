using System;
using Ceriv.Clases;
using Ceriv.Conexion;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_InformeJudicial
    {
        string fechaProtestoString;

        public string FechaProtestoString
        {
            get { return fechaProtestoString; }
            set { fechaProtestoString = value; }
        }
        DateTime fechaProtesto;

        public DateTime FechaProtesto
        {
            get { return fechaProtesto; }
            set { fechaProtesto = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }
        string nombreTitular;

        public string NombreTitular
        {
            get { return nombreTitular; }
            set { nombreTitular = value; }
        }
        string doi;

        public string Doi
        {
            get { return doi; }
            set { doi = value; }
        }
        string numExpediente;

        public string NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }
        string juzgado;

        public string Juzgado
        {
            get { return juzgado; }
            set { juzgado = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        string nombreProceso;

        public string NombreProceso
        {
            get { return nombreProceso; }
            set { nombreProceso = value; }
        }
        string descripcion2;

        public string Descripcion2
        {
            get { return descripcion2; }
            set { descripcion2 = value; }
        }
    }
}
