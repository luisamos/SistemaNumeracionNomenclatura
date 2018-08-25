namespace Formularios
{
    /// <summary>
    /// 
    /// </summary>
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
            this.guardar_btn = new System.Windows.Forms.Button();
            this.sector_lbl = new System.Windows.Forms.Label();
            this.cuadra_txt = new TextBoxConFormato.FormattedTextBox();
            this.codigoVias_txt = new TextBoxConFormato.FormattedTextBox();
            this.codVias_lbl = new System.Windows.Forms.Label();
            this.cuadra_lbl = new System.Windows.Forms.Label();
            this.sector_cbo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.direccion_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guardar_btn
            // 
            this.guardar_btn.Location = new System.Drawing.Point(167, 148);
            this.guardar_btn.Name = "guardar_btn";
            this.guardar_btn.Size = new System.Drawing.Size(75, 23);
            this.guardar_btn.TabIndex = 9;
            this.guardar_btn.Text = "&Guardar";
            this.guardar_btn.UseVisualStyleBackColor = true;
            this.guardar_btn.Click += new System.EventHandler(this.guardar_btn_Click);
            // 
            // sector_lbl
            // 
            this.sector_lbl.BackColor = System.Drawing.Color.White;
            this.sector_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sector_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sector_lbl.Location = new System.Drawing.Point(27, 41);
            this.sector_lbl.Name = "sector_lbl";
            this.sector_lbl.Size = new System.Drawing.Size(90, 20);
            this.sector_lbl.TabIndex = 5;
            this.sector_lbl.Text = "Sector:";
            this.sector_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cuadra_txt
            // 
            this.cuadra_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cuadra_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cuadra_txt.BackColor = System.Drawing.Color.White;
            this.cuadra_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cuadra_txt.Decimals = ((byte)(0));
            this.cuadra_txt.DecSeparator = '.';
            this.cuadra_txt.ForeColor = System.Drawing.Color.Black;
            this.cuadra_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.cuadra_txt.Location = new System.Drawing.Point(123, 122);
            this.cuadra_txt.MaxLength = 2;
            this.cuadra_txt.Name = "cuadra_txt";
            this.cuadra_txt.Size = new System.Drawing.Size(75, 20);
            this.cuadra_txt.TabIndex = 4;
            this.cuadra_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cuadra_txt.UserValues = "";
            this.cuadra_txt.TextChanged += new System.EventHandler(this.validar_TextChanged);
            this.cuadra_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            this.cuadra_txt.Leave += new System.EventHandler(this.cuadra_txt_Leave);
            // 
            // codigoVias_txt
            // 
            this.codigoVias_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.codigoVias_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.codigoVias_txt.BackColor = System.Drawing.Color.White;
            this.codigoVias_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigoVias_txt.Decimals = ((byte)(0));
            this.codigoVias_txt.DecSeparator = '.';
            this.codigoVias_txt.ForeColor = System.Drawing.Color.Black;
            this.codigoVias_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.codigoVias_txt.Location = new System.Drawing.Point(123, 66);
            this.codigoVias_txt.MaxLength = 3;
            this.codigoVias_txt.Name = "codigoVias_txt";
            this.codigoVias_txt.Size = new System.Drawing.Size(164, 20);
            this.codigoVias_txt.TabIndex = 2;
            this.codigoVias_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codigoVias_txt.UserValues = "";
            this.codigoVias_txt.TextChanged += new System.EventHandler(this.validar_TextChanged);
            this.codigoVias_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            this.codigoVias_txt.Leave += new System.EventHandler(this.codigoVias_txt_Leave);
            // 
            // codVias_lbl
            // 
            this.codVias_lbl.BackColor = System.Drawing.Color.White;
            this.codVias_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codVias_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codVias_lbl.Location = new System.Drawing.Point(27, 66);
            this.codVias_lbl.Name = "codVias_lbl";
            this.codVias_lbl.Size = new System.Drawing.Size(90, 20);
            this.codVias_lbl.TabIndex = 6;
            this.codVias_lbl.Text = "Código de Via:";
            this.codVias_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cuadra_lbl
            // 
            this.cuadra_lbl.BackColor = System.Drawing.Color.White;
            this.cuadra_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cuadra_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuadra_lbl.Location = new System.Drawing.Point(27, 122);
            this.cuadra_lbl.Name = "cuadra_lbl";
            this.cuadra_lbl.Size = new System.Drawing.Size(90, 20);
            this.cuadra_lbl.TabIndex = 8;
            this.cuadra_lbl.Text = "Cuadra:";
            this.cuadra_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sector_cbo
            // 
            this.sector_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sector_cbo.FormattingEnabled = true;
            this.sector_cbo.Location = new System.Drawing.Point(123, 41);
            this.sector_cbo.Name = "sector_cbo";
            this.sector_cbo.Size = new System.Drawing.Size(75, 21);
            this.sector_cbo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dirección:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // direccion_lbl
            // 
            this.direccion_lbl.BackColor = System.Drawing.Color.White;
            this.direccion_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccion_lbl.Location = new System.Drawing.Point(123, 93);
            this.direccion_lbl.Name = "direccion_lbl";
            this.direccion_lbl.Size = new System.Drawing.Size(258, 20);
            this.direccion_lbl.TabIndex = 3;
            this.direccion_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Vias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 196);
            this.Controls.Add(this.direccion_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sector_cbo);
            this.Controls.Add(this.cuadra_lbl);
            this.Controls.Add(this.codVias_lbl);
            this.Controls.Add(this.cuadra_txt);
            this.Controls.Add(this.codigoVias_txt);
            this.Controls.Add(this.sector_lbl);
            this.Controls.Add(this.guardar_btn);
            this.Name = "Vias";
            this.Text = "Ejes de Vias";
            this.Load += new System.EventHandler(this.vias_Load);
            this.Controls.SetChildIndex(this.guardar_btn, 0);
            this.Controls.SetChildIndex(this.sector_lbl, 0);
            this.Controls.SetChildIndex(this.codigoVias_txt, 0);
            this.Controls.SetChildIndex(this.cuadra_txt, 0);
            this.Controls.SetChildIndex(this.codVias_lbl, 0);
            this.Controls.SetChildIndex(this.cuadra_lbl, 0);
            this.Controls.SetChildIndex(this.sector_cbo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.direccion_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button guardar_btn;
        private System.Windows.Forms.Label sector_lbl;
        internal TextBoxConFormato.FormattedTextBox cuadra_txt;
        internal TextBoxConFormato.FormattedTextBox codigoVias_txt;
        private System.Windows.Forms.Label codVias_lbl;
        private System.Windows.Forms.Label cuadra_lbl;
        internal System.Windows.Forms.ComboBox sector_cbo;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label direccion_lbl;
    }
}