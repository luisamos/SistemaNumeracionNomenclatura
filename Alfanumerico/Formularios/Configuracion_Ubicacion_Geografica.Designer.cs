namespace Formularios
{
    partial class Configuracion_Ubicacion_Geografica
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
            this.distrito_cbo = new System.Windows.Forms.ComboBox();
            this.provincia_cbo = new System.Windows.Forms.ComboBox();
            this.departamento_cbo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aceptar_btn = new System.Windows.Forms.Button();
            this.distrito_lbl = new System.Windows.Forms.Label();
            this.provincia_lbl = new System.Windows.Forms.Label();
            this.departamento_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // distrito_cbo
            // 
            this.distrito_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distrito_cbo.FormattingEnabled = true;
            this.distrito_cbo.Location = new System.Drawing.Point(132, 109);
            this.distrito_cbo.Name = "distrito_cbo";
            this.distrito_cbo.Size = new System.Drawing.Size(205, 21);
            this.distrito_cbo.TabIndex = 33;
            // 
            // provincia_cbo
            // 
            this.provincia_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provincia_cbo.FormattingEnabled = true;
            this.provincia_cbo.Location = new System.Drawing.Point(132, 74);
            this.provincia_cbo.Name = "provincia_cbo";
            this.provincia_cbo.Size = new System.Drawing.Size(205, 21);
            this.provincia_cbo.TabIndex = 32;
            this.provincia_cbo.SelectedIndexChanged += new System.EventHandler(this.provincia_cbo_SelectedIndexChanged);
            // 
            // departamento_cbo
            // 
            this.departamento_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departamento_cbo.FormattingEnabled = true;
            this.departamento_cbo.Location = new System.Drawing.Point(132, 39);
            this.departamento_cbo.Name = "departamento_cbo";
            this.departamento_cbo.Size = new System.Drawing.Size(205, 21);
            this.departamento_cbo.TabIndex = 31;
            this.departamento_cbo.SelectedIndexChanged += new System.EventHandler(this.departamento_cbo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 23);
            this.label1.TabIndex = 30;
            this.label1.Text = "Seleccionar la Ubicación Geográfica";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aceptar_btn
            // 
            this.aceptar_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar_btn.Location = new System.Drawing.Point(277, 140);
            this.aceptar_btn.Name = "aceptar_btn";
            this.aceptar_btn.Size = new System.Drawing.Size(70, 23);
            this.aceptar_btn.TabIndex = 29;
            this.aceptar_btn.Text = "&Aceptar";
            this.aceptar_btn.UseVisualStyleBackColor = true;
            this.aceptar_btn.Click += new System.EventHandler(this.aceptar_btn_Click);
            // 
            // distrito_lbl
            // 
            this.distrito_lbl.BackColor = System.Drawing.Color.White;
            this.distrito_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.distrito_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distrito_lbl.Location = new System.Drawing.Point(36, 109);
            this.distrito_lbl.Name = "distrito_lbl";
            this.distrito_lbl.Size = new System.Drawing.Size(90, 23);
            this.distrito_lbl.TabIndex = 28;
            this.distrito_lbl.Text = "Distrito: ";
            this.distrito_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // provincia_lbl
            // 
            this.provincia_lbl.BackColor = System.Drawing.Color.White;
            this.provincia_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.provincia_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provincia_lbl.Location = new System.Drawing.Point(36, 74);
            this.provincia_lbl.Name = "provincia_lbl";
            this.provincia_lbl.Size = new System.Drawing.Size(90, 23);
            this.provincia_lbl.TabIndex = 27;
            this.provincia_lbl.Text = "Provincia: ";
            this.provincia_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // departamento_lbl
            // 
            this.departamento_lbl.BackColor = System.Drawing.Color.White;
            this.departamento_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.departamento_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departamento_lbl.Location = new System.Drawing.Point(36, 39);
            this.departamento_lbl.Name = "departamento_lbl";
            this.departamento_lbl.Size = new System.Drawing.Size(90, 23);
            this.departamento_lbl.TabIndex = 26;
            this.departamento_lbl.Text = "Departamento: ";
            this.departamento_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Configuracion_Ubicacion_Geografica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(351, 171);
            this.Controls.Add(this.distrito_cbo);
            this.Controls.Add(this.provincia_cbo);
            this.Controls.Add(this.departamento_cbo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aceptar_btn);
            this.Controls.Add(this.distrito_lbl);
            this.Controls.Add(this.provincia_lbl);
            this.Controls.Add(this.departamento_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuracion_Ubicacion_Geografica";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Ubicación Geográfica";
            this.Load += new System.EventHandler(this.Configuracion_Ubicacion_Geografica_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox distrito_cbo;
        private System.Windows.Forms.ComboBox provincia_cbo;
        private System.Windows.Forms.ComboBox departamento_cbo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aceptar_btn;
        private System.Windows.Forms.Label distrito_lbl;
        private System.Windows.Forms.Label provincia_lbl;
        private System.Windows.Forms.Label departamento_lbl;
    }
}