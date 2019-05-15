using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;


namespace Ceriv.Entidades
{
    [Entity("spr_microetapa")]
    [Table("microetapa")]
    class MicroEtapa
    {
        [Column("codigo_microetapa", PrimaryKey = true)]
        private int codigoMicroEtapa;

        [Column("nombre")]
        private string nombreMicroEtapa;

        [Column("flag")]
        private int flag;
    }
}
