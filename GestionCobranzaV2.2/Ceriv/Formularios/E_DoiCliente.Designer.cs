namespace Ceriv.Formularios
{
    partial class E_DoiCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(E_DoiCliente));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_ExpedienteCliente = new System.Windows.Forms.DataGridView();
            this.CuentaBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOI_CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExpedienteCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_ExpedienteCliente, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(859, 175);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_ExpedienteCliente
            // 
            this.dgv_ExpedienteCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ExpedienteCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExpedienteCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CuentaBT,
            this.DOI_CLIENTE,
            this.NombreCompleto});
            this.dgv_ExpedienteCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ExpedienteCliente.Location = new System.Drawing.Point(3, 3);
            this.dgv_ExpedienteCliente.Name = "dgv_ExpedienteCliente";
            this.dgv_ExpedienteCliente.ReadOnly = true;
            this.dgv_ExpedienteCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ExpedienteCliente.Size = new System.Drawing.Size(853, 169);
            this.dgv_ExpedienteCliente.TabIndex = 0;
            this.dgv_ExpedienteCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ExpedienteCliente_CellClick);
            this.dgv_ExpedienteCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ExpedienteCliente_CellContentClick_1);
            // 
            // CuentaBT
            // 
            this.CuentaBT.DataPropertyName = "CuentaBT";
            this.CuentaBT.HeaderText = "Cuenta BT";
            this.CuentaBT.Name = "CuentaBT";
            this.CuentaBT.ReadOnly = true;
            // 
            // DOI_CLIENTE
            // 
            this.DOI_CLIENTE.DataPropertyName = "DoiCliente";
            this.DOI_CLIENTE.HeaderText = "DOI Cliente";
            this.DOI_CLIENTE.Name = "DOI_CLIENTE";
            this.DOI_CLIENTE.ReadOnly = true;
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.DataPropertyName = "NombreCompleto";
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            // 
            // E_DoiCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 175);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "E_DoiCliente";
            this.Text = "Cuentas por Cliente";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExpedienteCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_ExpedienteCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOI_CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
    }
}