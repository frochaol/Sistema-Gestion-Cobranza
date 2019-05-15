using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_tipoProceso")]
    [Table("tipo_proceso")]
    class TipoProceso
    {
        [Column("codigo_proceso", PrimaryKey = true)]
        private int codigoProceso;

        [Column("nombre_proceso")]
        private string nombreProceso;

        [Column("flag")]
        private int flag;
    }
}
