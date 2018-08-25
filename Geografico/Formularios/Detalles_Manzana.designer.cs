namespace Formularios
{
    partial class Detalles_Manzana
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
            this.categoria2_cbo = new System.Windows.Forms.ComboBox();
            this.buscar2_txt = new System.Windows.Forms.TextBox();
            this.buscar2_lbl = new System.Windows.Forms.Label();
            this.categoria2_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // categoria2_cbo
            // 
            this.categoria2_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoria2_cbo.FormattingEnabled = true;
            this.categoria2_cbo.Location = new System.Drawing.Point(532, 12);
            this.categoria2_cbo.Name = "categoria2_cbo";
            this.categoria2_cbo.Size = new System.Drawing.Size(152, 23);
            this.categoria2_cbo.TabIndex = 6;
            this.categoria2_cbo.SelectedIndexChanged += new System.EventHandler(this.categoria2_cbo_SelectedIndexChanged);
            // 
            // buscar2_txt
            // 
            this.buscar2_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buscar2_txt.Location = new System.Drawing.Point(745, 13);
            this.buscar2_txt.Name = "buscar2_txt";
            this.buscar2_txt.Size = new System.Drawing.Size(212, 21);
            this.buscar2_txt.TabIndex = 4;
            this.buscar2_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buscar2_txt_KeyDown);
            // 
            // buscar2_lbl
            // 
            this.buscar2_lbl.AutoSize = true;
            this.buscar2_lbl.Location = new System.Drawing.Point(690, 16);
            this.buscar2_lbl.Name = "buscar2_lbl";
            this.buscar2_lbl.Size = new System.Drawing.Size(49, 15);
            this.buscar2_lbl.TabIndex = 5;
            this.buscar2_lbl.Text = "Buscar:";
            // 
            // categoria2_lbl
            // 
            this.categoria2_lbl.AutoSize = true;
            this.categoria2_lbl.Location = new System.Drawing.Point(462, 16);
            this.categoria2_lbl.Name = "categoria2_lbl";
            this.categoria2_lbl.Size = new System.Drawing.Size(64, 15);
            this.categoria2_lbl.TabIndex = 7;
            this.categoria2_lbl.Text = "Categoría:";
            // 
            // Detalles_Manzana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(966, 392);
            this.Controls.Add(this.categoria2_lbl);
            this.Controls.Add(this.buscar2_lbl);
            this.Controls.Add(this.buscar2_txt);
            this.Controls.Add(this.categoria2_cbo);
            this.Name = "Detalles_Manzana";
            this.Text = "";
            this.Load += new System.EventHandler(this.Detalles_Manzana_Load);
            this.Controls.SetChildIndex(this.categoria2_cbo, 0);
            this.Controls.SetChildIndex(this.buscar2_txt, 0);
            this.Controls.SetChildIndex(this.buscar2_lbl, 0);
            this.Controls.SetChildIndex(this.categoria2_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.ComboBox categoria2_cbo;
        private System.Windows.Forms.TextBox buscar2_txt;
        private System.Windows.Forms.Label buscar2_lbl;
        private System.Windows.Forms.Label categoria2_lbl;

    }
}