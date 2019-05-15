using Ceriv.Dto;
using Npgsql;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ceriv.Conexion
{
    class DinamicoSelect 
    {
        NpgsqlCommand _cmd;
        Conexion _conexion = Conexion.ObtenerInstancia();
        public DinamicoSelect()
        {
            
        }
        public List<T> DinamicoMostarLista<T>(DtoCondicion condicion = null) where T : new()
        {
            List<T> listaClase = new List<T>();
            var data = new T();
            PropertyInfo[] Properties = data.GetType().GetProperties();
            StringBuilder campos = new StringBuilder();
            bool flag = false;
            foreach (var p in Properties)
            {
                if(flag || condicion != null)
                    if (p.Name == condicion.Nombre)
                        flag = true;
                campos.Append( p.Name + ", ");
            }
            campos.Remove(campos.Length - 2, 2);
            StringBuilder query = new StringBuilder();
            query.Append("select " + campos + " from " + data.GetType().Name + " where flag = 1");
            if (condicion != null && flag)
            {
                if (condicion.Valor.GetType() == typeof(string))
                       query.Append(" and " + condicion.Nombre + " = '" + condicion.Valor + "'");
                if (condicion.Valor.GetType() != typeof(string))
                    query.Append(" and " + condicion.Nombre + " = " + condicion.Valor);
            }
            return _conexion.MostarLista<T>(query.ToString());
        }
    }

}
