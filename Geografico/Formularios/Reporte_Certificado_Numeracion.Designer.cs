namespace Formularios
{
    partial class Reporte_Certificado_Numeracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte_Certificado_Numeracion));
            this.web = new System.Windows.Forms.WebBrowser();
            this.barraHerramientas = new System.Windows.Forms.ToolStrip();
            this.imprimir_tsb = new System.Windows.Forms.ToolStripButton();
            this.separador = new System.Windows.Forms.ToolStripSeparator();
            this.barraHerramientas.SuspendLayout();
            this.SuspendLayout();
            // 
            // web
            // 
            this.web.AllowNavigation = false;
            this.web.AllowWebBrowserDrop = false;
            this.web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web.IsWebBrowserContextMenuEnabled = false;
            this.web.Location = new System.Drawing.Point(0, 25);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(907, 573);
            this.web.TabIndex = 1;
            // 
            // barraHerramientas
            // 
            this.barraHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimir_tsb,
            this.separador});
            this.barraHerramientas.Location = new System.Drawing.Point(0, 0);
            this.barraHerramientas.Name = "barraHerramientas";
            this.barraHerramientas.Size = new System.Drawing.Size(907, 25);
            this.barraHerramientas.TabIndex = 0;
            // 
            // imprimir_tsb
            // 
            this.imprimir_tsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimir_tsb.Image = ((System.Drawing.Image)(resources.GetObject("imprimir_tsb.Image")));
            this.imprimir_tsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimir_tsb.Name = "imprimir_tsb";
            this.imprimir_tsb.Size = new System.Drawing.Size(23, 22);
            this.imprimir_tsb.Text = "&Imprimir";
            this.imprimir_tsb.Click += new System.EventHandler(this.imprimir_tsb_Click);
            // 
            // separador
            // 
            this.separador.Name = "separador";
            this.separador.Size = new System.Drawing.Size(6, 25);
            // 
            // Reporte_Certificado_Numeracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(907, 598);
            this.Controls.Add(this.web);
            this.Controls.Add(this.barraHerramientas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reporte_Certificado_Numeracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificado de Numeración";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.certificado_numeracion_Load);
            this.barraHerramientas.ResumeLayout(false);
            this.barraHerramientas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraHerramientas;
        private System.Windows.Forms.ToolStripButton imprimir_tsb;
        private System.Windows.Forms.ToolStripSeparator separador;
        private System.Windows.Forms.WebBrowser web;
    }
}