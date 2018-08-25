namespace Formularios
{
    partial class Clasificacion_Uso_Resaltante
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
            this.tipo_cbo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.actualizar_btn = new System.Windows.Forms.Button();
            this.id_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).BeginInit();
            this.principal_tc.SuspendLayout();
            this.formulario_tp.SuspendLayout();
            this.SuspendLayout();
            // 
            // principal_tc
            // 
            this.principal_tc.Size = new System.Drawing.Size(654, 171);
            // 
            // tabla_tp
            // 
            this.tabla_tp.Size = new System.Drawing.Size(646, 142);
            // 
            // formulario_tp
            // 
            this.formulario_tp.Controls.Add(this.label5);
            this.formulario_tp.Controls.Add(this.tipo_cbo);
            this.formulario_tp.Controls.Add(this.actualizar_btn);
            this.formulario_tp.Controls.Add(this.id_lbl);
            this.formulario_tp.Size = new System.Drawing.Size(646, 142);
            this.formulario_tp.Controls.SetChildIndex(this.id_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.actualizar_btn, 0);
            this.formulario_tp.Controls.SetChildIndex(this.tipo_cbo, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label5, 0);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label2, 0);
            // 
            // label4
            // 
            this.descripcion_lbl.TabIndex = 3;
            // 
            // codigo_txt
            // 
            this.codigo_txt.TabIndex = 2;
            // 
            // descripcion_txt
            // 
            this.descripcion_txt.MaxLength = 50;
            // 
            // tipo_cbo
            // 
            this.tipo_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo_cbo.FormattingEnabled = true;
            this.tipo_cbo.Location = new System.Drawing.Point(141, 97);
            this.tipo_cbo.Name = "tipo_cbo";
            this.tipo_cbo.Size = new System.Drawing.Size(301, 24);
            this.tipo_cbo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(35, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tipo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // actualizar_btn
            // 
            this.actualizar_btn.BackgroundImage = global::Alfanumerico.Properties.Resources.actualizar;
            this.actualizar_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.actualizar_btn.Location = new System.Drawing.Point(446, 98);
            this.actualizar_btn.Name = "actualizar_btn";
            this.actualizar_btn.Size = new System.Drawing.Size(24, 23);
            this.actualizar_btn.TabIndex = 7;
            this.actualizar_btn.UseVisualStyleBackColor = true;
            this.actualizar_btn.Click += new System.EventHandler(this.actualizar_btn_Click);
            // 
            // id_lbl
            // 
            this.id_lbl.AutoSize = true;
            this.id_lbl.ForeColor = System.Drawing.Color.White;
            this.id_lbl.Location = new System.Drawing.Point(596, 123);
            this.id_lbl.Name = "id_lbl";
            this.id_lbl.Size = new System.Drawing.Size(0, 16);
            this.id_lbl.TabIndex = 8;
            // 
            // Clasificacion_Uso_Resaltante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 254);
            this.Name = "Clasificacion_Uso_Resaltante";
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).EndInit();
            this.principal_tc.ResumeLayout(false);
            this.formulario_tp.ResumeLayout(false);
            this.formulario_tp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox tipo_cbo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button actualizar_btn;
        private System.Windows.Forms.Label id_lbl;        
    }
}