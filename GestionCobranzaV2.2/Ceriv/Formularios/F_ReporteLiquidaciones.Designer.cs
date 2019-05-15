namespace Ceriv.Formularios
{
    partial class F_ReporteLiquidaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_ReporteLiquidaciones));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_cartera = new System.Windows.Forms.ComboBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.dgv_Liquidaciones = new System.Windows.Forms.DataGridView();
            this.agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoGasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle_Gasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrorecibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_tipogasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_Detalle_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liquidaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.SlateGray;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_Liquidaciones, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.38728F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.61272F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 387);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmb_cartera, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_Buscar, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.17647F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.82353F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1021, 68);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Cartera:";
            // 
            // cmb_cartera
            // 
            this.cmb_cartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_cartera.FormattingEnabled = true;
            this.cmb_cartera.Location = new System.Drawing.Point(3, 31);
            this.cmb_cartera.Name = "cmb_cartera";
            this.cmb_cartera.Size = new System.Drawing.Size(334, 28);
            this.cmb_cartera.TabIndex = 1;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(343, 31);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(134, 28);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Location = new System.Drawing.Point(683, 31);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(134, 28);
            this.btn_Exportar.TabIndex = 3;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // dgv_Liquidaciones
            // 
            this.dgv_Liquidaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Liquidaciones.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgv_Liquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Liquidaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.agencia,
            this.nombre_proceso,
            this.nombreCliente,
            this.operacion,
            this.TipoGasto,
            this.Detalle_Gasto,
            this.Fecha,
            this.nrorecibo,
            this.Cantidad,
            this.Monto,
            this.codigo_tipogasto,
            this.codigo_detalle,
            this.Codigo_Detalle_liquidacion});
            this.dgv_Liquidaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Liquidaciones.Location = new System.Drawing.Point(23, 97);
            this.dgv_Liquidaciones.Name = "dgv_Liquidaciones";
            this.dgv_Liquidaciones.ReadOnly = true;
            this.dgv_Liquidaciones.RowHeadersVisible = false;
            this.dgv_Liquidaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Liquidaciones.Size = new System.Drawing.Size(1021, 266);
            this.dgv_Liquidaciones.TabIndex = 4;
            // 
            // agencia
            // 
            this.agencia.DataPropertyName = "Agencia";
            this.agencia.HeaderText = "Agencia";
            this.agencia.Name = "agencia";
            this.agencia.ReadOnly = true;
            this.agencia.Width = 92;
            // 
            // nombre_proceso
            // 
            this.nombre_proceso.DataPropertyName = "Nombre_proceso";
            this.nombre_proceso.HeaderText = "NombreProceso";
            this.nombre_proceso.Name = "nombre_proceso";
            this.nombre_proceso.ReadOnly = true;
            this.nombre_proceso.Width = 148;
            // 
            // nombreCliente
            // 
            this.nombreCliente.DataPropertyName = "Nombre_cliente";
            this.nombreCliente.HeaderText = "NombreCliente";
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.ReadOnly = true;
            this.nombreCliente.Width = 139;
            // 
            // operacion
            // 
            this.operacion.DataPropertyName = "Operacion";
            this.operacion.HeaderText = "Operacion";
            this.operacion.Name = "operacion";
            this.operacion.ReadOnly = true;
            this.operacion.Width = 107;
            // 
            // TipoGasto
            // 
            this.TipoGasto.DataPropertyName = "Nombre_gasto";
            this.TipoGasto.HeaderText = "Tipo de Gasto";
            this.TipoGasto.Name = "TipoGasto";
            this.TipoGasto.ReadOnly = true;
            this.TipoGasto.Width = 123;
            // 
            // Detalle_Gasto
            // 
            this.Detalle_Gasto.DataPropertyName = "Nombre_detalle";
            this.Detalle_Gasto.HeaderText = "Detalle del Gasto";
            this.Detalle_Gasto.Name = "Detalle_Gasto";
            this.Detalle_Gasto.ReadOnly = true;
            this.Detalle_Gasto.Width = 104;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha_liquidacionString";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 79;
            // 
            // nrorecibo
            // 
            this.nrorecibo.DataPropertyName = "Nro_recibo";
            this.nrorecibo.HeaderText = "Nro° Recibo";
            this.nrorecibo.Name = "nrorecibo";
            this.nrorecibo.ReadOnly = true;
            this.nrorecibo.Width = 108;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 98;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 79;
            // 
            // codigo_tipogasto
            // 
            this.codigo_tipogasto.DataPropertyName = "Codigo_tipogasto";
            this.codigo_tipogasto.HeaderText = "ctg";
            this.codigo_tipogasto.Name = "codigo_tipogasto";
            this.codigo_tipogasto.ReadOnly = true;
            this.codigo_tipogasto.Visible = false;
            // 
            // codigo_detalle
            // 
            this.codigo_detalle.DataPropertyName = "Codigo_detalle";
            this.codigo_detalle.HeaderText = "cd";
            this.codigo_detalle.Name = "codigo_detalle";
            this.codigo_detalle.ReadOnly = true;
            this.codigo_detalle.Visible = false;
            // 
            // Codigo_Detalle_liquidacion
            // 
            this.Codigo_Detalle_liquidacion.DataPropertyName = "Codigo_Detalle_liquidacion";
            this.Codigo_Detalle_liquidacion.HeaderText = "Codigo_Detalle_liquidacion";
            this.Codigo_Detalle_liquidacion.Name = "Codigo_Detalle_liquidacion";
            this.Codigo_Detalle_liquidacion.ReadOnly = true;
            this.Codigo_Detalle_liquidacion.Visible = false;
            // 
            // F_ReporteLiquidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 387);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "F_ReporteLiquidaciones";
            this.Text = "Reporte Liquidaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Liquidaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_cartera;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.DataGridView dgv_Liquidaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoGasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle_Gasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrorecibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_tipogasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Detalle_liquidacion;
    }
}