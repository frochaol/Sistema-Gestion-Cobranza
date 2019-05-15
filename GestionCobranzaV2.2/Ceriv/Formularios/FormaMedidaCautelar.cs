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
    public partial class FormaMedidaCautelar : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FormaMedidaCautelar()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarFormaMedidaCautelar();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ModificarFormaMedidaCautelar();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarFormaMedidaCautelar();
        }

        private void cmb_M_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_FormaMedidaCautelar obj = _ceriv.FormaMedidaCautelarMostrar1(Int32.Parse(cmb_M_Nombre.SelectedValue.ToString()));
            txt_M_Nombre.Text = obj.Nombre;
        }
        public void EliminarFormaMedidaCautelar()
        {
            C_FormaMedidaCautelar objetoFormaMedidaCautelar = new C_FormaMedidaCautelar();
            objetoFormaMedidaCautelar.Nombre = " ";
            objetoFormaMedidaCautelar.Codigo = Int32.Parse(cmb_E_Nombre.SelectedValue.ToString());
            if (_ceriv.FormaMedidaCautelar(3, objetoFormaMedidaCautelar))
            {
                MessageBox.Show("Elimino Correctamente la forma de medida cautelar");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }
        public void ModificarFormaMedidaCautelar()
        {
            C_FormaMedidaCautelar objetoFormaMedidaCautelar = new C_FormaMedidaCautelar();
            if (txt_M_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese una forma de medida cautelar");
                return;
            }
            objetoFormaMedidaCautelar.Nombre = txt_M_Nombre.Text;
            objetoFormaMedidaCautelar.Codigo = Int32.Parse(cmb_M_Nombre.SelectedValue.ToString());
            if (_ceriv.FormaMedidaCautelar(2, objetoFormaMedidaCautelar))
            {
                MessageBox.Show("Modifico Correctamente la forma de medida cautelar");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }
        public void GuardarFormaMedidaCautelar()
        {
            C_FormaMedidaCautelar objetoFormaMedidaCautelar = new C_FormaMedidaCautelar();
            if (txt_I_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese una Medida Cautelar");
                return;
            }
            objetoFormaMedidaCautelar.Nombre = txt_I_Nombre.Text;
            if (_ceriv.FormaMedidaCautelar(1, objetoFormaMedidaCautelar))
            {
                MessageBox.Show("Ingreso Correctamente la forma de medida cautelar");
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
            cmb_E_Nombre.DataSource = _ceriv.FormaMedidaCautelarMostrar();
        }
        public void CargarComboBoxModificar()
        {
            cmb_M_Nombre.DisplayMember = "Nombre";
            cmb_M_Nombre.ValueMember = "Codigo";
            cmb_M_Nombre.DataSource = _ceriv.FormaMedidaCautelarMostrar();
        }


    }
}
