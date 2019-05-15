using Ceriv.Clases;
using Ceriv.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceriv.Formularios
{
    public partial class MicroEtapa : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public MicroEtapa()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {

            GuardarEstadoProcesal();
            GuardarMicroEtapa();
        }
        public void GuardarMicroEtapa() {

            C_Micro objetoMicroEtapa = new C_Micro();
            if (txt_I_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese una Micro Etapa");
                return;
            }
            objetoMicroEtapa.Nombre = txt_I_Nombre.Text;
            if (_ceriv.MicroEtapa(1, objetoMicroEtapa))
            {
                MessageBox.Show("Ingreso Correctamente la  Micro Etapa");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revisar los datos del Nombre Por Favor");
            }

        }
        public void GuardarEstadoProcesal() 
        {
            C_EstadoProcesal objetoEstadoProcesal = new C_EstadoProcesal();
            objetoEstadoProcesal.Nombre = txt_I_Nombre.Text;
            if (_ceriv.EstadoProcesal(1, objetoEstadoProcesal))
            {
               // MessageBox.Show("Ingreso Correctamente Estado procesal");
              //  CargarComboBox();
              //  txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarMicroEtapa();
        }
        public void ActualizarMicroEtapa() {

            C_Micro objetoMicroEtapa = new C_Micro();
            if (txt_M_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese una forma de Micro Etapa");
                return;
            }
            objetoMicroEtapa.Nombre = txt_M_Nombre.Text;
            objetoMicroEtapa.Codigo = Int32.Parse(cmb_M_Nombre.SelectedValue.ToString());
            if (_ceriv.MicroEtapa(2, objetoMicroEtapa))
            {
                MessageBox.Show("Modifico Correctamente la Micro Etapa");
                CargarComboBox();
                txt_M_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarMicroEtapa();
        }
        public void EliminarMicroEtapa() {

            C_Micro objetoMicroEtapa = new C_Micro();
            objetoMicroEtapa.Nombre = " ";
            objetoMicroEtapa.Codigo = Int32.Parse(cmb_E_Nombre.SelectedValue.ToString());
            if (_ceriv.MicroEtapa(3, objetoMicroEtapa))
            {
                MessageBox.Show("Elimino Correctamente la Micro Etapa");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }

        public void CargarComboBox() {
            CargarComboBoxModificar();
            CargarComboBoxEliminar();
        }
        public void CargarComboBoxModificar() {
            cmb_M_Nombre.DisplayMember = "Nombre";
            cmb_M_Nombre.ValueMember = "Codigo";
            cmb_M_Nombre.DataSource = _ceriv.MicroEtapaMostrar();
        }
        public void CargarComboBoxEliminar() {
            cmb_E_Nombre.DisplayMember = "Nombre";
            cmb_E_Nombre.ValueMember = "Codigo";
            cmb_E_Nombre.DataSource = _ceriv.MicroEtapaMostrar();
        }

    }
}
