namespace Formularios
{
    partial class Detalles
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.zoom_btn = new System.Windows.Forms.Button();
            this.cancelar_btn = new System.Windows.Forms.Button();
            this.categoria1_cbo = new System.Windows.Forms.ComboBox();
            this.buscar1_txt = new System.Windows.Forms.TextBox();
            this.categoria1_lbl = new System.Windows.Forms.Label();
            this.buscar1_lbl = new System.Windows.Forms.Label();
            this.GEODB_bs = new System.Windows.Forms.BindingSource(this.components);
            this.detalles_dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GEODB_bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalles_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // zoom_btn
            // 
            this.zoom_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.zoom_btn.Location = new System.Drawing.Point(409, 349);
            this.zoom_btn.Name = "zoom_btn";
            this.zoom_btn.Size = new System.Drawing.Size(65, 33);
            this.zoom_btn.TabIndex = 5;
            this.zoom_btn.Text = "Ir ";
            this.zoom_btn.UseVisualStyleBackColor = true;
            this.zoom_btn.Click += new System.EventHandler(this.zoom_btn_Click);
            // 
            // cancelar_btn
            // 
            this.cancelar_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelar_btn.Location = new System.Drawing.Point(480, 349);
            this.cancelar_btn.Name = "cancelar_btn";
            this.cancelar_btn.Size = new System.Drawing.Size(69, 33);
            this.cancelar_btn.TabIndex = 6;
            this.cancelar_btn.Text = "Cancelar";
            this.cancelar_btn.UseVisualStyleBackColor = true;
            // 
            // categoria1_cbo
            // 
            this.categoria1_cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoria1_cbo.FormattingEnabled = true;
            this.categoria1_cbo.Location = new System.Drawing.Point(67, 12);
            this.categoria1_cbo.Name = "categoria1_cbo";
            this.categoria1_cbo.Size = new System.Drawing.Size(152, 23);
            this.categoria1_cbo.TabIndex = 2;
            this.categoria1_cbo.SelectedIndexChanged += new System.EventHandler(this.categoria1_cbo_SelectedIndexChanged);
            // 
            // buscar1_txt
            // 
            this.buscar1_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buscar1_txt.Location = new System.Drawing.Point(280, 13);
            this.buscar1_txt.Name = "buscar1_txt";
            this.buscar1_txt.Size = new System.Drawing.Size(176, 21);
            this.buscar1_txt.TabIndex = 0;
            this.buscar1_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buscar1_txt_KeyDown);
            // 
            // categoria1_lbl
            // 
            this.categoria1_lbl.AutoSize = true;
            this.categoria1_lbl.Location = new System.Drawing.Point(3, 16);
            this.categoria1_lbl.Name = "categoria1_lbl";
            this.categoria1_lbl.Size = new System.Drawing.Size(64, 15);
            this.categoria1_lbl.TabIndex = 3;
            this.categoria1_lbl.Text = "Categoria:";
            // 
            // buscar1_lbl
            // 
            this.buscar1_lbl.AutoSize = true;
            this.buscar1_lbl.Location = new System.Drawing.Point(225, 16);
            this.buscar1_lbl.Name = "buscar1_lbl";
            this.buscar1_lbl.Size = new System.Drawing.Size(49, 15);
            this.buscar1_lbl.TabIndex = 1;
            this.buscar1_lbl.Text = "Buscar:";
            // 
            // detalles_dgv
            // 
            this.detalles_dgv.AllowUserToAddRows = false;
            this.detalles_dgv.AllowUserToDeleteRows = false;
            this.detalles_dgv.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.detalles_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.detalles_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.detalles_dgv.BackgroundColor = System.Drawing.Color.White;
            this.detalles_dgv.ColumnHeadersHeight = 24;
            this.detalles_dgv.Location = new System.Drawing.Point(1, 42);
            this.detalles_dgv.Name = "detalles_dgv";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detalles_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.detalles_dgv.RowHeadersWidth = 24;
            this.detalles_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detalles_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.detalles_dgv.Size = new System.Drawing.Size(960, 301);
            this.detalles_dgv.TabIndex = 7;
            this.detalles_dgv.CurrentCellChanged += new System.EventHandler(this.detalles_dgv_CurrentCellChanged);
            // 
            // Detalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelar_btn;
            this.ClientSize = new System.Drawing.Size(964, 392);
            this.Controls.Add(this.detalles_dgv);
            this.Controls.Add(this.buscar1_lbl);
            this.Controls.Add(this.categoria1_lbl);
            this.Controls.Add(this.buscar1_txt);
            this.Controls.Add(this.categoria1_cbo);
            this.Controls.Add(this.cancelar_btn);
            this.Controls.Add(this.zoom_btn);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Detalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.detalles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GEODB_bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalles_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.BindingSource GEODB_bs;
        internal System.Windows.Forms.Button zoom_btn;
        internal System.Windows.Forms.Button cancelar_btn;
        internal System.Windows.Forms.ComboBox categoria1_cbo;
        internal System.Windows.Forms.TextBox buscar1_txt;
        internal System.Windows.Forms.Label categoria1_lbl;
        internal System.Windows.Forms.Label buscar1_lbl;
        internal System.Windows.Forms.DataGridView detalles_dgv;

    }
}