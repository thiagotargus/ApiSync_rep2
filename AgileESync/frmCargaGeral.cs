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
    public partial class frmCargaGeral : Form
    {
        DataTable dtFiltro;
        List<Dicionario.Campos> list_campos_avulso;

        public frmCargaGeral()
        {
            InitializeComponent();
        }

        private void frmCargaGeral_Load(object sender, EventArgs e)
        {
            CarregarListTabelas();

            dtFiltro = new DataTable();

            dtFiltro.Columns.Add("ID");
            dtFiltro.Columns.Add("CONJUNCAO");
            dtFiltro.Columns.Add("CAMPO");
            dtFiltro.Columns.Add("CONDICAO");
            dtFiltro.Columns.Add("COMPARACAO");

            gridFiltros.AutoGenerateColumns = false;

            list_campos_avulso = new List<Dicionario.Campos>();
        }

        private void CarregarListTabelas()
        {
            cmbTabelaPlataforma.ValueMember = "Nome";
            cmbTabelaPlataforma.DisplayMember = "Nome";
            cmbTabelaPlataforma.DataSource = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select * from Tabelas order by Cast(Ordenacao As INT) ");
        }

        private void CarregarCamposTabela()
        {
            if (cmbTabelaPlataforma.SelectedValue != null)
            {
                cmbCamposTabela.ValueMember = "Campo";
                cmbCamposTabela.DisplayMember = "Campo";
                var campos = Geral.banco.LerNoBanco<Dicionario.Campos>("Select * from Campos where Tabela = '" + cmbTabelaPlataforma.SelectedValue.ToString() + "'");

                Dicionario.Campos campo_rownum = new Dicionario.Campos();
                campo_rownum.Campo = "ROWNUM";
                campo_rownum.CampoERP = "ROWNUM";
                campo_rownum.Tabela = cmbTabelaPlataforma.SelectedValue.ToString();

                campos.Add(campo_rownum);

                cmbCamposTabela.DataSource = campos;
            }

        }

        private void btnAddFiltro_Click(object sender, EventArgs e)
        {
            DataRow row = dtFiltro.NewRow();
            Dicionario.Campos campo_avulso;

            if (dtFiltro.Rows.Count > 0)
            {
                if (cmbConjuncao.Text == "")
                {
                    MessageBox.Show("É obrigatório selecionar a conjunção!");
                    return;
                }
            }

            row["ID"] = dtFiltro.Rows.Count + 1;

            var campos = Geral.banco.LerNoBanco<Dicionario.Campos>("Select * from Campos where Tabela = '" + cmbTabelaPlataforma.SelectedValue.ToString() + "'");

            if (campos.Where(x => x.Campo == cmbCamposTabela.Text).Count() == 0)
            {
                DialogResult dr = MessageBox.Show("Deseja filtrar utilizando um campo avulso " + cmbCamposTabela.Text + "? (É necessário que o campo exista na query)", "Pergunta", MessageBoxButtons.YesNo);

                if (dr == DialogResult.No)
                    return;

                campo_avulso = new Dicionario.Campos();
                campo_avulso.Campo = cmbCamposTabela.Text;
                campo_avulso.CampoERP = cmbCamposTabela.Text;
                campo_avulso.Tabela = cmbTabelaPlataforma.SelectedValue.ToString();

                list_campos_avulso.Add(campo_avulso);

                row["CAMPO"] = cmbCamposTabela.Text;
            }
            else
            {
                row["CAMPO"] = cmbCamposTabela.SelectedValue.ToString();
            }

            row["CONDICAO"] = cmbCondicao.Text.ToString();
            row["COMPARACAO"] = txtComparacao.Text;

            if (dtFiltro.Rows.Count > 0)
            {
                row["CONJUNCAO"] = cmbConjuncao.Text;
            }

            dtFiltro.Rows.Add(row);

            gridFiltros.DataSource = dtFiltro;
        }

        private void cmbTabelaPlataforma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCamposTabela();
        }

        private void gridFiltros_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                DeleteFiltro();
            }
        }

        private void DeleteFiltro()
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void gridFiltros_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    gridFiltros.CurrentCell = gridFiltros.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    gridFiltros.Rows[e.RowIndex].Selected = true;
                    gridFiltros.Focus();

                    var selectedBiodataId = gridFiltros.Rows[e.RowIndex].Cells[1].Value;

                    DataRow[] selectedrows = dtFiltro.Select(string.Format("ID = '{0}'", gridFiltros.Rows[e.RowIndex].Cells["ID"].Value));

                    
                    //the best way is:
                    for (int i = selectedrows.Length - 1; i >= 0; i--)
                    {
                        dtFiltro.Rows.Remove(selectedrows[i]);
                    }
                    //then with a dataset you need to accept changes
                    //(depending on your update strategy..)
                    dtFiltro.AcceptChanges();

                    gridFiltros.DataSource = dtFiltro;

                }
                catch (Exception)
                {

                }
            }
        }

        private void btnDoFilter_Click(object sender, EventArgs e)
        {
            var tabela = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select * from Tabelas where Nome = '" + cmbTabelaPlataforma.SelectedValue.ToString() + "'").FirstOrDefault();

            if (tabela == null)
            {
                MessageBox.Show("Configuração para a tabela " + cmbTabelaPlataforma.SelectedValue.ToString() + " não encontrada!");
                return;
            }

            var campos = Geral.banco.LerNoBanco<Dicionario.Campos>("Select * from Campos where Tabela = '" + cmbTabelaPlataforma.SelectedValue.ToString() + "'");

            Dicionario.Campos campo_rownum = new Dicionario.Campos();
            campo_rownum.Campo = "ROWNUM";
            campo_rownum.CampoERP = "ROWNUM";
            campo_rownum.Tabela = cmbTabelaPlataforma.SelectedValue.ToString();

            campos.Add(campo_rownum);


            if (list_campos_avulso != null)
            {
                foreach (var campo_avulso in list_campos_avulso)
                {
                    campos.Add(campo_avulso);
                }
            }

            string query = "";

            query = tabela.Query;
            
            foreach (DataRow row in dtFiltro.Rows)
            {
                var campo = campos.Where(x => x.Campo == row["CAMPO"].ToString()).FirstOrDefault();

                if (campo != null)
                {
                    if (row["ID"].ToString() == "1")
                        query = query + " AND ";

                    query += row["CONJUNCAO"] + " " + campo.CampoERP + " " + row["CONDICAO"] + " " + (campo.Tipo == "String" ? "'" : "") + row["COMPARACAO"] + (campo.Tipo == "String" ? "'" : "");
                }

            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                gridResultado.DataSource = Geral.agilee.ExecutarQuery(query.Replace("\"", "'"));
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

        private void button1_Click(object sender, EventArgs e)
        {

            StringBuilder bulk_insert = new StringBuilder();

            var tabela = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select * from Tabelas where Nome = '" + cmbTabelaPlataforma.SelectedValue.ToString() + "'").FirstOrDefault();

            if (tabela == null)
            {
                MessageBox.Show("Configuração para a tabela " + cmbTabelaPlataforma.SelectedValue.ToString() + " não encontrada!");
                return;
            }

            var campos = Geral.banco.LerNoBanco<Dicionario.Campos>("Select * from Campos where Tabela = '" + cmbTabelaPlataforma.SelectedValue.ToString() + "'");

            var gatilhocampos = Geral.banco.LerNoBanco<Dicionario.GatilhoCampos>("Select * from GatilhoCampos where TabelaNome = '" + tabela.Nome + "'");

            if (gatilhocampos.Where(x => x.CampoTipo == "K").Count() == 0)
            {
                MessageBox.Show("Configuração para o gatilho da tabela " + tabela.Nome + " não encontrada!");
                return;
            }

            DataTable dtSelecionados = (DataTable)gridResultado.DataSource;

            DialogResult dr = MessageBox.Show("Deseja enviar para plataforma " + dtSelecionados.Rows.Count + " registros da tabela " + cmbTabelaPlataforma.SelectedValue.ToString() + "?", "Pergunta", MessageBoxButtons.YesNo);

            switch (dr)
            {
                case DialogResult.No:
                    return;               
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                string sql_where;
                int count = 0;
                int bulk_count = 0;

                Geral.agilee.Open();

                foreach (DataRow row in dtSelecionados.Rows)
                {
                    sql_where = "";
                    count = 0;
                    bulk_count++;

                    foreach (var chave in gatilhocampos.Where(x => x.CampoTipo == "K"))
                    {
                        var campo = campos.Where(x => x.CampoERP == chave.CampoNome).FirstOrDefault();

                        if (campo == null)
                        {
                            MessageBox.Show("Não foi encontrado o campo chave " + chave.CampoNome + " na query da tabela " + tabela.Nome);
                            return;
                        }

                        if (count > 0)
                            sql_where += " AND ";

                        sql_where += "TO_CHAR(" + (campo.MascaraERP.Trim() == "" ? chave.CampoNome : campo.MascaraERP) + ") = ''" + row[campo.Campo] + "''";

                        count++;
                    }

                    if (bulk_count == 1000)
                    {
                        bulk_count = 0;
                        Geral.agilee.GravarNoBancoBulk(bulk_insert.ToString());
                        bulk_insert.Length = 0;
                    }

                    bulk_insert.AppendLine(string.Format("INSERT INTO AGILE_ECOM_INT_ERP (DATA_REGISTRO, TABELA, SQL_WHERE, SQL_TIPO, STATUS) VALUES (sysdate, '{0}', '{1}', 'U', 'P');", tabela.Nome, sql_where));

                }

                if (bulk_insert.Length > 0)
                    Geral.agilee.GravarNoBancoBulk(bulk_insert.ToString());


                this.Cursor = Cursors.Default;
                MessageBox.Show("Solicitações de envio registradas com sucesso!");

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                Geral.agilee.Close();
            }

        }
    }
}
