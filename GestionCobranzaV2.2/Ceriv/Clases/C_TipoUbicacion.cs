using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ceriv.Clases
{
    class C_TipoUbicacion
    {
        int idTipoUbicacion;

        public int IdTipoUbicacion
        {
            get { return idTipoUbicacion; }
            set { idTipoUbicacion = value; }
        }

        string nombreTipoUbicacion;

        public string NombreTipoUbicacion
        {
            get { return nombreTipoUbicacion; }
            set { nombreTipoUbicacion = value; }
        }
        int flag;

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }


    }
}
