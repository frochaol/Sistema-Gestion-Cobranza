using Ceriv.Atributos;
using Ceriv.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ceriv.Conexion;
using Npgsql;
namespace Ceriv.Api
{
    class ApiGenerico<C> where C : new()
    {
        Dictionary<string, string[]> _diccionario;
        Dictionary<string, string> _principal;
        Conexion.Conexion _conexion;
        NpgsqlCommand _cmd;
        public ApiGenerico()
        {
            C clase = new C();
            _principal =  obtenerPropiedadesClase(clase);
            if (_principal != null)
            {
                _diccionario = ObtenerPropiedadesAtributo(clase);
                _conexion = Conexion.Conexion.ObtenerInstancia();
            }
        }        

        private Dictionary<string, string> obtenerPropiedadesClase<T>(T clase) where T : new()
        {
            Dictionary<string,string> principal = new Dictionary<string,string>();
            Attribute[] atributos = System.Attribute.GetCustomAttributes(typeof(T));
            foreach (Attribute atributo in atributos)
            {
                if (atributo is EntityAttribute)
                {
                    EntityAttribute entidad = (EntityAttribute)atributo;
                    principal.Add(Util.Constantes.ENTIDAD, entidad.StoreProcedure.ToString());
                }
                if (atributo is TableAttribute)
                {
                    TableAttribute table = (TableAttribute)atributo;
                    principal.Add(Util.Constantes.TABLA,  table.Table);
                }
            }
            if (!principal.ContainsKey(Util.Constantes.ENTIDAD) || !principal.ContainsKey(Util.Constantes.TABLA))
            {
                return null;
            }
            return principal;            
        }

        private Dictionary<string, string[]> ObtenerPropiedadesAtributo<T>(T clase) where T : new()
        {
            Dictionary<string, string[]> diccionario = new Dictionary<string,string[]>();
            List<string> listaColumnas = new List<string>();
            List<string> primaryKeyColumnas = new List<string>();
            List<string> oneToManyColumnas = new List<string>();
            List<string> manyToOneColumnas = new List<string>();
            FieldInfo[] fields = clase.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                object[] atributosField = field.GetCustomAttributes(true);
                foreach (object objetoAtributo in atributosField)
                {
                    if (objetoAtributo is ColumnAttribute)
                    {
                        ColumnAttribute columna = (ColumnAttribute)objetoAtributo;
                        listaColumnas.Add(columna.Column);
                        if (columna.PrimaryKey)
                            _principal.Add(Util.Constantes.PRIMARYKEY, columna.Column);
                        else if (columna.OneToMany != null)
                            oneToManyColumnas.Add(columna.Column);
                        else if (columna.ManyToOne != null)
                            manyToOneColumnas.Add(columna.Column);
                            
                    }
                }
            }
            diccionario.Add(Util.Constantes.COLUMN, listaColumnas.ToArray());
            diccionario.Add(Util.Constantes.MANYTOONE, manyToOneColumnas.ToArray());
            diccionario.Add(Util.Constantes.ONETOMANY, oneToManyColumnas.ToArray());
            return diccionario;
        }

        public List<C> selectAll()
        {
            string query = Util.Constantes.SELECT;
            foreach (string column in _diccionario[Util.Constantes.COLUMN])
            {
                query += column + " ,";
            }
            query = query.TrimEnd(',');
            query += Util.Constantes.FROM + _principal[Util.Constantes.TABLA];
            return _conexion.MostarLista<C>(query);
        }
        //Read
        public C read<T>(ref T valor) 
        {
            string query = Util.Constantes.SELECT;
            foreach (string column in _diccionario[Util.Constantes.COLUMN])
            {
                query += column + " ,";
            }
            query = query.TrimEnd(',');
            query += Util.Constantes.FROM + _principal[Util.Constantes.TABLA];
            query += " " + Util.Constantes.WHERE + " " + _principal[Util.Constantes.PRIMARYKEY] + " = ";
            if (valor is int || valor is float || valor is double || valor is decimal)
            {
                query += valor;
            }
            else 
            {
                query += "'" + valor + "'";
            }
            return _conexion.Read<C>(query);
        }
        //Seleccionar todo
        public List<C> SelectEager()
        {
            return null;
        }
        //En construccion
        public bool Save()
        {
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue(Util.Constantes.ACCION,Util.Constantes.CREATE);
            /*
             *  _cmd.Parameters.AddWithValue("_cod_tipodocente", objetoMatriz.Cod_tipodocente);
             *  _cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
             */
            return _conexion.Crud<bool>(_principal[Util.Constantes.ENTIDAD], _cmd);
        }
        //En construccion
        public bool Update()
        {
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue(Util.Constantes.ACCION, Util.Constantes.UPDATE);
            /*
             *  _cmd.Parameters.AddWithValue("_cod_tipodocente", objetoMatriz.Cod_tipodocente);
             *  _cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
             */
            return _conexion.Crud<bool>(_principal[Util.Constantes.ENTIDAD], _cmd);
        }
        //En construccion
        public bool Delete()
        {
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue(Util.Constantes.ACCION, Util.Constantes.DELETE);
            /*
             *  _cmd.Parameters.AddWithValue("_cod_tipodocente", objetoMatriz.Cod_tipodocente);
             *  _cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
             */
            return _conexion.Crud<bool>(_principal[Util.Constantes.ENTIDAD], _cmd);
        }

    }
}
