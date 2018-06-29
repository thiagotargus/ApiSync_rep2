namespace AgileESync
{
    partial class frmSplash
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
            this.progressSplash = new System.Windows.Forms.ProgressBar();
            this.listSplash = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // progressSplash
            // 
            this.progressSplash.Location = new System.Drawing.Point(12, 150);
            this.progressSplash.Name = "progressSplash";
            this.progressSplash.Size = new System.Drawing.Size(429, 24);
            this.progressSplash.TabIndex = 0;
            // 
            // listSplash
            // 
            this.listSplash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listSplash.FormattingEnabled = true;
            this.listSplash.ItemHeight = 20;
            this.listSplash.Location = new System.Drawing.Point(12, 9);
            this.listSplash.Name = "listSplash";
            this.listSplash.Size = new System.Drawing.Size(429, 124);
            this.listSplash.TabIndex = 1;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(453, 185);
            this.ControlBox = false;
            this.Controls.Add(this.listSplash);
            this.Controls.Add(this.progressSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSplash_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressSplash;
        public System.Windows.Forms.ListBox listSplash;

    }
}