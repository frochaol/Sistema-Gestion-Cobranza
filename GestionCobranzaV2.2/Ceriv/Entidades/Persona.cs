using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_persona")]
    [Table("persona")]
    class Persona
    {
        [Column("doi_cliente", PrimaryKey = true)]
        private string doiCliente;

        [Column("codigo_distrito", ManyToOne="codigo_distrito")]
        private int codigoDistrito;

        [Column("cuenta_bt", ManyToOne = "cuenta_bt")]
        private string cuentaBt;

        [Column("nombre_completo")]
        private string nombreCompleto;

        [Column("nombre_conyuge")]
        private string nombreConyuge;

        [Column("domicilio_persona")]
        private string domicilioPersona;

        [Column("direccion_alterna")]
        private string direccionAlterna;

        [Column("flag")]
        private int flag;

        [Column("representante")]
        private string representante;

        [Column("numero")]
        private string numero;

        [Column("convenio_persona")]
        private string convenioPersona;
    }
}
