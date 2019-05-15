using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Proceso
    {
        string operacionCodigo;

        public string OperacionCodigo
        {
            get { return operacionCodigo; }
            set { operacionCodigo = value; }
        }
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
        string nombre_proceso;

        public string Nombre_proceso
        {
            get { return nombre_proceso; }
            set { nombre_proceso = value; }
        }
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string funcion;

        public string Funcion
        {
            get { return funcion; }
            set { funcion = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }
        int codigoMacro;

        public int CodigoMacro
        {
            get { return codigoMacro; }
            set { codigoMacro = value; }
        }
        DateTime fechaDemanda;

        public DateTime FechaDemanda
        {
            get { return fechaDemanda; }
            set { fechaDemanda = value; }
        }
        int codigoMicro;

        public int CodigoMicro
        {
            get { return codigoMicro; }
            set { codigoMicro = value; }
        }
        int codigoEtapa;

        public int CodigoEtapa
        {
            get { return codigoEtapa; }
            set { codigoEtapa = value; }
        }
        int codigoMedida;

        public int CodigoMedida
        {
            get { return codigoMedida; }
            set { codigoMedida = value; }
        }
        string tiempo;

        public string Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
        DateTime fechaEtapa;

        public DateTime FechaEtapa
        {
            get { return fechaEtapa; }
            set { fechaEtapa = value; }
        }
        DateTime fechaInscripcion;

        public DateTime FechaInscripcion
        {
            get { return fechaInscripcion; }
            set { fechaInscripcion = value; }
        }
        string estadoCautelar;

        public string EstadoCautelar
        {
            get { return estadoCautelar; }
            set { estadoCautelar = value; }
        }
        DateTime fechaMedidaCautelar;

        public DateTime FechaMedidaCautelar
        {
            get { return fechaMedidaCautelar; }
            set { fechaMedidaCautelar = value; }
        }
        string vigenciaMC;

        public string VigenciaMC
        {
            get { return vigenciaMC; }
            set { vigenciaMC = value; }
        }
        DateTime fechaActuadoCautelar;

        public DateTime FechaActuadoCautelar
        {
            get { return fechaActuadoCautelar; }
            set { fechaActuadoCautelar = value; }
        }
        string devolucionCedula;

        public string DevolucionCedula
        {
            get { return devolucionCedula; }
            set { devolucionCedula = value; }
        }
    }
}
