namespace Ceriv.Formularios
{
    partial class FR_ModeloA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_ModeloA));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_ModeloA = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.txt_cuenta_Bt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CuentaBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoiCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demandados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cartera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECTORISTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estudio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Juzgado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAdmitido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResumenProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadBien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoGarantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorComercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorRealizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaMedidaCautelar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDemanda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaMandatoEjecucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaContradiccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaOrdenRemate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRemate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAdjudicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoProcesal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEstadoProcesal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TareaJudicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModeloA)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_ModeloA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2268F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.77319F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1014, 485);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_ModeloA
            // 
            this.dgv_ModeloA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_ModeloA.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgv_ModeloA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ModeloA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CuentaBT,
            this.DoiCliente,
            this.NombreCliente,
            this.Demandados,
            this.Cartera,
            this.Modelo,
            this.SECTORISTA,
            this.Estudio,
            this.Region,
            this.Ciudad,
            this.TipoProceso,
            this.Juzgado,
            this.Expediente,
            this.Operacion,
            this.Moneda,
            this.MontoAdmitido,
            this.ResumenProceso,
            this.Direccion,
            this.Distrito,
            this.CiudadBien,
            this.Moneda2,
            this.MontoGarantia,
            this.ValorComercial,
            this.ValorRealizacion,
            this.FechaMedidaCautelar,
            this.FechaDemanda,
            this.FechaMandatoEjecucion,
            this.FechaContradiccion,
            this.FechaOrdenRemate,
            this.FechaRemate,
            this.FechaAdjudicacion,
            this.EstadoProcesal,
            this.FechaEstadoProcesal,
            this.TareaJudicial});
            this.dgv_ModeloA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ModeloA.Location = new System.Drawing.Point(3, 71);
            this.dgv_ModeloA.Name = "dgv_ModeloA";
            this.dgv_ModeloA.RowHeadersVisible = false;
            this.dgv_ModeloA.Size = new System.Drawing.Size(1008, 411);
            this.dgv_ModeloA.TabIndex = 0;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1008, 62);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(497, 12);
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
            this.btn_Limpiar.Location = new System.Drawing.Point(800, 12);
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
            this.txt_cuenta_Bt.Location = new System.Drawing.Point(124, 17);
            this.txt_cuenta_Bt.Name = "txt_cuenta_Bt";
            this.txt_cuenta_Bt.Size = new System.Drawing.Size(274, 26);
            this.txt_cuenta_Bt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cuenta BT";
            // 
            // CuentaBT
            // 
            this.CuentaBT.DataPropertyName = "Cuenta_bt";
            this.CuentaBT.HeaderText = "BT";
            this.CuentaBT.Name = "CuentaBT";
            this.CuentaBT.Width = 54;
            // 
            // DoiCliente
            // 
            this.DoiCliente.DataPropertyName = "Doi_cliente";
            this.DoiCliente.HeaderText = "DNI";
            this.DoiCliente.Name = "DoiCliente";
            this.DoiCliente.Width = 62;
            // 
            // NombreCliente
            // 
            this.NombreCliente.DataPropertyName = "Nombre_cliente";
            this.NombreCliente.HeaderText = "Cliente";
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.Width = 83;
            // 
            // Demandados
            // 
            this.Demandados.DataPropertyName = "Demandado";
            this.Demandados.HeaderText = "Demandados";
            this.Demandados.Name = "Demandados";
            this.Demandados.Width = 130;
            // 
            // Cartera
            // 
            this.Cartera.DataPropertyName = "NombreCartera";
            this.Cartera.HeaderText = "Cartera";
            this.Cartera.Name = "Cartera";
            this.Cartera.Width = 87;
            // 
            // Modelo
            // 
            this.Modelo.DataPropertyName = "NombreModelo";
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.Width = 86;
            // 
            // SECTORISTA
            // 
            this.SECTORISTA.DataPropertyName = "Sectorista";
            this.SECTORISTA.HeaderText = "SECTORISTA";
            this.SECTORISTA.Name = "SECTORISTA";
            this.SECTORISTA.Width = 136;
            // 
            // Estudio
            // 
            this.Estudio.DataPropertyName = "NombreEstudio";
            this.Estudio.HeaderText = "Estudio";
            this.Estudio.Name = "Estudio";
            this.Estudio.Width = 88;
            // 
            // Region
            // 
            this.Region.DataPropertyName = "Region";
            this.Region.HeaderText = "Region";
            this.Region.Name = "Region";
            this.Region.Width = 85;
            // 
            // Ciudad
            // 
            this.Ciudad.DataPropertyName = "Agencia";
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.Width = 84;
            // 
            // TipoProceso
            // 
            this.TipoProceso.DataPropertyName = "NombreProceso";
            this.TipoProceso.HeaderText = "Tipo de Proceso";
            this.TipoProceso.Name = "TipoProceso";
            this.TipoProceso.Width = 135;
            // 
            // Juzgado
            // 
            this.Juzgado.DataPropertyName = "Juzgado";
            this.Juzgado.HeaderText = "Juzgado";
            this.Juzgado.Name = "Juzgado";
            this.Juzgado.Width = 95;
            // 
            // Expediente
            // 
            this.Expediente.DataPropertyName = "NumExpediente";
            this.Expediente.HeaderText = "Expediente";
            this.Expediente.Name = "Expediente";
            this.Expediente.Width = 114;
            // 
            // Operacion
            // 
            this.Operacion.DataPropertyName = "Operacion";
            this.Operacion.HeaderText = "OPERACIÓN";
            this.Operacion.Name = "Operacion";
            this.Operacion.Width = 129;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "NombreMoneda";
            this.Moneda.HeaderText = "(US$ o S/.)";
            this.Moneda.Name = "Moneda";
            this.Moneda.Width = 81;
            // 
            // MontoAdmitido
            // 
            this.MontoAdmitido.DataPropertyName = "MontoAdmitido";
            this.MontoAdmitido.HeaderText = "Monto Admitido";
            this.MontoAdmitido.Name = "MontoAdmitido";
            this.MontoAdmitido.Width = 132;
            // 
            // ResumenProceso
            // 
            this.ResumenProceso.DataPropertyName = "ResumenProceso";
            this.ResumenProceso.HeaderText = "Resumen del Proceso";
            this.ResumenProceso.Name = "ResumenProceso";
            this.ResumenProceso.Width = 121;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "DescripcionBien";
            this.Direccion.HeaderText = "Direccion Bien";
            this.Direccion.Name = "Direccion";
            this.Direccion.Width = 124;
            // 
            // Distrito
            // 
            this.Distrito.DataPropertyName = "NombreDistrito";
            this.Distrito.HeaderText = "Distrito Bien";
            this.Distrito.Name = "Distrito";
            this.Distrito.Width = 110;
            // 
            // CiudadBien
            // 
            this.CiudadBien.DataPropertyName = "NombreCiudad";
            this.CiudadBien.HeaderText = "Ciudad Bien";
            this.CiudadBien.Name = "CiudadBien";
            this.CiudadBien.Width = 110;
            // 
            // Moneda2
            // 
            this.Moneda2.DataPropertyName = "NombreMonedaBien";
            this.Moneda2.HeaderText = "Moneda Bien";
            this.Moneda2.Name = "Moneda2";
            this.Moneda2.Width = 117;
            // 
            // MontoGarantia
            // 
            this.MontoGarantia.DataPropertyName = "MontoGarantia";
            this.MontoGarantia.HeaderText = "Monto Garantia";
            this.MontoGarantia.Name = "MontoGarantia";
            this.MontoGarantia.Width = 132;
            // 
            // ValorComercial
            // 
            this.ValorComercial.DataPropertyName = "ValorComercial";
            this.ValorComercial.HeaderText = "Valor Comercial";
            this.ValorComercial.Name = "ValorComercial";
            this.ValorComercial.Width = 132;
            // 
            // ValorRealizacion
            // 
            this.ValorRealizacion.DataPropertyName = "MontoTasacion";
            this.ValorRealizacion.HeaderText = "Valor de Realizacion";
            this.ValorRealizacion.Name = "ValorRealizacion";
            this.ValorRealizacion.Width = 163;
            // 
            // FechaMedidaCautelar
            // 
            this.FechaMedidaCautelar.DataPropertyName = "FechaMCString";
            this.FechaMedidaCautelar.HeaderText = "Fecha de Medida Cautelar";
            this.FechaMedidaCautelar.Name = "FechaMedidaCautelar";
            this.FechaMedidaCautelar.Width = 201;
            // 
            // FechaDemanda
            // 
            this.FechaDemanda.DataPropertyName = "FechaDemandaString";
            this.FechaDemanda.HeaderText = "Fecha Demanda";
            this.FechaDemanda.Name = "FechaDemanda";
            this.FechaDemanda.Width = 140;
            // 
            // FechaMandatoEjecucion
            // 
            this.FechaMandatoEjecucion.DataPropertyName = "FechaMandatoString";
            this.FechaMandatoEjecucion.HeaderText = "Fecha de Mandato de Ejecucion";
            this.FechaMandatoEjecucion.Name = "FechaMandatoEjecucion";
            this.FechaMandatoEjecucion.Width = 177;
            // 
            // FechaContradiccion
            // 
            this.FechaContradiccion.DataPropertyName = "FechaContradiccionString";
            this.FechaContradiccion.HeaderText = "Fecha de Contradiccion y/o Apelacion";
            this.FechaContradiccion.Name = "FechaContradiccion";
            this.FechaContradiccion.Width = 209;
            // 
            // FechaOrdenRemate
            // 
            this.FechaOrdenRemate.DataPropertyName = "FechaOrdenString";
            this.FechaOrdenRemate.HeaderText = "Fecha Orden de Remate";
            this.FechaOrdenRemate.Name = "FechaOrdenRemate";
            this.FechaOrdenRemate.Width = 140;
            // 
            // FechaRemate
            // 
            this.FechaRemate.DataPropertyName = "FechaRemateCapturaString";
            this.FechaRemate.HeaderText = "Fecha de Remate";
            this.FechaRemate.Name = "FechaRemate";
            this.FechaRemate.Width = 148;
            // 
            // FechaAdjudicacion
            // 
            this.FechaAdjudicacion.DataPropertyName = "FechaAdjucapturaString";
            this.FechaAdjudicacion.HeaderText = "Fecha de Adjudicacion";
            this.FechaAdjudicacion.Name = "FechaAdjudicacion";
            this.FechaAdjudicacion.Width = 177;
            // 
            // EstadoProcesal
            // 
            this.EstadoProcesal.DataPropertyName = "EstadoProcesal";
            this.EstadoProcesal.HeaderText = "Ultimo Estado Procesal";
            this.EstadoProcesal.Name = "EstadoProcesal";
            this.EstadoProcesal.Width = 181;
            // 
            // FechaEstadoProcesal
            // 
            this.FechaEstadoProcesal.DataPropertyName = "FechaEstadoProcesalString";
            this.FechaEstadoProcesal.HeaderText = "Fecha Ulimo Estado Procesal";
            this.FechaEstadoProcesal.Name = "FechaEstadoProcesal";
            this.FechaEstadoProcesal.Width = 166;
            // 
            // TareaJudicial
            // 
            this.TareaJudicial.DataPropertyName = "TareaJudicial";
            this.TareaJudicial.HeaderText = "Ultima Tarea Judicial";
            this.TareaJudicial.Name = "TareaJudicial";
            this.TareaJudicial.Width = 164;
            // 
            // FR_ModeloA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1014, 485);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_ModeloA";
            this.Text = "Reporte SCI Modelo A";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ModeloA)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.DataGridView dgv_ModeloA;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.TextBox txt_cuenta_Bt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoiCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demandados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cartera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECTORISTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estudio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Region;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Juzgado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAdmitido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResumenProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadBien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoGarantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorComercial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorRealizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaMedidaCautelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDemanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaMandatoEjecucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaContradiccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaOrdenRemate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRemate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAdjudicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoProcesal;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEstadoProcesal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TareaJudicial;
    }
}