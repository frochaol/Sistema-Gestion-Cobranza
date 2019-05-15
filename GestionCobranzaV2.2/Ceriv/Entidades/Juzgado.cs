using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_juzgado")]
    [Table("juzgado")]
    class Juzgado
    {
        [Column("codigo_juzgado", PrimaryKey = true)]
        private int codigoJuzgado;

        [Column("nombre")]
        private string nombreJuzgado;

        [Column("flag")]
        private int flag;
    }
}
