namespace Ceriv.Formularios
{
    partial class FR_Llamada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_Llamada));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Reporte = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.NumExpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaGestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaProxLlamada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoSolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoNoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_Reporte, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.31658F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.68342F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1022, 398);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_Reporte
            // 
            this.dgv_Reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Reporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_Reporte.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgv_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumExpediente,
            this.Operacion,
            this.FechaGestion,
            this.NombreCompleto,
            this.TelefonoContacto,
            this.Telefono,
            this.FechaProxLlamada,
            this.TipoSolucion,
            this.FechaPago,
            this.MotivoNoPago});
            this.dgv_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Reporte.Location = new System.Drawing.Point(3, 55);
            this.dgv_Reporte.Name = "dgv_Reporte";
            this.dgv_Reporte.RowHeadersVisible = false;
            this.dgv_Reporte.Size = new System.Drawing.Size(1016, 340);
            this.dgv_Reporte.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1016, 46);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(702, 5);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(119, 36);
            this.btn_Exportar.TabIndex = 0;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // NumExpediente
            // 
            this.NumExpediente.DataPropertyName = "NumExpediente";
            this.NumExpediente.HeaderText = "Nº Expediente";
            this.NumExpediente.Name = "NumExpediente";
            // 
            // Operacion
            // 
            this.Operacion.DataPropertyName = "Operacion";
            this.Operacion.HeaderText = "Operacion";
            this.Operacion.Name = "Operacion";
            // 
            // FechaGestion
            // 
            this.FechaGestion.DataPropertyName = "FechaGestionString";
            this.FechaGestion.HeaderText = "Fecha de Gestion";
            this.FechaGestion.Name = "FechaGestion";
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.DataPropertyName = "Nombre_cliente";
            this.NombreCompleto.HeaderText = "Nombre Cliente";
            this.NombreCompleto.Name = "NombreCompleto";
            // 
            // TelefonoContacto
            // 
            this.TelefonoContacto.DataPropertyName = "TelefonoLlamada";
            this.TelefonoContacto.HeaderText = "Telefono de Gestion";
            this.TelefonoContacto.Name = "TelefonoContacto";
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "TelefonoPersona";
            this.Telefono.HeaderText = "Telefono de Cliente";
            this.Telefono.Name = "Telefono";
            // 
            // FechaProxLlamada
            // 
            this.FechaProxLlamada.DataPropertyName = "FechaProxLlamadaString";
            this.FechaProxLlamada.HeaderText = "Fecha Proxima Llamada";
            this.FechaProxLlamada.Name = "FechaProxLlamada";
            // 
            // TipoSolucion
            // 
            this.TipoSolucion.DataPropertyName = "TipoSolucion";
            this.TipoSolucion.HeaderText = "Tipo de Solucion";
            this.TipoSolucion.Name = "TipoSolucion";
            // 
            // FechaPago
            // 
            this.FechaPago.DataPropertyName = "FechaPagoString";
            this.FechaPago.HeaderText = "Fecha de Pago";
            this.FechaPago.Name = "FechaPago";
            // 
            // MotivoNoPago
            // 
            this.MotivoNoPago.DataPropertyName = "NiegaPago";
            this.MotivoNoPago.HeaderText = "Motivo No Pago";
            this.MotivoNoPago.Name = "MotivoNoPago";
            // 
            // FR_Llamada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1022, 398);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_Llamada";
            this.Text = "Reporte Gestion Llamada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_Reporte;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaGestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaProxLlamada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoSolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoNoPago;
    }
}