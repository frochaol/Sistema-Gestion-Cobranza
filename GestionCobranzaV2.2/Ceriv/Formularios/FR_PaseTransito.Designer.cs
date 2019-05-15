namespace Ceriv.Formularios
{
    partial class FR_PaseTransito
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_PaseTransito));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_PaseAtransito = new System.Windows.Forms.DataGridView();
            this.NOMBRECLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUENTABT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMCAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESPONSABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaTramiteString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUENTABT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARTERA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHATRAMITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_cuentaBt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaseAtransito)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_PaseAtransito, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.60298F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.39703F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 403);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_PaseAtransito
            // 
            this.dgv_PaseAtransito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PaseAtransito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_PaseAtransito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PaseAtransito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOMBRECLIENTE,
            this.CUENTABT1,
            this.NUMCAJA,
            this.RESPONSABLE,
            this.FechaTramiteString,
            this.OBSERVACION,
            this.CUENTABT2,
            this.CARTERA,
            this.FECHATRAMITE});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PaseAtransito.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PaseAtransito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PaseAtransito.Location = new System.Drawing.Point(3, 81);
            this.dgv_PaseAtransito.Name = "dgv_PaseAtransito";
            this.dgv_PaseAtransito.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PaseAtransito.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_PaseAtransito.RowHeadersVisible = false;
            this.dgv_PaseAtransito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PaseAtransito.Size = new System.Drawing.Size(877, 319);
            this.dgv_PaseAtransito.TabIndex = 2;
            // 
            // NOMBRECLIENTE
            // 
            this.NOMBRECLIENTE.DataPropertyName = "NombreCliente";
            this.NOMBRECLIENTE.HeaderText = "Nombre Titular";
            this.NOMBRECLIENTE.Name = "NOMBRECLIENTE";
            this.NOMBRECLIENTE.ReadOnly = true;
            // 
            // CUENTABT1
            // 
            this.CUENTABT1.DataPropertyName = "CuentaBT";
            this.CUENTABT1.HeaderText = "Cuenta BT";
            this.CUENTABT1.Name = "CUENTABT1";
            this.CUENTABT1.ReadOnly = true;
            // 
            // NUMCAJA
            // 
            this.NUMCAJA.DataPropertyName = "NumCaja";
            this.NUMCAJA.HeaderText = "Num de Caja";
            this.NUMCAJA.Name = "NUMCAJA";
            this.NUMCAJA.ReadOnly = true;
            // 
            // RESPONSABLE
            // 
            this.RESPONSABLE.DataPropertyName = "NombreRes";
            this.RESPONSABLE.HeaderText = "Nombre Responsable";
            this.RESPONSABLE.Name = "RESPONSABLE";
            this.RESPONSABLE.ReadOnly = true;
            // 
            // FechaTramiteString
            // 
            this.FechaTramiteString.DataPropertyName = "FechaTramiteString";
            this.FechaTramiteString.HeaderText = "Fecha Tramite";
            this.FechaTramiteString.Name = "FechaTramiteString";
            this.FechaTramiteString.ReadOnly = true;
            // 
            // OBSERVACION
            // 
            this.OBSERVACION.DataPropertyName = "Observacion";
            this.OBSERVACION.HeaderText = "Observacion Motivo Archivo";
            this.OBSERVACION.Name = "OBSERVACION";
            this.OBSERVACION.ReadOnly = true;
            // 
            // CUENTABT2
            // 
            this.CUENTABT2.DataPropertyName = "Cuentabt2";
            this.CUENTABT2.HeaderText = "Cuenta BT";
            this.CUENTABT2.Name = "CUENTABT2";
            this.CUENTABT2.ReadOnly = true;
            // 
            // CARTERA
            // 
            this.CARTERA.DataPropertyName = "NombreCartera";
            this.CARTERA.HeaderText = "Cartera";
            this.CARTERA.Name = "CARTERA";
            this.CARTERA.ReadOnly = true;
            // 
            // FECHATRAMITE
            // 
            this.FECHATRAMITE.DataPropertyName = "FechaTramite";
            this.FECHATRAMITE.HeaderText = "Fecha Tramite/Cambio";
            this.FECHATRAMITE.Name = "FECHATRAMITE";
            this.FECHATRAMITE.ReadOnly = true;
            this.FECHATRAMITE.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.77081F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.13797F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Limpiar, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Buscar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_cuentaBt, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(877, 72);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Limpiar.Location = new System.Drawing.Point(722, 16);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(132, 39);
            this.btn_Limpiar.TabIndex = 0;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(546, 16);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(132, 39);
            this.btn_Exportar.TabIndex = 1;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Buscar.Location = new System.Drawing.Point(353, 16);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(132, 39);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_cuentaBt
            // 
            this.txt_cuentaBt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_cuentaBt.Enabled = false;
            this.txt_cuentaBt.Location = new System.Drawing.Point(115, 23);
            this.txt_cuentaBt.Name = "txt_cuentaBt";
            this.txt_cuentaBt.Size = new System.Drawing.Size(232, 26);
            this.txt_cuentaBt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cuenta BT :";
            // 
            // FR_PaseTransito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 403);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FR_PaseTransito";
            this.Text = "Reporte Pase a Transito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PaseAtransito)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_PaseAtransito;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_cuentaBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRECLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUENTABT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMCAJA;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESPONSABLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaTramiteString;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUENTABT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARTERA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHATRAMITE;
    }
}