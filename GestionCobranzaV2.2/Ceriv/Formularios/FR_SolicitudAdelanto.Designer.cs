namespace Ceriv.Formularios
{
    partial class FR_SolicitudAdelanto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_SolicitudAdelanto));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Reporte = new System.Windows.Forms.DataGridView();
            this.nombreestudio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecartera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doi_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto_demandado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCEPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_expediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARTERA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.demandante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demandado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrejuzgado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoJuicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_CuentaBT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1089, 403);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgv_Reporte
            // 
            this.dgv_Reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreestudio,
            this.nombreciudad,
            this.nombrecartera,
            this.doi_cliente,
            this.monto_demandado,
            this.CONCEPT,
            this.concepto,
            this.num_expediente,
            this.CARTERA,
            this.demandante,
            this.Demandado,
            this.nombrejuzgado,
            this.MotivoJuicio});
            this.dgv_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Reporte.Location = new System.Drawing.Point(3, 70);
            this.dgv_Reporte.Name = "dgv_Reporte";
            this.dgv_Reporte.ReadOnly = true;
            this.dgv_Reporte.RowHeadersVisible = false;
            this.dgv_Reporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Reporte.Size = new System.Drawing.Size(1083, 330);
            this.dgv_Reporte.TabIndex = 0;
            // 
            // nombreestudio
            // 
            this.nombreestudio.DataPropertyName = "Nombreestudio";
            this.nombreestudio.HeaderText = "Estudio";
            this.nombreestudio.Name = "nombreestudio";
            this.nombreestudio.ReadOnly = true;
            // 
            // nombreciudad
            // 
            this.nombreciudad.DataPropertyName = "Nombreciudad";
            this.nombreciudad.HeaderText = "Ciudad";
            this.nombreciudad.Name = "nombreciudad";
            this.nombreciudad.ReadOnly = true;
            // 
            // nombrecartera
            // 
            this.nombrecartera.DataPropertyName = "NombreCompleto";
            this.nombrecartera.HeaderText = "Cliente";
            this.nombrecartera.Name = "nombrecartera";
            this.nombrecartera.ReadOnly = true;
            // 
            // doi_cliente
            // 
            this.doi_cliente.DataPropertyName = "Doi_cliente";
            this.doi_cliente.HeaderText = "Doi Cliente";
            this.doi_cliente.Name = "doi_cliente";
            this.doi_cliente.ReadOnly = true;
            // 
            // monto_demandado
            // 
            this.monto_demandado.DataPropertyName = "Monto_demandado";
            this.monto_demandado.HeaderText = "Monto";
            this.monto_demandado.Name = "monto_demandado";
            this.monto_demandado.ReadOnly = true;
            // 
            // CONCEPT
            // 
            this.CONCEPT.DataPropertyName = "Concepto";
            this.CONCEPT.HeaderText = "Concepto";
            this.CONCEPT.Name = "CONCEPT";
            this.CONCEPT.ReadOnly = true;
            // 
            // concepto
            // 
            this.concepto.DataPropertyName = "Proveedor";
            this.concepto.HeaderText = "Juzgado/Proveedor";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            // 
            // num_expediente
            // 
            this.num_expediente.DataPropertyName = "Num_expediente";
            this.num_expediente.HeaderText = "Numero Expediente";
            this.num_expediente.Name = "num_expediente";
            this.num_expediente.ReadOnly = true;
            // 
            // CARTERA
            // 
            this.CARTERA.DataPropertyName = "Nombrecartera";
            this.CARTERA.HeaderText = "Cartera";
            this.CARTERA.Name = "CARTERA";
            this.CARTERA.ReadOnly = true;
            // 
            // demandante
            // 
            this.demandante.DataPropertyName = "Demandante";
            this.demandante.HeaderText = "Demandante";
            this.demandante.Name = "demandante";
            this.demandante.ReadOnly = true;
            // 
            // Demandado
            // 
            this.Demandado.DataPropertyName = "Demandado";
            this.Demandado.HeaderText = "Demandado";
            this.Demandado.Name = "Demandado";
            this.Demandado.ReadOnly = true;
            // 
            // nombrejuzgado
            // 
            this.nombrejuzgado.DataPropertyName = "Num_juzgado";
            this.nombrejuzgado.HeaderText = "Nombre Juzgado";
            this.nombrejuzgado.Name = "nombrejuzgado";
            this.nombrejuzgado.ReadOnly = true;
            // 
            // MotivoJuicio
            // 
            this.MotivoJuicio.DataPropertyName = "Motivojuicio";
            this.MotivoJuicio.HeaderText = "Motivo Juicio";
            this.MotivoJuicio.Name = "MotivoJuicio";
            this.MotivoJuicio.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.2549F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.37255F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.37255F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1083, 61);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Limpiar.Location = new System.Drawing.Point(891, 14);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(99, 33);
            this.btn_Limpiar.TabIndex = 0;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(671, 14);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(99, 33);
            this.btn_Exportar.TabIndex = 1;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Buscar.Location = new System.Drawing.Point(390, 14);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(99, 33);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_CuentaBT
            // 
            this.txt_CuentaBT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_CuentaBT.Enabled = false;
            this.txt_CuentaBT.Location = new System.Drawing.Point(126, 17);
            this.txt_CuentaBT.Name = "txt_CuentaBT";
            this.txt_CuentaBT.Size = new System.Drawing.Size(258, 26);
            this.txt_CuentaBT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cuenta BT :";
            // 
            // FR_SolicitudAdelanto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 403);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_SolicitudAdelanto";
            this.Text = "Reporte Solicitud de Adelanto";
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
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_CuentaBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreestudio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecartera;
        private System.Windows.Forms.DataGridViewTextBoxColumn doi_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto_demandado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCEPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_expediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARTERA;
        private System.Windows.Forms.DataGridViewTextBoxColumn demandante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demandado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrejuzgado;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoJuicio;
    }
}