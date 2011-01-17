using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ks_admin
{
    public partial class Explorer : ToolWindow
    {
        public Explorer()
        {
            InitializeComponent();
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            //treeView1.RightToLeftLayout = RightToLeftLayout;
        }

        private void Explorer_Load(object sender, EventArgs e)
        {

        }
    }
}