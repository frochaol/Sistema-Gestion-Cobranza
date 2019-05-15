using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_tramite")]
    [Table("tramite")]
    class Tramite
    {
        [Column("codigo_tramite", PrimaryKey = true)]
        private int codigoTramite;

        [Column("nombre_tramite")]
        private string nombreTramite;

        [Column("flag")]
        private int flag;
    }
}
