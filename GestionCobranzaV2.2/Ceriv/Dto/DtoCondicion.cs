using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ceriv.Dto
{
    class DtoCondicion
    {
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        object valor;

        public object Valor
        {
            get { return valor; }
            set { valor = value; }
        }

    }
}
