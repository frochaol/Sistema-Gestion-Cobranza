using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ceriv.Clases
{
    class C_CarteraPersona
    {
        int codigoCartera;

        public int CodigoCartera
        {
            get { return codigoCartera; }
            set { codigoCartera = value; }
        }
        string nombrePersona;

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }

        string dni;

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        
    }
}
