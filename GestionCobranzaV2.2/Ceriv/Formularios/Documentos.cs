using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWord = Microsoft.Office.Interop.Word;

namespace Ceriv.Formularios
{
    public partial class Documentos : Form
    {

        public Documentos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        
        public Documentos(string cuentaBt)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            txt_CuentaBt.Text = cuentaBt;
        }


        
        private void btn_Generar_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        
    }
}
