﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_TipoTrabajador
    {
        int codigoTipoTrabajador;

        public int CodigoTipoTrabajador
        {
            get { return codigoTipoTrabajador; }
            set { codigoTipoTrabajador = value; }
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}