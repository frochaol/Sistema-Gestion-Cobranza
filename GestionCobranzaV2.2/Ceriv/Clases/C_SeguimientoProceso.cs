using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_SeguimientoProceso
    {
        int codigoMicro;

        public int CodigoMicro
        {
            get { return codigoMicro; }
            set { codigoMicro = value; }
        }
        int codigoMacro;

        public int CodigoMacro
        {
            get { return codigoMacro; }
            set { codigoMacro = value; }
        }
        int estadoTareaAdministrativa;

        public int EstadoTareaAdministrativa
        {
            get { return estadoTareaAdministrativa; }
            set { estadoTareaAdministrativa = value; }
        }
        int estadoTareaJudicial;

        public int EstadoTareaJudicial
        {
            get { return estadoTareaJudicial; }
            set { estadoTareaJudicial = value; }
        }
        string detalleIncidencia;

        public string DetalleIncidencia
        {
            get { return detalleIncidencia; }
            set { detalleIncidencia = value; }
        }
        string incidencia;

        public string Incidencia
        {
            get { return incidencia; }
            set { incidencia = value; }
        }
        string detalleConvenio;

        public string DetalleConvenio
        {
            get { return detalleConvenio; }
            set { detalleConvenio = value; }
        }
        string convenio;

        public string Convenio
        {
            get { return convenio; }
            set { convenio = value; }
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
        string nombrePersona;

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }
        string nombreResponsable;

        public string NombreResponsable
        {
            get { return nombreResponsable; }
            set { nombreResponsable = value; }
        }
        string fechaAdministrativaString;

        public string FechaAdministrativaString
        {
            get { return fechaAdministrativaString; }
            set { fechaAdministrativaString = value; }
        }
        string FechaSiguienteString;

        public string FechaSiguienteString1
        {
            get { return FechaSiguienteString; }
            set { FechaSiguienteString = value; }
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
        int estadoProcesal;

        public int EstadoProcesal
        {
            get { return estadoProcesal; }
            set { estadoProcesal = value; }
        }

        string nombreEstadoProcesal;

        public string NombreEstadoProcesal
        {
            get { return nombreEstadoProcesal; }
            set { nombreEstadoProcesal = value; }
        }

        DateTime fechaEstadoProcesal;

        public DateTime FechaEstadoProcesal
        {
            get { return fechaEstadoProcesal; }
            set { fechaEstadoProcesal = value; }
        }
        string tareaJudicial;

        public string TareaJudicial
        {
            get { return tareaJudicial; }
            set { tareaJudicial = value; }
        }
        DateTime fechaTareaAdministrativa;

        public DateTime FechaTareaAdministrativa
        {
            get { return fechaTareaAdministrativa; }
            set { fechaTareaAdministrativa = value; }
        }
        string tareaAdministrativa;

        public string TareaAdministrativa
        {
            get { return tareaAdministrativa; }
            set { tareaAdministrativa = value; }
        }
        string etj;

        public string Etj
        {
            get { return etj; }
            set { etj = value; }
        }
        string eta;

        public string Eta
        {
            get { return eta; }
            set { eta = value; }
        }
    }
}
