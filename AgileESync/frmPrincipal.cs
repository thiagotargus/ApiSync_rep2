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
    public partial class frmPrincipal : Form
    {
        long count_geral;
        DateTime dt_ultimo_envio;
        DateTime dt_primeiro_envio;
        string[] splited_data;
        long qtd_loop_atual, count_loop_atual;
        long qtd_fail_loop_atual;

        public frmPrincipal()
        {
            count_geral = 0;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var retorno = Geral.agileapi.ReceberDados<AgileECommerceApi.Clientes>("select", "codigo=957043");

            Geral.agileapi.EnviarArquivos(@"F:\CLIENTES\R3\VENEZA\Img\000582.jpg");

            return;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            bgwTempoAtividade.RunWorkerAsync();

            Geral.frmSplash.progressSplash.Minimum = 0;
            Geral.frmSplash.progressSplash.Maximum = 100;

            bgwAtualizaBancoDados.RunWorkerAsync(Geral.BancoDadosPath());

            Geral.frmSplash.ShowDialog();

            Geral.frmconfiguracao.CarregarConfiguracao();

            if (Geral.frmconfiguracao.cmbERP.Text == "")
            {
                MessageBox.Show("Configuração não encontrada!");
                Geral.frmconfiguracao.ShowDialog();
            }
            else
            {
                //Verificando Arquivo de Configuração
                switch (Geral.frmconfiguracao.cmbERP.Text)
                {
                    case "Harpia":
                        Geral.erp = ERP.Harpia;
                        Geral.InstanciaApis();
                       
                        break;
                }
            }
            
            this.Text = "ApiSync - " + Geral.erp.ToString() + "ERP "  + Application.ProductVersion.ToString();

            //Start SyncJob
            //bgwSyncJob.RunWorkerAsync();

            //Start getPedidosJob
            //bgwInternalizaPedidos.RunWorkerAsync();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Geral.frmclientes == null)
                Geral.frmclientes = new frmClientes();

            Geral.frmclientes.ShowDialog();
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Geral.frmconfiguracao == null)
                Geral.frmconfiguracao = new frmConfiguracao();

            Geral.frmconfiguracao.ShowDialog();
        }

        private void bgwTempoAtividade_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime startTime = DateTime.Now;
            TimeSpan workedTime;

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                workedTime = DateTime.Now.Subtract(startTime);
                bgwTempoAtividade.ReportProgress(0, workedTime.Days.ToString().PadLeft(2, '0') + "d " + workedTime.Hours.ToString().PadLeft(2, '0') + "h " + workedTime.Minutes.ToString().PadLeft(2, '0') + "m " + workedTime.Seconds.ToString().PadLeft(2, '0') + "s ");
            }
        }

        private void bgwTempoAtividade_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                lblTempoAtividade.Text = e.UserState.ToString();
            }
        }

        private void bgwSyncJob_DoWork(object sender, DoWorkEventArgs e)
        {
            AgileE agilee = new AgileE();

            long count = 0;

            DataTable dtSyncJob = new DataTable();
            List<AgileECommerceApi.AgileESyncJob> listSyncJob = new List<AgileECommerceApi.AgileESyncJob>();

            while (!bgwSyncJob.CancellationPending)
            {
                dtSyncJob = agilee.getSyncJob();
                listSyncJob = Geral.DataTableToSyncJob(dtSyncJob);

                bgwSyncJob.ReportProgress(1, "0 / " + listSyncJob.Count().ToString());

                qtd_fail_loop_atual = 0;
                count = 0;

                foreach (var job in listSyncJob)
                {
                    var job_done = agilee.doJob(job, ref bgwSyncJob);
                    count++;

                    bgwSyncJob.ReportProgress(1, count.ToString() + " / " + listSyncJob.Count().ToString());

                    if (job_done.Status == "E")
                    {
                        qtd_fail_loop_atual++;
                        bgwSyncJob.ReportProgress(2, qtd_fail_loop_atual.ToString());
                    }

                    if (bgwSyncJob.CancellationPending)
                        break;
                }

                System.Threading.Thread.Sleep(10000);
            }

            if (bgwSyncJob.CancellationPending)
                return;

        }

        private void bgwSyncJob_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                listUltimasAcoes.Items.Insert(0, e.UserState.ToString());
            } 
            else if (e.ProgressPercentage == 1)
            {
                count_geral++;
                lblRegProcessadosLoop.Text = e.UserState.ToString();
                lblRegProcessadosTotal.Text = count_geral.ToString();

                splited_data = lblRegProcessadosLoop.Text.Split('/');

                count_loop_atual = Convert.ToInt64(splited_data[0]);
                qtd_loop_atual = Convert.ToInt64(splited_data[1]);

                if (count_loop_atual == 1)
                {
                    progressLoop.Minimum = 0;
                    progressLoop.Maximum = 100;

                    dt_primeiro_envio = DateTime.Now;
                    lblRegEstimativaTempo.Text = "00d 00h 00m 00s";
                }
                else if (count_loop_atual > 1)
                {
                    int percent = (int)(Convert.ToDecimal(Convert.ToDecimal(count_loop_atual) / Convert.ToDecimal(qtd_loop_atual)) * 100);

                    progressLoop.Value = (percent > 100 ? 100 : percent);

                    double worked_seconds = (DateTime.Now - dt_primeiro_envio).TotalSeconds;

                    decimal avg_seconds = Convert.ToDecimal(worked_seconds / count_loop_atual);

                    TimeSpan workingTimeLeft = new TimeSpan(0, 0, (int)(avg_seconds * (qtd_loop_atual - count_loop_atual)));

                    lblRegEstimativaTempo.Text = workingTimeLeft.Days.ToString().PadLeft(2, '0') + "d " + workingTimeLeft.Hours.ToString().PadLeft(2, '0') + "h " + workingTimeLeft.Minutes.ToString().PadLeft(2, '0') + "m " + workingTimeLeft.Seconds.ToString().PadLeft(2, '0') + "s ";
                }
            } else if (e.ProgressPercentage == 2)
            {
                lblRegProcessadosFalha.Text = e.UserState.ToString();
            }
        }

        private void gatilhosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Geral.frmgatilhos == null)
                Geral.frmgatilhos = new frmGatilhos();

            Geral.frmgatilhos.ShowDialog();
        }

        private void bgwInternalizaPedidos_DoWork(object sender, DoWorkEventArgs e)
        {
            AgileE agilee = new AgileE();

            while (true)
            {
                var listPedidos = Geral.agileapi.PedidosPendentes();

                foreach (var pedido in listPedidos)
                {
                    if (pedido.products != null)
                        agilee.setPedido(pedido);
                }

                System.Threading.Thread.Sleep(10000);
            }
        }

        private void btnAtualizaDados_Click(object sender, EventArgs e)
        {
            if (btnAtualizaDados.Text == "Desligado")
            {
                if (bgwSyncJob.IsBusy)
                {
                    MessageBox.Show("Aguarde para tentar iniciar novamente... Thread ainda em execução!");
                    return;
                }

                btnAtualizaDados.Text = "Ligado";
                bgwSyncJob.RunWorkerAsync();
            }
            else
            {
                btnAtualizaDados.Text = "Desligado";
                bgwSyncJob.WorkerSupportsCancellation = true;
                bgwSyncJob.CancelAsync();
            }
        }

        public delegate void AtualizaSplashCallback(string Comando, int Step);

        private void AtualizadaSplash(string Comando, int Step)
        {
            Geral.frmSplash.listSplash.Items.Insert(0, Comando);
            Geral.frmSplash.progressSplash.Step = Step;
        }

        private void bgwAtualizaBancoDados_DoWork(object sender, DoWorkEventArgs e)
        {
            AtualizaSplashCallback d = new AtualizaSplashCallback(AtualizadaSplash);

            db banco = new db((string)e.Argument);
            bgwAtualizaBancoDados.ReportProgress(0, "Iniciando Classe...");
            banco.ProcessarTabelasDoDicionario("TAB_", false, ref this.bgwAtualizaBancoDados);
        }

        private void bgwAtualizaBancoDados_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Geral.banco = new db(Geral.BancoDadosPath());
            Geral.dicionario = new Dicionario();

            Geral.dicionario.VerificaTabelas();

            Geral.frmSplash.Close();
        }

        private void QuerysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Geral.frmQuerys == null)
                Geral.frmQuerys = new frmQuerys();

            Geral.frmQuerys.ShowDialog();
        }

        private void bgwAtualizaBancoDados_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if ((string)e.UserState != "")
            {
                Geral.frmSplash.progressSplash.Value = 0;
                Geral.frmSplash.listSplash.Items.Insert(0, (string)e.UserState);
            }
            else
            {
                Geral.frmSplash.progressSplash.Value = e.ProgressPercentage;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tabelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Geral.frmTabelas == null)
                Geral.frmTabelas = new frmTabelas();

            Geral.frmTabelas.ShowDialog();
        }

        private void cargaGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Geral.frmCargaGeral == null)
                Geral.frmCargaGeral = new frmCargaGeral();

            Geral.frmCargaGeral.ShowDialog();
        }
    }
}
