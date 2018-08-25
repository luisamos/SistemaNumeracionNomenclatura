namespace Formularios
{
    partial class Modulo_Componente_Urbano_Mobiliario_Urbano
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
            this.aceptar_btn = new System.Windows.Forms.Button();
            this.mensaje_lbl = new System.Windows.Forms.Label();
            this.direccion_lbl = new System.Windows.Forms.Label();
            this.cuadra_txt = new TextBoxConFormato.FormattedTextBox();
            this.codigoVias_txt = new TextBoxConFormato.FormattedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cuadra_lbl = new System.Windows.Forms.Label();
            this.codVias_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aceptar_btn
            // 
            this.aceptar_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar_btn.Location = new System.Drawing.Point(171, 114);
            this.aceptar_btn.Name = "aceptar_btn";
            this.aceptar_btn.Size = new System.Drawing.Size(87, 21);
            this.aceptar_btn.TabIndex = 5;
            this.aceptar_btn.Text = "&Aceptar";
            this.aceptar_btn.UseVisualStyleBackColor = true;
            this.aceptar_btn.Click += new System.EventHandler(this.aceptar_btn_Click);
            // 
            // mensaje_lbl
            // 
            this.mensaje_lbl.BackColor = System.Drawing.Color.Black;
            this.mensaje_lbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje_lbl.ForeColor = System.Drawing.Color.White;
            this.mensaje_lbl.Location = new System.Drawing.Point(22, 9);
            this.mensaje_lbl.Name = "mensaje_lbl";
            this.mensaje_lbl.Size = new System.Drawing.Size(392, 23);
            this.mensaje_lbl.TabIndex = 0;
            this.mensaje_lbl.Text = "Ingresar:";
            this.mensaje_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // direccion_lbl
            // 
            this.direccion_lbl.BackColor = System.Drawing.Color.White;
            this.direccion_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccion_lbl.Location = new System.Drawing.Point(132, 60);
            this.direccion_lbl.Name = "direccion_lbl";
            this.direccion_lbl.Size = new System.Drawing.Size(258, 20);
            this.direccion_lbl.TabIndex = 3;
            this.direccion_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cuadra_txt.Location = new System.Drawing.Point(132, 85);
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
            this.codigoVias_txt.Location = new System.Drawing.Point(132, 35);
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dirección:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cuadra_lbl
            // 
            this.cuadra_lbl.BackColor = System.Drawing.Color.White;
            this.cuadra_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cuadra_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuadra_lbl.Location = new System.Drawing.Point(36, 85);
            this.cuadra_lbl.Name = "cuadra_lbl";
            this.cuadra_lbl.Size = new System.Drawing.Size(90, 20);
            this.cuadra_lbl.TabIndex = 11;
            this.cuadra_lbl.Text = "Cuadra:";
            this.cuadra_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // codVias_lbl
            // 
            this.codVias_lbl.BackColor = System.Drawing.Color.White;
            this.codVias_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codVias_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codVias_lbl.Location = new System.Drawing.Point(36, 35);
            this.codVias_lbl.Name = "codVias_lbl";
            this.codVias_lbl.Size = new System.Drawing.Size(90, 20);
            this.codVias_lbl.TabIndex = 9;
            this.codVias_lbl.Text = "Código de Via:";
            this.codVias_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Modulo_Componente_Urbano_Mobiliario_Urbano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(419, 147);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cuadra_lbl);
            this.Controls.Add(this.codVias_lbl);
            this.Controls.Add(this.direccion_lbl);
            this.Controls.Add(this.cuadra_txt);
            this.Controls.Add(this.codigoVias_txt);
            this.Controls.Add(this.aceptar_btn);
            this.Controls.Add(this.mensaje_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Modulo_Componente_Urbano_Mobiliario_Urbano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Modulo_Componente_Urbano_Mobiliario_Urbano_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aceptar_btn;
        internal System.Windows.Forms.Label mensaje_lbl;
        internal System.Windows.Forms.Label direccion_lbl;
        internal TextBoxConFormato.FormattedTextBox cuadra_txt;
        internal TextBoxConFormato.FormattedTextBox codigoVias_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cuadra_lbl;
        private System.Windows.Forms.Label codVias_lbl;
    }
}