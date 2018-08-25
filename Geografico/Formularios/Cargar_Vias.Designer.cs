namespace Formularios
{
    partial class Cargar_Vias
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
            WinControls.ListView.TreeListNode treeListNode1 = new WinControls.ListView.TreeListNode("Todos");
            this.cargar_btn = new System.Windows.Forms.Button();
            this.vias_tlst = new WinControls.ListView.TreeListView();
            this.ViasF = new WinControls.ListView.ContainerColumnHeader();
            this.SuspendLayout();
            // 
            // cargar_btn
            // 
            this.cargar_btn.Location = new System.Drawing.Point(123, 456);
            this.cargar_btn.Name = "cargar_btn";
            this.cargar_btn.Size = new System.Drawing.Size(89, 22);
            this.cargar_btn.TabIndex = 4;
            this.cargar_btn.TabStop = false;
            this.cargar_btn.Text = "&Cargar";
            this.cargar_btn.UseVisualStyleBackColor = true;
            this.cargar_btn.Click += new System.EventHandler(this.cargar_btn_Click);
            // 
            // vias_tlst
            // 
            this.vias_tlst.ActivationType = System.Windows.Forms.ItemActivation.OneClick;
            this.vias_tlst.BorderStyle = WinControls.ListView.Enums.BorderStyleType.None;
            this.vias_tlst.CheckBoxes = true;
            this.vias_tlst.CheckBoxSelection = System.Windows.Forms.ItemActivation.OneClick;
            this.vias_tlst.Columns.AddRange(new WinControls.ListView.ContainerColumnHeader[] {
            this.ViasF});
            this.vias_tlst.DefaultFolderImages = false;
            this.vias_tlst.DefaultImageIndex = -1;
            this.vias_tlst.DefaultSelectedImageIndex = -1;
            this.vias_tlst.Location = new System.Drawing.Point(23, 35);
            this.vias_tlst.Name = "vias_tlst";
            treeListNode1.AllowSelection = false;
            this.vias_tlst.Nodes.AddRange(new WinControls.ListView.TreeListNode[] {
            treeListNode1});
            this.vias_tlst.ShowRootLines = false;
            this.vias_tlst.Size = new System.Drawing.Size(292, 417);
            this.vias_tlst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.vias_tlst.TabIndex = 5;
            this.vias_tlst.Tag = "";
            // 
            // ViasF
            // 
            this.ViasF.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViasF.Text = "Elegir Eje de Vias";
            this.ViasF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ViasF.Width = 271;
            // 
            // Cargar_Vias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(321, 503);
            this.Controls.Add(this.vias_tlst);
            this.Controls.Add(this.cargar_btn);
            this.Name = "Cargar_Vias";
            this.ShowInTaskbar = false;
            this.Text = "Capa: Vias";
            this.Load += new System.EventHandler(this.cargar_vias_Load);
            this.Controls.SetChildIndex(this.cargar_btn, 0);
            this.Controls.SetChildIndex(this.vias_tlst, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cargar_btn;
        private WinControls.ListView.TreeListView vias_tlst;
        private WinControls.ListView.ContainerColumnHeader ViasF;
    }
}