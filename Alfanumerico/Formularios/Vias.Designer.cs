namespace Formularios
{
    partial class Vias
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
            this.tipoVia_cbo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toponimo_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.condicionNombreVia_cbo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nroAcuerdo_txt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.clasificacionVia_cbo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.codigoViaMTC_txt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.observaciones_txt = new System.Windows.Forms.TextBox();
            this.actualizarTipoVia_btn = new System.Windows.Forms.Button();
            this.actualizarCondicionNombreVia_btn = new System.Windows.Forms.Button();
            this.actualizarClasificacionVia_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).BeginInit();
            this.principal_tc.SuspendLayout();
            this.formulario_tp.SuspendLayout();
            this.SuspendLayout();
            // 
            // principal_tc
            // 
            this.principal_tc.Size = new System.Drawing.Size(654, 352);
            // 
            // tabla_tp
            // 
            this.tabla_tp.Size = new System.Drawing.Size(646, 323);
            // 
            // formulario_tp
            // 
            this.formulario_tp.Controls.Add(this.actualizarClasificacionVia_btn);
            this.formulario_tp.Controls.Add(this.actualizarCondicionNombreVia_btn);
            this.formulario_tp.Controls.Add(this.actualizarTipoVia_btn);
            this.formulario_tp.Controls.Add(this.observaciones_txt);
            this.formulario_tp.Controls.Add(this.label11);
            this.formulario_tp.Controls.Add(this.codigoViaMTC_txt);
            this.formulario_tp.Controls.Add(this.label10);
            this.formulario_tp.Controls.Add(this.clasificacionVia_cbo);
            this.formulario_tp.Controls.Add(this.label9);
            this.formulario_tp.Controls.Add(this.nroAcuerdo_txt);
            this.formulario_tp.Controls.Add(this.label8);
            this.formulario_tp.Controls.Add(this.condicionNombreVia_cbo);
            this.formulario_tp.Controls.Add(this.label7);
            this.formulario_tp.Controls.Add(this.toponimo_txt);
            this.formulario_tp.Controls.Add(this.label6);
            this.formulario_tp.Controls.Add(this.tipoVia_cbo);
            this.formulario_tp.Controls.Add(this.label5);
            this.formulario_tp.Size = new System.Drawing.Size(646, 323);
            this.formulario_tp.Controls.SetChildIndex(this.label5, 0);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.tipoVia_cbo, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label6, 0);
            this.formulario_tp.Controls.SetChildIndex(this.toponimo_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label7, 0);
            this.formulario_tp.Controls.SetChildIndex(this.condicionNombreVia_cbo, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label8, 0);
            this.formulario_tp.Controls.SetChildIndex(this.nroAcuerdo_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label9, 0);
            this.formulario_tp.Controls.SetChildIndex(this.clasificacionVia_cbo, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label10, 0);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label2, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigoViaMTC_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label11, 0);
            this.formulario_tp.Controls.SetChildIndex(this.observaciones_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.actualizarTipoVia_btn, 0);
            this.formulario_tp.Controls.SetChildIndex(this.actualizarCondicionNombreVia_btn, 0);
            this.formulario_tp.Controls.SetChildIndex(this.actualizarClasificacionVia_btn, 0);
            // 
            // label3
            // 
            this.codigo_lbl.Location = new System.Drawing.Point(31, 36);
            this.codigo_lbl.Size = new System.Drawing.Size(161, 22);
            this.codigo_lbl.Text = "Código de Via:";
            // 
            // label4
            // 
            this.descripcion_lbl.Location = new System.Drawing.Point(31, 66);
            this.descripcion_lbl.Size = new System.Drawing.Size(161, 22);
            this.descripcion_lbl.Text = "Nombre de Via:";
            // 
            // codigo_txt
            // 
            this.codigo_txt.Location = new System.Drawing.Point(198, 36);
            this.codigo_txt.MaxLength = 3;
            this.codigo_txt.TabIndex = 9;
            // 
            // descripcion_txt
            // 
            this.descripcion_txt.Location = new System.Drawing.Point(198, 66);
            this.descripcion_txt.MaxLength = 50;
            this.descripcion_txt.Size = new System.Drawing.Size(426, 22);
            this.descripcion_txt.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(31, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tipo de Via:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tipoVia_cbo
            // 
            this.tipoVia_cbo.BackColor = System.Drawing.Color.White;
            this.tipoVia_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoVia_cbo.FormattingEnabled = true;
            this.tipoVia_cbo.Location = new System.Drawing.Point(198, 97);
            this.tipoVia_cbo.Name = "tipoVia_cbo";
            this.tipoVia_cbo.Size = new System.Drawing.Size(217, 24);
            this.tipoVia_cbo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(31, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 22);
            this.label6.TabIndex = 4;
            this.label6.Text = "Toponimo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toponimo_txt
            // 
            this.toponimo_txt.BackColor = System.Drawing.Color.White;
            this.toponimo_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toponimo_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toponimo_txt.Location = new System.Drawing.Point(198, 130);
            this.toponimo_txt.MaxLength = 50;
            this.toponimo_txt.Name = "toponimo_txt";
            this.toponimo_txt.Size = new System.Drawing.Size(301, 22);
            this.toponimo_txt.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(31, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "Condición Nombre de Via:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // condicionNombreVia_cbo
            // 
            this.condicionNombreVia_cbo.BackColor = System.Drawing.Color.White;
            this.condicionNombreVia_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.condicionNombreVia_cbo.FormattingEnabled = true;
            this.condicionNombreVia_cbo.Location = new System.Drawing.Point(198, 160);
            this.condicionNombreVia_cbo.Name = "condicionNombreVia_cbo";
            this.condicionNombreVia_cbo.Size = new System.Drawing.Size(217, 24);
            this.condicionNombreVia_cbo.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(31, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 22);
            this.label8.TabIndex = 6;
            this.label8.Text = "Número de Acuerdo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nroAcuerdo_txt
            // 
            this.nroAcuerdo_txt.BackColor = System.Drawing.Color.White;
            this.nroAcuerdo_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nroAcuerdo_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nroAcuerdo_txt.Location = new System.Drawing.Point(198, 190);
            this.nroAcuerdo_txt.MaxLength = 50;
            this.nroAcuerdo_txt.Name = "nroAcuerdo_txt";
            this.nroAcuerdo_txt.Size = new System.Drawing.Size(301, 22);
            this.nroAcuerdo_txt.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(31, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 22);
            this.label9.TabIndex = 7;
            this.label9.Text = "Clasificación de la Via:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clasificacionVia_cbo
            // 
            this.clasificacionVia_cbo.BackColor = System.Drawing.Color.White;
            this.clasificacionVia_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clasificacionVia_cbo.FormattingEnabled = true;
            this.clasificacionVia_cbo.Location = new System.Drawing.Point(198, 218);
            this.clasificacionVia_cbo.Name = "clasificacionVia_cbo";
            this.clasificacionVia_cbo.Size = new System.Drawing.Size(301, 24);
            this.clasificacionVia_cbo.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(31, 250);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 22);
            this.label10.TabIndex = 8;
            this.label10.Text = "Código de Via M.T.C:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // codigoViaMTC_txt
            // 
            this.codigoViaMTC_txt.BackColor = System.Drawing.Color.White;
            this.codigoViaMTC_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigoViaMTC_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.codigoViaMTC_txt.Location = new System.Drawing.Point(198, 250);
            this.codigoViaMTC_txt.MaxLength = 50;
            this.codigoViaMTC_txt.Name = "codigoViaMTC_txt";
            this.codigoViaMTC_txt.Size = new System.Drawing.Size(149, 22);
            this.codigoViaMTC_txt.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(31, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 22);
            this.label11.TabIndex = 17;
            this.label11.Text = "Observaciones:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // observaciones_txt
            // 
            this.observaciones_txt.BackColor = System.Drawing.Color.White;
            this.observaciones_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.observaciones_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.observaciones_txt.Location = new System.Drawing.Point(198, 282);
            this.observaciones_txt.MaxLength = 50;
            this.observaciones_txt.Name = "observaciones_txt";
            this.observaciones_txt.Size = new System.Drawing.Size(426, 22);
            this.observaciones_txt.TabIndex = 18;
            // 
            // actualizarTipoVia_btn
            // 
            this.actualizarTipoVia_btn.BackgroundImage = global::Alfanumerico.Properties.Resources.actualizar;
            this.actualizarTipoVia_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.actualizarTipoVia_btn.Location = new System.Drawing.Point(421, 97);
            this.actualizarTipoVia_btn.Name = "actualizarTipoVia_btn";
            this.actualizarTipoVia_btn.Size = new System.Drawing.Size(24, 23);
            this.actualizarTipoVia_btn.TabIndex = 19;
            this.actualizarTipoVia_btn.UseVisualStyleBackColor = true;
            this.actualizarTipoVia_btn.Click += new System.EventHandler(this.actualizarTipoVia_btn_Click);
            // 
            // actualizarCondicionNombreVia_btn
            // 
            this.actualizarCondicionNombreVia_btn.BackgroundImage = global::Alfanumerico.Properties.Resources.actualizar;
            this.actualizarCondicionNombreVia_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.actualizarCondicionNombreVia_btn.Location = new System.Drawing.Point(421, 160);
            this.actualizarCondicionNombreVia_btn.Name = "actualizarCondicionNombreVia_btn";
            this.actualizarCondicionNombreVia_btn.Size = new System.Drawing.Size(24, 23);
            this.actualizarCondicionNombreVia_btn.TabIndex = 20;
            this.actualizarCondicionNombreVia_btn.UseVisualStyleBackColor = true;
            // 
            // actualizarClasificacionVia_btn
            // 
            this.actualizarClasificacionVia_btn.BackgroundImage = global::Alfanumerico.Properties.Resources.actualizar;
            this.actualizarClasificacionVia_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.actualizarClasificacionVia_btn.Location = new System.Drawing.Point(505, 219);
            this.actualizarClasificacionVia_btn.Name = "actualizarClasificacionVia_btn";
            this.actualizarClasificacionVia_btn.Size = new System.Drawing.Size(24, 23);
            this.actualizarClasificacionVia_btn.TabIndex = 21;
            this.actualizarClasificacionVia_btn.UseVisualStyleBackColor = true;
            // 
            // Vias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 435);
            this.Name = "Vias";
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).EndInit();
            this.principal_tc.ResumeLayout(false);
            this.formulario_tp.ResumeLayout(false);
            this.formulario_tp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tipoVia_cbo;        
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nroAcuerdo_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox condicionNombreVia_cbo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox toponimo_txt;
        private System.Windows.Forms.TextBox codigoViaMTC_txt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox clasificacionVia_cbo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox observaciones_txt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button actualizarClasificacionVia_btn;
        private System.Windows.Forms.Button actualizarCondicionNombreVia_btn;
        private System.Windows.Forms.Button actualizarTipoVia_btn;
    }
}