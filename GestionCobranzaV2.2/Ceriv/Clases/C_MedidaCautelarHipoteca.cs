using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_MedidaCautelarHipoteca
    {
        int codigoMCH;

        public int CodigoMCH
        {
            get { return codigoMCH; }
            set { codigoMCH = value; }
        }
        int codigoBienHipotecado;

        public int CodigoBienHipotecado
        {
            get { return codigoBienHipotecado; }
            set { codigoBienHipotecado = value; }
        }
        int codigoBienEmbargado;

        public int CodigoBienEmbargado
        {
            get { return codigoBienEmbargado; }
            set { codigoBienEmbargado = value; }
        }
        string montoTasacion;

        public string MontoTasacion
        {
            get { return montoTasacion; }
            set { montoTasacion = value; }
        }
        DateTime fechaUltTasacion;

        public DateTime FechaUltTasacion
        {
            get { return fechaUltTasacion; }
            set { fechaUltTasacion = value; }
        }
        string valorComercial;

        public string ValorComercial
        {
            get { return valorComercial; }
            set { valorComercial = value; }
        }
        string estadoCautelar;

        public string EstadoCautelar
        {
            get { return estadoCautelar; }
            set { estadoCautelar = value; }
        }
        DateTime fechaUltActCautelar;

        public DateTime FechaUltActCautelar
        {
            get { return fechaUltActCautelar; }
            set { fechaUltActCautelar = value; }
        }
        string otrosEmbargos;

        public string OtrosEmbargos
        {
            get { return otrosEmbargos; }
            set { otrosEmbargos = value; }
        }
        string montoOtrosEmbargos;

        public string MontoOtrosEmbargos
        {
            get { return montoOtrosEmbargos; }
            set { montoOtrosEmbargos = value; }
        }
        string porcentajeEmbargo;

        public string PorcentajeEmbargo
        {
            get { return porcentajeEmbargo; }
            set { porcentajeEmbargo = value; }
        }
        string vigenciaMC;

        public string VigenciaMC
        {
            get { return vigenciaMC; }
            set { vigenciaMC = value; }
        }
    }
}
