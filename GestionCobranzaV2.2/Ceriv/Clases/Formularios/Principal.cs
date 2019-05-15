using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ceriv.Conexion;

namespace Ceriv.Formularios
{
    public partial class Principal : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public Principal()
        {
            InitializeComponent();
            CargarDataGridView();
        }

        private void CargarDataGridView()
        {

            dgv_Alerta.AutoGenerateColumns = false;
            dgv_Alerta.DataSource = _ceriv.SeguimientoProcesoMostrar();
        }

        private void maestrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trabajador objetoTrabajador = new Trabajador();
            objetoTrabajador.ShowDialog();
        }

        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearModificar objetoCrearModificar = new CrearModificar();
            objetoCrearModificar.ShowDialog();
            CargarDataGridView();
        }

        private void resumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarExpediente objetoEliminarExpediente = new EliminarExpediente();
            objetoEliminarExpediente.ShowDialog();
        }

        private void resumenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Resumen objetoResumen = new Resumen();
            objetoResumen.ShowDialog();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos objetoPermisos = new Permisos();
            objetoPermisos.ShowDialog();
        }

        private void btn_detalle_Click(object sender, EventArgs e)
        {

        }
    }
}
