namespace ProxyGui
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TxtHostName = new System.Windows.Forms.TextBox();
            this.TxtCientPort = new System.Windows.Forms.TextBox();
            this.TxtHostPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.LblPWorKEY = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnStartStop = new System.Windows.Forms.Button();
            this.chkAdvanced = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ChkVerbose = new System.Windows.Forms.CheckBox();
            this.ChkHideShell = new System.Windows.Forms.CheckBox();
            this.LblHideShell = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ChkSaveKey = new System.Windows.Forms.CheckBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.PicProxyGUI = new System.Windows.Forms.PictureBox();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.PicImproved = new System.Windows.Forms.PictureBox();
            this.UsrModeLbl = new System.Windows.Forms.Label();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkCompress = new System.Windows.Forms.CheckBox();
            this.Compress = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkUseKey = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicProxyGUI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicImproved)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtHostName
            // 
            this.TxtHostName.Location = new System.Drawing.Point(65, 113);
            this.TxtHostName.Name = "TxtHostName";
            this.TxtHostName.Size = new System.Drawing.Size(150, 20);
            this.TxtHostName.TabIndex = 0;
            // 
            // TxtCientPort
            // 
            this.TxtCientPort.Location = new System.Drawing.Point(65, 165);
            this.TxtCientPort.Name = "TxtCientPort";
            this.TxtCientPort.Size = new System.Drawing.Size(150, 20);
            this.TxtCientPort.TabIndex = 2;
            this.TxtCientPort.Text = "8080";
            // 
            // TxtHostPort
            // 
            this.TxtHostPort.Location = new System.Drawing.Point(65, 139);
            this.TxtHostPort.Name = "TxtHostPort";
            this.TxtHostPort.Size = new System.Drawing.Size(150, 20);
            this.TxtHostPort.TabIndex = 1;
            this.TxtHostPort.Text = "22";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hostname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Client Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Username:";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(65, 192);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(150, 20);
            this.TxtUserName.TabIndex = 3;
            // 
            // LblPWorKEY
            // 
            this.LblPWorKEY.AutoSize = true;
            this.LblPWorKEY.Enabled = false;
            this.LblPWorKEY.Location = new System.Drawing.Point(6, 221);
            this.LblPWorKEY.Name = "LblPWorKEY";
            this.LblPWorKEY.Size = new System.Drawing.Size(56, 13);
            this.LblPWorKEY.TabIndex = 9;
            this.LblPWorKEY.Text = "Password:";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Enabled = false;
            this.TxtPassword.Location = new System.Drawing.Point(65, 218);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(150, 20);
            this.TxtPassword.TabIndex = 4;
            // 
            // BtnStartStop
            // 
            this.BtnStartStop.Location = new System.Drawing.Point(10, 298);
            this.BtnStartStop.Name = "BtnStartStop";
            this.BtnStartStop.Size = new System.Drawing.Size(112, 23);
            this.BtnStartStop.TabIndex = 11;
            this.BtnStartStop.Text = "Start";
            this.BtnStartStop.UseVisualStyleBackColor = true;
            this.BtnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // chkAdvanced
            // 
            this.chkAdvanced.AutoSize = true;
            this.chkAdvanced.Location = new System.Drawing.Point(74, 244);
            this.chkAdvanced.Name = "chkAdvanced";
            this.chkAdvanced.Size = new System.Drawing.Size(15, 14);
            this.chkAdvanced.TabIndex = 5;
            this.chkAdvanced.UseVisualStyleBackColor = true;
            this.chkAdvanced.CheckedChanged += new System.EventHandler(this.chkAdvanced_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Advanced";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Verbose";
            // 
            // ChkVerbose
            // 
            this.ChkVerbose.AutoSize = true;
            this.ChkVerbose.Location = new System.Drawing.Point(198, 244);
            this.ChkVerbose.Name = "ChkVerbose";
            this.ChkVerbose.Size = new System.Drawing.Size(15, 14);
            this.ChkVerbose.TabIndex = 6;
            this.ChkVerbose.UseVisualStyleBackColor = true;
            // 
            // ChkHideShell
            // 
            this.ChkHideShell.AutoSize = true;
            this.ChkHideShell.Enabled = false;
            this.ChkHideShell.Location = new System.Drawing.Point(198, 262);
            this.ChkHideShell.Name = "ChkHideShell";
            this.ChkHideShell.Size = new System.Drawing.Size(15, 14);
            this.ChkHideShell.TabIndex = 8;
            this.ChkHideShell.UseVisualStyleBackColor = true;
            this.ChkHideShell.CheckedChanged += new System.EventHandler(this.ChkHideShell_CheckedChanged);
            // 
            // LblHideShell
            // 
            this.LblHideShell.AutoSize = true;
            this.LblHideShell.Enabled = false;
            this.LblHideShell.Location = new System.Drawing.Point(137, 262);
            this.LblHideShell.Name = "LblHideShell";
            this.LblHideShell.Size = new System.Drawing.Size(55, 13);
            this.LblHideShell.TabIndex = 17;
            this.LblHideShell.Text = "Hide Shell";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Save Key";
            // 
            // ChkSaveKey
            // 
            this.ChkSaveKey.AutoSize = true;
            this.ChkSaveKey.Location = new System.Drawing.Point(74, 262);
            this.ChkSaveKey.Name = "ChkSaveKey";
            this.ChkSaveKey.Size = new System.Drawing.Size(15, 14);
            this.ChkSaveKey.TabIndex = 7;
            this.ChkSaveKey.UseVisualStyleBackColor = true;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(128, 298);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(87, 23);
            this.BtnUpdate.TabIndex = 12;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // PicProxyGUI
            // 
            this.PicProxyGUI.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicProxyGUI.Image = global::ProxyGui.Properties.Resources.Gui_logo;
            this.PicProxyGUI.Location = new System.Drawing.Point(0, 0);
            this.PicProxyGUI.Name = "PicProxyGUI";
            this.PicProxyGUI.Size = new System.Drawing.Size(227, 92);
            this.PicProxyGUI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicProxyGUI.TabIndex = 20;
            this.PicProxyGUI.TabStop = false;
            // 
            // VersionLbl
            // 
            this.VersionLbl.AutoSize = true;
            this.VersionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLbl.Location = new System.Drawing.Point(186, 324);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(41, 13);
            this.VersionLbl.TabIndex = 21;
            this.VersionLbl.Text = "version";
            // 
            // PicImproved
            // 
            this.PicImproved.BackColor = System.Drawing.Color.Transparent;
            this.PicImproved.Image = global::ProxyGui.Properties.Resources.kai_fun_stuff;
            this.PicImproved.Location = new System.Drawing.Point(0, 0);
            this.PicImproved.Name = "PicImproved";
            this.PicImproved.Size = new System.Drawing.Size(68, 48);
            this.PicImproved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicImproved.TabIndex = 22;
            this.PicImproved.TabStop = false;
            this.PicImproved.Visible = false;
            // 
            // UsrModeLbl
            // 
            this.UsrModeLbl.AutoSize = true;
            this.UsrModeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrModeLbl.Location = new System.Drawing.Point(4, 324);
            this.UsrModeLbl.Name = "UsrModeLbl";
            this.UsrModeLbl.Size = new System.Drawing.Size(69, 13);
            this.UsrModeLbl.TabIndex = 23;
            this.UsrModeLbl.Text = "USERMODE";
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipText = "Program is running in the background...";
            this.TrayIcon.BalloonTipTitle = "ProxyGUI";
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "ProxyGUI";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick_1);
            // 
            // chkCompress
            // 
            this.chkCompress.AutoSize = true;
            this.chkCompress.Enabled = false;
            this.chkCompress.Location = new System.Drawing.Point(198, 279);
            this.chkCompress.Name = "chkCompress";
            this.chkCompress.Size = new System.Drawing.Size(15, 14);
            this.chkCompress.TabIndex = 10;
            this.chkCompress.UseVisualStyleBackColor = true;
            this.chkCompress.CheckedChanged += new System.EventHandler(this.chkCompress_CheckedChanged);
            // 
            // Compress
            // 
            this.Compress.AutoSize = true;
            this.Compress.Enabled = false;
            this.Compress.Location = new System.Drawing.Point(137, 279);
            this.Compress.Name = "Compress";
            this.Compress.Size = new System.Drawing.Size(53, 13);
            this.Compress.TabIndex = 26;
            this.Compress.Text = "Compress";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(12, 278);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Use Key";
            // 
            // chkUseKey
            // 
            this.chkUseKey.AutoSize = true;
            this.chkUseKey.Enabled = false;
            this.chkUseKey.Location = new System.Drawing.Point(74, 279);
            this.chkUseKey.Name = "chkUseKey";
            this.chkUseKey.Size = new System.Drawing.Size(15, 14);
            this.chkUseKey.TabIndex = 9;
            this.chkUseKey.UseVisualStyleBackColor = true;
            this.chkUseKey.CheckedChanged += new System.EventHandler(this.chkUseKey_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 341);
            this.Controls.Add(this.chkCompress);
            this.Controls.Add(this.Compress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkUseKey);
            this.Controls.Add(this.UsrModeLbl);
            this.Controls.Add(this.PicImproved);
            this.Controls.Add(this.VersionLbl);
            this.Controls.Add(this.PicProxyGUI);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.ChkHideShell);
            this.Controls.Add(this.LblHideShell);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ChkSaveKey);
            this.Controls.Add(this.ChkVerbose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkAdvanced);
            this.Controls.Add(this.BtnStartStop);
            this.Controls.Add(this.LblPWorKEY);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtHostPort);
            this.Controls.Add(this.TxtCientPort);
            this.Controls.Add(this.TxtHostName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "ProxyGUI";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PicProxyGUI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicImproved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtHostName;
        private System.Windows.Forms.TextBox TxtCientPort;
        private System.Windows.Forms.TextBox TxtHostPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label LblPWorKEY;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnStartStop;
        private System.Windows.Forms.CheckBox chkAdvanced;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ChkVerbose;
        private System.Windows.Forms.CheckBox ChkHideShell;
        private System.Windows.Forms.Label LblHideShell;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ChkSaveKey;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.PictureBox PicProxyGUI;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.PictureBox PicImproved;
        private System.Windows.Forms.Label UsrModeLbl;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.CheckBox chkCompress;
        private System.Windows.Forms.Label Compress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkUseKey;
    }
}

