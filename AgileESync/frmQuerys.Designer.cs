namespace AgileESync
{
    partial class frmQuerys
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
            this.pnlGatilho = new System.Windows.Forms.Panel();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.GridResultado = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTabelas.SuspendLayout();
            this.pnlGatilho.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridResultado)).BeginInit();
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
            this.pnlTabelas.Location = new System.Drawing.Point(4, 3);
            this.pnlTabelas.Name = "pnlTabelas";
            this.pnlTabelas.Size = new System.Drawing.Size(222, 680);
            this.pnlTabelas.TabIndex = 1;
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
            // pnlGatilho
            // 
            this.pnlGatilho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGatilho.Controls.Add(this.btnExecutar);
            this.pnlGatilho.Controls.Add(this.label2);
            this.pnlGatilho.Controls.Add(this.txtQuery);
            this.pnlGatilho.Location = new System.Drawing.Point(229, 3);
            this.pnlGatilho.Name = "pnlGatilho";
            this.pnlGatilho.Size = new System.Drawing.Size(770, 400);
            this.pnlGatilho.TabIndex = 3;
            // 
            // btnExecutar
            // 
            this.btnExecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecutar.BackgroundImage = global::AgileESync.Properties.Resources.direction_1;
            this.btnExecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExecutar.Location = new System.Drawing.Point(730, 12);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(28, 23);
            this.btnExecutar.TabIndex = 7;
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Query:";
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(3, 45);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuery.Size = new System.Drawing.Size(764, 352);
            this.txtQuery.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.GridResultado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(229, 409);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 274);
            this.panel1.TabIndex = 4;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackgroundImage = global::AgileESync.Properties.Resources.direction_1;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalvar.Location = new System.Drawing.Point(732, 10);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(28, 23);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // GridResultado
            // 
            this.GridResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridResultado.Location = new System.Drawing.Point(3, 43);
            this.GridResultado.Name = "GridResultado";
            this.GridResultado.Size = new System.Drawing.Size(754, 224);
            this.GridResultado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Resultado:";
            // 
            // frmQuerys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 695);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGatilho);
            this.Controls.Add(this.pnlTabelas);
            this.Name = "frmQuerys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApiSync | Query de Consulta";
            this.Load += new System.EventHandler(this.frmQuerys_Load);
            this.pnlTabelas.ResumeLayout(false);
            this.pnlTabelas.PerformLayout();
            this.pnlGatilho.ResumeLayout(false);
            this.pnlGatilho.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabelas;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox cmbTabelaPlataforma;
        private System.Windows.Forms.Panel pnlGatilho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView GridResultado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Button btnSalvar;
    }
}