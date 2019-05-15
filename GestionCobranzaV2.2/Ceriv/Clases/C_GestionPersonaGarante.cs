using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_GestionPersonaGarante
    {
        string nombrePersona;

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }
        string nombreGarante;

        public string NombreGarante
        {
            get { return nombreGarante; }
            set { nombreGarante = value; }
        }
        string nombreConcatenado;

        public string NombreConcatenado
        {
            get { return nombreConcatenado; }
            set { nombreConcatenado = value; }
        }

    }
}
