namespace Formularios
{
    partial class Cargar_Manzanas
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
            WinControls.ListView.TreeListNode treeListNode2 = new WinControls.ListView.TreeListNode("Todos");
            this.cargar_btn = new System.Windows.Forms.Button();
            this.sector_tlst = new WinControls.ListView.TreeListView();
            this.Sector = new WinControls.ListView.ContainerColumnHeader();
            this.manzana_tlst = new WinControls.ListView.TreeListView();
            this.manzana = new WinControls.ListView.ContainerColumnHeader();
            this.expandirManzana_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cargar_btn
            // 
            this.cargar_btn.Location = new System.Drawing.Point(239, 478);
            this.cargar_btn.Name = "cargar_btn";
            this.cargar_btn.Size = new System.Drawing.Size(89, 22);
            this.cargar_btn.TabIndex = 7;
            this.cargar_btn.TabStop = false;
            this.cargar_btn.Text = "&Cargar";
            this.cargar_btn.UseVisualStyleBackColor = true;
            this.cargar_btn.Click += new System.EventHandler(this.cargar_btn_Click);
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
            this.sector_tlst.Location = new System.Drawing.Point(12, 35);
            this.sector_tlst.Name = "sector_tlst";
            this.sector_tlst.Nodes.AddRange(new WinControls.ListView.TreeListNode[] {
            treeListNode1});
            this.sector_tlst.ShowRootLines = false;
            this.sector_tlst.Size = new System.Drawing.Size(262, 437);
            this.sector_tlst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.sector_tlst.TabIndex = 8;
            this.sector_tlst.Tag = "";
            this.sector_tlst.BeforeCheckStateChanged += new WinControls.ListView.Delegates.ContainerListViewCancelEventHandler(this.sector_BeforeCheckStateChanged);
            // 
            // Sector
            // 
            this.Sector.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sector.Text = "Elegir Sector";
            this.Sector.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Sector.Width = 241;
            // 
            // manzana_tlst
            // 
            this.manzana_tlst.ActivationType = System.Windows.Forms.ItemActivation.OneClick;
            this.manzana_tlst.BorderStyle = WinControls.ListView.Enums.BorderStyleType.None;
            this.manzana_tlst.CheckBoxes = true;
            this.manzana_tlst.CheckBoxSelection = System.Windows.Forms.ItemActivation.OneClick;
            this.manzana_tlst.Columns.AddRange(new WinControls.ListView.ContainerColumnHeader[] {
            this.manzana});
            this.manzana_tlst.DefaultFolderImages = false;
            this.manzana_tlst.DefaultImageIndex = -1;
            this.manzana_tlst.DefaultSelectedImageIndex = -1;
            this.manzana_tlst.Location = new System.Drawing.Point(273, 35);
            this.manzana_tlst.Name = "manzana_tlst";
            treeListNode2.AllowSelection = false;
            this.manzana_tlst.Nodes.AddRange(new WinControls.ListView.TreeListNode[] {
            treeListNode2});
            this.manzana_tlst.ShowRootLines = false;
            this.manzana_tlst.Size = new System.Drawing.Size(265, 437);
            this.manzana_tlst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.manzana_tlst.TabIndex = 9;
            this.manzana_tlst.Tag = "";
            // 
            // manzana
            // 
            this.manzana.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manzana.Text = "Elegir Manzana";
            this.manzana.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.manzana.Width = 244;
            // 
            // expandirManzana_btn
            // 
            this.expandirManzana_btn.Location = new System.Drawing.Point(544, 35);
            this.expandirManzana_btn.Name = "expandirManzana_btn";
            this.expandirManzana_btn.Size = new System.Drawing.Size(20, 21);
            this.expandirManzana_btn.TabIndex = 10;
            this.expandirManzana_btn.Text = "+";
            this.expandirManzana_btn.UseVisualStyleBackColor = true;
            this.expandirManzana_btn.Click += new System.EventHandler(this.expandirManzana_btn_Click);
            // 
            // Cargar_Manzanas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 523);
            this.Controls.Add(this.manzana_tlst);
            this.Controls.Add(this.expandirManzana_btn);
            this.Controls.Add(this.sector_tlst);
            this.Controls.Add(this.cargar_btn);
            this.Name = "Cargar_Manzanas";
            this.Text = "Capa: Manzanas";
            this.Load += new System.EventHandler(this.cargar_manzanas_Load);
            this.Controls.SetChildIndex(this.cargar_btn, 0);
            this.Controls.SetChildIndex(this.sector_tlst, 0);
            this.Controls.SetChildIndex(this.expandirManzana_btn, 0);
            this.Controls.SetChildIndex(this.manzana_tlst, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cargar_btn;
        private WinControls.ListView.TreeListView sector_tlst;
        private WinControls.ListView.ContainerColumnHeader Sector;
        private WinControls.ListView.TreeListView manzana_tlst;
        private WinControls.ListView.ContainerColumnHeader manzana;
        private System.Windows.Forms.Button expandirManzana_btn;
    }
}