using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceriv.Clases;
using Ceriv.Conexion;

namespace Ceriv.Clases
{
    class C_PaseTransito
    {
        string fechaTramiteString;

        public string FechaTramiteString
        {
            get { return fechaTramiteString; }
            set { fechaTramiteString = value; }
        }
        string nombreCliente;

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }
        string numCaja;

        public string NumCaja
        {
            get { return numCaja; }
            set { numCaja = value; }
        }
        string nombreRes;

        public string NombreRes
        {
            get { return nombreRes; }
            set { nombreRes = value; }
        }
        string apRes;

        public string ApRes
        {
            get { return apRes; }
            set { apRes = value; }
        }
        string amRes;

        public string AmRes
        {
            get { return amRes; }
            set { amRes = value; }
        }
        DateTime fechaTramite;

        public DateTime FechaTramite
        {
            get { return fechaTramite; }
            set { fechaTramite = value; }
        }
        string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        string cuentabt2;

        public string Cuentabt2
        {
            get { return cuentabt2; }
            set { cuentabt2 = value; }
        }
        string nombreCartera;

        public string NombreCartera
        {
            get { return nombreCartera; }
            set { nombreCartera = value; }
        }

    }
}
