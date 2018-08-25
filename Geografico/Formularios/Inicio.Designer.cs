namespace Formularios
{
    /// <summary>
    /// 
    /// </summary>
    partial class Inicio
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
            this.salir_btn = new System.Windows.Forms.Button();
            this.mensaje_lbl = new System.Windows.Forms.Label();
            this.barraEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.baseDatos_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.usuario_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.barraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // salir_btn
            // 
            this.salir_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.salir_btn.Location = new System.Drawing.Point(363, 508);
            this.salir_btn.Name = "salir_btn";
            this.salir_btn.Size = new System.Drawing.Size(50, 23);
            this.salir_btn.TabIndex = 1;
            this.salir_btn.Text = "Salir";
            this.salir_btn.UseVisualStyleBackColor = true;
            this.salir_btn.Visible = false;
            this.salir_btn.Click += new System.EventHandler(this.salir_btn_Click);
            // 
            // mensaje_lbl
            // 
            this.mensaje_lbl.BackColor = System.Drawing.Color.Black;
            this.mensaje_lbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje_lbl.ForeColor = System.Drawing.Color.White;
            this.mensaje_lbl.Location = new System.Drawing.Point(7, 9);
            this.mensaje_lbl.Name = "mensaje_lbl";
            this.mensaje_lbl.Size = new System.Drawing.Size(703, 23);
            this.mensaje_lbl.TabIndex = 0;
            this.mensaje_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // barraEstado
            // 
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.baseDatos_lbl,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.usuario_lbl});
            this.barraEstado.Location = new System.Drawing.Point(0, 545);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.barraEstado.Size = new System.Drawing.Size(425, 22);
            this.barraEstado.TabIndex = 2;
            this.barraEstado.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel1.Text = "Base de Datos:";
            // 
            // baseDatos_lbl
            // 
            this.baseDatos_lbl.Name = "baseDatos_lbl";
            this.baseDatos_lbl.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel2.Text = " | ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel3.Text = "Usuario:";
            // 
            // usuario_lbl
            // 
            this.usuario_lbl.Name = "usuario_lbl";
            this.usuario_lbl.Size = new System.Drawing.Size(0, 17);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.salir_btn;
            this.ClientSize = new System.Drawing.Size(425, 567);
            this.Controls.Add(this.barraEstado);
            this.Controls.Add(this.mensaje_lbl);
            this.Controls.Add(this.salir_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.inicio_Load);
            this.barraEstado.ResumeLayout(false);
            this.barraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label mensaje_lbl;
        internal System.Windows.Forms.Button salir_btn;
        private System.Windows.Forms.StatusStrip barraEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel baseDatos_lbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel usuario_lbl;
    }
}