namespace Formularios
{
    partial class Equipamiento_Urbano
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
            this.nombreEquipamientoUrbano_lbl = new System.Windows.Forms.Label();
            this.tipoEquipamientoUrbano_txt = new TextBoxConFormato.FormattedTextBox();
            this.codigoUsos_txt = new TextBoxConFormato.FormattedTextBox();
            this.codigoUsos_lbl = new System.Windows.Forms.Label();
            this.tipoEquipamientoUrbano_lbl = new System.Windows.Forms.Label();
            this.nombreEquipamientoUrbano_txt = new TextBoxConFormato.FormattedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descripcionUsos_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sector_lbl = new System.Windows.Forms.Label();
            this.manzana_lbl = new System.Windows.Forms.Label();
            this.lote_lbl = new System.Windows.Forms.Label();
            this.lote_txt = new TextBoxConFormato.FormattedTextBox();
            this.label113 = new System.Windows.Forms.Label();
            this.edifica_txt = new TextBoxConFormato.FormattedTextBox();
            this.edifica_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guardar_btn
            // 
            this.guardar_btn.Enabled = false;
            this.guardar_btn.Location = new System.Drawing.Point(247, 307);
            this.guardar_btn.Name = "guardar_btn";
            this.guardar_btn.Size = new System.Drawing.Size(75, 23);
            this.guardar_btn.TabIndex = 17;
            this.guardar_btn.Text = "&Guardar";
            this.guardar_btn.UseVisualStyleBackColor = true;
            this.guardar_btn.Click += new System.EventHandler(this.guardar_btn_Click);
            // 
            // nombreEquipamientoUrbano_lbl
            // 
            this.nombreEquipamientoUrbano_lbl.BackColor = System.Drawing.Color.White;
            this.nombreEquipamientoUrbano_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombreEquipamientoUrbano_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreEquipamientoUrbano_lbl.Location = new System.Drawing.Point(10, 153);
            this.nombreEquipamientoUrbano_lbl.Name = "nombreEquipamientoUrbano_lbl";
            this.nombreEquipamientoUrbano_lbl.Size = new System.Drawing.Size(177, 20);
            this.nombreEquipamientoUrbano_lbl.TabIndex = 12;
            this.nombreEquipamientoUrbano_lbl.Text = "Nombre Equipamiento Urbano:";
            this.nombreEquipamientoUrbano_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tipoEquipamientoUrbano_txt
            // 
            this.tipoEquipamientoUrbano_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tipoEquipamientoUrbano_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tipoEquipamientoUrbano_txt.BackColor = System.Drawing.Color.White;
            this.tipoEquipamientoUrbano_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tipoEquipamientoUrbano_txt.Decimals = ((byte)(0));
            this.tipoEquipamientoUrbano_txt.DecSeparator = '.';
            this.tipoEquipamientoUrbano_txt.ForeColor = System.Drawing.Color.Black;
            this.tipoEquipamientoUrbano_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.tipoEquipamientoUrbano_txt.Location = new System.Drawing.Point(193, 181);
            this.tipoEquipamientoUrbano_txt.MaxLength = 2;
            this.tipoEquipamientoUrbano_txt.Name = "tipoEquipamientoUrbano_txt";
            this.tipoEquipamientoUrbano_txt.Size = new System.Drawing.Size(129, 20);
            this.tipoEquipamientoUrbano_txt.TabIndex = 6;
            this.tipoEquipamientoUrbano_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipoEquipamientoUrbano_txt.UserValues = "";
            this.tipoEquipamientoUrbano_txt.TextChanged += new System.EventHandler(this.validar_TextChanged);
            this.tipoEquipamientoUrbano_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            this.tipoEquipamientoUrbano_txt.Leave += new System.EventHandler(this.tipoEquipamientoUrbano_txt_Leave);
            // 
            // codigoUsos_txt
            // 
            this.codigoUsos_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.codigoUsos_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.codigoUsos_txt.BackColor = System.Drawing.Color.White;
            this.codigoUsos_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigoUsos_txt.Decimals = ((byte)(0));
            this.codigoUsos_txt.DecSeparator = '.';
            this.codigoUsos_txt.ForeColor = System.Drawing.Color.Black;
            this.codigoUsos_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.codigoUsos_txt.Location = new System.Drawing.Point(193, 209);
            this.codigoUsos_txt.MaxLength = 6;
            this.codigoUsos_txt.Name = "codigoUsos_txt";
            this.codigoUsos_txt.Size = new System.Drawing.Size(338, 20);
            this.codigoUsos_txt.TabIndex = 8;
            this.codigoUsos_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codigoUsos_txt.UserValues = "";
            this.codigoUsos_txt.TextChanged += new System.EventHandler(this.validar_TextChanged);
            this.codigoUsos_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            this.codigoUsos_txt.Leave += new System.EventHandler(this.codigoUsos_txt_Leave);
            // 
            // codigoUsos_lbl
            // 
            this.codigoUsos_lbl.BackColor = System.Drawing.Color.White;
            this.codigoUsos_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigoUsos_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoUsos_lbl.Location = new System.Drawing.Point(10, 209);
            this.codigoUsos_lbl.Name = "codigoUsos_lbl";
            this.codigoUsos_lbl.Size = new System.Drawing.Size(177, 20);
            this.codigoUsos_lbl.TabIndex = 3;
            this.codigoUsos_lbl.Text = "Código de Usos:";
            this.codigoUsos_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tipoEquipamientoUrbano_lbl
            // 
            this.tipoEquipamientoUrbano_lbl.BackColor = System.Drawing.Color.White;
            this.tipoEquipamientoUrbano_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tipoEquipamientoUrbano_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoEquipamientoUrbano_lbl.Location = new System.Drawing.Point(10, 181);
            this.tipoEquipamientoUrbano_lbl.Name = "tipoEquipamientoUrbano_lbl";
            this.tipoEquipamientoUrbano_lbl.Size = new System.Drawing.Size(177, 20);
            this.tipoEquipamientoUrbano_lbl.TabIndex = 11;
            this.tipoEquipamientoUrbano_lbl.Text = "Tipo de Equipamiento Urbano:";
            this.tipoEquipamientoUrbano_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nombreEquipamientoUrbano_txt
            // 
            this.nombreEquipamientoUrbano_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nombreEquipamientoUrbano_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.nombreEquipamientoUrbano_txt.BackColor = System.Drawing.Color.White;
            this.nombreEquipamientoUrbano_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombreEquipamientoUrbano_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreEquipamientoUrbano_txt.Decimals = ((byte)(0));
            this.nombreEquipamientoUrbano_txt.DecSeparator = '.';
            this.nombreEquipamientoUrbano_txt.ForeColor = System.Drawing.Color.Black;
            this.nombreEquipamientoUrbano_txt.Format = TextBoxConFormato.tbFormats.SpacedAlphaNumeric;
            this.nombreEquipamientoUrbano_txt.Location = new System.Drawing.Point(193, 153);
            this.nombreEquipamientoUrbano_txt.MaxLength = 50;
            this.nombreEquipamientoUrbano_txt.Name = "nombreEquipamientoUrbano_txt";
            this.nombreEquipamientoUrbano_txt.Size = new System.Drawing.Size(338, 20);
            this.nombreEquipamientoUrbano_txt.TabIndex = 5;
            this.nombreEquipamientoUrbano_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nombreEquipamientoUrbano_txt.UserValues = "";
            this.nombreEquipamientoUrbano_txt.TextChanged += new System.EventHandler(this.validar_TextChanged);
            this.nombreEquipamientoUrbano_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            this.nombreEquipamientoUrbano_txt.Leave += new System.EventHandler(this.nombreEquipamientoUrbano_txt_Leave);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Descripción:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // descripcionUsos_lbl
            // 
            this.descripcionUsos_lbl.BackColor = System.Drawing.Color.White;
            this.descripcionUsos_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descripcionUsos_lbl.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcionUsos_lbl.Location = new System.Drawing.Point(10, 261);
            this.descripcionUsos_lbl.Name = "descripcionUsos_lbl";
            this.descripcionUsos_lbl.Size = new System.Drawing.Size(521, 39);
            this.descripcionUsos_lbl.TabIndex = 10;
            this.descripcionUsos_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sector:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Manzana:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sector_lbl
            // 
            this.sector_lbl.BackColor = System.Drawing.Color.White;
            this.sector_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sector_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sector_lbl.Location = new System.Drawing.Point(193, 41);
            this.sector_lbl.Name = "sector_lbl";
            this.sector_lbl.Size = new System.Drawing.Size(75, 20);
            this.sector_lbl.TabIndex = 1;
            this.sector_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // manzana_lbl
            // 
            this.manzana_lbl.BackColor = System.Drawing.Color.White;
            this.manzana_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.manzana_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manzana_lbl.Location = new System.Drawing.Point(193, 69);
            this.manzana_lbl.Name = "manzana_lbl";
            this.manzana_lbl.Size = new System.Drawing.Size(75, 20);
            this.manzana_lbl.TabIndex = 2;
            this.manzana_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lote_lbl
            // 
            this.lote_lbl.BackColor = System.Drawing.Color.White;
            this.lote_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lote_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lote_lbl.Location = new System.Drawing.Point(10, 97);
            this.lote_lbl.Name = "lote_lbl";
            this.lote_lbl.Size = new System.Drawing.Size(177, 20);
            this.lote_lbl.TabIndex = 14;
            this.lote_lbl.Text = "Lote:";
            this.lote_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lote_txt
            // 
            this.lote_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lote_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.lote_txt.BackColor = System.Drawing.Color.White;
            this.lote_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lote_txt.Decimals = ((byte)(0));
            this.lote_txt.DecSeparator = '.';
            this.lote_txt.ForeColor = System.Drawing.Color.Black;
            this.lote_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.lote_txt.Location = new System.Drawing.Point(193, 97);
            this.lote_txt.MaxLength = 3;
            this.lote_txt.Name = "lote_txt";
            this.lote_txt.Size = new System.Drawing.Size(75, 20);
            this.lote_txt.TabIndex = 3;
            this.lote_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lote_txt.UserValues = "";
            this.lote_txt.TextChanged += new System.EventHandler(this.validar_TextChanged);
            this.lote_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            this.lote_txt.Leave += new System.EventHandler(this.lote_txt_Leave);
            // 
            // label113
            // 
            this.label113.BackColor = System.Drawing.Color.Gainsboro;
            this.label113.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label113.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label113.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label113.Location = new System.Drawing.Point(329, 181);
            this.label113.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(81, 20);
            this.label113.TabIndex = 7;
            this.label113.Text = "01 PUBLICA\r\n02 PRIVADA";
            // 
            // edifica_txt
            // 
            this.edifica_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edifica_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edifica_txt.BackColor = System.Drawing.Color.White;
            this.edifica_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edifica_txt.Decimals = ((byte)(0));
            this.edifica_txt.DecSeparator = '.';
            this.edifica_txt.ForeColor = System.Drawing.Color.Black;
            this.edifica_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.edifica_txt.Location = new System.Drawing.Point(193, 125);
            this.edifica_txt.MaxLength = 2;
            this.edifica_txt.Name = "edifica_txt";
            this.edifica_txt.Size = new System.Drawing.Size(75, 20);
            this.edifica_txt.TabIndex = 4;
            this.edifica_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edifica_txt.UserValues = "";
            this.edifica_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            this.edifica_txt.Leave += new System.EventHandler(this.edifica_Leave);
            // 
            // edifica_lbl
            // 
            this.edifica_lbl.BackColor = System.Drawing.Color.White;
            this.edifica_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edifica_lbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edifica_lbl.Location = new System.Drawing.Point(10, 125);
            this.edifica_lbl.Name = "edifica_lbl";
            this.edifica_lbl.Size = new System.Drawing.Size(177, 20);
            this.edifica_lbl.TabIndex = 13;
            this.edifica_lbl.Text = "Edifica:";
            this.edifica_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Equipamiento_Urbano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 364);
            this.Controls.Add(this.edifica_txt);
            this.Controls.Add(this.edifica_lbl);
            this.Controls.Add(this.label113);
            this.Controls.Add(this.lote_txt);
            this.Controls.Add(this.lote_lbl);
            this.Controls.Add(this.manzana_lbl);
            this.Controls.Add(this.sector_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descripcionUsos_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nombreEquipamientoUrbano_txt);
            this.Controls.Add(this.tipoEquipamientoUrbano_lbl);
            this.Controls.Add(this.codigoUsos_lbl);
            this.Controls.Add(this.tipoEquipamientoUrbano_txt);
            this.Controls.Add(this.codigoUsos_txt);
            this.Controls.Add(this.nombreEquipamientoUrbano_lbl);
            this.Controls.Add(this.guardar_btn);
            this.Name = "Equipamiento_Urbano";
            this.Text = "Equipamiento Urbano";
            this.Load += new System.EventHandler(this.equipamiento_urbano_Load);
            this.Controls.SetChildIndex(this.guardar_btn, 0);
            this.Controls.SetChildIndex(this.nombreEquipamientoUrbano_lbl, 0);
            this.Controls.SetChildIndex(this.codigoUsos_txt, 0);
            this.Controls.SetChildIndex(this.tipoEquipamientoUrbano_txt, 0);
            this.Controls.SetChildIndex(this.codigoUsos_lbl, 0);
            this.Controls.SetChildIndex(this.tipoEquipamientoUrbano_lbl, 0);
            this.Controls.SetChildIndex(this.nombreEquipamientoUrbano_txt, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.descripcionUsos_lbl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.sector_lbl, 0);
            this.Controls.SetChildIndex(this.manzana_lbl, 0);
            this.Controls.SetChildIndex(this.lote_lbl, 0);
            this.Controls.SetChildIndex(this.lote_txt, 0);
            this.Controls.SetChildIndex(this.label113, 0);
            this.Controls.SetChildIndex(this.edifica_lbl, 0);
            this.Controls.SetChildIndex(this.edifica_txt, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button guardar_btn;
        private System.Windows.Forms.Label nombreEquipamientoUrbano_lbl;
        internal TextBoxConFormato.FormattedTextBox tipoEquipamientoUrbano_txt;
        internal TextBoxConFormato.FormattedTextBox codigoUsos_txt;
        private System.Windows.Forms.Label codigoUsos_lbl;
        private System.Windows.Forms.Label tipoEquipamientoUrbano_lbl;
        internal TextBoxConFormato.FormattedTextBox nombreEquipamientoUrbano_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lote_lbl;
        internal TextBoxConFormato.FormattedTextBox lote_txt;
        internal System.Windows.Forms.Label sector_lbl;
        internal System.Windows.Forms.Label manzana_lbl;
        private System.Windows.Forms.Label label113;
        internal System.Windows.Forms.Label descripcionUsos_lbl;
        internal TextBoxConFormato.FormattedTextBox edifica_txt;
        private System.Windows.Forms.Label edifica_lbl;
    }
}