using Amazon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgileESync
{
    public partial class frmConfiguracao : Form
    {
        public frmConfiguracao()
        {
            InitializeComponent();
        }

        public void CarregarConfiguracao()
        {
            AgileESyncConfig.CarregarConfig(this);
        }

        private void btnSalvarConfiguracao_Click(object sender, EventArgs e)
        {
            try
            {
                AgileESyncConfig.SalvarConfig(this);
                MessageBox.Show("Configuração Gravada com Sucesso!");    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmConfiguracao_Load(object sender, EventArgs e)
        {
            CarregarAWSEndPoints();
            CarregarConfiguracao();
        }

        private void CarregarAWSEndPoints()
        {
            cmbRegionEndpoint.DisplayMember = "SystemName";
            cmbRegionEndpoint.ValueMember = "SystemName";
            cmbRegionEndpoint.DataSource = RegionEndpoint.EnumerableAllRegions;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnImagensPath_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
            if (directchoosedlg.ShowDialog() == DialogResult.OK)
            {
                folderPath = directchoosedlg.SelectedPath;
            }

            txtImagensPath.Text = folderPath;
        }
    }
}
