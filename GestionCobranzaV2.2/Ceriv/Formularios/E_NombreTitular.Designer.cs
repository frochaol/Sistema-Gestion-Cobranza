namespace Ceriv.Formularios
{
    partial class E_NombreTitular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(E_NombreTitular));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.cmb_NombrePersona = new System.Windows.Forms.ComboBox();
            this.dgv_NombreTitular = new System.Windows.Forms.DataGridView();
            this.cuenta_bt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOICLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRECLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NombreTitular)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_NombreTitular, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.14815F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.85185F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1145, 266);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.SlateGray;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.87456F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.39625F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.61196F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Buscar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmb_NombrePersona, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1137, 53);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Cliente :";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Buscar.Location = new System.Drawing.Point(917, 8);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(135, 36);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Cargar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // cmb_NombrePersona
            // 
            this.cmb_NombrePersona.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmb_NombrePersona.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_NombrePersona.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_NombrePersona.FormattingEnabled = true;
            this.cmb_NombrePersona.Location = new System.Drawing.Point(218, 14);
            this.cmb_NombrePersona.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_NombrePersona.Name = "cmb_NombrePersona";
            this.cmb_NombrePersona.Size = new System.Drawing.Size(500, 33);
            this.cmb_NombrePersona.TabIndex = 0;
            this.cmb_NombrePersona.SelectedIndexChanged += new System.EventHandler(this.cmb_NombrePersona_SelectedIndexChanged);
            // 
            // dgv_NombreTitular
            // 
            this.dgv_NombreTitular.AllowUserToAddRows = false;
            this.dgv_NombreTitular.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_NombreTitular.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgv_NombreTitular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NombreTitular.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cuenta_bt,
            this.DOICLIENTE,
            this.NOMBRECLIENTE});
            this.dgv_NombreTitular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_NombreTitular.Location = new System.Drawing.Point(4, 65);
            this.dgv_NombreTitular.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_NombreTitular.Name = "dgv_NombreTitular";
            this.dgv_NombreTitular.ReadOnly = true;
            this.dgv_NombreTitular.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_NombreTitular.Size = new System.Drawing.Size(1137, 197);
            this.dgv_NombreTitular.TabIndex = 1;
            this.dgv_NombreTitular.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_NombreTitular_CellDoubleClick);
            // 
            // cuenta_bt
            // 
            this.cuenta_bt.DataPropertyName = "Cuenta_bt";
            this.cuenta_bt.HeaderText = "CuentaBT";
            this.cuenta_bt.Name = "cuenta_bt";
            this.cuenta_bt.ReadOnly = true;
            // 
            // DOICLIENTE
            // 
            this.DOICLIENTE.DataPropertyName = "Doi_cliente";
            this.DOICLIENTE.HeaderText = "DOI CLIENTE";
            this.DOICLIENTE.Name = "DOICLIENTE";
            this.DOICLIENTE.ReadOnly = true;
            // 
            // NOMBRECLIENTE
            // 
            this.NOMBRECLIENTE.DataPropertyName = "NombreCompleto";
            this.NOMBRECLIENTE.HeaderText = "NOMBRE CLIENTE";
            this.NOMBRECLIENTE.Name = "NOMBRECLIENTE";
            this.NOMBRECLIENTE.ReadOnly = true;
            // 
            // E_NombreTitular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "E_NombreTitular";
            this.Text = "Buscar Nombre Titular";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.E_NombreTitular_FormClosed);
            this.Load += new System.EventHandler(this.E_NombreTitular_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NombreTitular)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cmb_NombrePersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_NombreTitular;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuenta_bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOICLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRECLIENTE;
    }
}