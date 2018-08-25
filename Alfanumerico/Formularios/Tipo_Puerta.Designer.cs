namespace Formularios
{
    partial class Tipo_Puerta
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
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).BeginInit();
            this.principal_tc.SuspendLayout();
            this.formulario_tp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.codigo_lbl.Text = "Tipo de Puerta:";
            // 
            // codigo_txt
            // 
            this.codigo_txt.Format = TextBoxConFormato.tbFormats.NoSpacedAlphabetic;
            this.codigo_txt.MaxLength = 1;
            // 
            // descripcion_txt
            // 
            this.descripcion_txt.MaxLength = 50;
            // 
            // Tipo_Puerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 232);
            this.Name = "Tipo_Puerta";
            ((System.ComponentModel.ISupportInitialize)(this.SUBFICHA_bs)).EndInit();
            this.principal_tc.ResumeLayout(false);
            this.formulario_tp.ResumeLayout(false);
            this.formulario_tp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}