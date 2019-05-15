using System;
using Ceriv.Conexion;
using Ceriv.Clases;
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
    public partial class Juzgado : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public Juzgado()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarJuzgado();
        }
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarJuzgado();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarJuzgado();
        }

        private void CargarComboBox()
        {
            CargarComboBoxModificar();
            CargarComboBoxEliminar();
        }
        private void CargarComboBoxModificar()
        {
            cmb_M_Juzgado.DisplayMember = "NombreJuzgado";
            cmb_M_Juzgado.ValueMember = "CodigoJuzgado";
            cmb_M_Juzgado.DataSource = _ceriv.JuzgadoMostrar();
        }
        private void CargarComboBoxEliminar()
        {
            cmb_E_Juzgado.DisplayMember = "NombreJuzgado";
            cmb_E_Juzgado.ValueMember = "CodigoJuzgado";
            cmb_E_Juzgado.DataSource = _ceriv.JuzgadoMostrar();
        }

        private void cmb_M_Juzgado_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Juzgado obj = _ceriv.JuzgadoMostrar1(Int32.Parse(cmb_M_Juzgado.SelectedValue.ToString()));
            txt_M_Juzgado.Text = obj.NombreJuzgado;
        }

        private void GuardarJuzgado()
        {
            C_Juzgado objetoJuzgado = new C_Juzgado();
            objetoJuzgado.NombreJuzgado = txt_I_Juzgado.Text;
            if (_ceriv.Juzgado(1, objetoJuzgado))
            {
                MessageBox.Show("Se Ingreso Correctamente el Juzgado");
                CargarComboBox();
                txt_I_Juzgado.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo Ingresar el Juzgado");
            }
        }
        private void ActualizarJuzgado()
        {
            C_Juzgado objetoJuzgado = new C_Juzgado();
            objetoJuzgado.CodigoJuzgado = Int32.Parse(cmb_M_Juzgado.SelectedValue.ToString());
            objetoJuzgado.NombreJuzgado = txt_M_Juzgado.Text;
            if (_ceriv.Juzgado(2, objetoJuzgado))
            {
                MessageBox.Show("Se Modifico Correctamente el Juzgado");
                CargarComboBox();
                txt_M_Juzgado.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }
        private void EliminarJuzgado()
        {
            C_Juzgado objetoJuzgado = new C_Juzgado();
            objetoJuzgado.CodigoJuzgado = Int32.Parse(cmb_E_Juzgado.SelectedValue.ToString());
            objetoJuzgado.NombreJuzgado = "";
            if (_ceriv.Juzgado(3, objetoJuzgado))
            {
                MessageBox.Show("Se Elimino el Juzgado");
                CargarComboBox();
                cmb_E_Juzgado.SelectedIndex = -1;
            }
        }




    }
}
