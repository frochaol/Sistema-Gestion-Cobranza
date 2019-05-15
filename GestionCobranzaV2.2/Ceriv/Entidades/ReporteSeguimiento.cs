using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_reporteSeguimiento")]
    [Table("reporte_seguimiento")]
    class ReporteSeguimiento
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoReporteSeguimiento;

        [Column("num_expediente", ManyToOne="num_expediente")]
        private string numExpediente;

        [Column("estado_procesal")]
        private string estadoProcesal;

        [Column("fecha_estado_procesal")]
        private DateTime fechaEstadoProcesal;

        [Column("tarea_judicial")]
        private string tareaJudicial;

        [Column("fecha_tarea_administrativa")]
        private DateTime fechaTareaAdministrativa;

        [Column("tarea_administrativa")]
        private string tareaAdministrativa;

        [Column("incidencia")]
        private string incidencia;

        [Column("detalle_incidencia")]
        private string detalleIncidencia;

    }
}
