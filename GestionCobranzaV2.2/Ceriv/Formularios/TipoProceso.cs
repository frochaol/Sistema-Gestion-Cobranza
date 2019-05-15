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
    public partial class TipoProceso : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public TipoProceso()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarProceso();
        }
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarProceso();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarProceso();
        }

        public void CargarComboBox()
        {
            CargarComboBoxModificarProceso();
            CargarComboBoxEliminarProceso();
        }
        public void CargarComboBoxModificarProceso()
        {
            cmb_M_Proceso.DisplayMember = "NombreProceso";
            cmb_M_Proceso.ValueMember = "CodigoProceso";
            cmb_M_Proceso.DataSource = _ceriv.ProcesoMostrar();
        }
        public void CargarComboBoxEliminarProceso()
        {
            cmb_E_Proceso.DisplayMember = "NombreProceso";
            cmb_E_Proceso.ValueMember = "CodigoProceso";
            cmb_E_Proceso.DataSource = _ceriv.ProcesoMostrar();
        }
        private void cmb_M_Proceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cmb_M_Proceso.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese un Tipo de Proceso");
                return;
            }
            C_TipoProceso obj = _ceriv.ProcesoMostrar1(Int32.Parse(cmb_M_Proceso.SelectedValue.ToString()));
            txt_M_Proceso.Text = obj.NombreProceso;
        }

        private void GuardarProceso()
        {
            C_TipoProceso objetoProceso = new C_TipoProceso();
            objetoProceso.NombreProceso = txt_I_Proceso.Text;
            if (_ceriv.Proceso(1, objetoProceso))
            {
                MessageBox.Show("Ingreso el Proceso Correctamente");
                CargarComboBox();
                txt_I_Proceso.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre del Proceso");
            } 
        }       
        private void ActualizarProceso()
        {
            C_TipoProceso objetoProceso = new C_TipoProceso();
            objetoProceso.CodigoProceso = Int32.Parse(cmb_M_Proceso.SelectedValue.ToString());
            objetoProceso.NombreProceso = txt_M_Proceso.Text;
            if (_ceriv.Proceso(2, objetoProceso))
            {
                MessageBox.Show("Se actualizo el Proceso Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se pudo Actualizar el Proceso");
            }
        }        
        private void EliminarProceso()
        {
            C_TipoProceso objetoProceso = new C_TipoProceso();
            objetoProceso.CodigoProceso = Int32.Parse(cmb_E_Proceso.SelectedValue.ToString());
            objetoProceso.NombreProceso = " ";
            if (_ceriv.Proceso(3, objetoProceso))
            {
                MessageBox.Show("Se elimino el Proceso Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar el Proceso");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirIngreso();
        }

        private void AbrirIngreso()
        {
            MacroMicro obj = new MacroMicro();
            obj.ShowDialog();
        }

    }
}
