using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AgileESync
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.listSplash.Items.Clear();
            this.progressSplash.Value = 0;
        }
    }
}
