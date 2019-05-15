using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Garante
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
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string nombreDistrito;

        public string NombreDistrito
        {
            get { return nombreDistrito; }
            set { nombreDistrito = value; }
        }
        string nombreCompleto;

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }
        string nombreConyuge;

        public string NombreConyuge
        {
            get { return nombreConyuge; }
            set { nombreConyuge = value; }
        }
        int codigoDistrito;

        public int CodigoDistrito
        {
            get { return codigoDistrito; }
            set { codigoDistrito = value; }
        }
        string cuentaBT;

        public string CuentaBT
        {
            get { return cuentaBT; }
            set { cuentaBT = value; }
        }
        string domicilioGarante;

        public string DomicilioGarante
        {
            get { return domicilioGarante; }
            set { domicilioGarante = value; }
        }
    }
}
