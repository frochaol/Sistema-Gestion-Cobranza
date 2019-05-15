namespace Ceriv.Formularios
{
    partial class FR_InformeJudicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_InformeJudicial));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_CuentaBT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_InformeJudicial = new System.Windows.Forms.DataGridView();
            this.CUENTABT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRETITULAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI_DOI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMEXPEDIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JUZGADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionBIEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescBien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaProtesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InformeJudicial)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_InformeJudicial, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.83289F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.16711F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(975, 377);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44764F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.4672F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.03913F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Limpiar, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Buscar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_CuentaBT, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(967, 60);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Limpiar.Location = new System.Drawing.Point(772, 11);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(112, 38);
            this.btn_Limpiar.TabIndex = 0;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(571, 11);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(112, 38);
            this.btn_Exportar.TabIndex = 1;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Buscar.Location = new System.Drawing.Point(395, 11);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(112, 38);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_CuentaBT
            // 
            this.txt_CuentaBT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_CuentaBT.Enabled = false;
            this.txt_CuentaBT.Location = new System.Drawing.Point(169, 17);
            this.txt_CuentaBT.Name = "txt_CuentaBT";
            this.txt_CuentaBT.Size = new System.Drawing.Size(220, 26);
            this.txt_CuentaBT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cuenta BT :";
            // 
            // dgv_InformeJudicial
            // 
            this.dgv_InformeJudicial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_InformeJudicial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InformeJudicial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CUENTABT,
            this.NOMBRETITULAR,
            this.DNI_DOI,
            this.NUMEXPEDIENTE,
            this.JUZGADO,
            this.DescripcionBIEN,
            this.TipoProceso,
            this.DescBien,
            this.FechaProtesto});
            this.dgv_InformeJudicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_InformeJudicial.Location = new System.Drawing.Point(3, 73);
            this.dgv_InformeJudicial.Name = "dgv_InformeJudicial";
            this.dgv_InformeJudicial.ReadOnly = true;
            this.dgv_InformeJudicial.RowHeadersVisible = false;
            this.dgv_InformeJudicial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_InformeJudicial.Size = new System.Drawing.Size(969, 301);
            this.dgv_InformeJudicial.TabIndex = 1;
            // 
            // CUENTABT
            // 
            this.CUENTABT.DataPropertyName = "CuentaBT";
            this.CUENTABT.HeaderText = "Cuenta BT";
            this.CUENTABT.Name = "CUENTABT";
            this.CUENTABT.ReadOnly = true;
            // 
            // NOMBRETITULAR
            // 
            this.NOMBRETITULAR.DataPropertyName = "NombreTitular";
            this.NOMBRETITULAR.HeaderText = "Nombre Titular";
            this.NOMBRETITULAR.Name = "NOMBRETITULAR";
            this.NOMBRETITULAR.ReadOnly = true;
            // 
            // DNI_DOI
            // 
            this.DNI_DOI.DataPropertyName = "Doi";
            this.DNI_DOI.HeaderText = "DNI/DOI";
            this.DNI_DOI.Name = "DNI_DOI";
            this.DNI_DOI.ReadOnly = true;
            // 
            // NUMEXPEDIENTE
            // 
            this.NUMEXPEDIENTE.DataPropertyName = "NumExpediente";
            this.NUMEXPEDIENTE.HeaderText = "Num. de Expediente";
            this.NUMEXPEDIENTE.Name = "NUMEXPEDIENTE";
            this.NUMEXPEDIENTE.ReadOnly = true;
            // 
            // JUZGADO
            // 
            this.JUZGADO.DataPropertyName = "Juzgado";
            this.JUZGADO.HeaderText = "Juzgado";
            this.JUZGADO.Name = "JUZGADO";
            this.JUZGADO.ReadOnly = true;
            // 
            // DescripcionBIEN
            // 
            this.DescripcionBIEN.DataPropertyName = "Descripcion";
            this.DescripcionBIEN.HeaderText = "Descripcion del Bien";
            this.DescripcionBIEN.Name = "DescripcionBIEN";
            this.DescripcionBIEN.ReadOnly = true;
            // 
            // TipoProceso
            // 
            this.TipoProceso.DataPropertyName = "NombreProceso";
            this.TipoProceso.HeaderText = "Tipo de Proceso";
            this.TipoProceso.Name = "TipoProceso";
            this.TipoProceso.ReadOnly = true;
            // 
            // DescBien
            // 
            this.DescBien.DataPropertyName = "Descripcion";
            this.DescBien.HeaderText = "Descripcion del Bien";
            this.DescBien.Name = "DescBien";
            this.DescBien.ReadOnly = true;
            // 
            // FechaProtesto
            // 
            this.FechaProtesto.DataPropertyName = "FechaProtestoString";
            this.FechaProtesto.HeaderText = "Fecha de Protesto";
            this.FechaProtesto.Name = "FechaProtesto";
            this.FechaProtesto.ReadOnly = true;
            // 
            // FR_InformeJudicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 377);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_InformeJudicial";
            this.Text = "Reporte Informe Judicial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InformeJudicial)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_InformeJudicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUENTABT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRETITULAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI_DOI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMEXPEDIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn JUZGADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionBIEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescBien;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaProtesto;
    }
}