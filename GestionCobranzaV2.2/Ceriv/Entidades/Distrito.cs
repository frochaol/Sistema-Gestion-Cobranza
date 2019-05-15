using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_distrito")]
    [Table("distrito")]
    class Distrito
    {
        [Column("codigo_distrito", PrimaryKey = true)]
        private int codigoDistrito;

        [Column("nombre")]
        private string nombreDistrito;

        [Column("flag")]
        private int flag;

    }
}
