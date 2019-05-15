using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ceriv.Clases;
using Ceriv.Conexion;

namespace Ceriv.Formularios
{
    public partial class EstadoProcesal : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public EstadoProcesal()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarEstadoProcesal();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ModificarEstadoProcesal();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarEstadoProcesal();
        }

        private void cmb_M_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_EstadoProcesal obj = _ceriv.EstadoProcesalMostrar1(Int32.Parse(cmb_M_Nombre.SelectedValue.ToString()));
            txt_M_Nombre.Text = obj.Nombre;
        }
        private void GuardarEstadoProcesal()
        {
            C_EstadoProcesal objetoEstadoProcesal = new C_EstadoProcesal();
            if (txt_I_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese un Estado procesal");
                return;
            }
            objetoEstadoProcesal.Nombre = txt_I_Nombre.Text;
            if (_ceriv.EstadoProcesal(1, objetoEstadoProcesal))
            {
                MessageBox.Show("Ingreso Correctamente Estado procesal");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }

        }
        private void ModificarEstadoProcesal()
        {
            C_EstadoProcesal objetoEstadoProcesal = new C_EstadoProcesal();
            if (txt_M_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese un Estado procesal");
                return;
            }
            objetoEstadoProcesal.Nombre = txt_M_Nombre.Text;
            objetoEstadoProcesal.Codigo = Int32.Parse(cmb_M_Nombre.SelectedValue.ToString());
            if (_ceriv.EstadoProcesal(2, objetoEstadoProcesal))
            {
                MessageBox.Show("Modifico Correctamente el Estado procesal");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }
        private void EliminarEstadoProcesal()
        {
            C_EstadoProcesal objetoEstadoProcesal = new C_EstadoProcesal();
            objetoEstadoProcesal.Nombre = " ";
            objetoEstadoProcesal.Codigo = Int32.Parse(cmb_E_Nombre.SelectedValue.ToString());
            if (_ceriv.EstadoProcesal(3, objetoEstadoProcesal))
            {
                MessageBox.Show("Elimino Correctamente el Estado procesal");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }
        public void CargarComboBox()
        {
            CargarComboBoxModificar();
            CargarComboBoxEliminar();
        }
        public void CargarComboBoxEliminar()
        {

            cmb_E_Nombre.DisplayMember = "Nombre";
            cmb_E_Nombre.ValueMember = "Codigo";
            cmb_E_Nombre.DataSource = _ceriv.EstadoProcesalMostrar();
        }
        public void CargarComboBoxModificar()
        {
            cmb_M_Nombre.DisplayMember = "Nombre";
            cmb_M_Nombre.ValueMember = "Codigo";
            cmb_M_Nombre.DataSource = _ceriv.EstadoProcesalMostrar();
        }

        private void button1_Click(object sender, EventArgs e){

            AbrirIngreso();

        }

                private void AbrirIngreso()
            {
                MacroMicro obj = new MacroMicro();
                obj.ShowDialog();
            }


    }
}
