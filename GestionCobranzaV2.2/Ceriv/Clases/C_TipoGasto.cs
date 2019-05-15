using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ceriv.Clases
{
    class C_TipoGasto
    {

        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        int flag;
        public int Flag
        {
            get { return flag; }
            set { flag = value;}
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
