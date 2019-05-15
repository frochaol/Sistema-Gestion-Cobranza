using Ceriv.Atributos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ceriv.Conexion
{
    class Conexion
    {
        private static Conexion _instancia = null;
        private const string RUTA = "localhost";
        private const string PUERTO = "5432";
        private const string ID = "postgres";
        private const string PASSWORD = "root";
        private const string DATABASE = "Ceriv";
        static string cadenaConexion = "Server=" + RUTA + "; port = " + PUERTO + " ;User Id=" + ID + ";Password=" + PASSWORD + ";Database=" + DATABASE;
        private Conexion() {}
        public static Conexion ObtenerInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Conexion();
            }
            return _instancia;
        }

        public T Crud <T>(string procedimientoalmacenado, NpgsqlCommand cmd)
        {
            T resultado = default(T);
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = procedimientoalmacenado;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                cmd.Parameters[":resultado"].Value.GetType();
                resultado = (T)Convert.ChangeType(cmd.Parameters[":resultado"].Value, typeof(T));
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ingresar, modificar y/o eliminar " + procedimientoalmacenado, ex);
            }
            finally
            {
                cnn.Close();
            }
            return (T)Convert.ChangeType(resultado, typeof(T));
        }

        public List<T> MostarLista<T>(string query) where T : new()
        {
            List<T> listaClase = new List<T>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    Dictionary<string,string> diccionario = ObtenerPropiedadesAtributo(new T());
                    while (rd.Read())
                    {
                        T clase = new T();
                        foreach (KeyValuePair<string, string> palabra in diccionario)
                        {
                            var field = clase.GetType().GetField(palabra.Key, BindingFlags.NonPublic | BindingFlags.Instance);
                            field.SetValue(clase, rd.GetValue(rd.GetOrdinal(palabra.Value)));
                        }
                        listaClase.Add(clase);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Mostrar clase" + listaClase.GetType(), ex);
            }
            finally
            {
                cnn.Close();
            }
            return listaClase;
        }

        public T Read<T>(string query) where T : new()
        {
            T clase = new T();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    Dictionary<string, string> diccionario = ObtenerPropiedadesAtributo(new T());
                    while (rd.Read())
                    {
                        foreach (KeyValuePair<string, string> palabra in diccionario)
                        {
                            var field = clase.GetType().GetField(palabra.Key, BindingFlags.NonPublic | BindingFlags.Instance);
                            field.SetValue(clase, rd.GetValue(rd.GetOrdinal(palabra.Value)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Mostrar clase" + clase.GetType(), ex);
            }
            finally
            {
                cnn.Close();
            }
            return clase;
        }

        private Dictionary<string, string> ObtenerPropiedadesAtributo<T>(T clase) where T : new()
        {
            Dictionary<string, string> diccionario = new Dictionary<string, string>();
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
                        diccionario.Add(field.Name, columna.Column);
                    }
                }
            }
            return diccionario;
        }

        [System.Obsolete("Usar Read")]
        public T MostarClase<T>(string query) where T : new()
        {
            T objetoClase = default(T);
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        var data = new T();
                        PropertyInfo[] Properties = data.GetType().GetProperties();
                        foreach (var p in Properties)
                        {
                            p.SetValue(data, rd.GetValue(rd.GetOrdinal(p.Name)), null);
                        }
                        objetoClase = data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Mostrar clase" + objetoClase.GetType(), ex);
            }
            finally
            {
                cnn.Close();
            }
            return objetoClase;
        }
    }
}
