namespace Formularios
{
    partial class Usos
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
            this.label3 = new System.Windows.Forms.Label();
            this.sub_codigo_txt = new TextBoxConFormato.FormattedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).BeginInit();
            this.principal_tc.SuspendLayout();
            this.formulario_tp.SuspendLayout();
            this.SuspendLayout();
            // 
            // formulario_tp
            // 
            this.formulario_tp.Controls.Add(this.label3);
            this.formulario_tp.Controls.Add(this.sub_codigo_txt);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.descripcion_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.codigo_lbl, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label2, 0);
            this.formulario_tp.Controls.SetChildIndex(this.sub_codigo_txt, 0);
            this.formulario_tp.Controls.SetChildIndex(this.label3, 0);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(295, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sub Código:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sub_codigo_txt
            // 
            this.sub_codigo_txt.BackColor = System.Drawing.Color.White;
            this.sub_codigo_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sub_codigo_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sub_codigo_txt.Decimals = ((byte)(0));
            this.sub_codigo_txt.DecSeparator = '.';
            this.sub_codigo_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.sub_codigo_txt.Location = new System.Drawing.Point(401, 35);
            this.sub_codigo_txt.MaxLength = 4;
            this.sub_codigo_txt.Name = "sub_codigo_txt";
            this.sub_codigo_txt.Size = new System.Drawing.Size(143, 22);
            this.sub_codigo_txt.TabIndex = 6;
            this.sub_codigo_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sub_codigo_txt.UserValues = "";
            // 
            // Usos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 232);
            this.Name = "Usos";
            this.Text = "Usos";
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).EndInit();
            this.principal_tc.ResumeLayout(false);
            this.formulario_tp.ResumeLayout(false);
            this.formulario_tp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label3;
        protected TextBoxConFormato.FormattedTextBox sub_codigo_txt;
    }
}