using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_bien")]
    [Table("bien")]
    class Bien
    {
        [Column("codigo_bien", PrimaryKey = true)]
        private int codigoBien;

        [Column("codigo_rango", ManyToOne = "codigo_rango")]
        private int codigoRango;

        [Column("codigo_tipobien", ManyToOne = "codigo_tipobien")]
        private int codigoTipoBien;

        [Column("codigo_ciudad", ManyToOne = "codigo_ciudad")]
        private int codigoCiudad;

        [Column("codigo_distrito", ManyToOne = "codigo_distrito")]
        private int codigoDistrito;

        [Column("num_expediente", ManyToOne = "num_expediente")]
        private int numExpediente;

        [Column("nombre_bien")]
        private string nombreBien;

        [Column("monto_garantia")]
        private string montoGarantia;

        [Column("monto_tasacion")]
        private string montoTasacion;

        [Column("fecha_tasacion")]
        private DateTime fechaTasacion;

        [Column("partida_placa")]
        private string partida_placa;

        [Column("porcentaje_derechos")]
        private string porcentaje_derechos;

        [Column("descripcion")]
        private string descripcion;

        [Column("flag")]
        private int flag;

        [Column("valor_comercial")]
        private string valorComercial;

        [Column("marca")]
        private string marca;

        [Column("modelo")]
        private string modelo;

        [Column("partida")]
        private string partida;

        [Column("zona_registral")]
        private string zonaRegistral;

    }
}
