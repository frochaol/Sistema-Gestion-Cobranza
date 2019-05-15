using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Expediente
    {
        string nombreTipoProceso;

        public string NombreTipoProceso
        {
            get { return nombreTipoProceso; }
            set { nombreTipoProceso = value; }
        }
        string numJuzgado;

        public string NumJuzgado
        {
            get { return numJuzgado; }
            set { numJuzgado = value; }
        }
        string expedienteNuevo;

        public string ExpedienteNuevo
        {
            get { return expedienteNuevo; }
            set { expedienteNuevo = value; }
        }
        string operacion;

        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        string numExpediente;

        public string NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }
        int codigoTipoProceso;

        public int CodigoTipoProceso
        {
            get { return codigoTipoProceso; }
            set { codigoTipoProceso = value; }
        }
        int trabajadorAbogado;

        public int TrabajadorAbogado
        {
            get { return trabajadorAbogado; }
            set { trabajadorAbogado = value; }
        }
        int trabajadoResponsable;

        public int TrabajadoResponsable
        {
            get { return trabajadoResponsable; }
            set { trabajadoResponsable = value; }
        }
        string trabajadorSecretario;

        public string TrabajadorSecretario
        {
            get { return trabajadorSecretario; }
            set { trabajadorSecretario = value; }
        }
        string numExpediente22Digitos;

        public string NumExpediente22Digitos
        {
            get { return numExpediente22Digitos; }
            set { numExpediente22Digitos = value; }
        }

        string juzgado;

        public string Juzgado
        {
            get { return juzgado; }
            set { juzgado = value; }
        }
        string codigoCautelar;

        public string CodigoCautelar
        {
            get { return codigoCautelar; }
            set { codigoCautelar = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }
    }
}
