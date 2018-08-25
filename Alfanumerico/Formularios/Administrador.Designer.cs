namespace Formularios
{
    partial class Administrador
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
            this.direccion_lbl = new System.Windows.Forms.Label();
            this.correoElectronico_lbl = new System.Windows.Forms.Label();
            this.contraseña_lbl = new System.Windows.Forms.Label();
            this.correoElectronico_txt = new System.Windows.Forms.TextBox();
            this.direccion_txt = new System.Windows.Forms.TextBox();
            this.contraseña_txt = new System.Windows.Forms.TextBox();
            this.contraseña_ckb = new System.Windows.Forms.CheckBox();
            this.habilitado_ckb = new System.Windows.Forms.CheckBox();
            this.administrador_ckb = new System.Windows.Forms.CheckBox();
            this.celular_lbl = new System.Windows.Forms.Label();
            this.celular_txt = new TextBoxConFormato.FormattedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).BeginInit();
            this.principal_tc.SuspendLayout();
            this.formulario_tp.SuspendLayout();
            this.SuspendLayout();
            // 
            // principal_tc
            // 
            this.principal_tc.Size = new System.Drawing.Size(654, 289);
            // 
            // tabla_tp
            // 
            this.tabla_tp.Size = new System.Drawing.Size(646, 260);
            // 
            // formulario_tp
            // 
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
            this.formulario_tp.Size = new System.Drawing.Size(646, 260);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label2, 0);
            this.formulario_tp.Controls.SetChildIndex(this.direccion_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.correoElectronico_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.contraseña_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.correoElectronico_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.direccion_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.contraseña_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.contraseña_ckb, 0);
            this.formulario_tp.Controls.SetChildIndex(this.habilitado_ckb, 0);
            this.formulario_tp.Controls.SetChildIndex(this.administrador_ckb, 0);
            this.formulario_tp.Controls.SetChildIndex(this.celular_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.celular_txt, 0);
            // 
            // codigo_lbl
            // 
            this.codigo_lbl.Text = "Usuario:";
            // 
            // descripcion_lbl
            // 
            this.descripcion_lbl.Location = new System.Drawing.Point(35, 69);
            this.descripcion_lbl.Size = new System.Drawing.Size(100, 36);
            this.descripcion_lbl.Text = "Apellidos y Nombres:";
            // 
            // codigo_txt
            // 
            this.codigo_txt.Format = TextBoxConFormato.tbFormats.NoSpacedAlphaNumeric;
            this.codigo_txt.MaxLength = 10;
            this.codigo_txt.Size = new System.Drawing.Size(164, 22);
            this.codigo_txt.TabIndex = 7;
            this.codigo_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // descripcion_txt
            // 
            this.descripcion_txt.Location = new System.Drawing.Point(141, 83);
            this.descripcion_txt.MaxLength = 300;
            this.descripcion_txt.TabIndex = 8;
            // 
            // direccion_lbl
            // 
            this.direccion_lbl.BackColor = System.Drawing.Color.White;
            this.direccion_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion_lbl.Location = new System.Drawing.Point(35, 115);
            this.direccion_lbl.Name = "direccion_lbl";
            this.direccion_lbl.Size = new System.Drawing.Size(100, 22);
            this.direccion_lbl.TabIndex = 3;
            this.direccion_lbl.Text = "Dirección:";
            this.direccion_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // correoElectronico_lbl
            // 
            this.correoElectronico_lbl.BackColor = System.Drawing.Color.White;
            this.correoElectronico_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.correoElectronico_lbl.Location = new System.Drawing.Point(35, 182);
            this.correoElectronico_lbl.Name = "correoElectronico_lbl";
            this.correoElectronico_lbl.Size = new System.Drawing.Size(100, 37);
            this.correoElectronico_lbl.TabIndex = 5;
            this.correoElectronico_lbl.Text = "Correo Electrónico:";
            this.correoElectronico_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contraseña_lbl
            // 
            this.contraseña_lbl.BackColor = System.Drawing.Color.White;
            this.contraseña_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseña_lbl.Location = new System.Drawing.Point(35, 230);
            this.contraseña_lbl.Name = "contraseña_lbl";
            this.contraseña_lbl.Size = new System.Drawing.Size(100, 22);
            this.contraseña_lbl.TabIndex = 6;
            this.contraseña_lbl.Text = "Contraseña:";
            this.contraseña_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // correoElectronico_txt
            // 
            this.correoElectronico_txt.BackColor = System.Drawing.Color.White;
            this.correoElectronico_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.correoElectronico_txt.Location = new System.Drawing.Point(141, 197);
            this.correoElectronico_txt.MaxLength = 50;
            this.correoElectronico_txt.Name = "correoElectronico_txt";
            this.correoElectronico_txt.Size = new System.Drawing.Size(483, 22);
            this.correoElectronico_txt.TabIndex = 11;
            // 
            // direccion_txt
            // 
            this.direccion_txt.BackColor = System.Drawing.Color.White;
            this.direccion_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.direccion_txt.Location = new System.Drawing.Point(141, 116);
            this.direccion_txt.MaxLength = 100;
            this.direccion_txt.Name = "direccion_txt";
            this.direccion_txt.Size = new System.Drawing.Size(483, 22);
            this.direccion_txt.TabIndex = 9;
            // 
            // contraseña_txt
            // 
            this.contraseña_txt.BackColor = System.Drawing.Color.White;
            this.contraseña_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contraseña_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.contraseña_txt.Location = new System.Drawing.Point(141, 230);
            this.contraseña_txt.MaxLength = 10;
            this.contraseña_txt.Name = "contraseña_txt";
            this.contraseña_txt.PasswordChar = '*';
            this.contraseña_txt.Size = new System.Drawing.Size(164, 22);
            this.contraseña_txt.TabIndex = 12;            
            // 
            // contraseña_ckb
            // 
            this.contraseña_ckb.AutoSize = true;
            this.contraseña_ckb.Location = new System.Drawing.Point(311, 230);
            this.contraseña_ckb.Name = "contraseña_ckb";
            this.contraseña_ckb.Size = new System.Drawing.Size(141, 20);
            this.contraseña_ckb.TabIndex = 15;
            this.contraseña_ckb.Text = "Mostrar Contraseña";
            this.contraseña_ckb.UseVisualStyleBackColor = true;
            this.contraseña_ckb.CheckedChanged += new System.EventHandler(this.contraseña_ckb_CheckedChanged);
            // 
            // habilitado_ckb
            // 
            this.habilitado_ckb.AutoSize = true;
            this.habilitado_ckb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.habilitado_ckb.Location = new System.Drawing.Point(381, 38);
            this.habilitado_ckb.Name = "habilitado_ckb";
            this.habilitado_ckb.Size = new System.Drawing.Size(88, 20);
            this.habilitado_ckb.TabIndex = 13;
            this.habilitado_ckb.Text = "Habilitado:";
            this.habilitado_ckb.UseVisualStyleBackColor = true;
            // 
            // administrador_ckb
            // 
            this.administrador_ckb.AutoSize = true;
            this.administrador_ckb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.administrador_ckb.Location = new System.Drawing.Point(485, 38);
            this.administrador_ckb.Name = "administrador_ckb";
            this.administrador_ckb.Size = new System.Drawing.Size(111, 20);
            this.administrador_ckb.TabIndex = 14;
            this.administrador_ckb.Text = "Administrador:";
            this.administrador_ckb.UseVisualStyleBackColor = true;
            // 
            // celular_lbl
            // 
            this.celular_lbl.BackColor = System.Drawing.Color.White;
            this.celular_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.celular_lbl.Location = new System.Drawing.Point(35, 149);
            this.celular_lbl.Name = "celular_lbl";
            this.celular_lbl.Size = new System.Drawing.Size(100, 22);
            this.celular_lbl.TabIndex = 4;
            this.celular_lbl.Text = "Celular:";
            this.celular_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // celular_txt
            // 
            this.celular_txt.BackColor = System.Drawing.Color.White;
            this.celular_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.celular_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.celular_txt.Decimals = ((byte)(0));
            this.celular_txt.DecSeparator = '.';
            this.celular_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.celular_txt.Location = new System.Drawing.Point(141, 149);
            this.celular_txt.MaxLength = 30;
            this.celular_txt.Name = "celular_txt";
            this.celular_txt.Size = new System.Drawing.Size(233, 22);
            this.celular_txt.TabIndex = 10;
            this.celular_txt.UserValues = "";
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 372);
            this.Name = "Administrador";
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).EndInit();
            this.principal_tc.ResumeLayout(false);
            this.formulario_tp.ResumeLayout(false);
            this.formulario_tp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contraseña_lbl;
        private System.Windows.Forms.Label correoElectronico_lbl;
        private System.Windows.Forms.Label direccion_lbl;
        private System.Windows.Forms.CheckBox administrador_ckb;
        private System.Windows.Forms.CheckBox habilitado_ckb;
        private System.Windows.Forms.CheckBox contraseña_ckb;
        private System.Windows.Forms.TextBox contraseña_txt;
        private System.Windows.Forms.TextBox direccion_txt;
        private System.Windows.Forms.TextBox correoElectronico_txt;
        private System.Windows.Forms.Label celular_lbl;
        protected TextBoxConFormato.FormattedTextBox celular_txt;
    }
}