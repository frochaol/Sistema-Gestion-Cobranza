using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ceriv.Conexion
{

    class S_Abogados 
    {
        NpgsqlCommand _cmd;
        Conexion _conexion;
        /*
         * EJEMPLO
         * 
         * Select
         * 
         * public C_Matriz MatrizMostrar(int codigo)
            {
                string query = "select cod_matriz Cod_Matriz, nombre_matriz Nombre_Matriz, fecha_inicio Fecha_Inicio, fecha_fin Fecha_Fin, flag Flag, cod_escuela Cod_escuela from matriz where flag = 1 and cod_matriz = " + codigo;
                return _conexion.MostarClase<C_Matriz>(query);
            }
         * 
         * CRUD
         * 
         * public bool MatrizAsignaturaDocente(int accion, C_MatrizAsignaturaDocente objetoMatriz)
            {
                _cmd.Parameters.Clear();
                _cmd.Parameters.AddWithValue("_accion", accion);
                _cmd.Parameters.AddWithValue("_cod_matasigdoc", objetoMatriz.Cod_matasigdoc);
                _cmd.Parameters.AddWithValue("_cod_matasig", objetoMatriz.Cod_matasig);
                _cmd.Parameters.AddWithValue("cod_docente", objetoMatriz.Cod_docente);
                _cmd.Parameters.AddWithValue("_cod_tipodocente", objetoMatriz.Cod_tipodocente);
                _cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                return _conexion.InsertarModificarEliminart<bool>("spr_matriz_asignatura_docente", _cmd);
            }
         * 
         */
        




    }
}
