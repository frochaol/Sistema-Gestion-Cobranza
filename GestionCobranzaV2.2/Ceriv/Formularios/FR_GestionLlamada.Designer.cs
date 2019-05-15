namespace Ceriv.Formularios
{
    partial class FR_GestionLlamada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_GestionLlamada));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.txt_cuenta_Bt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Reporte = new System.Windows.Forms.DataGridView();
            this.CuentaBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumExpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fechas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Historico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1026, 397);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgv_Reporte, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.94885F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.05115F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1020, 391);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.SlateGray;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.038F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.79838F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.47893F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.68469F));
            this.tableLayoutPanel3.Controls.Add(this.btn_Exportar, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_Limpiar, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txt_cuenta_Bt, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1014, 71);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(500, 17);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(115, 35);
            this.btn_Exportar.TabIndex = 4;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click_1);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Limpiar.Location = new System.Drawing.Point(805, 17);
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
            this.txt_cuenta_Bt.Location = new System.Drawing.Point(125, 21);
            this.txt_cuenta_Bt.Name = "txt_cuenta_Bt";
            this.txt_cuenta_Bt.Size = new System.Drawing.Size(274, 26);
            this.txt_cuenta_Bt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cuenta BT";
            // 
            // dgv_Reporte
            // 
            this.dgv_Reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Reporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_Reporte.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgv_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CuentaBT,
            this.Operacion,
            this.NumExpediente,
            this.Fechas,
            this.Telefono,
            this.Resultado,
            this.Historico,
            this.MotivoPago});
            this.dgv_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Reporte.Location = new System.Drawing.Point(3, 80);
            this.dgv_Reporte.Name = "dgv_Reporte";
            this.dgv_Reporte.RowHeadersVisible = false;
            this.dgv_Reporte.Size = new System.Drawing.Size(1014, 308);
            this.dgv_Reporte.TabIndex = 3;
            // 
            // CuentaBT
            // 
            this.CuentaBT.DataPropertyName = "Cuenta_bt";
            this.CuentaBT.HeaderText = "BT";
            this.CuentaBT.Name = "CuentaBT";
            // 
            // Operacion
            // 
            this.Operacion.DataPropertyName = "Operacion";
            this.Operacion.HeaderText = "Operacion";
            this.Operacion.Name = "Operacion";
            // 
            // NumExpediente
            // 
            this.NumExpediente.DataPropertyName = "NumExpediente";
            this.NumExpediente.HeaderText = "Nº Expediente";
            this.NumExpediente.Name = "NumExpediente";
            // 
            // Fechas
            // 
            this.Fechas.DataPropertyName = "FechaReporteLlamada";
            this.Fechas.HeaderText = "FechaMax- FechaMin";
            this.Fechas.Name = "Fechas";
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "TelefonoLlamada";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // Resultado
            // 
            this.Resultado.DataPropertyName = "ResultadoLlamda";
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Name = "Resultado";
            // 
            // Historico
            // 
            this.Historico.DataPropertyName = "ResumenLlamada";
            this.Historico.HeaderText = "Historico";
            this.Historico.Name = "Historico";
            // 
            // MotivoPago
            // 
            this.MotivoPago.DataPropertyName = "MotivoNoPago";
            this.MotivoPago.HeaderText = "Motivos de No Pago";
            this.MotivoPago.Name = "MotivoPago";
            // 
            // FR_GestionLlamada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 397);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_GestionLlamada";
            this.Text = "Reporte Gestion de Llamada";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.TextBox txt_cuenta_Bt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Reporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fechas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Historico;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoPago;
    }
}