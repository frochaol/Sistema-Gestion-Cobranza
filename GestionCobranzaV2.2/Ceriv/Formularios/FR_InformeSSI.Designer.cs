namespace Ceriv.Formularios
{
    partial class FR_InformeSSI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_InformeSSI));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_CuentaBT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Reporte = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEMANDADOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARTERA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODELO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECTORISTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTUDIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REGION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIUDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPODEPROCESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JUZGADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXPEDIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONEDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTOADMITIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESUMEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_Reporte, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.15576F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.84425F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 443);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40642F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.45455F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.13904F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Limpiar, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Buscar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_CuentaBT, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(997, 70);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Limpiar.Location = new System.Drawing.Point(806, 14);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(117, 42);
            this.btn_Limpiar.TabIndex = 0;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(603, 14);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(117, 42);
            this.btn_Exportar.TabIndex = 1;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Buscar.Location = new System.Drawing.Point(350, 14);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(117, 42);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_CuentaBT
            // 
            this.txt_CuentaBT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_CuentaBT.Enabled = false;
            this.txt_CuentaBT.Location = new System.Drawing.Point(117, 22);
            this.txt_CuentaBT.Name = "txt_CuentaBT";
            this.txt_CuentaBT.Size = new System.Drawing.Size(227, 26);
            this.txt_CuentaBT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cuenta BT :";
            // 
            // dgv_Reporte
            // 
            this.dgv_Reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI,
            this.CLIENTE,
            this.DEMANDADOS,
            this.CARTERA,
            this.MODELO,
            this.SECTORISTA,
            this.ESTUDIO,
            this.REGION,
            this.CIUDAD,
            this.TIPODEPROCESO,
            this.JUZGADO,
            this.EXPEDIENTE,
            this.MONEDA,
            this.MONTOADMITIDO,
            this.RESUMEN});
            this.dgv_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Reporte.Location = new System.Drawing.Point(3, 79);
            this.dgv_Reporte.Name = "dgv_Reporte";
            this.dgv_Reporte.ReadOnly = true;
            this.dgv_Reporte.RowHeadersVisible = false;
            this.dgv_Reporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Reporte.Size = new System.Drawing.Size(997, 361);
            this.dgv_Reporte.TabIndex = 1;
            // 
            // DNI
            // 
            this.DNI.DataPropertyName = "Doi";
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 62;
            // 
            // CLIENTE
            // 
            this.CLIENTE.DataPropertyName = "NombreCliente";
            this.CLIENTE.HeaderText = "Cliente";
            this.CLIENTE.Name = "CLIENTE";
            this.CLIENTE.ReadOnly = true;
            this.CLIENTE.Width = 83;
            // 
            // DEMANDADOS
            // 
            this.DEMANDADOS.DataPropertyName = "NombreGarante";
            this.DEMANDADOS.HeaderText = "Demandado";
            this.DEMANDADOS.Name = "DEMANDADOS";
            this.DEMANDADOS.ReadOnly = true;
            this.DEMANDADOS.Width = 122;
            // 
            // CARTERA
            // 
            this.CARTERA.DataPropertyName = "Cartera";
            this.CARTERA.HeaderText = "Cartera";
            this.CARTERA.Name = "CARTERA";
            this.CARTERA.ReadOnly = true;
            this.CARTERA.Width = 87;
            // 
            // MODELO
            // 
            this.MODELO.DataPropertyName = "Modelo";
            this.MODELO.HeaderText = "Modelo";
            this.MODELO.Name = "MODELO";
            this.MODELO.ReadOnly = true;
            this.MODELO.Width = 86;
            // 
            // SECTORISTA
            // 
            this.SECTORISTA.DataPropertyName = "Sectorista";
            this.SECTORISTA.HeaderText = "SECTORISTA";
            this.SECTORISTA.Name = "SECTORISTA";
            this.SECTORISTA.ReadOnly = true;
            this.SECTORISTA.Width = 136;
            // 
            // ESTUDIO
            // 
            this.ESTUDIO.DataPropertyName = "Estudio";
            this.ESTUDIO.HeaderText = "Estudio";
            this.ESTUDIO.Name = "ESTUDIO";
            this.ESTUDIO.ReadOnly = true;
            this.ESTUDIO.Width = 88;
            // 
            // REGION
            // 
            this.REGION.DataPropertyName = "Region";
            this.REGION.HeaderText = "Region";
            this.REGION.Name = "REGION";
            this.REGION.ReadOnly = true;
            this.REGION.Width = 85;
            // 
            // CIUDAD
            // 
            this.CIUDAD.DataPropertyName = "Ciudad";
            this.CIUDAD.HeaderText = "Ciudad";
            this.CIUDAD.Name = "CIUDAD";
            this.CIUDAD.ReadOnly = true;
            this.CIUDAD.Width = 84;
            // 
            // TIPODEPROCESO
            // 
            this.TIPODEPROCESO.DataPropertyName = "TipoProceso";
            this.TIPODEPROCESO.HeaderText = "Tipo de Proceso";
            this.TIPODEPROCESO.Name = "TIPODEPROCESO";
            this.TIPODEPROCESO.ReadOnly = true;
            this.TIPODEPROCESO.Width = 135;
            // 
            // JUZGADO
            // 
            this.JUZGADO.DataPropertyName = "Juzgado";
            this.JUZGADO.HeaderText = "Juzgado";
            this.JUZGADO.Name = "JUZGADO";
            this.JUZGADO.ReadOnly = true;
            this.JUZGADO.Width = 95;
            // 
            // EXPEDIENTE
            // 
            this.EXPEDIENTE.DataPropertyName = "NumJuzgado";
            this.EXPEDIENTE.HeaderText = "Expediente";
            this.EXPEDIENTE.Name = "EXPEDIENTE";
            this.EXPEDIENTE.ReadOnly = true;
            this.EXPEDIENTE.Width = 114;
            // 
            // MONEDA
            // 
            this.MONEDA.DataPropertyName = "Moneda";
            this.MONEDA.HeaderText = "(US$ o S/.)";
            this.MONEDA.Name = "MONEDA";
            this.MONEDA.ReadOnly = true;
            this.MONEDA.Width = 81;
            // 
            // MONTOADMITIDO
            // 
            this.MONTOADMITIDO.DataPropertyName = "MontoAdmitido";
            this.MONTOADMITIDO.HeaderText = "Monto Admitido";
            this.MONTOADMITIDO.Name = "MONTOADMITIDO";
            this.MONTOADMITIDO.ReadOnly = true;
            this.MONTOADMITIDO.Width = 132;
            // 
            // RESUMEN
            // 
            this.RESUMEN.DataPropertyName = "Resumen";
            this.RESUMEN.HeaderText = "Resumen";
            this.RESUMEN.Name = "RESUMEN";
            this.RESUMEN.ReadOnly = true;
            this.RESUMEN.Width = 103;
            // 
            // FR_InformeSSI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 443);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_InformeSSI";
            this.Text = "Reporte Informe SCI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_CuentaBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Reporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEMANDADOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARTERA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODELO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECTORISTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTUDIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIUDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPODEPROCESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn JUZGADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXPEDIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONEDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTOADMITIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESUMEN;
    }
}