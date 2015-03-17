namespace ProxyGui
{
    partial class FrmServerSelect
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
            this.LstServerSelect = new System.Windows.Forms.ListBox();
            this.ChkRemember = new System.Windows.Forms.CheckBox();
            this.BtnProceed = new System.Windows.Forms.Button();
            this.ChkDontShow = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnForceUpd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LstServerSelect
            // 
            this.LstServerSelect.FormattingEnabled = true;
            this.LstServerSelect.Location = new System.Drawing.Point(12, 12);
            this.LstServerSelect.Name = "LstServerSelect";
            this.LstServerSelect.Size = new System.Drawing.Size(291, 69);
            this.LstServerSelect.TabIndex = 4;
            this.LstServerSelect.SelectedIndexChanged += new System.EventHandler(this.LstServerSelect_SelectedIndexChanged);
            // 
            // ChkRemember
            // 
            this.ChkRemember.AutoSize = true;
            this.ChkRemember.Enabled = false;
            this.ChkRemember.Location = new System.Drawing.Point(12, 90);
            this.ChkRemember.Name = "ChkRemember";
            this.ChkRemember.Size = new System.Drawing.Size(131, 17);
            this.ChkRemember.TabIndex = 5;
            this.ChkRemember.Text = "Remember my choice ";
            this.ChkRemember.UseVisualStyleBackColor = true;
            this.ChkRemember.CheckedChanged += new System.EventHandler(this.ChkRemember_CheckedChanged);
            // 
            // BtnProceed
            // 
            this.BtnProceed.Location = new System.Drawing.Point(13, 113);
            this.BtnProceed.Name = "BtnProceed";
            this.BtnProceed.Size = new System.Drawing.Size(143, 28);
            this.BtnProceed.TabIndex = 7;
            this.BtnProceed.Text = "Proceed";
            this.BtnProceed.UseVisualStyleBackColor = true;
            this.BtnProceed.Click += new System.EventHandler(this.BtnProceed_Click);
            // 
            // ChkDontShow
            // 
            this.ChkDontShow.AutoSize = true;
            this.ChkDontShow.Enabled = false;
            this.ChkDontShow.Location = new System.Drawing.Point(176, 90);
            this.ChkDontShow.Name = "ChkDontShow";
            this.ChkDontShow.Size = new System.Drawing.Size(127, 17);
            this.ChkDontShow.TabIndex = 6;
            this.ChkDontShow.Text = "Don\'t show this again";
            this.ChkDontShow.UseVisualStyleBackColor = true;
            this.ChkDontShow.CheckedChanged += new System.EventHandler(this.ChkDontShow_CheckedChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(252, 113);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(51, 28);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnForceUpd
            // 
            this.BtnForceUpd.Location = new System.Drawing.Point(162, 113);
            this.BtnForceUpd.Name = "BtnForceUpd";
            this.BtnForceUpd.Size = new System.Drawing.Size(84, 28);
            this.BtnForceUpd.TabIndex = 8;
            this.BtnForceUpd.Text = "Force Update";
            this.BtnForceUpd.UseVisualStyleBackColor = true;
            this.BtnForceUpd.Click += new System.EventHandler(this.BtnForceUpd_Click);
            // 
            // FrmServerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 150);
            this.Controls.Add(this.BtnForceUpd);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.ChkDontShow);
            this.Controls.Add(this.BtnProceed);
            this.Controls.Add(this.ChkRemember);
            this.Controls.Add(this.LstServerSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmServerSelect";
            this.ShowInTaskbar = false;
            this.Text = "Select a download server...";
            this.Load += new System.EventHandler(this.FrmServerSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstServerSelect;
        private System.Windows.Forms.CheckBox ChkRemember;
        private System.Windows.Forms.Button BtnProceed;
        private System.Windows.Forms.CheckBox ChkDontShow;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnForceUpd;
    }
}