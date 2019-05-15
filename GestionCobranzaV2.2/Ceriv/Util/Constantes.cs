using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ceriv.Util
{
    static class Constantes
    {
        public static readonly int CREATE = 1;
        public static readonly int UPDATE = 2;
        public static readonly int DELETE = 3;
        public static readonly string PRIMARYKEY = "primaryKey";
        public static readonly string COLUMN = "column";
        public static readonly string MANYTOONE = "manyToOne";
        public static readonly string ONETOMANY = "oneToMany";
        public static readonly string ENTIDAD = "entidad";
        public static readonly string TABLA = "tabla";
        public static readonly string ACCION = "_accion";
        public static readonly string SELECT = "select ";
        public static readonly string FROM = "from ";
        public static readonly string WHERE = "where ";
    }
}
