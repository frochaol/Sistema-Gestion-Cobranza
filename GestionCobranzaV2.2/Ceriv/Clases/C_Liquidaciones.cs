using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ceriv.Clases
{
    class C_Liquidaciones
    {
        string nro_recibo;

        public string Nro_recibo
        {
            get { return nro_recibo; }
            set { nro_recibo = value; }
        }

        string cantidad;

        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        string monto;

        public string Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        string nombre_cliente;

        public string Nombre_cliente
        {
            get { return nombre_cliente; }
            set { nombre_cliente = value; }
        }
        DateTime fecha_liquidacion;

        public DateTime Fecha_liquidacion
        {
            get { return fecha_liquidacion; }
            set { fecha_liquidacion = value; }
        }

        string fecha_liquidacionString;

        public string Fecha_liquidacionString
        {
            get { return fecha_liquidacionString; }
            set { fecha_liquidacionString = value; }
        }

        string operacion;

        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        string num_expediente;

        public string Num_expediente
        {
            get { return num_expediente; }
            set { num_expediente = value; }
        }
        int codigo_tipogasto;

        public int Codigo_tipogasto
        {
            get { return codigo_tipogasto; }
            set { codigo_tipogasto = value; }
        }
        int codigo_detalle;

        public int Codigo_detalle
        {
            get { return codigo_detalle; }
            set { codigo_detalle = value; }
        }

        string agencia;

        public string Agencia
        {
            get { return agencia; }
            set { agencia = value; }
        }

        string nombre_proceso;

        public string Nombre_proceso
        {
            get { return nombre_proceso; }
            set { nombre_proceso = value; }
        }
        string nombre_gasto;

        public string Nombre_gasto
        {
            get { return nombre_gasto; }
            set { nombre_gasto = value; }
        }

        string nombre_detalle;

        public string Nombre_detalle
        {
            get { return nombre_detalle; }
            set { nombre_detalle = value; }
        }

        string cuenta_bt;

        public string Cuenta_bt
        {
            get { return cuenta_bt; }
            set { cuenta_bt = value; }
        }

        int flag;

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        int codigo_Detalle_liquidacion;

        public int Codigo_Detalle_liquidacion
        {
            get { return codigo_Detalle_liquidacion; }
            set { codigo_Detalle_liquidacion = value; }
        }


    }
        
}
