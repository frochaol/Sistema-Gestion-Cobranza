namespace Ceriv.Formularios
{
    partial class Principal
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Alerta = new System.Windows.Forms.DataGridView();
            this.numeroexpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoprocesal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaestadoprocesal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareaJudicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareaJudicialCumplida = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechatareaadminitrativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TareaAdministrativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tareaAdministrativaCumplida = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Guardar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Expediente = new System.Windows.Forms.TextBox();
            this.btn_detalle = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Alerta)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_Alerta, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.834101F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.912442F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.96774F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.74654F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(859, 434);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_Alerta
            // 
            this.dgv_Alerta.AllowUserToAddRows = false;
            this.dgv_Alerta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Alerta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Alerta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroexpediente,
            this.estadoprocesal,
            this.fechaestadoprocesal,
            this.tareaJudicial,
            this.tareaJudicialCumplida,
            this.fechatareaadminitrativa,
            this.TareaAdministrativa,
            this.tareaAdministrativaCumplida,
            this.Guardar});
            this.dgv_Alerta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Alerta.Location = new System.Drawing.Point(4, 154);
            this.dgv_Alerta.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgv_Alerta.Name = "dgv_Alerta";
            this.dgv_Alerta.Size = new System.Drawing.Size(851, 278);
            this.dgv_Alerta.TabIndex = 5;
            // 
            // numeroexpediente
            // 
            this.numeroexpediente.DataPropertyName = "NumeroExpediente";
            this.numeroexpediente.FillWeight = 92.09391F;
            this.numeroexpediente.HeaderText = "Expediente";
            this.numeroexpediente.Name = "numeroexpediente";
            this.numeroexpediente.ReadOnly = true;
            // 
            // estadoprocesal
            // 
            this.estadoprocesal.DataPropertyName = "NombreEstadoProcesal";
            this.estadoprocesal.FillWeight = 92.09391F;
            this.estadoprocesal.HeaderText = "Estado Procesal";
            this.estadoprocesal.Name = "estadoprocesal";
            this.estadoprocesal.ReadOnly = true;
            this.estadoprocesal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // fechaestadoprocesal
            // 
            this.fechaestadoprocesal.DataPropertyName = "FechaEstadoProcesal";
            this.fechaestadoprocesal.FillWeight = 92.09391F;
            this.fechaestadoprocesal.HeaderText = "Fecha Estado Procesal";
            this.fechaestadoprocesal.Name = "fechaestadoprocesal";
            this.fechaestadoprocesal.ReadOnly = true;
            // 
            // tareaJudicial
            // 
            this.tareaJudicial.DataPropertyName = "TareaJudicial";
            this.tareaJudicial.FillWeight = 92.09391F;
            this.tareaJudicial.HeaderText = "Tarea Judicial";
            this.tareaJudicial.Name = "tareaJudicial";
            this.tareaJudicial.ReadOnly = true;
            // 
            // tareaJudicialCumplida
            // 
            this.tareaJudicialCumplida.FillWeight = 25F;
            this.tareaJudicialCumplida.HeaderText = "Tarea";
            this.tareaJudicialCumplida.Name = "tareaJudicialCumplida";
            this.tareaJudicialCumplida.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // fechatareaadminitrativa
            // 
            this.fechatareaadminitrativa.DataPropertyName = "FechaTareaAdministrativa";
            this.fechatareaadminitrativa.FillWeight = 92.09391F;
            this.fechatareaadminitrativa.HeaderText = "Fecha Tarea Adminitrativa";
            this.fechatareaadminitrativa.Name = "fechatareaadminitrativa";
            this.fechatareaadminitrativa.ReadOnly = true;
            // 
            // TareaAdministrativa
            // 
            this.TareaAdministrativa.DataPropertyName = "TareaAdministrativa";
            this.TareaAdministrativa.FillWeight = 92.09391F;
            this.TareaAdministrativa.HeaderText = "Tarea Administrativa";
            this.TareaAdministrativa.Name = "TareaAdministrativa";
            this.TareaAdministrativa.ReadOnly = true;
            // 
            // tareaAdministrativaCumplida
            // 
            this.tareaAdministrativaCumplida.FillWeight = 25F;
            this.tareaAdministrativaCumplida.HeaderText = "Tarea";
            this.tareaAdministrativaCumplida.Name = "tareaAdministrativaCumplida";
            this.tareaAdministrativaCumplida.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Guardar
            // 
            this.Guardar.FillWeight = 35F;
            this.Guardar.HeaderText = "Guardar";
            this.Guardar.Name = "Guardar";
            this.Guardar.Text = "Guardar";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maestrosToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.resumenToolStripMenuItem,
            this.resumenToolStripMenuItem1,
            this.permisosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(859, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // maestrosToolStripMenuItem
            // 
            this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            this.maestrosToolStripMenuItem.Size = new System.Drawing.Size(88, 25);
            this.maestrosToolStripMenuItem.Text = "Usuarios";
            this.maestrosToolStripMenuItem.Click += new System.EventHandler(this.maestrosToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(153, 25);
            this.operacionesToolStripMenuItem.Text = "Crear y Modificar";
            this.operacionesToolStripMenuItem.Click += new System.EventHandler(this.operacionesToolStripMenuItem_Click);
            // 
            // resumenToolStripMenuItem
            // 
            this.resumenToolStripMenuItem.Name = "resumenToolStripMenuItem";
            this.resumenToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.resumenToolStripMenuItem.Text = "Eliminar";
            this.resumenToolStripMenuItem.Click += new System.EventHandler(this.resumenToolStripMenuItem_Click);
            // 
            // resumenToolStripMenuItem1
            // 
            this.resumenToolStripMenuItem1.Name = "resumenToolStripMenuItem1";
            this.resumenToolStripMenuItem1.Size = new System.Drawing.Size(92, 25);
            this.resumenToolStripMenuItem1.Text = "Resumen";
            this.resumenToolStripMenuItem1.Click += new System.EventHandler(this.resumenToolStripMenuItem1_Click);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(91, 25);
            this.permisosToolStripMenuItem.Text = "Permisos";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(851, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "ALERTAS";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.86052F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.86052F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.86052F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.483943F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.583831F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.75149F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.59918F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.Txt_Expediente, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_detalle, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.button1, 7, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(853, 84);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Expediente:";
            // 
            // Txt_Expediente
            // 
            this.Txt_Expediente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Expediente.Location = new System.Drawing.Point(159, 29);
            this.Txt_Expediente.Name = "Txt_Expediente";
            this.Txt_Expediente.Size = new System.Drawing.Size(96, 26);
            this.Txt_Expediente.TabIndex = 6;
            // 
            // btn_detalle
            // 
            this.btn_detalle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_detalle.Location = new System.Drawing.Point(261, 26);
            this.btn_detalle.Name = "btn_detalle";
            this.btn_detalle.Size = new System.Drawing.Size(96, 31);
            this.btn_detalle.TabIndex = 7;
            this.btn_detalle.Text = "Ver Detalle";
            this.btn_detalle.UseVisualStyleBackColor = true;
            this.btn_detalle.Click += new System.EventHandler(this.btn_detalle_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Estado Procesal",
            "Fecha estado procesal",
            "fecha tarea administrativa"});
            this.comboBox1.Location = new System.Drawing.Point(466, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 28);
            this.comboBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(671, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ordenar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 434);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Alerta)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_Alerta;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maestrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Expediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroexpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoprocesal;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaestadoprocesal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareaJudicial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tareaJudicialCumplida;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechatareaadminitrativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TareaAdministrativa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tareaAdministrativaCumplida;
        private System.Windows.Forms.DataGridViewButtonColumn Guardar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_detalle;


    }
}