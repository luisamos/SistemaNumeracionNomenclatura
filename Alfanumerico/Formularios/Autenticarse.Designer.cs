namespace Formularios
{
    partial class Autenticarse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autenticarse));
            this.mensaje_lbl = new System.Windows.Forms.Label();
            this.cancelar_btn = new System.Windows.Forms.Button();
            this.aceptar_btn = new System.Windows.Forms.Button();
            this.contraseña_txt = new System.Windows.Forms.TextBox();
            this.usuario_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logo_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // mensaje_lbl
            // 
            this.mensaje_lbl.AutoSize = true;
            this.mensaje_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje_lbl.ForeColor = System.Drawing.Color.Red;
            this.mensaje_lbl.Location = new System.Drawing.Point(12, 84);
            this.mensaje_lbl.Name = "mensaje_lbl";
            this.mensaje_lbl.Size = new System.Drawing.Size(0, 15);
            this.mensaje_lbl.TabIndex = 6;
            // 
            // cancelar_btn
            // 
            this.cancelar_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelar_btn.Location = new System.Drawing.Point(276, 61);
            this.cancelar_btn.Name = "cancelar_btn";
            this.cancelar_btn.Size = new System.Drawing.Size(87, 21);
            this.cancelar_btn.TabIndex = 3;
            this.cancelar_btn.Text = "&Cancelar";
            this.cancelar_btn.UseVisualStyleBackColor = true;
            // 
            // aceptar_btn
            // 
            this.aceptar_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar_btn.Enabled = false;
            this.aceptar_btn.Location = new System.Drawing.Point(276, 34);
            this.aceptar_btn.Name = "aceptar_btn";
            this.aceptar_btn.Size = new System.Drawing.Size(87, 21);
            this.aceptar_btn.TabIndex = 2;
            this.aceptar_btn.Text = "&Aceptar";
            this.aceptar_btn.UseVisualStyleBackColor = true;
            // 
            // contraseña_txt
            // 
            this.contraseña_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseña_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.contraseña_txt.Location = new System.Drawing.Point(134, 61);
            this.contraseña_txt.MaxLength = 20;
            this.contraseña_txt.Name = "contraseña_txt";
            this.contraseña_txt.PasswordChar = '*';
            this.contraseña_txt.Size = new System.Drawing.Size(135, 21);
            this.contraseña_txt.TabIndex = 1;
            this.contraseña_txt.TextChanged += new System.EventHandler(this.validar);
            this.contraseña_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contraseña_txt_KeyPress);
            // 
            // usuario_txt
            // 
            this.usuario_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuario_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.usuario_txt.Location = new System.Drawing.Point(134, 34);
            this.usuario_txt.MaxLength = 10;
            this.usuario_txt.Name = "usuario_txt";
            this.usuario_txt.Size = new System.Drawing.Size(135, 21);
            this.usuario_txt.TabIndex = 0;
            this.usuario_txt.TextChanged += new System.EventHandler(this.validar);
            this.usuario_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usuario_txt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Introduzca su Usuario y Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 45);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario:\r\n\r\nContraseña:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logo_pb
            // 
            this.logo_pb.Image = global::Alfanumerico.Properties.Resources.usuarios;
            this.logo_pb.Location = new System.Drawing.Point(9, 12);
            this.logo_pb.Name = "logo_pb";
            this.logo_pb.Size = new System.Drawing.Size(59, 62);
            this.logo_pb.TabIndex = 8;
            this.logo_pb.TabStop = false;
            // 
            // Autenticarse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelar_btn;
            this.ClientSize = new System.Drawing.Size(374, 102);
            this.Controls.Add(this.mensaje_lbl);
            this.Controls.Add(this.cancelar_btn);
            this.Controls.Add(this.aceptar_btn);
            this.Controls.Add(this.contraseña_txt);
            this.Controls.Add(this.usuario_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logo_pb);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Autenticarse";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Acceso";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Autenticarse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar_btn;
        private System.Windows.Forms.Button aceptar_btn;
        internal System.Windows.Forms.TextBox contraseña_txt;
        internal System.Windows.Forms.TextBox usuario_txt;
        private System.Windows.Forms.PictureBox logo_pb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label mensaje_lbl;
    }
}