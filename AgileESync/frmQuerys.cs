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
    public partial class frmQuerys : Form
    {
        public frmQuerys()
        {
            InitializeComponent();
        }

        private void frmQuerys_Load(object sender, EventArgs e)
        {
            CarregarListTabelas();
        }

        private void CarregarListTabelas()
        {
            cmbTabelaPlataforma.ValueMember = "Nome";
            cmbTabelaPlataforma.DisplayMember = "Descricao";
            cmbTabelaPlataforma.DataSource = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select * from Tabelas order by Ordenacao");
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                GridResultado.DataSource = Geral.agilee.ExecutarQuery(txtQuery.Text);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string tabela_selecionada = cmbTabelaPlataforma.SelectedValue.ToString();

            if (GridResultado.RowCount == 0)
            {
                MessageBox.Show("Não é possivel salvar a query sem resultado!");
                return;
            }

            DialogResult dr = MessageBox.Show("Deseja salvar a query para a tabela " + tabela_selecionada + "?", "Pergunta", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    Geral.banco.ExecutarComando("UPDATE Tabelas SET Query = '" + txtQuery.Text.Replace("'", "\"") + "' WHERE Nome = '" + tabela_selecionada + "'");
                    GravaCamposTabela(tabela_selecionada);
                    MessageBox.Show("Registro atualizado com sucesso!");    
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void GravaCamposTabela(string tabela_selecionada)
        {
            var campos = Geral.banco.LerNoBanco<Dicionario.Campos>("Select * from Campos where Tabela = '" + tabela_selecionada + "'");

            foreach (DataGridViewColumn col in GridResultado.Columns)
            {
                var campo = campos.Where(x => x.Campo == col.Name).FirstOrDefault();

                string original_field = getFieldNameBasedOnQuery(txtQuery.Text, col.Name);

                if (campo == null)
                {
                    Geral.banco.ExecutarComando(string.Format("INSERT INTO Campos (Tabela, Campo, Tipo, Tamanho, CampoERP) values ('{0}', '{1}', '{2}', '{3}', '{4}')", tabela_selecionada, col.Name, col.ValueType.Name, col.Width, original_field));
                }
                else
                {
                    Geral.banco.ExecutarComando(string.Format("UPDATE Campos Set Tipo = '{0}', Tamanho = '{1}', CampoERP = '{2}' where Tabela = '{3}' AND Campo = '{4}'", col.ValueType.Name, col.Width, original_field, tabela_selecionada, col.Name));
                }
            }              
        }

        public string getFieldNameBasedOnQuery(string query, string alias)
        {
            int idx_alias = query.ToUpper().IndexOf(alias + ",");
            string original_field = "";
            int space_count = 0;

            for (int i = 1; i <= idx_alias; i++)
            {
                char l = query[idx_alias - i];

                if (l == ' ')
                {
                    space_count += 1;
                    continue;
                }

                if (l == ',')
                {
                    break;
                }

                original_field = l.ToString() + original_field;    
            }

            original_field = original_field.ToUpper().Replace("SELECT", "").Trim();

            return original_field;
        }

        private void cmbTabelaPlataforma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabela_selecionada = cmbTabelaPlataforma.SelectedValue.ToString();
            txtQuery.Text = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select * from Tabelas").Where(x => x.Nome == tabela_selecionada).FirstOrDefault().Query.Replace("\"", "'");

            GridResultado.DataSource = null;                
        }
    }
}
