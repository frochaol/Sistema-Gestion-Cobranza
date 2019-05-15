using Ceriv.Clases;
using Ceriv.Conexion;
using Ceriv.Dto;
using Ceriv.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xWord = Microsoft.Office.Interop.Word;
namespace Ceriv.Formularios
{
    public partial class FD_Expediente : Form
    {
        const int CAJASULLANA = 17;
        const int PROEMPRESA = 19;
        const int ODSD = 16;
        const int ODSD_SELECTIVA = 25;
        const int ODSD_MASIVO = 26;
        const int EJECUCION = 15;

        S_Ceriv _ceriv = new S_Ceriv();
        public FD_Expediente()
        {
            InitializeComponent();
            SelectDinamico<Credito>();
            CargarComboBoxCartera();
            CargarComboBoxProceso();
            CargarComboBoxPersona();
            Atajo();
        }
        public List<T> SelectDinamico<T>(string nombre = null, object valor = null) where T : new()
        {
            DinamicoSelect select = new DinamicoSelect(); 
            DtoCondicion dto = new DtoCondicion();
            if (nombre == null)
                dto = null;
            else
            {
                
                dto.Nombre = nombre;
                dto.Valor = valor;
            }
            return select.DinamicoMostarLista<T>(dto);
        }

        private void CargarComboBoxPersona()
        {
            cmb_Persona.DisplayMember = "NombrePersona";
            cmb_Persona.ValueMember = "Dni";
            List<C_CarteraPersona> carteras = _ceriv.CarteraPersonaMostrar();
            for (int i = carteras.Count - 1; i >= 0; i--)
            {
                if (carteras[i].CodigoCartera != CAJASULLANA && carteras[i].CodigoCartera != PROEMPRESA)
                {
                    carteras.Remove(carteras[i]);
                }
            }
            cmb_Persona.DataSource = carteras;
        }
        private void CargarComboBoxCartera()
        {
            cmb_Cartera.DisplayMember = "NombreCartera";
            cmb_Cartera.ValueMember = "CodigoCartera";
            List<C_Cartera> carteras = _ceriv.CarteraMostrar();
            for (int i = carteras.Count - 1; i >= 0; i--)
            {
                if (carteras[i].CodigoCartera != CAJASULLANA && carteras[i].CodigoCartera != PROEMPRESA)
                {
                    carteras.Remove(carteras[i]);
                }
            }
            
            cmb_Cartera.DataSource = carteras;
        }
        public void CargarComboBoxProceso()
        {
            cmb_Proceso.DisplayMember = "NombreProceso";
            cmb_Proceso.ValueMember = "CodigoProceso";
            List<C_TipoProceso> proceso = _ceriv.ProcesoMostrar();
            for (int i = proceso.Count - 1; i >= 0; i--)
            {
                if (proceso[i].CodigoProceso != ODSD && proceso[i].CodigoProceso != ODSD_SELECTIVA && proceso[i].CodigoProceso != ODSD_MASIVO && proceso[i].CodigoProceso != EJECUCION)
                {
                    proceso.Remove(proceso[i]);
                }
            }
            cmb_Proceso.DataSource = proceso;
        }
        // ATAJO DE TECLAS

        public void Atajo()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.CrearModificar_KeyDown);
        }
        private void CrearModificar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                AbrirBuscarClienteNombre();
            }
        }
        public void AbrirBuscarClienteNombre()
        {
            E_NombreTitular obj1 = new E_NombreTitular();
            obj1.ShowDialog();
            if (obj1.Nuevo == string.Empty)
            {
                MessageBox.Show("Seleccione un Cliente");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            object objMiss = System.Reflection.Missing.Value;
            xWord.Application objWord = new xWord.Application();
            //abrir
            //xWord.Document objDoc = objWord.Documents.Add(ref objMiss, ref objMiss, ref objMiss, ref objMiss);
            //objDoc.Activate();
            //objWord.Selection.Font.Color = xWord.WdColor.wdColorRed;
            //objWord.Selection.TypeText("prueba");
            //objWord.Visible = true;
            string ruta = @"D:\plantilla de abogados\Expediente.docx";
            object parametro = ruta;
            object variable1 = "nombrePersona";
            object variable2 = "direccionPersona";
            object variable3 = "distritoPersona";
            xWord.Document objDoc = objWord.Documents.Open(parametro, objMiss);
            xWord.Range nombre = objDoc.Bookmarks.get_Item(ref variable1).Range;
            xWord.Range direccion = objDoc.Bookmarks.get_Item(ref variable1).Range;
            xWord.Range distrito = objDoc.Bookmarks.get_Item(ref variable1).Range;
            nombre.Text = "nombrePersona";
            direccion.Text = "direccionPersona";
            direccion.Text = "distrito Persona";
            object nombreObj1 = nombre;
            objDoc.Bookmarks.Add("nombrePersonaVal", ref nombreObj1);
            objDoc.Bookmarks.Add("direccionPersonaVal", ref nombreObj1);
            objDoc.Bookmarks.Add("distritoPersonaVal", ref nombreObj1);
            objWord.Visible = true;
        }
        
    }
}
