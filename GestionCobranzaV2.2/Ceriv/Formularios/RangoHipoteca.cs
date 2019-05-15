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
    public partial class RangoHipoteca : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public RangoHipoteca()
        {
            InitializeComponent();
            CargarComboBox();
        }

        public void CargarComboBox()
        {
            CargarComboBoxModificar();
            CargarComboBoxEliminar();
        }
        public void CargarComboBoxModificar()
        {
            cmb_M_Nombre.DisplayMember = "NombreRangoHipotecado";
            cmb_M_Nombre.ValueMember = "CodigoRangoHipotecado";
            cmb_M_Nombre.DataSource = _ceriv.RangoHipotecadoMostrar();
        }
        public void CargarComboBoxEliminar()
        {
            cmb_E_Nombre.DisplayMember = "NombreRangoHipotecado";
            cmb_E_Nombre.ValueMember = "CodigoRangoHipotecado";
            cmb_E_Nombre.DataSource = _ceriv.RangoHipotecadoMostrar();
        }

        private void cmb_M_Nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_RangoHipotecado obj = _ceriv.RangoHipotecadoMostrar1(Int32.Parse(cmb_M_Nombre.SelectedValue.ToString()));
            txt_M_Nombre.Text = obj.NombreRangoHipotecado;
        }

        public void Guardar()
        {
            C_RangoHipotecado objetoRangoHipotecado = new C_RangoHipotecado();
            objetoRangoHipotecado.NombreRangoHipotecado = txt_I_Nombre.Text;
            if (_ceriv.RangoHipotecado(1, objetoRangoHipotecado))
            {
                MessageBox.Show("Se ingreso Correctamente");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public void Actualizar()
        {
            C_RangoHipotecado objetoRangoHipotecado = new C_RangoHipotecado();
            objetoRangoHipotecado.CodigoRangoHipotecado = Int32.Parse(cmb_M_Nombre.SelectedValue.ToString());
            objetoRangoHipotecado.NombreRangoHipotecado = txt_M_Nombre.Text;
            if (_ceriv.RangoHipotecado(2, objetoRangoHipotecado))
            {
                MessageBox.Show("Se modifico Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se logro modificar");
            }
        }
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        public void Eliminar()
        {
            C_RangoHipotecado objetoRangoHipotecado = new C_RangoHipotecado();
            objetoRangoHipotecado.CodigoRangoHipotecado = Int32.Parse(cmb_E_Nombre.SelectedValue.ToString());
            objetoRangoHipotecado.NombreRangoHipotecado = " ";
            if (_ceriv.RangoHipotecado(3, objetoRangoHipotecado))
            {
                MessageBox.Show("Se elimino Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar");
            }
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }


    }
}
