using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_macroEtapa")]
    [Table("macroetapa")]
    class MacroEtapa
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoMacroEtapa;

        [Column("nombre")]
        private string nombreMacroEtapa;

        [Column("flag")]
        private int flag;
    }
}
