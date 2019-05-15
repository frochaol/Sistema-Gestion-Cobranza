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
    public partial class BienHipotecado : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public BienHipotecado()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarBienHipotecado();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ModificarBienHipotecado();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarBienHipotecado();
        }

        public void EliminarBienHipotecado()
        {
            C_BienHipotecado objetoBienHipotecado = new C_BienHipotecado();
            objetoBienHipotecado.Nombre = " ";
            objetoBienHipotecado.Codigo = Int32.Parse(cmb_E_Nombre.SelectedValue.ToString());
            if (_ceriv.BienHipotecado(3, objetoBienHipotecado))
            {
                MessageBox.Show("Elimino Correctamente el Bien Hipotecado");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }
        public void ModificarBienHipotecado()
        {
            C_BienHipotecado objetoBienHipotecado = new C_BienHipotecado();
            if (txt_M_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese un bien");
                return;
            }
            objetoBienHipotecado.Nombre = txt_M_Nombre.Text;
            objetoBienHipotecado.Codigo = Int32.Parse(cmb_M_Nombre.SelectedValue.ToString());
            if (_ceriv.BienHipotecado(2, objetoBienHipotecado))
            {
                MessageBox.Show("Modifico Correctamente el Bien Hipotecado");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }
        public void GuardarBienHipotecado()
        {
            C_BienHipotecado objetoBienHipotecado = new C_BienHipotecado();
            if (txt_I_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese un bien");
                return;
            }
            objetoBienHipotecado.Nombre = txt_I_Nombre.Text;
            if (_ceriv.BienHipotecado(1, objetoBienHipotecado))
            {
                MessageBox.Show("Ingreso Correctamente Bien Hipotecado");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
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
            cmb_E_Nombre.DataSource = _ceriv.BienHipotecadoMostrar();
        }
        public void CargarComboBoxModificar()
        {
            cmb_M_Nombre.DisplayMember = "Nombre";
            cmb_M_Nombre.ValueMember = "Codigo";
            cmb_M_Nombre.DataSource = _ceriv.BienHipotecadoMostrar();
        }

        private void cmb_M_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_BienHipotecado obj = _ceriv.BienHipotecadoMostrar1(Int32.Parse(cmb_M_Nombre.SelectedValue.ToString()));
            txt_M_Nombre.Text = obj.Nombre;
        }




    }
}
