namespace HydraLife
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.Label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnrestart = new System.Windows.Forms.Button();
            this.btnEndSession = new System.Windows.Forms.Button();
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.Label1.Location = new System.Drawing.Point(4, 95);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(865, 17);
            this.Label1.TabIndex = 4;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 1013);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.Label1);
            this.panel3.Location = new System.Drawing.Point(109, 834);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(883, 176);
            this.panel3.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnrestart);
            this.panel2.Controls.Add(this.btnEndSession);
            this.panel2.Controls.Add(this.btnCloseApp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(992, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(95, 1013);
            this.panel2.TabIndex = 8;
            // 
            // btnrestart
            // 
            this.btnrestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrestart.BackColor = System.Drawing.Color.Transparent;
            this.btnrestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnrestart.ForeColor = System.Drawing.Color.Blue;
           // this.btnrestart.Image = global::LifeCicles.Properties.Resources.reset1;
            this.btnrestart.Location = new System.Drawing.Point(27, 881);
            this.btnrestart.Name = "btnrestart";
            this.btnrestart.Size = new System.Drawing.Size(47, 47);
            this.btnrestart.TabIndex = 4;
            this.btnrestart.UseVisualStyleBackColor = false;
            this.btnrestart.Visible = false;
            // 
            // btnEndSession
            // 
            this.btnEndSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndSession.BackColor = System.Drawing.Color.Transparent;
            this.btnEndSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnEndSession.ForeColor = System.Drawing.Color.Blue;
            this.btnEndSession.Image = global::LifeCicles.Properties.Resources.logout1;
            this.btnEndSession.Location = new System.Drawing.Point(27, 821);
            this.btnEndSession.Name = "btnEndSession";
            this.btnEndSession.Size = new System.Drawing.Size(47, 47);
            this.btnEndSession.TabIndex = 3;
            this.btnEndSession.UseVisualStyleBackColor = false;
            this.btnEndSession.Visible = false;
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseApp.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnCloseApp.ForeColor = System.Drawing.Color.Blue;
            this.btnCloseApp.Image = global::LifeCicles.Properties.Resources.power_on;
            this.btnCloseApp.Location = new System.Drawing.Point(27, 943);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(47, 47);
            this.btnCloseApp.TabIndex = 1;
            this.btnCloseApp.UseVisualStyleBackColor = false;
            this.btnCloseApp.Visible = false;
            this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
            // 
            // PicLogo
            // 
            this.PicLogo.BackColor = System.Drawing.Color.Transparent;
            this.PicLogo.BackgroundImage = global::LifeCicles.Properties.Resources.hydra1;
            this.PicLogo.Location = new System.Drawing.Point(-300, 100);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(300, 120);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLogo.TabIndex = 9;
            this.PicLogo.TabStop = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(98, 33);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(894, 23);
            this.progressBar2.TabIndex = 10;
            this.progressBar2.Visible = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1087, 1013);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.PicLogo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Button btnCloseApp;
       
       
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
       
        private System.Windows.Forms.Button btnrestart;
        private System.Windows.Forms.Button btnEndSession;
        
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.PictureBox PicLogo;

        private System.Windows.Forms.ProgressBar progressBar2;
    }
}

