namespace Formularios
{
    partial class Configuracion_Base_Datos
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
            this.contraseña_txt = new System.Windows.Forms.TextBox();
            this.usuario_txt = new System.Windows.Forms.TextBox();
            this.baseDatos_txt = new System.Windows.Forms.TextBox();
            this.servidor_txt = new System.Windows.Forms.TextBox();
            this.contraseña_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aceptar_btn = new System.Windows.Forms.Button();
            this.usuario_lbl = new System.Windows.Forms.Label();
            this.base_datos_lbl = new System.Windows.Forms.Label();
            this.servidor_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contraseña_txt
            // 
            this.contraseña_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseña_txt.Location = new System.Drawing.Point(107, 122);
            this.contraseña_txt.MaxLength = 50;
            this.contraseña_txt.Name = "contraseña_txt";
            this.contraseña_txt.PasswordChar = '*';
            this.contraseña_txt.Size = new System.Drawing.Size(205, 20);
            this.contraseña_txt.TabIndex = 18;
            // 
            // usuario_txt
            // 
            this.usuario_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuario_txt.Location = new System.Drawing.Point(107, 95);
            this.usuario_txt.MaxLength = 50;
            this.usuario_txt.Name = "usuario_txt";
            this.usuario_txt.PasswordChar = '*';
            this.usuario_txt.Size = new System.Drawing.Size(205, 20);
            this.usuario_txt.TabIndex = 16;
            // 
            // baseDatos_txt
            // 
            this.baseDatos_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseDatos_txt.Location = new System.Drawing.Point(107, 68);
            this.baseDatos_txt.MaxLength = 50;
            this.baseDatos_txt.Name = "baseDatos_txt";
            this.baseDatos_txt.PasswordChar = '*';
            this.baseDatos_txt.Size = new System.Drawing.Size(205, 20);
            this.baseDatos_txt.TabIndex = 14;
            // 
            // servidor_txt
            // 
            this.servidor_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.servidor_txt.Location = new System.Drawing.Point(107, 41);
            this.servidor_txt.MaxLength = 50;
            this.servidor_txt.Name = "servidor_txt";
            this.servidor_txt.PasswordChar = '*';
            this.servidor_txt.Size = new System.Drawing.Size(205, 20);
            this.servidor_txt.TabIndex = 12;
            // 
            // contraseña_lbl
            // 
            this.contraseña_lbl.BackColor = System.Drawing.Color.White;
            this.contraseña_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseña_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contraseña_lbl.Location = new System.Drawing.Point(11, 122);
            this.contraseña_lbl.Name = "contraseña_lbl";
            this.contraseña_lbl.Size = new System.Drawing.Size(90, 20);
            this.contraseña_lbl.TabIndex = 17;
            this.contraseña_lbl.Text = "Contraseña:";
            this.contraseña_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Configuración";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aceptar_btn
            // 
            this.aceptar_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar_btn.Location = new System.Drawing.Point(258, 148);
            this.aceptar_btn.Name = "aceptar_btn";
            this.aceptar_btn.Size = new System.Drawing.Size(68, 23);
            this.aceptar_btn.TabIndex = 19;
            this.aceptar_btn.Text = "&Aceptar";
            this.aceptar_btn.UseVisualStyleBackColor = true;
            this.aceptar_btn.Click += new System.EventHandler(this.aceptar_btn_Click);
            // 
            // usuario_lbl
            // 
            this.usuario_lbl.BackColor = System.Drawing.Color.White;
            this.usuario_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuario_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario_lbl.Location = new System.Drawing.Point(11, 95);
            this.usuario_lbl.Name = "usuario_lbl";
            this.usuario_lbl.Size = new System.Drawing.Size(90, 20);
            this.usuario_lbl.TabIndex = 15;
            this.usuario_lbl.Text = "Usuario:";
            this.usuario_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // base_datos_lbl
            // 
            this.base_datos_lbl.BackColor = System.Drawing.Color.White;
            this.base_datos_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.base_datos_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.base_datos_lbl.Location = new System.Drawing.Point(11, 68);
            this.base_datos_lbl.Name = "base_datos_lbl";
            this.base_datos_lbl.Size = new System.Drawing.Size(90, 20);
            this.base_datos_lbl.TabIndex = 13;
            this.base_datos_lbl.Text = "Base de Datos:";
            this.base_datos_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // servidor_lbl
            // 
            this.servidor_lbl.BackColor = System.Drawing.Color.White;
            this.servidor_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.servidor_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servidor_lbl.Location = new System.Drawing.Point(11, 41);
            this.servidor_lbl.Name = "servidor_lbl";
            this.servidor_lbl.Size = new System.Drawing.Size(90, 20);
            this.servidor_lbl.TabIndex = 11;
            this.servidor_lbl.Text = "Servidor:";
            this.servidor_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Configuracion_Base_Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 174);
            this.Controls.Add(this.contraseña_txt);
            this.Controls.Add(this.usuario_txt);
            this.Controls.Add(this.baseDatos_txt);
            this.Controls.Add(this.servidor_txt);
            this.Controls.Add(this.contraseña_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aceptar_btn);
            this.Controls.Add(this.usuario_lbl);
            this.Controls.Add(this.base_datos_lbl);
            this.Controls.Add(this.servidor_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuracion_Base_Datos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de la Base Datos";
            this.Load += new System.EventHandler(this.Configuracion_Base_Datos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contraseña_txt;
        private System.Windows.Forms.TextBox usuario_txt;
        private System.Windows.Forms.TextBox baseDatos_txt;
        private System.Windows.Forms.TextBox servidor_txt;
        private System.Windows.Forms.Label contraseña_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aceptar_btn;
        private System.Windows.Forms.Label usuario_lbl;
        private System.Windows.Forms.Label base_datos_lbl;
        private System.Windows.Forms.Label servidor_lbl;
    }
}