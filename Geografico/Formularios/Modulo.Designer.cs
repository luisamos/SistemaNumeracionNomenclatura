namespace Formularios
{
    partial class Modulo
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
            this.cancelar_btn = new System.Windows.Forms.Button();
            this.aceptar_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.capa_cbo = new System.Windows.Forms.ComboBox();
            this.tipo_cbo = new System.Windows.Forms.ComboBox();
            this.material_cbo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // mensaje_lbl
            // 
            this.mensaje_lbl.BackColor = System.Drawing.Color.Black;
            this.mensaje_lbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje_lbl.ForeColor = System.Drawing.Color.White;
            this.mensaje_lbl.Location = new System.Drawing.Point(3, 5);
            this.mensaje_lbl.Name = "mensaje_lbl";
            this.mensaje_lbl.Size = new System.Drawing.Size(392, 23);
            this.mensaje_lbl.TabIndex = 8;
            this.mensaje_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cancelar_btn
            // 
            this.cancelar_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelar_btn.Location = new System.Drawing.Point(309, 123);
            this.cancelar_btn.Name = "cancelar_btn";
            this.cancelar_btn.Size = new System.Drawing.Size(87, 21);
            this.cancelar_btn.TabIndex = 10;
            this.cancelar_btn.Text = "&Cancelar";
            this.cancelar_btn.UseVisualStyleBackColor = true;
            this.cancelar_btn.Click += new System.EventHandler(this.cancelar_btn_Click);
            // 
            // aceptar_btn
            // 
            this.aceptar_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar_btn.Location = new System.Drawing.Point(216, 123);
            this.aceptar_btn.Name = "aceptar_btn";
            this.aceptar_btn.Size = new System.Drawing.Size(87, 21);
            this.aceptar_btn.TabIndex = 9;
            this.aceptar_btn.Text = "&Aceptar";
            this.aceptar_btn.UseVisualStyleBackColor = true;
            this.aceptar_btn.Click += new System.EventHandler(this.aceptar_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 65);
            this.label2.TabIndex = 11;
            this.label2.Text = "Capa:\r\n\r\nTipo:\r\n\r\nMaterial:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // capa_cbo
            // 
            this.capa_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.capa_cbo.FormattingEnabled = true;
            this.capa_cbo.Location = new System.Drawing.Point(63, 35);
            this.capa_cbo.Name = "capa_cbo";
            this.capa_cbo.Size = new System.Drawing.Size(323, 21);
            this.capa_cbo.TabIndex = 12;
            // 
            // tipo_cbo
            // 
            this.tipo_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo_cbo.FormattingEnabled = true;
            this.tipo_cbo.Location = new System.Drawing.Point(63, 61);
            this.tipo_cbo.Name = "tipo_cbo";
            this.tipo_cbo.Size = new System.Drawing.Size(323, 21);
            this.tipo_cbo.TabIndex = 13;
            // 
            // material_cbo
            // 
            this.material_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.material_cbo.FormattingEnabled = true;
            this.material_cbo.Location = new System.Drawing.Point(63, 87);
            this.material_cbo.Name = "material_cbo";
            this.material_cbo.Size = new System.Drawing.Size(240, 21);
            this.material_cbo.TabIndex = 14;
            // 
            // Modulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 151);
            this.Controls.Add(this.cancelar_btn);
            this.Controls.Add(this.aceptar_btn);
            this.Controls.Add(this.material_cbo);
            this.Controls.Add(this.tipo_cbo);
            this.Controls.Add(this.capa_cbo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mensaje_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Modulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.modulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label mensaje_lbl;
        private System.Windows.Forms.Button cancelar_btn;
        private System.Windows.Forms.Button aceptar_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox capa_cbo;
        private System.Windows.Forms.ComboBox tipo_cbo;
        private System.Windows.Forms.ComboBox material_cbo;
    }
}