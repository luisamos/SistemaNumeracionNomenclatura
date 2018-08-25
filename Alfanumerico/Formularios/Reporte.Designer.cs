namespace Formularios
{
    partial class Reporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte));
            this.visor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // visor
            // 
            this.visor.ActiveViewIndex = -1;
            this.visor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.visor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.visor.Cursor = System.Windows.Forms.Cursors.Default;
            this.visor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visor.Location = new System.Drawing.Point(0, 0);
            this.visor.Name = "visor";
            this.visor.ShowCloseButton = false;
            this.visor.ShowGroupTreeButton = false;
            this.visor.ShowParameterPanelButton = false;
            this.visor.ShowRefreshButton = false;
            this.visor.Size = new System.Drawing.Size(873, 632);
            this.visor.TabIndex = 0;
            this.visor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(396, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 24);
            this.label1.TabIndex = 1;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(873, 632);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.visor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer visor;
        private System.Windows.Forms.Label label1;
    }
}