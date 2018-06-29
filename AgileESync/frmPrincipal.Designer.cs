namespace AgileESync
{
    partial class frmPrincipal
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
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuerysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatilhosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargaGeralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAtualizaDados = new System.Windows.Forms.Button();
            this.listUltimasAcoes = new System.Windows.Forms.ListBox();
            this.lblTempoAtividade = new System.Windows.Forms.Label();
            this.bgwTempoAtividade = new System.ComponentModel.BackgroundWorker();
            this.bgwSyncJob = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInternalizacao = new System.Windows.Forms.Button();
            this.listPedidos = new System.Windows.Forms.ListBox();
            this.bgwInternalizaPedidos = new System.ComponentModel.BackgroundWorker();
            this.bgwAtualizaBancoDados = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRegProcessadosLoop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRegProcessadosTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRegEstimativaTempo = new System.Windows.Forms.Label();
            this.progressLoop = new System.Windows.Forms.ProgressBar();
            this.lblRegProcessadosFalha = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 567);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Teste";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçãoToolStripMenuItem,
            this.tabelasToolStripMenuItem,
            this.QuerysToolStripMenuItem,
            this.gatilhosToolStripMenuItem,
            this.cargaGeralToolStripMenuItem,
            this.syncToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.configuraçãoToolStripMenuItem.Text = "Configuração";
            this.configuraçãoToolStripMenuItem.Click += new System.EventHandler(this.configuraçãoToolStripMenuItem_Click);
            // 
            // tabelasToolStripMenuItem
            // 
            this.tabelasToolStripMenuItem.Name = "tabelasToolStripMenuItem";
            this.tabelasToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.tabelasToolStripMenuItem.Text = "Tabelas";
            this.tabelasToolStripMenuItem.Click += new System.EventHandler(this.tabelasToolStripMenuItem_Click);
            // 
            // QuerysToolStripMenuItem
            // 
            this.QuerysToolStripMenuItem.Name = "QuerysToolStripMenuItem";
            this.QuerysToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.QuerysToolStripMenuItem.Text = "Querys";
            this.QuerysToolStripMenuItem.Click += new System.EventHandler(this.QuerysToolStripMenuItem_Click);
            // 
            // gatilhosToolStripMenuItem
            // 
            this.gatilhosToolStripMenuItem.Name = "gatilhosToolStripMenuItem";
            this.gatilhosToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.gatilhosToolStripMenuItem.Text = "Gatilhos";
            this.gatilhosToolStripMenuItem.Click += new System.EventHandler(this.gatilhosToolStripMenuItem_Click);
            // 
            // cargaGeralToolStripMenuItem
            // 
            this.cargaGeralToolStripMenuItem.Name = "cargaGeralToolStripMenuItem";
            this.cargaGeralToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cargaGeralToolStripMenuItem.Text = "Carga Geral";
            this.cargaGeralToolStripMenuItem.Click += new System.EventHandler(this.cargaGeralToolStripMenuItem_Click);
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem});
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.syncToolStripMenuItem.Text = "Sync";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRegProcessadosFalha);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.progressLoop);
            this.groupBox1.Controls.Add(this.lblRegEstimativaTempo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblRegProcessadosTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblRegProcessadosLoop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAtualizaDados);
            this.groupBox1.Controls.Add(this.listUltimasAcoes);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 325);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atualização de Dados:";
            // 
            // btnAtualizaDados
            // 
            this.btnAtualizaDados.Location = new System.Drawing.Point(6, 23);
            this.btnAtualizaDados.Name = "btnAtualizaDados";
            this.btnAtualizaDados.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizaDados.TabIndex = 5;
            this.btnAtualizaDados.Text = "Desligado";
            this.btnAtualizaDados.UseVisualStyleBackColor = true;
            this.btnAtualizaDados.Click += new System.EventHandler(this.btnAtualizaDados_Click);
            // 
            // listUltimasAcoes
            // 
            this.listUltimasAcoes.FormattingEnabled = true;
            this.listUltimasAcoes.Location = new System.Drawing.Point(6, 55);
            this.listUltimasAcoes.Name = "listUltimasAcoes";
            this.listUltimasAcoes.Size = new System.Drawing.Size(572, 173);
            this.listUltimasAcoes.TabIndex = 0;
            // 
            // lblTempoAtividade
            // 
            this.lblTempoAtividade.AutoSize = true;
            this.lblTempoAtividade.Location = new System.Drawing.Point(501, 9);
            this.lblTempoAtividade.Name = "lblTempoAtividade";
            this.lblTempoAtividade.Size = new System.Drawing.Size(89, 13);
            this.lblTempoAtividade.TabIndex = 2;
            this.lblTempoAtividade.Text = "00d 00h 00m 00s";
            // 
            // bgwTempoAtividade
            // 
            this.bgwTempoAtividade.WorkerReportsProgress = true;
            this.bgwTempoAtividade.WorkerSupportsCancellation = true;
            this.bgwTempoAtividade.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTempoAtividade_DoWork);
            this.bgwTempoAtividade.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwTempoAtividade_ProgressChanged);
            // 
            // bgwSyncJob
            // 
            this.bgwSyncJob.WorkerReportsProgress = true;
            this.bgwSyncJob.WorkerSupportsCancellation = true;
            this.bgwSyncJob.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSyncJob_DoWork);
            this.bgwSyncJob.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSyncJob_ProgressChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInternalizacao);
            this.groupBox2.Controls.Add(this.listPedidos);
            this.groupBox2.Location = new System.Drawing.Point(12, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 226);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Internalização de Pedidos:";
            // 
            // btnInternalizacao
            // 
            this.btnInternalizacao.BackColor = System.Drawing.SystemColors.Control;
            this.btnInternalizacao.Location = new System.Drawing.Point(6, 25);
            this.btnInternalizacao.Name = "btnInternalizacao";
            this.btnInternalizacao.Size = new System.Drawing.Size(75, 23);
            this.btnInternalizacao.TabIndex = 6;
            this.btnInternalizacao.Text = "Desligado";
            this.btnInternalizacao.UseVisualStyleBackColor = false;
            // 
            // listPedidos
            // 
            this.listPedidos.FormattingEnabled = true;
            this.listPedidos.Location = new System.Drawing.Point(6, 54);
            this.listPedidos.Name = "listPedidos";
            this.listPedidos.Size = new System.Drawing.Size(572, 160);
            this.listPedidos.TabIndex = 0;
            // 
            // bgwInternalizaPedidos
            // 
            this.bgwInternalizaPedidos.WorkerReportsProgress = true;
            this.bgwInternalizaPedidos.WorkerSupportsCancellation = true;
            this.bgwInternalizaPedidos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwInternalizaPedidos_DoWork);
            // 
            // bgwAtualizaBancoDados
            // 
            this.bgwAtualizaBancoDados.WorkerReportsProgress = true;
            this.bgwAtualizaBancoDados.WorkerSupportsCancellation = true;
            this.bgwAtualizaBancoDados.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAtualizaBancoDados_DoWork);
            this.bgwAtualizaBancoDados.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwAtualizaBancoDados_ProgressChanged);
            this.bgwAtualizaBancoDados.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAtualizaBancoDados_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Reg Processados no Loop........:";
            // 
            // lblRegProcessadosLoop
            // 
            this.lblRegProcessadosLoop.AutoSize = true;
            this.lblRegProcessadosLoop.Location = new System.Drawing.Point(172, 250);
            this.lblRegProcessadosLoop.Name = "lblRegProcessadosLoop";
            this.lblRegProcessadosLoop.Size = new System.Drawing.Size(30, 13);
            this.lblRegProcessadosLoop.TabIndex = 8;
            this.lblRegProcessadosLoop.Text = "0 / 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Uptime:";
            // 
            // lblRegProcessadosTotal
            // 
            this.lblRegProcessadosTotal.AutoSize = true;
            this.lblRegProcessadosTotal.Location = new System.Drawing.Point(172, 231);
            this.lblRegProcessadosTotal.Name = "lblRegProcessadosTotal";
            this.lblRegProcessadosTotal.Size = new System.Drawing.Size(13, 13);
            this.lblRegProcessadosTotal.TabIndex = 10;
            this.lblRegProcessadosTotal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Reg Processados no Total........:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Estimativa para término:";
            // 
            // lblRegEstimativaTempo
            // 
            this.lblRegEstimativaTempo.AutoSize = true;
            this.lblRegEstimativaTempo.Location = new System.Drawing.Point(489, 250);
            this.lblRegEstimativaTempo.Name = "lblRegEstimativaTempo";
            this.lblRegEstimativaTempo.Size = new System.Drawing.Size(89, 13);
            this.lblRegEstimativaTempo.TabIndex = 12;
            this.lblRegEstimativaTempo.Text = "00d 00h 00m 00s";
            // 
            // progressLoop
            // 
            this.progressLoop.Location = new System.Drawing.Point(9, 288);
            this.progressLoop.Name = "progressLoop";
            this.progressLoop.Size = new System.Drawing.Size(569, 11);
            this.progressLoop.TabIndex = 13;
            // 
            // lblRegProcessadosFalha
            // 
            this.lblRegProcessadosFalha.AutoSize = true;
            this.lblRegProcessadosFalha.Location = new System.Drawing.Point(172, 269);
            this.lblRegProcessadosFalha.Name = "lblRegProcessadosFalha";
            this.lblRegProcessadosFalha.Size = new System.Drawing.Size(13, 13);
            this.lblRegProcessadosFalha.TabIndex = 15;
            this.lblRegProcessadosFalha.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Reg Processados com Falha....:";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 589);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTempoAtividade);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApiSync";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listUltimasAcoes;
        private System.Windows.Forms.Label lblTempoAtividade;
        public System.ComponentModel.BackgroundWorker bgwTempoAtividade;
        private System.ComponentModel.BackgroundWorker bgwSyncJob;
        private System.Windows.Forms.ToolStripMenuItem gatilhosToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listPedidos;
        public System.ComponentModel.BackgroundWorker bgwInternalizaPedidos;
        private System.Windows.Forms.Button btnAtualizaDados;
        private System.Windows.Forms.Button btnInternalizacao;
        private System.ComponentModel.BackgroundWorker bgwAtualizaBancoDados;
        private System.Windows.Forms.ToolStripMenuItem QuerysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargaGeralToolStripMenuItem;
        private System.Windows.Forms.Label lblRegProcessadosLoop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressLoop;
        private System.Windows.Forms.Label lblRegEstimativaTempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRegProcessadosTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRegProcessadosFalha;
        private System.Windows.Forms.Label label6;
    }
}

