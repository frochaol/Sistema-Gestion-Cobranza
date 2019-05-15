using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_rangoHipoteca")]
    [Table("rango_hipoteca")]
    class RangoHipoteca
    {
        [Column("codigo_rango_hipoteca", PrimaryKey = true)]
        private int codigoRangoHipoteca;

        [Column("nombre")]
        private string nombreRangoHipoteca;

        [Column("flag")]
        private int flag;
    }
}
