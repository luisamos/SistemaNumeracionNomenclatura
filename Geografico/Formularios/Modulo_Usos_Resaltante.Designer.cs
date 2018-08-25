namespace Formularios
{
    partial class Modulo_Usos_Resaltantes
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
            this.mensaje_lbl = new System.Windows.Forms.Label();
            this.aceptar_btn = new System.Windows.Forms.Button();
            this.capa_cbo = new System.Windows.Forms.ComboBox();
            this.cancelar_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mensaje_lbl
            // 
            this.mensaje_lbl.BackColor = System.Drawing.Color.Black;
            this.mensaje_lbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje_lbl.ForeColor = System.Drawing.Color.White;
            this.mensaje_lbl.Location = new System.Drawing.Point(12, 9);
            this.mensaje_lbl.Name = "mensaje_lbl";
            this.mensaje_lbl.Size = new System.Drawing.Size(392, 23);
            this.mensaje_lbl.TabIndex = 0;
            this.mensaje_lbl.Text = "Seleccionar:";
            this.mensaje_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aceptar_btn
            // 
            this.aceptar_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar_btn.Location = new System.Drawing.Point(123, 62);
            this.aceptar_btn.Name = "aceptar_btn";
            this.aceptar_btn.Size = new System.Drawing.Size(87, 21);
            this.aceptar_btn.TabIndex = 3;
            this.aceptar_btn.Text = "&Aceptar";
            this.aceptar_btn.UseVisualStyleBackColor = true;
            this.aceptar_btn.Click += new System.EventHandler(this.aceptar_btn_Click);
            // 
            // capa_cbo
            // 
            this.capa_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.capa_cbo.FormattingEnabled = true;
            this.capa_cbo.Location = new System.Drawing.Point(81, 35);
            this.capa_cbo.Name = "capa_cbo";
            this.capa_cbo.Size = new System.Drawing.Size(323, 21);
            this.capa_cbo.TabIndex = 2;
            // 
            // cancelar_btn
            // 
            this.cancelar_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelar_btn.Location = new System.Drawing.Point(241, 62);
            this.cancelar_btn.Name = "cancelar_btn";
            this.cancelar_btn.Size = new System.Drawing.Size(87, 21);
            this.cancelar_btn.TabIndex = 4;
            this.cancelar_btn.Text = "&Cancelar";
            this.cancelar_btn.UseVisualStyleBackColor = true;
            this.cancelar_btn.Click += new System.EventHandler(this.cancelar_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Capa:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Modulo_Usos_Resaltantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 88);
            this.Controls.Add(this.cancelar_btn);
            this.Controls.Add(this.aceptar_btn);
            this.Controls.Add(this.capa_cbo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mensaje_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Modulo_Usos_Resaltantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulo Usos Resaltantes";
            this.Load += new System.EventHandler(this.modulo_usos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label mensaje_lbl;
        private System.Windows.Forms.Button aceptar_btn;
        private System.Windows.Forms.ComboBox capa_cbo;
        private System.Windows.Forms.Button cancelar_btn;
        private System.Windows.Forms.Label label2;
    }
}