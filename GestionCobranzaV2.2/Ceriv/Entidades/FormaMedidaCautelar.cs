using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_formaMedidaCautelar")]
    [Table("formamedidacautelar")]
    class FormaMedidaCautelar
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoFormaMedidaCautelar;

        [Column("nombre")]
        private string nombreFormaMedidaCautelar;

        [Column("flag")]
        private int flag;

    }
}
