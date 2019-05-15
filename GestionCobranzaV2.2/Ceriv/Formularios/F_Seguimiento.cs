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
    public partial class F_Seguimiento : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        string _expediente;

        public F_Seguimiento(string expediente)
        {
            InitializeComponent();
            _expediente = expediente;
            txt_NumExpediente.Text = _expediente;
            CargarComboBox();
            cmb_Macro.SelectedIndex = -1;
            cmb_Micro.SelectedIndex = -1;
            CargarTipoProceso();
        }


        //
        public void CargarComboBox()
        {
            
            
        }
        public void CargarComboBoxMacro(int codigo) 
        {
            cmb_Macro.DisplayMember = "Nombre";
            cmb_Macro.ValueMember = "Codigo";
            cmb_Macro.DataSource = _ceriv.MacroEtapaMostrarTipoProceso(codigo);
            CargarComboBoxMicro();
        }
        public void CargarComboBoxMicro()
        {
            cmb_Micro.DataSource = null;
            cmb_Micro.DisplayMember = "Nombre";
            cmb_Micro.ValueMember = "Codigo";
            if (cmb_Macro.SelectedItem != null)
            {
                int codigoMacro = int.Parse(cmb_Macro.SelectedValue.ToString());
                cmb_Micro.DataSource = _ceriv.MicroMostrarByMacro(codigoMacro);
            }
        }
        //
        public void CargarTipoProceso()
        {
            if (txt_NumExpediente.Text != string.Empty)
            {
                C_SeguimientoProceso objetoSeguimiento = _ceriv.CargarFSeguimiento(_expediente);
                txt_TipoProceso.Text = objetoSeguimiento.NombreEstadoProcesal;
                CargarComboBoxMacro(objetoSeguimiento.Codigo);
                cmb_Macro.SelectedValue = Int32.Parse(objetoSeguimiento.CodigoMacro.ToString());
                cmb_Micro.SelectedValue = Int32.Parse(objetoSeguimiento.CodigoMicro.ToString());
            }

        }
        //


        private void F_Seguimiento_Load(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            int accion = 1;
            C_SeguimientoProceso objetoSeguimiento = new C_SeguimientoProceso();
            objetoSeguimiento.Num_expediente = txt_NumExpediente.Text;
            //
            if (cmb_Macro.SelectedIndex != -1)
            {
                objetoSeguimiento.CodigoMacro = Int32.Parse(cmb_Macro.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Seleccione una Macro Etapa");
            }
            //
            if (cmb_Micro.SelectedIndex != -1)
            {
                objetoSeguimiento.CodigoMicro = Int32.Parse(cmb_Micro.SelectedValue.ToString());
            }
            //
            if (_ceriv.F_Seguimiento(accion, objetoSeguimiento))
            {
                MessageBox.Show("Se Actualizaron Correctamente las Etapas del Proceso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Revise Los Datos Por Favor");
                return;
            }

        }

        private void txt_TipoProceso_TextChanged(object sender, EventArgs e)
        {
            if (txt_TipoProceso.Text == "EJECUCION DE GARANTIA")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroEjecucionGarantia();
                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroEjecucionGarantia();
            }
            else if (txt_TipoProceso.Text == "ODSD SELECTIVA")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroEjecucionGarantia();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroODSDSelectiva();
            }
            else if (txt_TipoProceso.Text == "INCAUTACION")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroIncautacion();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroIncautacion();
            }
            else if (txt_TipoProceso.Text == "ODSD MASIVO")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroODSDMasivo();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroODSDMasivo();
            }
            else if (txt_TipoProceso.Text == "LEASING")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroIncautacion();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroIncautacion();
            }
            else if (txt_TipoProceso.Text == "TERCERO NO EJECUTANTE")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroEjecucionGarantia();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroODSDSelectiva();
            }
            else if (txt_TipoProceso.Text == "ODSD")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroODSDMasivo();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroODSDMasivo();
            }
            else if (txt_TipoProceso.Text == "AA Y DD")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroEjecucionGarantia();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroODSDSelectiva();
            }
            else if (txt_TipoProceso.Text == "EXCLUSIVA")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroEjecucionGarantia();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroODSDSelectiva();
            }
            else if (txt_TipoProceso.Text == "TERCERIA")
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroEjecucionGarantia();

                cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                cmb_Micro.DataSource = _ceriv.MicroODSDSelectiva();
            }
        }

        private void cmb_Macro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboBoxMicro();
        }
    }
}
