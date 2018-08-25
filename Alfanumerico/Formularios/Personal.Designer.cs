namespace Formularios
{
    partial class Personal
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.apaterno_txt = new TextBoxConFormato.FormattedTextBox();
            this.amaterno_txt = new System.Windows.Forms.TextBox();
            this.cargo_cbo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).BeginInit();
            this.principal_tc.SuspendLayout();
            this.formulario_tp.SuspendLayout();
            this.SuspendLayout();
            // 
            // principal_tc
            // 
            this.principal_tc.Size = new System.Drawing.Size(658, 235);
            // 
            // tabla_tp
            // 
            this.tabla_tp.Size = new System.Drawing.Size(646, 206);
            // 
            // formulario_tp
            // 
            this.formulario_tp.Controls.Add(this.label7);
            this.formulario_tp.Controls.Add(this.cargo_cbo);
            this.formulario_tp.Controls.Add(this.label5);
            this.formulario_tp.Controls.Add(this.label6);
            this.formulario_tp.Controls.Add(this.apaterno_txt);
            this.formulario_tp.Controls.Add(this.amaterno_txt);
            this.formulario_tp.Size = new System.Drawing.Size(650, 206);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label2, 0);
            this.formulario_tp.Controls.SetChildIndex(this.amaterno_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.apaterno_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label6, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label5, 0);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.cargo_cbo, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label7, 0);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Size = new System.Drawing.Size(615, 20);
            // 
            // codigo_lbl
            // 
            this.codigo_lbl.Location = new System.Drawing.Point(9, 36);
            this.codigo_lbl.Size = new System.Drawing.Size(126, 22);
            this.codigo_lbl.Text = "D.N.I.:";
            // 
            // descripcion_lbl
            // 
            this.descripcion_lbl.Location = new System.Drawing.Point(9, 70);
            this.descripcion_lbl.Size = new System.Drawing.Size(126, 22);
            this.descripcion_lbl.Text = "Nombres:";
            // 
            // codigo_txt
            // 
            this.codigo_txt.MaxLength = 8;
            this.codigo_txt.Size = new System.Drawing.Size(154, 22);
            // 
            // descripcion_txt
            // 
            this.descripcion_txt.Location = new System.Drawing.Point(141, 71);
            this.descripcion_txt.MaxLength = 50;
            this.descripcion_txt.Size = new System.Drawing.Size(406, 22);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(9, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cargo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(9, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Apellido Materno:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // apaterno_txt
            // 
            this.apaterno_txt.BackColor = System.Drawing.Color.White;
            this.apaterno_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apaterno_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.apaterno_txt.Decimals = ((byte)(0));
            this.apaterno_txt.DecSeparator = '.';
            this.apaterno_txt.Format = TextBoxConFormato.tbFormats.SpacedAlphabetic;
            this.apaterno_txt.Location = new System.Drawing.Point(142, 104);
            this.apaterno_txt.MaxLength = 50;
            this.apaterno_txt.Name = "apaterno_txt";
            this.apaterno_txt.Size = new System.Drawing.Size(405, 22);
            this.apaterno_txt.TabIndex = 6;
            this.apaterno_txt.UserValues = "";
            // 
            // amaterno_txt
            // 
            this.amaterno_txt.BackColor = System.Drawing.Color.White;
            this.amaterno_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amaterno_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.amaterno_txt.Location = new System.Drawing.Point(141, 138);
            this.amaterno_txt.MaxLength = 50;
            this.amaterno_txt.Name = "amaterno_txt";
            this.amaterno_txt.Size = new System.Drawing.Size(406, 22);
            this.amaterno_txt.TabIndex = 8;
            // 
            // cargo_cbo
            // 
            this.cargo_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cargo_cbo.FormattingEnabled = true;
            this.cargo_cbo.Items.AddRange(new object[] {
            "SUPERVISOR",
            "TECNICO CATASTRAL",
            "DIGITACION"});
            this.cargo_cbo.Location = new System.Drawing.Point(141, 169);
            this.cargo_cbo.Name = "cargo_cbo";
            this.cargo_cbo.Size = new System.Drawing.Size(406, 24);
            this.cargo_cbo.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(9, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Apellido Paterno:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 318);
            this.Name = "Personal";
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).EndInit();
            this.principal_tc.ResumeLayout(false);
            this.formulario_tp.ResumeLayout(false);
            this.formulario_tp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;        
        private System.Windows.Forms.Label label6;
        private TextBoxConFormato.FormattedTextBox apaterno_txt;
        private System.Windows.Forms.TextBox amaterno_txt;
        private System.Windows.Forms.ComboBox cargo_cbo;
        private System.Windows.Forms.Label label7;
    }
}