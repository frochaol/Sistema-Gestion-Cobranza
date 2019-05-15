namespace Ceriv.Formularios
{
    partial class FR_CreditosEliminados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FR_CreditosEliminados));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_CreditosEliminados = new System.Windows.Forms.DataGridView();
            this.CUENTABT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAELIMNADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRETITULAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Exportar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_CuentaBT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CreditosEliminados)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_CreditosEliminados, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.36228F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.63772F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 403);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_CreditosEliminados
            // 
            this.dgv_CreditosEliminados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_CreditosEliminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CreditosEliminados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CUENTABT,
            this.FECHAELIMNADO,
            this.NOMBRETITULAR});
            this.dgv_CreditosEliminados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_CreditosEliminados.Location = new System.Drawing.Point(3, 76);
            this.dgv_CreditosEliminados.Name = "dgv_CreditosEliminados";
            this.dgv_CreditosEliminados.ReadOnly = true;
            this.dgv_CreditosEliminados.RowHeadersVisible = false;
            this.dgv_CreditosEliminados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CreditosEliminados.Size = new System.Drawing.Size(843, 324);
            this.dgv_CreditosEliminados.TabIndex = 0;
            // 
            // CUENTABT
            // 
            this.CUENTABT.DataPropertyName = "CuentaBT";
            this.CUENTABT.HeaderText = "Cuenta BT";
            this.CUENTABT.Name = "CUENTABT";
            this.CUENTABT.ReadOnly = true;
            // 
            // FECHAELIMNADO
            // 
            this.FECHAELIMNADO.DataPropertyName = "FechaTramite";
            this.FECHAELIMNADO.HeaderText = "Fecha de Eliminacion";
            this.FECHAELIMNADO.Name = "FECHAELIMNADO";
            this.FECHAELIMNADO.ReadOnly = true;
            // 
            // NOMBRETITULAR
            // 
            this.NOMBRETITULAR.DataPropertyName = "NombreCompleto";
            this.NOMBRETITULAR.HeaderText = "Nombre Titular";
            this.NOMBRETITULAR.Name = "NOMBRETITULAR";
            this.NOMBRETITULAR.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.64176F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.21589F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Limpiar, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Exportar, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Buscar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_CuentaBT, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(843, 67);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Limpiar.Location = new System.Drawing.Point(697, 15);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(121, 36);
            this.btn_Limpiar.TabIndex = 0;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Exportar
            // 
            this.btn_Exportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Exportar.Location = new System.Drawing.Point(527, 15);
            this.btn_Exportar.Name = "btn_Exportar";
            this.btn_Exportar.Size = new System.Drawing.Size(121, 36);
            this.btn_Exportar.TabIndex = 1;
            this.btn_Exportar.Text = "Exportar";
            this.btn_Exportar.UseVisualStyleBackColor = true;
            this.btn_Exportar.Click += new System.EventHandler(this.btn_Exportar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Buscar.Location = new System.Drawing.Point(339, 15);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(121, 36);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Visible = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_CuentaBT
            // 
            this.txt_CuentaBT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_CuentaBT.Location = new System.Drawing.Point(118, 20);
            this.txt_CuentaBT.Name = "txt_CuentaBT";
            this.txt_CuentaBT.Size = new System.Drawing.Size(215, 26);
            this.txt_CuentaBT.TabIndex = 3;
            this.txt_CuentaBT.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cuenta BT :";
            this.label1.Visible = false;
            // 
            // FR_CreditosEliminados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 403);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FR_CreditosEliminados";
            this.Text = "Reporte Creditos Eliminados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CreditosEliminados)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_CreditosEliminados;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Exportar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_CuentaBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUENTABT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAELIMNADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRETITULAR;
    }
}