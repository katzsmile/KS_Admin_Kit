namespace ks_admin
{
    partial class Explorer
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("TestPC");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Library", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Problems");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Troubles");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ilImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.ilImages;
            this.treeView1.Indent = 19;
            this.treeView1.Location = new System.Drawing.Point(0, 24);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "Iconfactory.ico";
            treeNode1.Name = "TestPC";
            treeNode1.SelectedImageKey = "Iconfactory.ico";
            treeNode1.Text = "TestPC";
            treeNode2.Name = "Library";
            treeNode2.Text = "Library";
            treeNode3.ImageKey = "Public Folder.png";
            treeNode3.Name = "Problems";
            treeNode3.SelectedImageKey = "Public Folder.png";
            treeNode3.StateImageKey = "(none)";
            treeNode3.Text = "Problems";
            treeNode4.ImageKey = "Burnable Folder.png";
            treeNode4.Name = "Troubles";
            treeNode4.SelectedImageKey = "Burnable Folder.png";
            treeNode4.Text = "Troubles";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(245, 297);
            this.treeView1.TabIndex = 0;
            // 
            // ilImages
            // 
            this.ilImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilImages.ImageStream")));
            this.ilImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilImages.Images.SetKeyName(0, "Library Folder.png");
            this.ilImages.Images.SetKeyName(1, "Public Folder.png");
            this.ilImages.Images.SetKeyName(2, "Burnable Folder.png");
            this.ilImages.Images.SetKeyName(3, "Iconfactory.ico");
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(245, 322);
            this.Controls.Add(this.treeView1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Explorer";
            this.Padding = new System.Windows.Forms.Padding(0, 24, 0, 1);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "Explorer";
            this.Text = "Explorer";
            this.Load += new System.EventHandler(this.Explorer_Load);
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList ilImages;
    }
}