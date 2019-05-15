namespace Ceriv.Formularios
{
    partial class FR_CambioModelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_CambioModelo));
            this.dgv_Reporte = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doi_Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta_Bt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Cartera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Estudio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Solucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacion_Devolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_Cuentabt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Reporte
            // 
            this.dgv_Reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Doi_Cliente,
            this.Cuenta_Bt,
            this.Operacion,
            this.Nombre_Cartera,
            this.Nombre_Estudio,
            this.Solucion,
            this.Observacion_Devolucion});
            this.dgv_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Reporte.Location = new System.Drawing.Point(3, 70);
            this.dgv_Reporte.Name = "dgv_Reporte";
            this.dgv_Reporte.ReadOnly = true;
            this.dgv_Reporte.RowHeadersVisible = false;
            this.dgv_Reporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Reporte.Size = new System.Drawing.Size(843, 330);
            this.dgv_Reporte.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "NombreCompleto";
            this.Nombre.HeaderText = "Nombre Titular";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Doi_Cliente
            // 
            this.Doi_Cliente.DataPropertyName = "DoiCliente";
            this.Doi_Cliente.HeaderText = "DOI Titular";
            this.Doi_Cliente.Name = "Doi_Cliente";
            this.Doi_Cliente.ReadOnly = true;
            // 
            // Cuenta_Bt
            // 
            this.Cuenta_Bt.DataPropertyName = "CuentaBT";
            this.Cuenta_Bt.HeaderText = "Cuenta BT";
            this.Cuenta_Bt.Name = "Cuenta_Bt";
            this.Cuenta_Bt.ReadOnly = true;
            // 
            // Operacion
            // 
            this.Operacion.DataPropertyName = "Operacion";
            this.Operacion.HeaderText = "Operacion";
            this.Operacion.Name = "Operacion";
            this.Operacion.ReadOnly = true;
            // 
            // Nombre_Cartera
            // 
            this.Nombre_Cartera.DataPropertyName = "NombreCartera";
            this.Nombre_Cartera.HeaderText = "Cartera";
            this.Nombre_Cartera.Name = "Nombre_Cartera";
            this.Nombre_Cartera.ReadOnly = true;
            // 
            // Nombre_Estudio
            // 
            this.Nombre_Estudio.DataPropertyName = "NombreEstudio";
            this.Nombre_Estudio.HeaderText = "Estudio";
            this.Nombre_Estudio.Name = "Nombre_Estudio";
            this.Nombre_Estudio.ReadOnly = true;
            // 
            // Solucion
            // 
            this.Solucion.DataPropertyName = "TipoSolucion";
            this.Solucion.HeaderText = "Solucion";
            this.Solucion.Name = "Solucion";
            this.Solucion.ReadOnly = true;
            // 
            // Observacion_Devolucion
            // 
            this.Observacion_Devolucion.DataPropertyName = "ObservacionTramite";
            this.Observacion_Devolucion.HeaderText = "Motivo de Cambio";
            this.Observacion_Devolucion.Name = "Observacion_Devolucion";
            this.Observacion_Devolucion.ReadOnly = true;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 403);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.54768F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.33985F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.99266F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.82641F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Limpiar, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Buscar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_Cuentabt, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(843, 61);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Limpiar.Location = new System.Drawing.Point(699, 14);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(117, 33);
            this.btn_Limpiar.TabIndex = 0;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta BT :";
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(534, 14);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(117, 33);
            this.btn_Exportar.TabIndex = 2;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Buscar.Location = new System.Drawing.Point(373, 14);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(117, 33);
            this.btn_Buscar.TabIndex = 4;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_Cuentabt
            // 
            this.txt_Cuentabt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_Cuentabt.Enabled = false;
            this.txt_Cuentabt.Location = new System.Drawing.Point(125, 17);
            this.txt_Cuentabt.Name = "txt_Cuentabt";
            this.txt_Cuentabt.Size = new System.Drawing.Size(234, 26);
            this.txt_Cuentabt.TabIndex = 5;
            // 
            // FR_CambioModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 403);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_CambioModelo";
            this.Text = "Reporte Cambio de Modelo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Reporte;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Cuentabt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doi_Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta_Bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Cartera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Estudio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Solucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacion_Devolucion;

    }
}