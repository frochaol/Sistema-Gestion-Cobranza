using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Micro
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        int codigoEstado;

        public int CodigoEstado
        {
            get { return codigoEstado; }
            set { codigoEstado = value; }
        }
    }
}
