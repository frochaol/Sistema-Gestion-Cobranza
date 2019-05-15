using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_Ubicacion
    {
        string numExpediente;

        public string NumExpediente
        {
            get { return numExpediente; }
            set { numExpediente = value; }
        }
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        byte[] imagen;

        public byte[] Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        string cuenta_bt;

        public string Cuenta_bt
        {
            get { return cuenta_bt; }
            set { cuenta_bt = value; }
        }

        int id_tipoUbicacion;

        public int Id_tipoUbicacion 
        {
            get { return id_tipoUbicacion; }
            set { id_tipoUbicacion = value; }
        }

        int visita;

        public int Visita
        {
            get { return visita; }
            set { visita = value; }
        }
    }
}
