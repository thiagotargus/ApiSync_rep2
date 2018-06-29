namespace AgileESync
{
    partial class frmGatilhos
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
            this.pnlTabelas = new System.Windows.Forms.Panel();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroTabela = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listTabelas = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTabelaPlataforma = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listCamposChave = new System.Windows.Forms.CheckedListBox();
            this.listCampos = new System.Windows.Forms.CheckedListBox();
            this.btnGerarGatilho = new System.Windows.Forms.Button();
            this.pnlGatilho = new System.Windows.Forms.Panel();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnExecutarGatilho = new System.Windows.Forms.Button();
            this.txtGatilho = new System.Windows.Forms.TextBox();
            this.pnlTabelas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlGatilho.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTabelas
            // 
            this.pnlTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTabelas.Controls.Add(this.btnFiltrar);
            this.pnlTabelas.Controls.Add(this.txtFiltroTabela);
            this.pnlTabelas.Controls.Add(this.label1);
            this.pnlTabelas.Controls.Add(this.listTabelas);
            this.pnlTabelas.Location = new System.Drawing.Point(1, 0);
            this.pnlTabelas.Name = "pnlTabelas";
            this.pnlTabelas.Size = new System.Drawing.Size(222, 546);
            this.pnlTabelas.TabIndex = 0;
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
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
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
            // listTabelas
            // 
            this.listTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTabelas.FormattingEnabled = true;
            this.listTabelas.Location = new System.Drawing.Point(3, 45);
            this.listTabelas.Name = "listTabelas";
            this.listTabelas.Size = new System.Drawing.Size(213, 498);
            this.listTabelas.TabIndex = 2;
            this.listTabelas.SelectedIndexChanged += new System.EventHandler(this.listTabelas_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.cmbTabelaPlataforma);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listCamposChave);
            this.panel1.Controls.Add(this.listCampos);
            this.panel1.Controls.Add(this.btnGerarGatilho);
            this.panel1.Location = new System.Drawing.Point(229, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 546);
            this.panel1.TabIndex = 1;
            // 
            // cmbTabelaPlataforma
            // 
            this.cmbTabelaPlataforma.FormattingEnabled = true;
            this.cmbTabelaPlataforma.Location = new System.Drawing.Point(120, 42);
            this.cmbTabelaPlataforma.Name = "cmbTabelaPlataforma";
            this.cmbTabelaPlataforma.Size = new System.Drawing.Size(164, 21);
            this.cmbTabelaPlataforma.TabIndex = 12;
            this.cmbTabelaPlataforma.SelectedIndexChanged += new System.EventHandler(this.cmbTabelaPlataforma_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tabela na Plataforma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Campos para chave:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Campos para verificação:";
            // 
            // listCamposChave
            // 
            this.listCamposChave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCamposChave.FormattingEnabled = true;
            this.listCamposChave.Location = new System.Drawing.Point(5, 319);
            this.listCamposChave.Name = "listCamposChave";
            this.listCamposChave.Size = new System.Drawing.Size(281, 214);
            this.listCamposChave.TabIndex = 8;
            // 
            // listCampos
            // 
            this.listCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCampos.FormattingEnabled = true;
            this.listCampos.Location = new System.Drawing.Point(3, 86);
            this.listCampos.Name = "listCampos";
            this.listCampos.Size = new System.Drawing.Size(281, 214);
            this.listCampos.TabIndex = 7;
            // 
            // btnGerarGatilho
            // 
            this.btnGerarGatilho.BackgroundImage = global::AgileESync.Properties.Resources.direction_1;
            this.btnGerarGatilho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGerarGatilho.Location = new System.Drawing.Point(247, 9);
            this.btnGerarGatilho.Name = "btnGerarGatilho";
            this.btnGerarGatilho.Size = new System.Drawing.Size(28, 23);
            this.btnGerarGatilho.TabIndex = 6;
            this.btnGerarGatilho.UseVisualStyleBackColor = true;
            this.btnGerarGatilho.Click += new System.EventHandler(this.btnGerarGatilho_Click);
            // 
            // pnlGatilho
            // 
            this.pnlGatilho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGatilho.Controls.Add(this.btnCopyToClipboard);
            this.pnlGatilho.Controls.Add(this.btnExecutarGatilho);
            this.pnlGatilho.Controls.Add(this.txtGatilho);
            this.pnlGatilho.Location = new System.Drawing.Point(525, 0);
            this.pnlGatilho.Name = "pnlGatilho";
            this.pnlGatilho.Size = new System.Drawing.Size(717, 533);
            this.pnlGatilho.TabIndex = 2;
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.BackgroundImage = global::AgileESync.Properties.Resources.direction_1;
            this.btnCopyToClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCopyToClipboard.Location = new System.Drawing.Point(680, 11);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(28, 23);
            this.btnCopyToClipboard.TabIndex = 13;
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnExecutarGatilho
            // 
            this.btnExecutarGatilho.Location = new System.Drawing.Point(748, 10);
            this.btnExecutarGatilho.Name = "btnExecutarGatilho";
            this.btnExecutarGatilho.Size = new System.Drawing.Size(28, 23);
            this.btnExecutarGatilho.TabIndex = 7;
            this.btnExecutarGatilho.UseVisualStyleBackColor = true;
            // 
            // txtGatilho
            // 
            this.txtGatilho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGatilho.Location = new System.Drawing.Point(3, 45);
            this.txtGatilho.Multiline = true;
            this.txtGatilho.Name = "txtGatilho";
            this.txtGatilho.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGatilho.Size = new System.Drawing.Size(711, 485);
            this.txtGatilho.TabIndex = 0;
            // 
            // frmGatilhos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 545);
            this.Controls.Add(this.pnlGatilho);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTabelas);
            this.Name = "frmGatilhos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApiSync | Criação de Gatilhos no ERP";
            this.Load += new System.EventHandler(this.frmGatilhos_Load);
            this.pnlTabelas.ResumeLayout(false);
            this.pnlTabelas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlGatilho.ResumeLayout(false);
            this.pnlGatilho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabelas;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listTabelas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGerarGatilho;
        private System.Windows.Forms.Panel pnlGatilho;
        private System.Windows.Forms.Button btnExecutarGatilho;
        private System.Windows.Forms.TextBox txtGatilho;
        private System.Windows.Forms.CheckedListBox listCampos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox listCamposChave;
        private System.Windows.Forms.ComboBox cmbTabelaPlataforma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopyToClipboard;
    }
}