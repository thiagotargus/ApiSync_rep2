namespace AgileESync
{
    partial class frmCargaGeral
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
            this.pnlTabelas = new System.Windows.Forms.Panel();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroTabela = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTabelaPlataforma = new System.Windows.Forms.ListBox();
            this.pnlCargaGeralDados = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCamposTabela = new System.Windows.Forms.ComboBox();
            this.cmbCondicao = new System.Windows.Forms.ComboBox();
            this.txtComparacao = new System.Windows.Forms.TextBox();
            this.cmbConjuncao = new System.Windows.Forms.ComboBox();
            this.btnAddFiltro = new System.Windows.Forms.Button();
            this.gridFiltros = new System.Windows.Forms.DataGridView();
            this.gridResultado = new System.Windows.Forms.DataGridView();
            this.btnDoFilter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CONJUNCAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAMPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONDICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPARACAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTabelas.SuspendLayout();
            this.pnlCargaGeralDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiltros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTabelas
            // 
            this.pnlTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTabelas.Controls.Add(this.btnFiltrar);
            this.pnlTabelas.Controls.Add(this.txtFiltroTabela);
            this.pnlTabelas.Controls.Add(this.label1);
            this.pnlTabelas.Controls.Add(this.cmbTabelaPlataforma);
            this.pnlTabelas.Location = new System.Drawing.Point(2, 3);
            this.pnlTabelas.Name = "pnlTabelas";
            this.pnlTabelas.Size = new System.Drawing.Size(222, 702);
            this.pnlTabelas.TabIndex = 2;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackgroundImage = global::AgileESync.Properties.Resources.money;
            this.btnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFiltrar.Location = new System.Drawing.Point(188, 11);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(28, 23);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // txtFiltroTabela
            // 
            this.txtFiltroTabela.Location = new System.Drawing.Point(49, 12);
            this.txtFiltroTabela.Name = "txtFiltroTabela";
            this.txtFiltroTabela.Size = new System.Drawing.Size(134, 20);
            this.txtFiltroTabela.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filtro:";
            // 
            // cmbTabelaPlataforma
            // 
            this.cmbTabelaPlataforma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTabelaPlataforma.FormattingEnabled = true;
            this.cmbTabelaPlataforma.Location = new System.Drawing.Point(3, 45);
            this.cmbTabelaPlataforma.Name = "cmbTabelaPlataforma";
            this.cmbTabelaPlataforma.Size = new System.Drawing.Size(213, 641);
            this.cmbTabelaPlataforma.TabIndex = 2;
            this.cmbTabelaPlataforma.SelectedIndexChanged += new System.EventHandler(this.cmbTabelaPlataforma_SelectedIndexChanged);
            // 
            // pnlCargaGeralDados
            // 
            this.pnlCargaGeralDados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCargaGeralDados.Controls.Add(this.button1);
            this.pnlCargaGeralDados.Controls.Add(this.label3);
            this.pnlCargaGeralDados.Controls.Add(this.btnDoFilter);
            this.pnlCargaGeralDados.Controls.Add(this.gridResultado);
            this.pnlCargaGeralDados.Controls.Add(this.gridFiltros);
            this.pnlCargaGeralDados.Controls.Add(this.btnAddFiltro);
            this.pnlCargaGeralDados.Controls.Add(this.cmbConjuncao);
            this.pnlCargaGeralDados.Controls.Add(this.txtComparacao);
            this.pnlCargaGeralDados.Controls.Add(this.cmbCondicao);
            this.pnlCargaGeralDados.Controls.Add(this.cmbCamposTabela);
            this.pnlCargaGeralDados.Controls.Add(this.label2);
            this.pnlCargaGeralDados.Location = new System.Drawing.Point(230, 3);
            this.pnlCargaGeralDados.Name = "pnlCargaGeralDados";
            this.pnlCargaGeralDados.Size = new System.Drawing.Size(761, 514);
            this.pnlCargaGeralDados.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filtro:";
            // 
            // cmbCamposTabela
            // 
            this.cmbCamposTabela.FormattingEnabled = true;
            this.cmbCamposTabela.Location = new System.Drawing.Point(58, 13);
            this.cmbCamposTabela.Name = "cmbCamposTabela";
            this.cmbCamposTabela.Size = new System.Drawing.Size(189, 21);
            this.cmbCamposTabela.TabIndex = 5;
            // 
            // cmbCondicao
            // 
            this.cmbCondicao.FormattingEnabled = true;
            this.cmbCondicao.Items.AddRange(new object[] {
            "=",
            "<>",
            ">",
            "<",
            "LIKE",
            "IN",
            "NOT IN",
            "IS NULL",
            "IS NOT NULL"});
            this.cmbCondicao.Location = new System.Drawing.Point(268, 13);
            this.cmbCondicao.Name = "cmbCondicao";
            this.cmbCondicao.Size = new System.Drawing.Size(95, 21);
            this.cmbCondicao.TabIndex = 6;
            // 
            // txtComparacao
            // 
            this.txtComparacao.Location = new System.Drawing.Point(381, 13);
            this.txtComparacao.Name = "txtComparacao";
            this.txtComparacao.Size = new System.Drawing.Size(156, 20);
            this.txtComparacao.TabIndex = 7;
            // 
            // cmbConjuncao
            // 
            this.cmbConjuncao.FormattingEnabled = true;
            this.cmbConjuncao.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cmbConjuncao.Location = new System.Drawing.Point(555, 12);
            this.cmbConjuncao.Name = "cmbConjuncao";
            this.cmbConjuncao.Size = new System.Drawing.Size(68, 21);
            this.cmbConjuncao.TabIndex = 8;
            // 
            // btnAddFiltro
            // 
            this.btnAddFiltro.BackgroundImage = global::AgileESync.Properties.Resources.direction_1;
            this.btnAddFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddFiltro.Location = new System.Drawing.Point(641, 11);
            this.btnAddFiltro.Name = "btnAddFiltro";
            this.btnAddFiltro.Size = new System.Drawing.Size(28, 23);
            this.btnAddFiltro.TabIndex = 14;
            this.btnAddFiltro.UseVisualStyleBackColor = true;
            this.btnAddFiltro.Click += new System.EventHandler(this.btnAddFiltro_Click);
            // 
            // gridFiltros
            // 
            this.gridFiltros.AllowUserToAddRows = false;
            this.gridFiltros.AllowUserToDeleteRows = false;
            this.gridFiltros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFiltros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CONJUNCAO,
            this.CAMPO,
            this.CONDICAO,
            this.COMPARACAO,
            this.ID});
            this.gridFiltros.Location = new System.Drawing.Point(23, 45);
            this.gridFiltros.MultiSelect = false;
            this.gridFiltros.Name = "gridFiltros";
            this.gridFiltros.ReadOnly = true;
            this.gridFiltros.RowHeadersVisible = false;
            this.gridFiltros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFiltros.Size = new System.Drawing.Size(729, 99);
            this.gridFiltros.TabIndex = 15;
            this.gridFiltros.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridFiltros_CellMouseDown);
            this.gridFiltros.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridFiltros_MouseClick);
            // 
            // gridResultado
            // 
            this.gridResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultado.Location = new System.Drawing.Point(23, 175);
            this.gridResultado.Name = "gridResultado";
            this.gridResultado.RowHeadersVisible = false;
            this.gridResultado.Size = new System.Drawing.Size(729, 307);
            this.gridResultado.TabIndex = 16;
            // 
            // btnDoFilter
            // 
            this.btnDoFilter.BackgroundImage = global::AgileESync.Properties.Resources.money;
            this.btnDoFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoFilter.Location = new System.Drawing.Point(675, 11);
            this.btnDoFilter.Name = "btnDoFilter";
            this.btnDoFilter.Size = new System.Drawing.Size(28, 23);
            this.btnDoFilter.TabIndex = 17;
            this.btnDoFilter.UseVisualStyleBackColor = true;
            this.btnDoFilter.Click += new System.EventHandler(this.btnDoFilter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Dados:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Text = "Excluir";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // CONJUNCAO
            // 
            this.CONJUNCAO.DataPropertyName = "CONJUNCAO";
            this.CONJUNCAO.HeaderText = "Conjunção";
            this.CONJUNCAO.Name = "CONJUNCAO";
            this.CONJUNCAO.ReadOnly = true;
            // 
            // CAMPO
            // 
            this.CAMPO.DataPropertyName = "CAMPO";
            this.CAMPO.HeaderText = "Campo";
            this.CAMPO.Name = "CAMPO";
            this.CAMPO.ReadOnly = true;
            // 
            // CONDICAO
            // 
            this.CONDICAO.DataPropertyName = "CONDICAO";
            this.CONDICAO.HeaderText = "Condição";
            this.CONDICAO.Name = "CONDICAO";
            this.CONDICAO.ReadOnly = true;
            // 
            // COMPARACAO
            // 
            this.COMPARACAO.DataPropertyName = "COMPARACAO";
            this.COMPARACAO.HeaderText = "Comparação";
            this.COMPARACAO.Name = "COMPARACAO";
            this.COMPARACAO.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::AgileESync.Properties.Resources.direction_1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(724, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCargaGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 517);
            this.Controls.Add(this.pnlCargaGeralDados);
            this.Controls.Add(this.pnlTabelas);
            this.Name = "frmCargaGeral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApiSync | Carga Geral ";
            this.Load += new System.EventHandler(this.frmCargaGeral_Load);
            this.pnlTabelas.ResumeLayout(false);
            this.pnlTabelas.PerformLayout();
            this.pnlCargaGeralDados.ResumeLayout(false);
            this.pnlCargaGeralDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiltros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabelas;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox cmbTabelaPlataforma;
        private System.Windows.Forms.Panel pnlCargaGeralDados;
        private System.Windows.Forms.ComboBox cmbConjuncao;
        private System.Windows.Forms.TextBox txtComparacao;
        private System.Windows.Forms.ComboBox cmbCondicao;
        private System.Windows.Forms.ComboBox cmbCamposTabela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDoFilter;
        private System.Windows.Forms.DataGridView gridResultado;
        private System.Windows.Forms.DataGridView gridFiltros;
        private System.Windows.Forms.Button btnAddFiltro;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONJUNCAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAMPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONDICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPARACAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Button button1;
    }
}