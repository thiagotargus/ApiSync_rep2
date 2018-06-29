namespace AgileESync
{
    partial class frmTabelas
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
            this.cmbTabelaPlataforma = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.txtNomeTabelaERP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUrlTabela = new System.Windows.Forms.TextBox();
            this.txtNomeTabela = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricaoTabela = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModuloTabela = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlTabelas.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnlTabelas.Location = new System.Drawing.Point(3, 12);
            this.pnlTabelas.Name = "pnlTabelas";
            this.pnlTabelas.Size = new System.Drawing.Size(222, 680);
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
            this.cmbTabelaPlataforma.Size = new System.Drawing.Size(213, 628);
            this.cmbTabelaPlataforma.TabIndex = 2;
            this.cmbTabelaPlataforma.SelectedIndexChanged += new System.EventHandler(this.cmbTabelaPlataforma_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtModuloTabela);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDescricaoTabela);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnExecutar);
            this.panel1.Controls.Add(this.txtNomeTabelaERP);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtUrlTabela);
            this.panel1.Controls.Add(this.txtNomeTabela);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(231, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 471);
            this.panel1.TabIndex = 3;
            // 
            // btnExecutar
            // 
            this.btnExecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecutar.BackgroundImage = global::AgileESync.Properties.Resources.direction_1;
            this.btnExecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExecutar.Location = new System.Drawing.Point(533, 10);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(28, 23);
            this.btnExecutar.TabIndex = 8;
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // txtNomeTabelaERP
            // 
            this.txtNomeTabelaERP.Enabled = false;
            this.txtNomeTabelaERP.Location = new System.Drawing.Point(123, 121);
            this.txtNomeTabelaERP.Name = "txtNomeTabelaERP";
            this.txtNomeTabelaERP.Size = new System.Drawing.Size(438, 20);
            this.txtNomeTabelaERP.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nome no ERP:";
            // 
            // txtUrlTabela
            // 
            this.txtUrlTabela.Location = new System.Drawing.Point(123, 147);
            this.txtUrlTabela.Name = "txtUrlTabela";
            this.txtUrlTabela.Size = new System.Drawing.Size(438, 20);
            this.txtUrlTabela.TabIndex = 4;
            // 
            // txtNomeTabela
            // 
            this.txtNomeTabela.Enabled = false;
            this.txtNomeTabela.Location = new System.Drawing.Point(123, 42);
            this.txtNomeTabela.Name = "txtNomeTabela";
            this.txtNomeTabela.Size = new System.Drawing.Size(438, 20);
            this.txtNomeTabela.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Rota:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nome da Tabela:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dados:";
            // 
            // txtDescricaoTabela
            // 
            this.txtDescricaoTabela.Enabled = false;
            this.txtDescricaoTabela.Location = new System.Drawing.Point(123, 68);
            this.txtDescricaoTabela.Name = "txtDescricaoTabela";
            this.txtDescricaoTabela.Size = new System.Drawing.Size(438, 20);
            this.txtDescricaoTabela.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Descrição da Tabela:";
            // 
            // txtModuloTabela
            // 
            this.txtModuloTabela.Enabled = false;
            this.txtModuloTabela.Location = new System.Drawing.Point(123, 94);
            this.txtModuloTabela.Name = "txtModuloTabela";
            this.txtModuloTabela.Size = new System.Drawing.Size(438, 20);
            this.txtModuloTabela.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Módulo da Tabela:";
            // 
            // frmTabelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 488);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTabelas);
            this.Name = "frmTabelas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApiSync | Tabelas da Api";
            this.Load += new System.EventHandler(this.frmTabelas_Load);
            this.pnlTabelas.ResumeLayout(false);
            this.pnlTabelas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabelas;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox cmbTabelaPlataforma;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUrlTabela;
        private System.Windows.Forms.TextBox txtNomeTabela;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeTabelaERP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.TextBox txtModuloTabela;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescricaoTabela;
        private System.Windows.Forms.Label label6;
    }
}