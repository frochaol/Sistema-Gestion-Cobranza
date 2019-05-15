using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_tipoSolucion")]
    [Table("tipo_solucion")]
    class TipoSolucion
    {
        [Column("codigo_tipo_solucion", PrimaryKey = true)]
        private int codigoTipoSolucion;

        [Column("nombre")]
        private string nombreTipoSolucion;

        [Column("flag")]
        private int flag;
    }
}
