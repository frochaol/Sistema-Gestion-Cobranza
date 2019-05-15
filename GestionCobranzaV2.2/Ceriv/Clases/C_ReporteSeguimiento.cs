using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceriv.Clases
{
    class C_ReporteSeguimiento
    {
        string num_Expediente;

        public string Num_Expediente1
        {
            get { return num_Expediente; }
            set { num_Expediente = value; }
        }

        string estadoProcesal;

        public string EstadoProcesal
        {
            get { return estadoProcesal; }
            set { estadoProcesal = value; }
        }

        DateTime fecha_EstadoProcesal;

        public DateTime Fecha_EstadoProcesal
        {
            get { return fecha_EstadoProcesal; }
            set { fecha_EstadoProcesal = value; }
        }

        string tarea_Judicial;

        public string Tarea_Judicial
        {
            get { return tarea_Judicial; }
            set { tarea_Judicial = value; }
        }

        DateTime fecha_TarejaAdministrativa;

        public DateTime Fecha_TarejaAdministrativa
        {
            get { return fecha_TarejaAdministrativa; }
            set { fecha_TarejaAdministrativa = value; }
        }
        string tareaAdministrativa;

        public string TareaAdministrativa
        {
            get { return tareaAdministrativa; }
            set { tareaAdministrativa = value; }
        }
        string incidencia;

        public string Incidencia
        {
            get { return incidencia; }
            set { incidencia = value; }
        }
        string detalleIncidencia;

        public string DetalleIncidencia
        {
            get { return detalleIncidencia; }
            set { detalleIncidencia = value; }
        }

    }
}
