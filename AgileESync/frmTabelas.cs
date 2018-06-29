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
    public partial class frmTabelas : Form
    {
        public frmTabelas()
        {
            InitializeComponent();
        }

        private void frmTabelas_Load(object sender, EventArgs e)
        {
            CarregarListTabelas();
        }

        private void CarregarListTabelas()
        {
            cmbTabelaPlataforma.ValueMember = "Nome";
            cmbTabelaPlataforma.DisplayMember = "Descricao";
            cmbTabelaPlataforma.DataSource = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select * from Tabelas order by Ordenacao");
        }

        private void cmbTabelaPlataforma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabela_selecionada = cmbTabelaPlataforma.SelectedValue.ToString();

            var tabela = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select Nome, Url, TabelaNomeERP NomeERP, Descricao, Modulo from Tabelas left join Gatilhos on Nome = TabelaNome").Where(x => x.Nome == tabela_selecionada).FirstOrDefault();

            if (tabela != null)
            {
                txtNomeTabela.Text = tabela.Nome;
                txtNomeTabelaERP.Text = tabela.NomeERP;
                txtUrlTabela.Text = tabela.Url;
                txtModuloTabela.Text = tabela.Modulo;
                txtDescricaoTabela.Text = tabela.Descricao;
            }

        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            string tabela_selecionada = cmbTabelaPlataforma.SelectedValue.ToString();

            DialogResult dr = MessageBox.Show("Deseja salvar a configuração para a tabela " + tabela_selecionada + "?", "Pergunta", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    Geral.banco.ExecutarComando("UPDATE Tabelas SET Url = '" + txtUrlTabela.Text + "' WHERE Nome = '" + tabela_selecionada + "'");
                    MessageBox.Show("Registro atualizado com sucesso!");
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
