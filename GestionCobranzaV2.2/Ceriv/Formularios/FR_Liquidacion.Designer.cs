namespace Ceriv.Formularios
{
    partial class FR_Liquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_Liquidacion));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Reporte = new System.Windows.Forms.DataGridView();
            this.doi_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecartera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuenta_bt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_BuscarCuentaBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cuentaBTLiquidacion = new System.Windows.Forms.TextBox();
            this.btn_Importar = new System.Windows.Forms.Button();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_Reporte, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 273);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgv_Reporte
            // 
            this.dgv_Reporte.AllowUserToAddRows = false;
            this.dgv_Reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.doi_cliente,
            this.nombre,
            this.Modelo,
            this.nombrecartera,
            this.cuenta_bt,
            this.cdr});
            this.dgv_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Reporte.Location = new System.Drawing.Point(3, 48);
            this.dgv_Reporte.Name = "dgv_Reporte";
            this.dgv_Reporte.ReadOnly = true;
            this.dgv_Reporte.RowHeadersVisible = false;
            this.dgv_Reporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Reporte.Size = new System.Drawing.Size(985, 222);
            this.dgv_Reporte.TabIndex = 0;
            // 
            // doi_cliente
            // 
            this.doi_cliente.DataPropertyName = "DoiCliente";
            this.doi_cliente.HeaderText = "DOI Titular";
            this.doi_cliente.Name = "doi_cliente";
            this.doi_cliente.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "NombreCliente";
            this.nombre.HeaderText = "Nombre Titular";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // Modelo
            // 
            this.Modelo.DataPropertyName = "NombreModelo";
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            // 
            // nombrecartera
            // 
            this.nombrecartera.DataPropertyName = "Nombrecartera";
            this.nombrecartera.HeaderText = "Cartera";
            this.nombrecartera.Name = "nombrecartera";
            this.nombrecartera.ReadOnly = true;
            // 
            // cuenta_bt
            // 
            this.cuenta_bt.DataPropertyName = "Cuenta_bt";
            this.cuenta_bt.HeaderText = "Cuenta bt";
            this.cuenta_bt.Name = "cuenta_bt";
            this.cuenta_bt.ReadOnly = true;
            // 
            // cdr
            // 
            this.cdr.DataPropertyName = "Cdr";
            this.cdr.HeaderText = "Cdr";
            this.cdr.Name = "cdr";
            this.cdr.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btn_BuscarCuentaBT, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_cuentaBTLiquidacion, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Importar, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(985, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_BuscarCuentaBT
            // 
            this.btn_BuscarCuentaBT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_BuscarCuentaBT.Location = new System.Drawing.Point(397, 4);
            this.btn_BuscarCuentaBT.Name = "btn_BuscarCuentaBT";
            this.btn_BuscarCuentaBT.Size = new System.Drawing.Size(105, 31);
            this.btn_BuscarCuentaBT.TabIndex = 0;
            this.btn_BuscarCuentaBT.Text = "Buscar";
            this.btn_BuscarCuentaBT.UseVisualStyleBackColor = true;
            this.btn_BuscarCuentaBT.Click += new System.EventHandler(this.btn_BuscarCuentaBT_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta BT";
            // 
            // txt_cuentaBTLiquidacion
            // 
            this.txt_cuentaBTLiquidacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_cuentaBTLiquidacion.Enabled = false;
            this.txt_cuentaBTLiquidacion.Location = new System.Drawing.Point(200, 6);
            this.txt_cuentaBTLiquidacion.Name = "txt_cuentaBTLiquidacion";
            this.txt_cuentaBTLiquidacion.Size = new System.Drawing.Size(191, 26);
            this.txt_cuentaBTLiquidacion.TabIndex = 2;
            // 
            // btn_Importar
            // 
            this.btn_Importar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Importar.Location = new System.Drawing.Point(834, 4);
            this.btn_Importar.Name = "btn_Importar";
            this.btn_Importar.Size = new System.Drawing.Size(105, 31);
            this.btn_Importar.TabIndex = 3;
            this.btn_Importar.Text = "Limpiar";
            this.btn_Importar.UseVisualStyleBackColor = true;
            this.btn_Importar.Click += new System.EventHandler(this.btn_Importar_Click);
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(637, 4);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(105, 31);
            this.btn_Exportar.TabIndex = 4;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // FR_Liquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_Liquidacion";
            this.Text = "Reporte Liquidacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_Reporte;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_BuscarCuentaBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_cuentaBTLiquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn doi_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecartera;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuenta_bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdr;
        private System.Windows.Forms.Button btn_Importar;
        private System.Windows.Forms.Button btn_Exportar;
    }
}