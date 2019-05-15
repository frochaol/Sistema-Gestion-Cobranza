using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_OtrasCargas
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        int codigoBien;

        public int CodigoBien
        {
            get { return codigoBien; }
            set { codigoBien = value; }
        }
        string descripcionBien;

        public string DescripcionBien
        {
            get { return descripcionBien; }
            set { descripcionBien = value; }
        }
        string acreedor;

        public string Acreedor
        {
            get { return acreedor; }
            set { acreedor = value; }
        }
        string rango;

        public string Rango
        {
            get { return rango; }
            set { rango = value; }
        }
        string montoGarantia;

        public string MontoGarantia
        {
            get { return montoGarantia; }
            set { montoGarantia = value; }
        }
        string montoAdeudado;

        public string MontoAdeudado
        {
            get { return montoAdeudado; }
            set { montoAdeudado = value; }
        }
    }
}
