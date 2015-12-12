namespace ODBS_Updater
{
    partial class Form1
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
            this.up = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.web = new System.Windows.Forms.WebBrowser();
            this.stat = new System.Windows.Forms.Label();
            this.pro = new System.Windows.Forms.Label();
            this.play = new System.Windows.Forms.Button();
            this.current = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.onstat = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // up
            // 
            this.up.Location = new System.Drawing.Point(1028, 850);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(435, 47);
            this.up.TabIndex = 0;
            this.up.Text = "UPDATE";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 849);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(992, 47);
            this.progress.TabIndex = 1;
            this.progress.Click += new System.EventHandler(this.progress_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.web);
            this.panel1.Location = new System.Drawing.Point(4, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1813, 754);
            this.panel1.TabIndex = 2;
            // 
            // web
            // 
            this.web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web.Location = new System.Drawing.Point(0, 0);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(1813, 754);
            this.web.TabIndex = 0;
            this.web.Url = new System.Uri("", System.UriKind.Relative);
            this.web.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // stat
            // 
            this.stat.AutoSize = true;
            this.stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06283F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stat.Location = new System.Drawing.Point(12, 791);
            this.stat.Name = "stat";
            this.stat.Size = new System.Drawing.Size(206, 38);
            this.stat.TabIndex = 3;
            this.stat.Text = "Status: None";
            // 
            // pro
            // 
            this.pro.AutoSize = true;
            this.pro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06283F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pro.Location = new System.Drawing.Point(463, 792);
            this.pro.Name = "pro";
            this.pro.Size = new System.Drawing.Size(212, 38);
            this.pro.TabIndex = 4;
            this.pro.Text = "Progress: 0/0";
            this.pro.Click += new System.EventHandler(this.label1_Click);
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(1028, 783);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(435, 47);
            this.play.TabIndex = 5;
            this.play.Text = "WEBSITE";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // current
            // 
            this.current.AutoSize = true;
            this.current.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.06283F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current.Location = new System.Drawing.Point(722, 792);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(282, 38);
            this.current.TabIndex = 6;
            this.current.Text = "Current Version: 0";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.onstat);
            this.panel2.Location = new System.Drawing.Point(1487, 771);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 125);
            this.panel2.TabIndex = 7;
            // 
            // onstat
            // 
            this.onstat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onstat.Location = new System.Drawing.Point(0, 0);
            this.onstat.MinimumSize = new System.Drawing.Size(20, 20);
            this.onstat.Name = "onstat";
            this.onstat.ScrollBarsEnabled = false;
            this.onstat.Size = new System.Drawing.Size(321, 125);
            this.onstat.TabIndex = 0;
            this.onstat.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1829, 909);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.current);
            this.Controls.Add(this.play);
            this.Controls.Add(this.pro);
            this.Controls.Add(this.stat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.up);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button up;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.Label stat;
        private System.Windows.Forms.Label pro;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Label current;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser onstat;

    }
}

