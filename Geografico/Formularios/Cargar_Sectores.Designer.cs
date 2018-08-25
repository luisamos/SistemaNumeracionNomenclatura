namespace Formularios
{
    partial class Cargar_Sectores
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
            this.sector_tlst = new WinControls.ListView.TreeListView();
            this.Sector = new WinControls.ListView.ContainerColumnHeader();
            this.cargar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sector_tlst
            // 
            this.sector_tlst.ActivationType = System.Windows.Forms.ItemActivation.OneClick;
            this.sector_tlst.BorderStyle = WinControls.ListView.Enums.BorderStyleType.None;
            this.sector_tlst.CheckBoxes = true;
            this.sector_tlst.CheckBoxSelection = System.Windows.Forms.ItemActivation.OneClick;
            this.sector_tlst.Columns.AddRange(new WinControls.ListView.ContainerColumnHeader[] {
            this.Sector});
            this.sector_tlst.DefaultFolderImages = false;
            this.sector_tlst.DefaultImageIndex = -1;
            this.sector_tlst.DefaultSelectedImageIndex = -1;
            this.sector_tlst.Location = new System.Drawing.Point(65, 35);
            this.sector_tlst.Name = "sector_tlst";
            this.sector_tlst.Nodes.AddRange(new WinControls.ListView.TreeListNode[] {
            treeListNode1});
            this.sector_tlst.ShowRootLines = false;
            this.sector_tlst.Size = new System.Drawing.Size(231, 393);
            this.sector_tlst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.sector_tlst.TabIndex = 2;
            this.sector_tlst.Tag = "";
            // 
            // Sector
            // 
            this.Sector.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sector.Text = "Elegir Sector";
            this.Sector.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Sector.Width = 205;
            // 
            // cargar_btn
            // 
            this.cargar_btn.Location = new System.Drawing.Point(135, 434);
            this.cargar_btn.Name = "cargar_btn";
            this.cargar_btn.Size = new System.Drawing.Size(89, 22);
            this.cargar_btn.TabIndex = 4;
            this.cargar_btn.TabStop = false;
            this.cargar_btn.Text = "&Cargar";
            this.cargar_btn.UseVisualStyleBackColor = true;
            this.cargar_btn.Click += new System.EventHandler(this.cargar_btn_Click);
            // 
            // Cargar_Sectores
            // 
            this.AcceptButton = this.cargar_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 483);
            this.Controls.Add(this.cargar_btn);
            this.Controls.Add(this.sector_tlst);
            this.Name = "Cargar_Sectores";
            this.ShowInTaskbar = false;
            this.Text = "Capa: Sectores";
            this.Load += new System.EventHandler(this.cargar_sectores_Load);
            this.Controls.SetChildIndex(this.sector_tlst, 0);
            this.Controls.SetChildIndex(this.cargar_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinControls.ListView.TreeListView sector_tlst;
        private WinControls.ListView.ContainerColumnHeader Sector;
        private System.Windows.Forms.Button cargar_btn;
    }
}