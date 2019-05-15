using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Pagos
    {
        string num_expediente;

        public string Num_expediente
        {
            get { return num_expediente; }
            set { num_expediente = value; }
        }
        string operacion;

        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        string fechaPagoStrin;

        public string FechaPagoStrin
        {
            get { return fechaPagoStrin; }
            set { fechaPagoStrin = value; }
        }
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }
        string tipoSolucion;

        public string TipoSolucion
        {
            get { return tipoSolucion; }
            set { tipoSolucion = value; }
        }
        string pago;

        public string Pago
        {
            get { return pago; }
            set { pago = value; }
        }
        string comision;

        public string Comision
        {
            get { return comision; }
            set { comision = value; }
        }
        DateTime fechaPago;

        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }
        string nombrePersona;

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }
        string nombreCartera;

        public string NombreCartera
        {
            get { return nombreCartera; }
            set { nombreCartera = value; }
        }
        string nombreMoneda;

        public string NombreMoneda
        {
            get { return nombreMoneda; }
            set { nombreMoneda = value; }
        }
    }
}
