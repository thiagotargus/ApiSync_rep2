namespace AgileESync
{
    partial class frmConfiguracao
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImagensPath = new System.Windows.Forms.Button();
            this.txtImagensPath = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInstancia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbERP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbAgileEcommerce = new System.Windows.Forms.GroupBox();
            this.txtApiUrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSalvarConfiguracao = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBucketName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbRegionEndpoint = new System.Windows.Forms.ComboBox();
            this.txtSecretAccessKey = new System.Windows.Forms.TextBox();
            this.txtAccessKeyId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbAgileEcommerce.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImagensPath);
            this.groupBox1.Controls.Add(this.txtImagensPath);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtSenha);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtInstancia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbERP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPorta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexão ERP:";
            // 
            // btnImagensPath
            // 
            this.btnImagensPath.Location = new System.Drawing.Point(416, 118);
            this.btnImagensPath.Name = "btnImagensPath";
            this.btnImagensPath.Size = new System.Drawing.Size(33, 21);
            this.btnImagensPath.TabIndex = 19;
            this.btnImagensPath.Text = "...";
            this.btnImagensPath.UseVisualStyleBackColor = true;
            this.btnImagensPath.Click += new System.EventHandler(this.btnImagensPath_Click);
            // 
            // txtImagensPath
            // 
            this.txtImagensPath.Location = new System.Drawing.Point(73, 118);
            this.txtImagensPath.Name = "txtImagensPath";
            this.txtImagensPath.Size = new System.Drawing.Size(337, 20);
            this.txtImagensPath.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Imagens:";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(309, 85);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(141, 20);
            this.txtSenha.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Senha:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(309, 56);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(141, 20);
            this.txtUsuario.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Usuário:";
            // 
            // txtInstancia
            // 
            this.txtInstancia.Location = new System.Drawing.Point(309, 25);
            this.txtInstancia.Name = "txtInstancia";
            this.txtInstancia.Size = new System.Drawing.Size(141, 20);
            this.txtInstancia.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Instância:";
            // 
            // cmbERP
            // 
            this.cmbERP.FormattingEnabled = true;
            this.cmbERP.Items.AddRange(new object[] {
            "Harpia",
            "Winthor"});
            this.cmbERP.Location = new System.Drawing.Point(73, 24);
            this.cmbERP.Name = "cmbERP";
            this.cmbERP.Size = new System.Drawing.Size(141, 21);
            this.cmbERP.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ERP:";
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(73, 85);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(141, 20);
            this.txtPorta.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Porta:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(73, 56);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(141, 20);
            this.txtIP.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IP:";
            // 
            // gbAgileEcommerce
            // 
            this.gbAgileEcommerce.Controls.Add(this.txtApiUrl);
            this.gbAgileEcommerce.Controls.Add(this.label8);
            this.gbAgileEcommerce.Controls.Add(this.txtToken);
            this.gbAgileEcommerce.Controls.Add(this.label7);
            this.gbAgileEcommerce.Location = new System.Drawing.Point(12, 181);
            this.gbAgileEcommerce.Name = "gbAgileEcommerce";
            this.gbAgileEcommerce.Size = new System.Drawing.Size(470, 101);
            this.gbAgileEcommerce.TabIndex = 1;
            this.gbAgileEcommerce.TabStop = false;
            this.gbAgileEcommerce.Text = "Rest Api:";
            // 
            // txtApiUrl
            // 
            this.txtApiUrl.Location = new System.Drawing.Point(64, 63);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(386, 20);
            this.txtApiUrl.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Api Url:";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(64, 29);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(141, 20);
            this.txtToken.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Token:";
            // 
            // btnSalvarConfiguracao
            // 
            this.btnSalvarConfiguracao.Location = new System.Drawing.Point(200, 446);
            this.btnSalvarConfiguracao.Name = "btnSalvarConfiguracao";
            this.btnSalvarConfiguracao.Size = new System.Drawing.Size(88, 23);
            this.btnSalvarConfiguracao.TabIndex = 2;
            this.btnSalvarConfiguracao.Text = "Salvar";
            this.btnSalvarConfiguracao.UseVisualStyleBackColor = true;
            this.btnSalvarConfiguracao.Click += new System.EventHandler(this.btnSalvarConfiguracao_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBucketName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbRegionEndpoint);
            this.groupBox2.Controls.Add(this.txtSecretAccessKey);
            this.groupBox2.Controls.Add(this.txtAccessKeyId);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 152);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AWS S3:";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtBucketName
            // 
            this.txtBucketName.Location = new System.Drawing.Point(113, 120);
            this.txtBucketName.Name = "txtBucketName";
            this.txtBucketName.Size = new System.Drawing.Size(331, 20);
            this.txtBucketName.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "BucketName:";
            // 
            // cmbRegionEndpoint
            // 
            this.cmbRegionEndpoint.FormattingEnabled = true;
            this.cmbRegionEndpoint.Location = new System.Drawing.Point(113, 91);
            this.cmbRegionEndpoint.Name = "cmbRegionEndpoint";
            this.cmbRegionEndpoint.Size = new System.Drawing.Size(331, 21);
            this.cmbRegionEndpoint.TabIndex = 12;
            // 
            // txtSecretAccessKey
            // 
            this.txtSecretAccessKey.Location = new System.Drawing.Point(113, 60);
            this.txtSecretAccessKey.Name = "txtSecretAccessKey";
            this.txtSecretAccessKey.Size = new System.Drawing.Size(331, 20);
            this.txtSecretAccessKey.TabIndex = 11;
            // 
            // txtAccessKeyId
            // 
            this.txtAccessKeyId.Location = new System.Drawing.Point(113, 29);
            this.txtAccessKeyId.Name = "txtAccessKeyId";
            this.txtAccessKeyId.Size = new System.Drawing.Size(331, 20);
            this.txtAccessKeyId.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "RegionEndpoint:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "SecretAccessKey:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "AccessKeyId:";
            // 
            // frmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 481);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalvarConfiguracao);
            this.Controls.Add(this.gbAgileEcommerce);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApiSync | Configuração";
            this.Load += new System.EventHandler(this.frmConfiguracao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAgileEcommerce.ResumeLayout(false);
            this.gbAgileEcommerce.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtInstancia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbAgileEcommerce;
        public System.Windows.Forms.TextBox txtApiUrl;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSalvarConfiguracao;
        public System.Windows.Forms.ComboBox cmbERP;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtBucketName;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cmbRegionEndpoint;
        public System.Windows.Forms.TextBox txtSecretAccessKey;
        public System.Windows.Forms.TextBox txtAccessKeyId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnImagensPath;
        public System.Windows.Forms.TextBox txtImagensPath;
        private System.Windows.Forms.Label label13;
    }
}