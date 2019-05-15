using System;
using System.Collections.Generic;
using Ceriv.Conexion;
using Ceriv.Clases;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceriv.Formularios
{
    public partial class BienEmbargado : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        
        public BienEmbargado()
        {
            InitializeComponent();
            CargarComboBox();
        }
        public void CargarComboBox()
        {
            CargarComboBoxActualizar();
            CargarComboBoxEliminar();
        }
        public void CargarComboBoxActualizar()
        {
            cmb_M_Nombre.DisplayMember = "Nombre";
            cmb_M_Nombre.ValueMember = "Codigo";
            cmb_M_Nombre.DataSource = _ceriv.BienEmbargadoMostrar();
        }
        public void CargarComboBoxEliminar()
        {
            cmb_E_Nombre.DisplayMember = "Nombre";
            cmb_E_Nombre.ValueMember = "Codigo";
            cmb_E_Nombre.DataSource = _ceriv.BienEmbargadoMostrar();
        }

        private void cmb_M_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_BienEmbargado obj = _ceriv.BienEmbargadoMostrar1(Int32.Parse(cmb_M_Nombre.SelectedValue.ToString()));
            txt_M_Nombre.Text = obj.Nombre;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            C_BienEmbargado objetoBienEmbargado = new C_BienEmbargado();
            objetoBienEmbargado.Nombre = txt_I_Nombre.Text;
            if (_ceriv.BienEmbargado(1, objetoBienEmbargado))
            {
                MessageBox.Show("Ingreso Correctamente");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo Ingresar");
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            C_BienEmbargado objetoBienEmbargado = new C_BienEmbargado();
            objetoBienEmbargado.Nombre = txt_M_Nombre.Text;
            objetoBienEmbargado.Codigo = Int32.Parse(cmb_M_Nombre.SelectedValue.ToString());
            if (_ceriv.BienEmbargado(2, objetoBienEmbargado))
            {
                MessageBox.Show("Se Modifico Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se pudo Modificar");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            C_BienEmbargado objetoBienEmbargado = new C_BienEmbargado();
            objetoBienEmbargado.Nombre = " ";
            objetoBienEmbargado.Codigo = Int32.Parse(cmb_E_Nombre.SelectedValue.ToString());
            if (_ceriv.BienEmbargado(3, objetoBienEmbargado))
            {
                MessageBox.Show("Se elimino Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }
        }

    }
}
