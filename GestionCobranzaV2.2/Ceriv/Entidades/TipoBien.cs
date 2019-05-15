using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_tipoBien")]
    [Table("tipo_bien")]
    class TipoBien
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoTipoBien;

        [Column("nombre")]
        private string nombreTipoBien;

        [Column("flag")]
        private int flag;

    }
}
