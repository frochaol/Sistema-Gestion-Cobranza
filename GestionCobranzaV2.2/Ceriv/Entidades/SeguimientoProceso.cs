using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_seguimientoProceso")]
    [Table("seguimientoproceso")]
    class SeguimientoProceso
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoSeguimientoProceso;

        [Column("estadoprocesal", ManyToOne="codigo")]
        private int codigoEstadoProcesal;

        [Column("num_expediente", ManyToOne = "num_expediente")]
        private string numExpediente;

        [Column("fechaestadoprocesal")]
        private DateTime fechaEstadoProcesal;

        [Column("tareajudicial")]
        private string tareaJudicial;

        [Column("fechatareaadministrativa")]
        private DateTime fechaTareaAdministrativa;

        [Column("tareaadministrativa")]
        private string tareaAdministrativa;

        [Column("estadotareajudicial")]
        private int estadotareaJudicial;

        [Column("estadotareaadministrativa")]
        private int estadotareaAdministrativa;

        [Column("convenio")]
        private string convenio;

        [Column("incidencia")]
        private string incidencia;

        [Column("detalle_incidencia")]
        private string detalleIncidencia;

        [Column("detalle_convenio")]
        private string detalleConvenio;




    }
}
