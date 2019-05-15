using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_estadoProcesal")]
    [Table("estado_procesal")]
    class EstadoProcesal
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoEstadoProcesal;

        [Column("nombre")]
        private string nombreEstadoProcesal;

        [Column("flag")]
        private int flag;
    }
}
