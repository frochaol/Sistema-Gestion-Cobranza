using System;
using Ceriv.Conexion;
using Ceriv.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ceriv.Conexion
{
    interface I_Ceriv
    {
        bool Proceso(int accion, C_TipoProceso objetoProceso);
        List<C_TipoProceso> ProcesoMostrar();
        C_TipoProceso ProcesoMostrar1(int codigo);

        bool Trabajador(int accion, C_Trabajador objetoTrabajador);
        List<C_Trabajador> TrabajadorMostrar();
        C_Trabajador TrabajadorMostrar1(int dniTrabajador);



    }
}
