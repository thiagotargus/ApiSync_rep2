using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgileESync
{
    public partial class frmGatilhos : Form
    {
        AgileE agilee;
        string tabela = "";
        string primary = "";
        string nomegatilho = "";

        List<string> campos;
        List<string> camposchave;

        public frmGatilhos()
        {
            InitializeComponent();
        }

        private void frmGatilhos_Load(object sender, EventArgs e)
        {
            agilee = new AgileE();

            CarregarListTabelas();
            CarregarGatilhoDoBancoPlataforma(cmbTabelaPlataforma.SelectedValue.ToString());
        }

        private void CarregarListaTabelasERP()
        {
            listTabelas.ValueMember = "TABLE_NAME";
            listTabelas.DisplayMember = "TABLE_NAME";
            listTabelas.DataSource = Geral.ToListof<AgileE.Tabela>(agilee.getTabelas()).ToList();
        }

        private void CarregarCamposTabelaERP()
        {
            listCampos.DataSource = Geral.ToListof<AgileE.Campo>(agilee.getCampos(listTabelas.SelectedValue.ToString())).OrderBy(x => x.ID).ToList();
            listCampos.ValueMember = "COLUNA";
            listCampos.DisplayMember = "COLUNA";


            listCamposChave.DataSource = Geral.ToListof<AgileE.Campo>(agilee.getCampos(listTabelas.SelectedValue.ToString())).OrderBy(x => x.ID).ToList();
            listCamposChave.ValueMember = "COLUNA";
            listCamposChave.DisplayMember = "COLUNA";
        }

        private void CarregarListaTabelasPlataforma()
        {
            cmbTabelaPlataforma.ValueMember = "Nome";
            cmbTabelaPlataforma.DisplayMember = "Descricao";
            cmbTabelaPlataforma.DataSource = Geral.banco.LerNoBanco<Dicionario.Tabelas>("Select * from Tabelas order by Ordenacao");
        }

        private void CarregarListTabelas()
        {
            CarregarListaTabelasPlataforma();
            CarregarListaTabelasERP();
        }

        private void CarregarListTabelas(string filtro)
        {
            string firstChar = filtro[0].ToString();
            string lastChar = filtro[filtro.Length - 1].ToString();
            string filtro_puro = filtro.Replace("*", "");

            if (firstChar == "*" && lastChar == "*")
            {
                listTabelas.DataSource = Geral.ToListof<AgileE.Tabela>(agilee.getTabelas()).Where(x => x.TABLE_NAME.Contains(filtro_puro)).ToList();
            }
            else if (firstChar == "*" && lastChar != "*")
            {
                listTabelas.DataSource = Geral.ToListof<AgileE.Tabela>(agilee.getTabelas()).Where(x => x.TABLE_NAME.EndsWith(filtro_puro)).ToList();
            }
            else if (firstChar != "*" && lastChar == "*")
            {
                listTabelas.DataSource = Geral.ToListof<AgileE.Tabela>(agilee.getTabelas()).Where(x => x.TABLE_NAME.StartsWith(filtro_puro)).ToList();
            }
            else
            {
                listTabelas.DataSource = Geral.ToListof<AgileE.Tabela>(agilee.getTabelas()).Where(x => x.TABLE_NAME == filtro_puro).ToList();
            }

            listTabelas.ValueMember = "TABLE_NAME";
            listTabelas.DisplayMember = "TABLE_NAME";
        }

        private void listTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCamposTabelaERP();    
        }

        private void CarregarGatilhoDoBancoPlataforma(string tabela_plataforma)
        {
            //Verificando se o gatilho existe no banco.
            if (Geral.banco.LerNoBanco<Dicionario.Gatilhos>("Select * from Gatilhos").Where(x => x.TabelaNome == tabela_plataforma).Count() > 0)
            {
                var gatilho = Geral.banco.LerNoBanco<Dicionario.Gatilhos>("Select * from Gatilhos").Where(x => x.TabelaNome == tabela_plataforma).FirstOrDefault();

                txtFiltroTabela.Text = gatilho.TabelaNomeERP;
                btnFiltrar_Click(this, new EventArgs());
                if (listTabelas.Items.Count == 1)
                {
                    listTabelas.SelectedIndex = 0;
                }    
                txtGatilho.Text = gatilho.GatilhoScript.Replace("\"", "'");

                CarregarCamposGatilhoDoBanco(gatilho.TabelaNome);
            }
            else
            {
                txtFiltroTabela.Text = "";
                txtGatilho.Text = "";
                CarregarListaTabelasERP();
                listTabelas.SelectedIndex = 0;
                UnCheckAll();
            }
        }

        private void CarregarGatilhoDoBancoERP(string tabela_ERP)
        {
            //Verificando se o gatilho existe no banco.
            if (Geral.banco.LerNoBanco<Dicionario.Gatilhos>("Select * from Gatilhos").Where(x => x.TabelaNomeERP == tabela_ERP).Count() > 0)
            {
                var gatilho = Geral.banco.LerNoBanco<Dicionario.Gatilhos>("Select * from Gatilhos").Where(x => x.TabelaNomeERP == tabela_ERP).FirstOrDefault();

                cmbTabelaPlataforma.SelectedItem = gatilho.TabelaNome;

                txtGatilho.Text = gatilho.GatilhoScript;

                CarregarCamposGatilhoDoBanco(gatilho.TabelaNome);
            }
        }

        private void UnCheckAll()
        {
            for (int i = 0; i < listCampos.Items.Count; i++)
            {
                listCampos.SetItemChecked(i, false);
            }
            for (int i = 0; i < listCamposChave.Items.Count; i++)
            {
                listCamposChave.SetItemChecked(i, false);
            }
        }

        private void CarregarCamposGatilhoDoBanco(string tabela_plataforma)
        {
            var camposdogatilho = Geral.banco.LerNoBanco<Dicionario.GatilhoCampos>("Select * from GatilhoCampos").Where(x => x.TabelaNome == tabela_plataforma);

            foreach(var campo in camposdogatilho.Where(x => x.CampoTipo == "F"))
            {
                for (int i = 0; i < listCampos.Items.Count; i++)
                {
                    if (((AgileE.Campo)listCampos.Items[i]).COLUNA == campo.CampoNome)
                    {
                        listCampos.SetItemChecked(i, true);
                    }
                }
            }

            foreach (var campo in camposdogatilho.Where(x => x.CampoTipo == "K"))
            {
                for (int i = 0; i < listCamposChave.Items.Count; i++)
                {
                    if (((AgileE.Campo)listCamposChave.Items[i]).COLUNA == campo.CampoNome)
                    {
                        listCamposChave.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void ProcessaCampos()
        {
            campos = new List<string>();
            camposchave = new List<string>();

            tabela = listTabelas.SelectedValue.ToString();

            primary = listCampos.SelectedValue.ToString();

            foreach (var itemchecked in listCampos.CheckedItems)
            {
                campos.Add(((AgileE.Campo)itemchecked).COLUNA);
            }

            foreach (var itemchecked in listCamposChave.CheckedItems)
            {
                camposchave.Add(((AgileE.Campo)itemchecked).COLUNA);
            }
        }

        private bool VerificaGeracaoGatilho()
        {
            bool isOk = true;

            if (cmbTabelaPlataforma.Text == "")
            {
                MessageBox.Show("É necessário selecionar uma tabela da plataforma!");
                isOk = false;
            }

            ProcessaCampos();

            if (campos.Count == 0)
            {
                MessageBox.Show("É necessário escolher algum campo para verificação!");
                isOk = false;
            }

            if (camposchave.Count == 0)
            {
                MessageBox.Show("É necessário escolher algum campo para chave!");
                isOk = false;
            }

            if (isOk)
                txtGatilho.Text = agilee.getGatilho(tabela, cmbTabelaPlataforma.Text, campos.ToArray(), camposchave.ToArray(), ref nomegatilho);

            return isOk;
        }

        private void btnGerarGatilho_Click(object sender, EventArgs e)
        {
            VerificaGeracaoGatilho();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarListTabelas(txtFiltroTabela.Text);
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string tabela_plataforma = cmbTabelaPlataforma.SelectedValue.ToString();
            string tabela_erp = listTabelas.SelectedValue.ToString();

            DialogResult dr = MessageBox.Show("Deseja salvar a configuração do gatilho " + tabela_plataforma + "?", "Pergunta", MessageBoxButtons.YesNo);

            switch (dr)
            {
                case DialogResult.Yes:

                    if (VerificaGeracaoGatilho())
                    {
                        if (Geral.banco.LerNoBanco<Dicionario.Gatilhos>("Select * from Gatilhos").Where(x => x.TabelaNome == tabela_plataforma).Count() > 0)
                        {
                            //Atualizando configuração do gatilho no banco
                            AtualizaGatilhoNoBanco(tabela_plataforma, tabela_erp);
                            MessageBox.Show("Registro atualizado com sucesso!");
                        }
                        else
                        {
                            //Salvando configuração do gatilho no banco
                            RegistraGatilhoNoBanco(tabela_plataforma, tabela_erp);
                            MessageBox.Show("Registro criado com sucesso!");
                        }
                    }

                    break;
                case DialogResult.No:
                    break;
            }

            Clipboard.SetText(txtGatilho.Text);
            MessageBox.Show("Copiado para area de transferência!");
        }

        private void AtualizaGatilhoNoBanco(string tabela_plataforma, string tabela_erp)
        {
            Geral.banco.ExecutarComando(string.Format("UPDATE Gatilhos Set TabelaNomeERP = '{0}', GatilhoNome = '{1}', GatilhoScript = '{2}' WHERE TabelaNome = '{3}'", tabela_erp, nomegatilho, txtGatilho.Text.Replace("'", "\""), tabela_plataforma));
            RegistraGatilhoCampos(tabela_plataforma);
        }

        private void RegistraGatilhoNoBanco(string tabela_plataforma, string tabela_erp)
        {
            Geral.banco.ExecutarComando(string.Format("INSERT INTO Gatilhos (TabelaNome, TabelaNomeERP, GatilhoNome, GatilhoScript) values ('{0}', '{1}', '{2}', '{3}')", tabela_plataforma, tabela_erp, nomegatilho, txtGatilho.Text.Replace("'", "\"")));
            RegistraGatilhoCampos(tabela_plataforma);
        }

        private void RegistraGatilhoCampos(string tabela_plataforma)
        {

            //Deletando Campos do registro
            Geral.banco.ExecutarComando(string.Format("DELETE FROM GatilhoCampos WHERE TabelaNome = '{0}'", tabela_plataforma));

            foreach (var campo in campos)
            {
                Geral.banco.ExecutarComando(string.Format("INSERT INTO GatilhoCampos (TabelaNome, CampoNome, CampoTipo) values ('{0}', '{1}', '{2}')", tabela_plataforma, campo, "F"));
            }

            foreach (var campo in camposchave)
            {
                Geral.banco.ExecutarComando(string.Format("INSERT INTO GatilhoCampos (TabelaNome, CampoNome, CampoTipo) values ('{0}', '{1}', '{2}')", tabela_plataforma, campo, "K"));
            }
        }

        private void cmbTabelaPlataforma_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarGatilhoDoBancoPlataforma(cmbTabelaPlataforma.SelectedValue.ToString());
        }
    }
}
