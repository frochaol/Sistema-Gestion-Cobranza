using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_BH
    {
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
        int codigoHipotecado;

        public int CodigoHipotecado
        {
            get { return codigoHipotecado; }
            set { codigoHipotecado = value; }
        }
        string nombreHipotecado;

        public string NombreHipotecado
        {
            get { return nombreHipotecado; }
            set { nombreHipotecado = value; }
        }
        string montoDemandado;

        public string MontoDemandado
        {
            get { return montoDemandado; }
            set { montoDemandado = value; }
        }
        string montoHipotecado;

        public string MontoHipotecado
        {
            get { return montoHipotecado; }
            set { montoHipotecado = value; }
        }
        DateTime fechaDemanda;

        public DateTime FechaDemanda
        {
            get { return fechaDemanda; }
            set { fechaDemanda = value; }
        }
        int codigoFMC;

        public int CodigoFMC
        {
            get { return codigoFMC; }
            set { codigoFMC = value; }
        }
        string nombreCodigoFMC;

        public string NombreCodigoFMC
        {
            get { return nombreCodigoFMC; }
            set { nombreCodigoFMC = value; }
        }
        DateTime fechaPRESMC;

        public DateTime FechaPRESMC
        {
            get { return fechaPRESMC; }
            set { fechaPRESMC = value; }
        }
    }
}
