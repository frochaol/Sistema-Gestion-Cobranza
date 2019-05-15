namespace Ceriv.Formularios
{
    partial class SeleccionEstudio
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
            this.rdb_Ceriv = new System.Windows.Forms.RadioButton();
            this.rdb_peru = new System.Windows.Forms.RadioButton();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdb_Ceriv
            // 
            this.rdb_Ceriv.AutoSize = true;
            this.rdb_Ceriv.Location = new System.Drawing.Point(12, 12);
            this.rdb_Ceriv.Name = "rdb_Ceriv";
            this.rdb_Ceriv.Size = new System.Drawing.Size(71, 28);
            this.rdb_Ceriv.TabIndex = 0;
            this.rdb_Ceriv.TabStop = true;
            this.rdb_Ceriv.Text = "Ceriv";
            this.rdb_Ceriv.UseVisualStyleBackColor = true;
            // 
            // rdb_peru
            // 
            this.rdb_peru.AutoSize = true;
            this.rdb_peru.Location = new System.Drawing.Point(13, 57);
            this.rdb_peru.Name = "rdb_peru";
            this.rdb_peru.Size = new System.Drawing.Size(157, 28);
            this.rdb_peru.TabIndex = 1;
            this.rdb_peru.TabStop = true;
            this.rdb_peru.Text = "Peru abogados";
            this.rdb_peru.UseVisualStyleBackColor = true;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(7, 110);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(181, 55);
            this.btn_aceptar.TabIndex = 2;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // SeleccionEstudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 177);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.rdb_peru);
            this.Controls.Add(this.rdb_Ceriv);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SeleccionEstudio";
            this.Text = "SeleccionEstudio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_Ceriv;
        private System.Windows.Forms.RadioButton rdb_peru;
        private System.Windows.Forms.Button btn_aceptar;

    }
}