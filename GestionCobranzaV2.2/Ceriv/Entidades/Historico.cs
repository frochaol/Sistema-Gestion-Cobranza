using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_historico")]
    [Table("historico")]
    class Historico
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoHistorico;

        [Column("num_expediente", ManyToOne = "num_expediente")]
        private string numExpediente;
        
        [Column("texto_proceso")]
        private string textoProceso;

        [Column("flag")]
        private int flag;

        [Column("texto_llamada")]
        private string textoLlamada;

        [Column("texto_campo")]
        private string textoCampo;


    }
}
