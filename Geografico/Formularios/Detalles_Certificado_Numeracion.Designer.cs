namespace Formularios
{
    partial class Detalles_Certificado_Numeracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detalles_Certificado_Numeracion));
            this.sigla_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fecha_txt = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numeroExpediente_txt = new System.Windows.Forms.TextBox();
            this.codigoVia_txt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.direccion_txt = new System.Windows.Forms.Label();
            this.fotografiaDigital_pb = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.propietario_txt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.añoFotografiaDigital_txt = new TextBoxConFormato.FormattedTextBox();
            this.cuerpo_txt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numeroRecibo_txt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.observaciones_txt = new System.Windows.Forms.TextBox();
            this.aceptar_btn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.abrirFotografia = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoPuerta_txt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fotografiaDigital_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // sigla_txt
            // 
            this.sigla_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_txt.Location = new System.Drawing.Point(462, 67);
            this.sigla_txt.MaxLength = 20;
            this.sigla_txt.Name = "sigla_txt";
            this.sigla_txt.Size = new System.Drawing.Size(159, 20);
            this.sigla_txt.TabIndex = 9;
            this.sigla_txt.Text = "ODU-MPC";
            this.sigla_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(335, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sigla:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(335, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fecha:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fecha_txt
            // 
            this.fecha_txt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_txt.Location = new System.Drawing.Point(462, 117);
            this.fecha_txt.Name = "fecha_txt";
            this.fecha_txt.Size = new System.Drawing.Size(159, 20);
            this.fecha_txt.TabIndex = 13;
            this.fecha_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(335, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nro. de Expediente:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(335, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Código de la Vía:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numeroExpediente_txt
            // 
            this.numeroExpediente_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numeroExpediente_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numeroExpediente_txt.Location = new System.Drawing.Point(462, 92);
            this.numeroExpediente_txt.MaxLength = 100;
            this.numeroExpediente_txt.Name = "numeroExpediente_txt";
            this.numeroExpediente_txt.Size = new System.Drawing.Size(159, 20);
            this.numeroExpediente_txt.TabIndex = 11;
            this.numeroExpediente_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // codigoVia_txt
            // 
            this.codigoVia_txt.BackColor = System.Drawing.Color.White;
            this.codigoVia_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigoVia_txt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoVia_txt.Location = new System.Drawing.Point(462, 142);
            this.codigoVia_txt.Name = "codigoVia_txt";
            this.codigoVia_txt.Size = new System.Drawing.Size(159, 20);
            this.codigoVia_txt.TabIndex = 15;
            this.codigoVia_txt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(335, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Dirección:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // direccion_txt
            // 
            this.direccion_txt.BackColor = System.Drawing.Color.White;
            this.direccion_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion_txt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccion_txt.Location = new System.Drawing.Point(335, 192);
            this.direccion_txt.Name = "direccion_txt";
            this.direccion_txt.Size = new System.Drawing.Size(286, 33);
            this.direccion_txt.TabIndex = 17;
            this.direccion_txt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fotografiaDigital_pb
            // 
            this.fotografiaDigital_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fotografiaDigital_pb.Location = new System.Drawing.Point(11, 67);
            this.fotografiaDigital_pb.Name = "fotografiaDigital_pb";
            this.fotografiaDigital_pb.Size = new System.Drawing.Size(314, 258);
            this.fotografiaDigital_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotografiaDigital_pb.TabIndex = 420;
            this.fotografiaDigital_pb.TabStop = false;
            this.fotografiaDigital_pb.Click += new System.EventHandler(this.fotografiaDigital_pb_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(313, 23);
            this.label9.TabIndex = 7;
            this.label9.Text = "Fotografía:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // propietario_txt
            // 
            this.propietario_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propietario_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.propietario_txt.Location = new System.Drawing.Point(123, 408);
            this.propietario_txt.MaxLength = 100;
            this.propietario_txt.Name = "propietario_txt";
            this.propietario_txt.Size = new System.Drawing.Size(498, 20);
            this.propietario_txt.TabIndex = 0;
            this.propietario_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(12, 327);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 24;
            this.label11.Text = "Cuerpo:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(404, 230);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Año:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // añoFotografiaDigital_txt
            // 
            this.añoFotografiaDigital_txt.BackColor = System.Drawing.Color.White;
            this.añoFotografiaDigital_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.añoFotografiaDigital_txt.Decimals = ((byte)(0));
            this.añoFotografiaDigital_txt.DecSeparator = '.';
            this.añoFotografiaDigital_txt.Font = new System.Drawing.Font("Arial", 8.25F);
            this.añoFotografiaDigital_txt.ForeColor = System.Drawing.Color.Black;
            this.añoFotografiaDigital_txt.Format = TextBoxConFormato.tbFormats.UnsignedNumber;
            this.añoFotografiaDigital_txt.Location = new System.Drawing.Point(462, 230);
            this.añoFotografiaDigital_txt.MaxLength = 4;
            this.añoFotografiaDigital_txt.Name = "añoFotografiaDigital_txt";
            this.añoFotografiaDigital_txt.Size = new System.Drawing.Size(60, 20);
            this.añoFotografiaDigital_txt.TabIndex = 19;
            this.añoFotografiaDigital_txt.UserValues = "";
            this.añoFotografiaDigital_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // cuerpo_txt
            // 
            this.cuerpo_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cuerpo_txt.Location = new System.Drawing.Point(12, 351);
            this.cuerpo_txt.MaxLength = 8000;
            this.cuerpo_txt.Multiline = true;
            this.cuerpo_txt.Name = "cuerpo_txt";
            this.cuerpo_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cuerpo_txt.Size = new System.Drawing.Size(609, 51);
            this.cuerpo_txt.TabIndex = 25;
            this.cuerpo_txt.Text = resources.GetString("cuerpo_txt.Text");
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(335, 255);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "Número de Recibo:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numeroRecibo_txt
            // 
            this.numeroRecibo_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numeroRecibo_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numeroRecibo_txt.Location = new System.Drawing.Point(462, 255);
            this.numeroRecibo_txt.MaxLength = 100;
            this.numeroRecibo_txt.Name = "numeroRecibo_txt";
            this.numeroRecibo_txt.Size = new System.Drawing.Size(159, 20);
            this.numeroRecibo_txt.TabIndex = 21;
            this.numeroRecibo_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(13, 432);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 23);
            this.label14.TabIndex = 1;
            this.label14.Text = "Observaciones:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // observaciones_txt
            // 
            this.observaciones_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.observaciones_txt.Location = new System.Drawing.Point(12, 458);
            this.observaciones_txt.MaxLength = 300;
            this.observaciones_txt.Multiline = true;
            this.observaciones_txt.Name = "observaciones_txt";
            this.observaciones_txt.Size = new System.Drawing.Size(609, 46);
            this.observaciones_txt.TabIndex = 2;
            this.observaciones_txt.Text = "(*) Ninguna";
            this.observaciones_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // aceptar_btn
            // 
            this.aceptar_btn.Location = new System.Drawing.Point(282, 508);
            this.aceptar_btn.Name = "aceptar_btn";
            this.aceptar_btn.Size = new System.Drawing.Size(75, 23);
            this.aceptar_btn.TabIndex = 3;
            this.aceptar_btn.Text = "&Guardar";
            this.aceptar_btn.UseVisualStyleBackColor = true;
            this.aceptar_btn.Click += new System.EventHandler(this.aceptar_btn_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(13, 408);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Propietario:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // abrirFotografia
            // 
            this.abrirFotografia.AddExtension = false;
            this.abrirFotografia.Filter = "ImAgenes|*.jpg;*.gif;*.png;*.bmp|Todos (*.*)|*.*";
            this.abrirFotografia.Title = "Abrir FotografIa";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(335, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tipo de Puerta:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tipoPuerta_txt
            // 
            this.tipoPuerta_txt.BackColor = System.Drawing.Color.White;
            this.tipoPuerta_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tipoPuerta_txt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoPuerta_txt.Location = new System.Drawing.Point(462, 280);
            this.tipoPuerta_txt.Name = "tipoPuerta_txt";
            this.tipoPuerta_txt.Size = new System.Drawing.Size(60, 20);
            this.tipoPuerta_txt.TabIndex = 23;
            this.tipoPuerta_txt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Detalles_Certificado_Numeracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(627, 555);
            this.Controls.Add(this.tipoPuerta_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.observaciones_txt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numeroRecibo_txt);
            this.Controls.Add(this.aceptar_btn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cuerpo_txt);
            this.Controls.Add(this.añoFotografiaDigital_txt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.propietario_txt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fotografiaDigital_pb);
            this.Controls.Add(this.direccion_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.codigoVia_txt);
            this.Controls.Add(this.numeroExpediente_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fecha_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sigla_txt);
            this.Name = "Detalles_Certificado_Numeracion";
            this.Text = "Detalles, Certificado Numeración";
            this.Load += new System.EventHandler(this.detalles_certificado_numeracion_Load);
            this.Controls.SetChildIndex(this.sigla_txt, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.fecha_txt, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.numeroExpediente_txt, 0);
            this.Controls.SetChildIndex(this.codigoVia_txt, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.direccion_txt, 0);
            this.Controls.SetChildIndex(this.fotografiaDigital_pb, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.propietario_txt, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.añoFotografiaDigital_txt, 0);
            this.Controls.SetChildIndex(this.cuerpo_txt, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.aceptar_btn, 0);
            this.Controls.SetChildIndex(this.numeroRecibo_txt, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.observaciones_txt, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tipoPuerta_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fotografiaDigital_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sigla_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fecha_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numeroExpediente_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox fotografiaDigital_pb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox propietario_txt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private TextBoxConFormato.FormattedTextBox añoFotografiaDigital_txt;
        private System.Windows.Forms.TextBox cuerpo_txt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox numeroRecibo_txt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox observaciones_txt;
        private System.Windows.Forms.Button aceptar_btn;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.OpenFileDialog abrirFotografia;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label codigoVia_txt;
        protected System.Windows.Forms.Label direccion_txt;
        protected System.Windows.Forms.Label tipoPuerta_txt;
    }
}