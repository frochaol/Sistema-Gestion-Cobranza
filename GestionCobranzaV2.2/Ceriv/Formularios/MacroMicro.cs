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
    public partial class MacroMicro : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public MacroMicro()
        {
            InitializeComponent();
            cargarComboBox();
        }

        public void cargarComboBox() {
            cargarMacro();
            cargarMicro();
            cargarEstadoProcesalMacro();
            cargarEstadoProcesalMicro();
        }

        //EVENTOS Y BOTONES DE MICRO ETAPA




        public void cargarDataGridViewMicroEtapa() {
            dgv_MicroEtapa.AutoGenerateColumns = false;
            dgv_MicroEtapa.DataSource = _ceriv.MacroEstadoMostrar(Int32.Parse(cmb_UltimoEstadoProcesal.SelectedValue.ToString()));
        
        }

        public void bloquearMacroMicro()
        {
            txt_NombreMicro.Enabled = false;

        }


        //EVENTOS Y BOTONES DE MACRO ETAPA
        private void btn_MacroCargar_Click(object sender, EventArgs e)
        {
            cargarDataGridViewMacroEtapa();
            activarMacro();
        }


        private void bloquearMacro() {
            txt_MacroEtapa.Enabled = false;
        }
        private void activarMacro() {
            txt_MacroEtapa.Enabled = true;
        
        }

        private void cmb_EstadoMacro_SelectedValueChanged(object sender, EventArgs e)
        {
          //  cargarDataGridViewMacroEtapa();
        }

        private void cmb_UltimoEstadoProcesal_SelectedValueChanged(object sender, EventArgs e)
        {
            
         //   cargarDataGridViewMicroEtapa();
        }


        //DESDE ACA MICRO
        public void cargarEstadoProcesalMicro()
        {

            cmb_UltimoEstadoProcesal.DisplayMember = "NombreProceso";
            cmb_UltimoEstadoProcesal.ValueMember = "CodigoProceso";
            cmb_UltimoEstadoProcesal.DataSource = _ceriv.TipoProcesoMostrar();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            CargarDataGridViewMacrosProceso();
        }
        private void cmb_UltimoEstadoProcesal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_UltimoEstadoProcesal.SelectedIndex != -1)
            {
                LimpiarTipoProcesoMacro();
                CargarDataGridViewMacrosProceso();
            }
        }
        public void LimpiarTipoProcesoMacro() {
            txt_NombreMicro.Clear();
            lbl_Estado.Text = "0";
            lbl_Micro.Text = "0";
        }
        public void CargarDataGridViewMacrosProceso() {

            dgv_MicroEtapa.AutoGenerateColumns = false;
            dgv_MicroEtapa.DataSource = _ceriv.MacroEstadoMostrar(Int32.Parse(cmb_UltimoEstadoProcesal.SelectedValue.ToString()));
        }

        private void dgv_MicroEtapa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (e.RowIndex > -1)
            {
                txt_NombreMicro.Text = dgv_MicroEtapa.Rows[row].Cells["Micro"].Value.ToString();
                lbl_Micro.Text = dgv_MicroEtapa.Rows[row].Cells["codigoMicro"].Value.ToString();
                lbl_Estado.Text = dgv_MicroEtapa.Rows[row].Cells["CodigoEstadoMacro"].Value.ToString();
                bloquearMacroMicro();
            }
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            guardarMacroEtapa();
        }
        public void guardarMacroEtapa()
        {

            C_Macro objetoMacro = new C_Macro();
            objetoMacro.Codigo = Int32.Parse(cmb_Macro.SelectedValue.ToString());
            objetoMacro.CodigoEstadoMacro = Int32.Parse(cmb_UltimoEstadoProcesal.SelectedValue.ToString());

            if (_ceriv.MacroEstado(1, objetoMacro))
            {
                MessageBox.Show("Se agrego una Macro Etapa");
                cargarComboBox();
            }
            else
            {
                MessageBox.Show("No se pudo agregar la Micro Etapa");
            }
        }

        public void activarMacroMicro()
        {

            txt_NombreMicro.Enabled = true;
        }
        public void limpiarMacroMicro()
        {

        }
        private void btn_EliminarMicro_Click(object sender, EventArgs e)
        {

         
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            C_Macro objetoMacro = new C_Macro();

            objetoMacro.Codigo = Int32.Parse(lbl_Micro.Text);
            objetoMacro.CodigoEstadoMacro = Int32.Parse(lbl_Estado.Text);
            if (objetoMacro.Codigo != 0)
            {
                if (objetoMacro.CodigoEstadoMacro != 0)
                {
                    if (_ceriv.MacroEstado(3, objetoMacro))
                    {
                        MessageBox.Show("Se elimino una Micro Etapa");
                        cargarComboBox();
                        CargarDataGridViewMacrosProceso();
                        activarMacroMicro();
                        LimpiarTipoProcesoMacro();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Micro Etapa");
                    }
                }
            }
            else
            {
                MessageBox.Show("No se selecciono ninguna Micro Etapa");
            }
        }

        //DESDE ACA MACRO

        public void cargarEstadoProcesalMacro()
        {
            cmb_EstadoMacro.DisplayMember = "Nombre";
            cmb_EstadoMacro.ValueMember = "Codigo";
            cmb_EstadoMacro.DataSource = _ceriv.MacroEtapaMostrar();

        }
        public void cargarMacro()
        {
            cmb_Macro.DisplayMember = "Nombre";
            cmb_Macro.ValueMember = "Codigo";
            cmb_Macro.DataSource = _ceriv.MacroEtapaMostrar();
        }
        private void cmb_EstadoMacro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_EstadoMacro.SelectedIndex != -1){
                cargarDataGridViewMacroEtapa();
            }
        }
        public void cargarDataGridViewMacroEtapa()
        {
            dgv_Macro.AutoGenerateColumns = false;
            dgv_Macro.DataSource = _ceriv.MicroEstadoMostrar(Int32.Parse(cmb_EstadoMacro.SelectedValue.ToString()));
        }
        public void cargarMicro()
        {
            cmb_MicroEtapa.DisplayMember = "Nombre";
            cmb_MicroEtapa.ValueMember = "Codigo";
            cmb_MicroEtapa.DataSource = _ceriv.MicroEtapaMostrar();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            guardarMicroEtapa();
        }
        public void guardarMicroEtapa()
        {

            C_Micro objetoMicro = new C_Micro();
            objetoMicro.Codigo = Int32.Parse(cmb_MicroEtapa.SelectedValue.ToString());
            objetoMicro.CodigoEstado = Int32.Parse(cmb_EstadoMacro.SelectedValue.ToString());

            if (_ceriv.MicroEstado(1, objetoMicro))
            {
                MessageBox.Show("Se agrego una Micro Etapa");
                cargarComboBox();
            }
            else
            {
                MessageBox.Show("No se pudo agregar la Micro Etapa");
            }
        }

        private void dgv_Macro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (e.RowIndex > -1)
            {
                txt_MacroEtapa.Text = dgv_Macro.Rows[row].Cells["Nombre"].Value.ToString();
                lbl_Macro.Text = dgv_Macro.Rows[row].Cells["Codigo"].Value.ToString();
                lbl_EstadoMacro.Text = dgv_Macro.Rows[row].Cells["CodigoEstado"].Value.ToString();
                bloquearMacro();
            }
        }

        private void limpiarMacro()
        {
            txt_MacroEtapa.Clear();
            lbl_EstadoMacro.Text = "0";
            lbl_Macro.Text = "0";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            C_Macro objetoMacro = new C_Macro();

            objetoMacro.Codigo = Int32.Parse(lbl_Macro.Text);
            objetoMacro.CodigoEstadoMacro = Int32.Parse(lbl_EstadoMacro.Text);
            if (objetoMacro.Codigo != 0)
            {
                if (objetoMacro.CodigoEstadoMacro != 0)
                {
                    if (_ceriv.MacroEstado(3, objetoMacro))
                    {
                        MessageBox.Show("Se elimino una Micro Etapa");
                        cargarComboBox();
                        cargarDataGridViewMacroEtapa();
                        activarMacro();
                        limpiarMacro();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Micro Etapa");
                    }
                }
            }
            else
            {
                MessageBox.Show("No se selecciono ninguna Micro Etapa");
            }
        }

        private void btn_EliminarMicro_Click_1(object sender, EventArgs e)
        {
            C_Micro objetoMicro = new C_Micro();
            objetoMicro.Codigo = Int32.Parse(lbl_Macro.Text);
            objetoMicro.CodigoEstado = Int32.Parse(lbl_EstadoMacro.Text);
            if (objetoMicro.Codigo != 0)
            {
                if (objetoMicro.CodigoEstado != 0)
                {
                    if (_ceriv.MicroEstado(3, objetoMicro))
                    {
                        MessageBox.Show("Se elimino una Macro Etapa");
                        cargarComboBox();
                        cargarDataGridViewMacroEtapa();
                        activarMacro();
                        limpiarMacro();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Macro Etapa");
                    }
                }
            }
            else
            {
                MessageBox.Show("No se selecciono ninguna Macro Etapa");
            }


        }


    }
}
