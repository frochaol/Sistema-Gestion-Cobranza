using System;
using Ceriv.Clases;
using Ceriv.Conexion;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Historico
    {
        string expediente;

        public string Expediente
        {
            get { return expediente; }
            set { expediente = value; }
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
        string texto;

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
        string llamada;

        public string Llamada
        {
            get { return llamada; }
            set { llamada = value; }
        }
        string campo;

        public string Campo
        {
            get { return campo; }
            set { campo = value; }
        }

    }
}
