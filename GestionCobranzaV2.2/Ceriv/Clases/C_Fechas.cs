using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Fechas
    {
        DateTime fechaApelacion;

        public DateTime FechaApelacion
        {
            get { return fechaApelacion; }
            set { fechaApelacion = value; }
        }
        DateTime fechaAutoFinal;

        public DateTime FechaAutoFinal
        {
            get { return fechaAutoFinal; }
            set { fechaAutoFinal = value; }
        }
        DateTime fechaDemanda;

        public DateTime FechaDemanda
        {
            get { return fechaDemanda; }
            set { fechaDemanda = value; }
        }
        string codigoOperacion;

        public string CodigoOperacion
        {
            get { return codigoOperacion; }
            set { codigoOperacion = value; }
        }
        string num_Expediente;

        public string Num_Expediente
        {
            get { return num_Expediente; }
            set { num_Expediente = value; }
        }
        string operacion;

        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        string funcion;

        public string Funcion
        {
            get { return funcion; }
            set { funcion = value; }
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
        DateTime fechaMando;

        public DateTime FechaMando
        {
            get { return fechaMando; }
            set { fechaMando = value; }
        }
        DateTime fechaContradiccion;

        public DateTime FechaContradiccion
        {
            get { return fechaContradiccion; }
            set { fechaContradiccion = value; }
        }
        DateTime fechaOrden;

        public DateTime FechaOrden
        {
            get { return fechaOrden; }
            set { fechaOrden = value; }
        }
        DateTime fechaRematecaptura;

        public DateTime FechaRematecaptura
        {
            get { return fechaRematecaptura; }
            set { fechaRematecaptura = value; }
        }
        DateTime fechaAdjucaptura;

        public DateTime FechaAdjucaptura
        {
            get { return fechaAdjucaptura; }
            set { fechaAdjucaptura = value; }
        }
    }
}
