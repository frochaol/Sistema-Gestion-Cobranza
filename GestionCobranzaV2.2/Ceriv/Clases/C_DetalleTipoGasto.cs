using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ceriv.Clases
{
    class C_DetalleTipoGasto
    {
        int codigo_detalle;

        public int Codigo_detalle
        {
            get { return codigo_detalle; }
            set { codigo_detalle = value; }
        }

        int flag;
        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        string nombre_detalle;

        public string Nombre_detalle
        {
            get { return nombre_detalle; }
            set { nombre_detalle = value; }
        }

        int codigo_tipogasto;

        public int Codigo_tipogasto
        {
            get { return codigo_tipogasto; }
            set { codigo_tipogasto = value; }
        }
    }
}
