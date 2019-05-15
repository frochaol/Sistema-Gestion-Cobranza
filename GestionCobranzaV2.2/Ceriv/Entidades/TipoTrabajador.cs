using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_tipoTrabajador")]
    [Table("tipo_trabajador")]
    class TipoTrabajador
    {
        [Column("codigo_tipo_trabajador", PrimaryKey = true)]
        private int codigoTipoTrabajador;

        [Column("nombre")]
        private string nombreTipoTrabajador;

        [Column("flag")]
        private int flag;
    }
}
