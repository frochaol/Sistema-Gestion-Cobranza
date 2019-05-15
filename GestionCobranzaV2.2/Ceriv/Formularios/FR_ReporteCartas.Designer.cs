namespace Ceriv.Formularios
{
    partial class FR_ReporteCartas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_ReporteCartas));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.txt_cuenta_Bt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Reporte = new System.Windows.Forms.DataGridView();
            this.CuentaBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conyuge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cartera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abogado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionAlterna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inubicable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_Reporte, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.28117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.71883F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(981, 377);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.SlateGray;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.038F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.79838F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.47893F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.68469F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_Limpiar, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt_cuenta_Bt, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(975, 78);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(479, 20);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(115, 35);
            this.btn_Exportar.TabIndex = 4;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Limpiar.Location = new System.Drawing.Point(772, 20);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(115, 35);
            this.btn_Limpiar.TabIndex = 6;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // txt_cuenta_Bt
            // 
            this.txt_cuenta_Bt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cuenta_Bt.Enabled = false;
            this.txt_cuenta_Bt.Location = new System.Drawing.Point(120, 25);
            this.txt_cuenta_Bt.Name = "txt_cuenta_Bt";
            this.txt_cuenta_Bt.Size = new System.Drawing.Size(265, 26);
            this.txt_cuenta_Bt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cuenta BT";
            // 
            // dgv_Reporte
            // 
            this.dgv_Reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Reporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CuentaBT,
            this.Cliente,
            this.Conyuge,
            this.Representante,
            this.Cartera,
            this.Abogado,
            this.DireccionAlterna,
            this.Domicilio,
            this.Distrito,
            this.NombreProceso,
            this.Inubicable});
            this.dgv_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Reporte.Location = new System.Drawing.Point(3, 87);
            this.dgv_Reporte.Name = "dgv_Reporte";
            this.dgv_Reporte.RowHeadersVisible = false;
            this.dgv_Reporte.Size = new System.Drawing.Size(975, 287);
            this.dgv_Reporte.TabIndex = 7;
            // 
            // CuentaBT
            // 
            this.CuentaBT.DataPropertyName = "Cuenta_bt";
            this.CuentaBT.HeaderText = "BT";
            this.CuentaBT.Name = "CuentaBT";
            this.CuentaBT.Width = 54;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Nombre_cliente";
            this.Cliente.HeaderText = "Nombre Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 131;
            // 
            // Conyuge
            // 
            this.Conyuge.DataPropertyName = "NombreConyuge";
            this.Conyuge.HeaderText = "Nombre Conyuge";
            this.Conyuge.Name = "Conyuge";
            this.Conyuge.Width = 143;
            // 
            // Representante
            // 
            this.Representante.DataPropertyName = "Representante";
            this.Representante.HeaderText = "Representante";
            this.Representante.Name = "Representante";
            this.Representante.Width = 141;
            // 
            // Cartera
            // 
            this.Cartera.DataPropertyName = "NombreCartera";
            this.Cartera.HeaderText = "Cartera";
            this.Cartera.Name = "Cartera";
            this.Cartera.Width = 87;
            // 
            // Abogado
            // 
            this.Abogado.DataPropertyName = "Abogado";
            this.Abogado.HeaderText = "Abogado";
            this.Abogado.Name = "Abogado";
            this.Abogado.Width = 99;
            // 
            // DireccionAlterna
            // 
            this.DireccionAlterna.DataPropertyName = "DireccionAlterna";
            this.DireccionAlterna.HeaderText = "Direccion Alterna";
            this.DireccionAlterna.Name = "DireccionAlterna";
            this.DireccionAlterna.Width = 141;
            // 
            // Domicilio
            // 
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio Cliente";
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Width = 137;
            // 
            // Distrito
            // 
            this.Distrito.DataPropertyName = "NombreDistrito";
            this.Distrito.HeaderText = "Distrito";
            this.Distrito.Name = "Distrito";
            this.Distrito.Width = 84;
            // 
            // NombreProceso
            // 
            this.NombreProceso.DataPropertyName = "NombreProceso";
            this.NombreProceso.HeaderText = "Nombre Proceso";
            this.NombreProceso.Name = "NombreProceso";
            this.NombreProceso.Width = 139;
            // 
            // Inubicable
            // 
            this.Inubicable.DataPropertyName = "Inubicable";
            this.Inubicable.HeaderText = "Inubicable";
            this.Inubicable.Name = "Inubicable";
            this.Inubicable.Width = 107;
            // 
            // FR_ReporteCartas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 377);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_ReporteCartas";
            this.Text = "Reporte Cartas";
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
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.TextBox txt_cuenta_Bt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Reporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conyuge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cartera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abogado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionAlterna;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inubicable;
    }
}