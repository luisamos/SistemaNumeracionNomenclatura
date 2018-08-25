namespace Formularios
{
    partial class Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuario));
            this.label1 = new System.Windows.Forms.Label();
            this.principal_tc = new System.Windows.Forms.TabControl();
            this.formulario_tp = new System.Windows.Forms.TabPage();
            this.guardar_btn = new System.Windows.Forms.Button();
            this.celular_txt = new TextBoxConFormato.FormattedTextBox();
            this.celular_lbl = new System.Windows.Forms.Label();
            this.administrador_ckb = new System.Windows.Forms.CheckBox();
            this.habilitado_ckb = new System.Windows.Forms.CheckBox();
            this.contraseña_ckb = new System.Windows.Forms.CheckBox();
            this.contraseña_txt = new System.Windows.Forms.TextBox();
            this.direccion_txt = new System.Windows.Forms.TextBox();
            this.correoElectronico_txt = new System.Windows.Forms.TextBox();
            this.contraseña_lbl = new System.Windows.Forms.Label();
            this.correoElectronico_lbl = new System.Windows.Forms.Label();
            this.direccion_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usuario_lbl = new System.Windows.Forms.Label();
            this.apellidosNombres_lbl = new System.Windows.Forms.Label();
            this.apellidosNombres_txt = new System.Windows.Forms.TextBox();
            this.principal_tc.SuspendLayout();
            this.formulario_tp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta de Usuario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // principal_tc
            // 
            this.principal_tc.Controls.Add(this.formulario_tp);
            this.principal_tc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.principal_tc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.principal_tc.Location = new System.Drawing.Point(0, 33);
            this.principal_tc.Name = "principal_tc";
            this.principal_tc.SelectedIndex = 0;
            this.principal_tc.Size = new System.Drawing.Size(644, 310);
            this.principal_tc.TabIndex = 0;
            // 
            // formulario_tp
            // 
            this.formulario_tp.Controls.Add(this.guardar_btn);
            this.formulario_tp.Controls.Add(this.celular_txt);
            this.formulario_tp.Controls.Add(this.celular_lbl);
            this.formulario_tp.Controls.Add(this.administrador_ckb);
            this.formulario_tp.Controls.Add(this.habilitado_ckb);
            this.formulario_tp.Controls.Add(this.contraseña_ckb);
            this.formulario_tp.Controls.Add(this.contraseña_txt);
            this.formulario_tp.Controls.Add(this.direccion_txt);
            this.formulario_tp.Controls.Add(this.correoElectronico_txt);
            this.formulario_tp.Controls.Add(this.contraseña_lbl);
            this.formulario_tp.Controls.Add(this.correoElectronico_lbl);
            this.formulario_tp.Controls.Add(this.direccion_lbl);
            this.formulario_tp.Controls.Add(this.label3);
            this.formulario_tp.Controls.Add(this.label2);
            this.formulario_tp.Controls.Add(this.usuario_lbl);
            this.formulario_tp.Controls.Add(this.apellidosNombres_lbl);
            this.formulario_tp.Controls.Add(this.apellidosNombres_txt);
            this.formulario_tp.Location = new System.Drawing.Point(4, 25);
            this.formulario_tp.Name = "formulario_tp";
            this.formulario_tp.Padding = new System.Windows.Forms.Padding(3);
            this.formulario_tp.Size = new System.Drawing.Size(636, 281);
            this.formulario_tp.TabIndex = 1;
            this.formulario_tp.Text = "Formulario";
            this.formulario_tp.UseVisualStyleBackColor = true;
            // 
            // guardar_btn
            // 
            this.guardar_btn.Location = new System.Drawing.Point(282, 252);
            this.guardar_btn.Name = "guardar_btn";
            this.guardar_btn.Size = new System.Drawing.Size(75, 23);
            this.guardar_btn.TabIndex = 8;
            this.guardar_btn.Text = "&Guardar";
            this.guardar_btn.UseVisualStyleBackColor = true;
            this.guardar_btn.Click += new System.EventHandler(this.guardar_btn_Click);
            // 
            // celular_txt
            // 
            this.celular_txt.BackColor = System.Drawing.Color.White;
            this.celular_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.celular_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.celular_txt.Decimals = ((byte)(0));
            this.celular_txt.DecSeparator = '.';
            this.celular_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.celular_txt.Location = new System.Drawing.Point(141, 145);
            this.celular_txt.MaxLength = 30;
            this.celular_txt.Name = "celular_txt";
            this.celular_txt.Size = new System.Drawing.Size(233, 22);
            this.celular_txt.TabIndex = 2;
            this.celular_txt.UserValues = "";
            this.celular_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // celular_lbl
            // 
            this.celular_lbl.BackColor = System.Drawing.Color.White;
            this.celular_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.celular_lbl.Location = new System.Drawing.Point(35, 145);
            this.celular_lbl.Name = "celular_lbl";
            this.celular_lbl.Size = new System.Drawing.Size(100, 22);
            this.celular_lbl.TabIndex = 13;
            this.celular_lbl.Text = "Celular:";
            this.celular_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // administrador_ckb
            // 
            this.administrador_ckb.AutoSize = true;
            this.administrador_ckb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.administrador_ckb.Enabled = false;
            this.administrador_ckb.Location = new System.Drawing.Point(485, 36);
            this.administrador_ckb.Name = "administrador_ckb";
            this.administrador_ckb.Size = new System.Drawing.Size(111, 20);
            this.administrador_ckb.TabIndex = 7;
            this.administrador_ckb.Text = "Administrador:";
            this.administrador_ckb.UseVisualStyleBackColor = true;
            // 
            // habilitado_ckb
            // 
            this.habilitado_ckb.AutoSize = true;
            this.habilitado_ckb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.habilitado_ckb.Enabled = false;
            this.habilitado_ckb.Location = new System.Drawing.Point(381, 36);
            this.habilitado_ckb.Name = "habilitado_ckb";
            this.habilitado_ckb.Size = new System.Drawing.Size(88, 20);
            this.habilitado_ckb.TabIndex = 6;
            this.habilitado_ckb.Text = "Habilitado:";
            this.habilitado_ckb.UseVisualStyleBackColor = true;
            // 
            // contraseña_ckb
            // 
            this.contraseña_ckb.AutoSize = true;
            this.contraseña_ckb.Location = new System.Drawing.Point(311, 226);
            this.contraseña_ckb.Name = "contraseña_ckb";
            this.contraseña_ckb.Size = new System.Drawing.Size(141, 20);
            this.contraseña_ckb.TabIndex = 5;
            this.contraseña_ckb.Text = "Mostrar Contraseña";
            this.contraseña_ckb.UseVisualStyleBackColor = true;
            this.contraseña_ckb.CheckedChanged += new System.EventHandler(this.contraseña_ckb_CheckedChanged);
            // 
            // contraseña_txt
            // 
            this.contraseña_txt.BackColor = System.Drawing.Color.White;
            this.contraseña_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseña_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.contraseña_txt.Location = new System.Drawing.Point(141, 224);
            this.contraseña_txt.MaxLength = 10;
            this.contraseña_txt.Name = "contraseña_txt";
            this.contraseña_txt.PasswordChar = '*';
            this.contraseña_txt.Size = new System.Drawing.Size(164, 22);
            this.contraseña_txt.TabIndex = 4;
            this.contraseña_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // direccion_txt
            // 
            this.direccion_txt.BackColor = System.Drawing.Color.White;
            this.direccion_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.direccion_txt.Location = new System.Drawing.Point(141, 113);
            this.direccion_txt.MaxLength = 100;
            this.direccion_txt.Name = "direccion_txt";
            this.direccion_txt.Size = new System.Drawing.Size(483, 22);
            this.direccion_txt.TabIndex = 1;
            this.direccion_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // correoElectronico_txt
            // 
            this.correoElectronico_txt.BackColor = System.Drawing.Color.White;
            this.correoElectronico_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.correoElectronico_txt.Location = new System.Drawing.Point(141, 192);
            this.correoElectronico_txt.MaxLength = 50;
            this.correoElectronico_txt.Name = "correoElectronico_txt";
            this.correoElectronico_txt.Size = new System.Drawing.Size(483, 22);
            this.correoElectronico_txt.TabIndex = 3;
            this.correoElectronico_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // contraseña_lbl
            // 
            this.contraseña_lbl.BackColor = System.Drawing.Color.White;
            this.contraseña_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseña_lbl.Location = new System.Drawing.Point(35, 224);
            this.contraseña_lbl.Name = "contraseña_lbl";
            this.contraseña_lbl.Size = new System.Drawing.Size(100, 22);
            this.contraseña_lbl.TabIndex = 15;
            this.contraseña_lbl.Text = "Contraseña:";
            this.contraseña_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // correoElectronico_lbl
            // 
            this.correoElectronico_lbl.BackColor = System.Drawing.Color.White;
            this.correoElectronico_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.correoElectronico_lbl.Location = new System.Drawing.Point(35, 177);
            this.correoElectronico_lbl.Name = "correoElectronico_lbl";
            this.correoElectronico_lbl.Size = new System.Drawing.Size(100, 37);
            this.correoElectronico_lbl.TabIndex = 14;
            this.correoElectronico_lbl.Text = "Correo Electrónico:";
            this.correoElectronico_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // direccion_lbl
            // 
            this.direccion_lbl.BackColor = System.Drawing.Color.White;
            this.direccion_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion_lbl.Location = new System.Drawing.Point(35, 113);
            this.direccion_lbl.Name = "direccion_lbl";
            this.direccion_lbl.Size = new System.Drawing.Size(100, 22);
            this.direccion_lbl.TabIndex = 12;
            this.direccion_lbl.Text = "Dirección:";
            this.direccion_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(35, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Código:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(603, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Campos:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usuario_lbl
            // 
            this.usuario_lbl.BackColor = System.Drawing.Color.White;
            this.usuario_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usuario_lbl.Location = new System.Drawing.Point(141, 37);
            this.usuario_lbl.Name = "usuario_lbl";
            this.usuario_lbl.Size = new System.Drawing.Size(100, 22);
            this.usuario_lbl.TabIndex = 16;
            this.usuario_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apellidosNombres_lbl
            // 
            this.apellidosNombres_lbl.BackColor = System.Drawing.Color.White;
            this.apellidosNombres_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apellidosNombres_lbl.Location = new System.Drawing.Point(35, 69);
            this.apellidosNombres_lbl.Name = "apellidosNombres_lbl";
            this.apellidosNombres_lbl.Size = new System.Drawing.Size(100, 34);
            this.apellidosNombres_lbl.TabIndex = 11;
            this.apellidosNombres_lbl.Text = "Apellidos y Nombres:";
            this.apellidosNombres_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // apellidosNombres_txt
            // 
            this.apellidosNombres_txt.BackColor = System.Drawing.Color.White;
            this.apellidosNombres_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apellidosNombres_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.apellidosNombres_txt.Location = new System.Drawing.Point(141, 81);
            this.apellidosNombres_txt.MaxLength = 30;
            this.apellidosNombres_txt.Name = "apellidosNombres_txt";
            this.apellidosNombres_txt.Size = new System.Drawing.Size(483, 22);
            this.apellidosNombres_txt.TabIndex = 0;
            this.apellidosNombres_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 343);
            this.Controls.Add(this.principal_tc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuenta de Usuario";
            this.Load += new System.EventHandler(this.usuario_Load);
            this.principal_tc.ResumeLayout(false);
            this.formulario_tp.ResumeLayout(false);
            this.formulario_tp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TabControl principal_tc;
        protected System.Windows.Forms.TabPage formulario_tp;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label usuario_lbl;
        protected System.Windows.Forms.Label apellidosNombres_lbl;
        protected System.Windows.Forms.TextBox apellidosNombres_txt;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardar_btn;
        protected TextBoxConFormato.FormattedTextBox celular_txt;
        private System.Windows.Forms.Label celular_lbl;
        private System.Windows.Forms.CheckBox contraseña_ckb;
        private System.Windows.Forms.TextBox contraseña_txt;
        private System.Windows.Forms.TextBox direccion_txt;
        private System.Windows.Forms.TextBox correoElectronico_txt;
        private System.Windows.Forms.Label contraseña_lbl;
        private System.Windows.Forms.Label correoElectronico_lbl;
        private System.Windows.Forms.Label direccion_lbl;
        private System.Windows.Forms.CheckBox administrador_ckb;
        private System.Windows.Forms.CheckBox habilitado_ckb;
    }
}