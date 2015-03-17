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
            this.LblServer1Active = new System.Windows.Forms.Label();
            this.LblServer2Active = new System.Windows.Forms.Label();
            this.LblServer3Active = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LstServerSelect
            // 
            this.LstServerSelect.FormattingEnabled = true;
            this.LstServerSelect.Location = new System.Drawing.Point(12, 12);
            this.LstServerSelect.Name = "LstServerSelect";
            this.LstServerSelect.Size = new System.Drawing.Size(255, 43);
            this.LstServerSelect.TabIndex = 0;
            this.LstServerSelect.SelectedIndexChanged += new System.EventHandler(this.LstServerSelect_SelectedIndexChanged);
            // 
            // ChkRemember
            // 
            this.ChkRemember.AutoSize = true;
            this.ChkRemember.Enabled = false;
            this.ChkRemember.Location = new System.Drawing.Point(12, 61);
            this.ChkRemember.Name = "ChkRemember";
            this.ChkRemember.Size = new System.Drawing.Size(131, 17);
            this.ChkRemember.TabIndex = 1;
            this.ChkRemember.Text = "Remember my choice ";
            this.ChkRemember.UseVisualStyleBackColor = true;
            this.ChkRemember.CheckedChanged += new System.EventHandler(this.ChkRemember_CheckedChanged);
            // 
            // BtnProceed
            // 
            this.BtnProceed.Location = new System.Drawing.Point(13, 84);
            this.BtnProceed.Name = "BtnProceed";
            this.BtnProceed.Size = new System.Drawing.Size(197, 28);
            this.BtnProceed.TabIndex = 2;
            this.BtnProceed.Text = "Proceed";
            this.BtnProceed.UseVisualStyleBackColor = true;
            this.BtnProceed.Click += new System.EventHandler(this.BtnProceed_Click);
            // 
            // ChkDontShow
            // 
            this.ChkDontShow.AutoSize = true;
            this.ChkDontShow.Enabled = false;
            this.ChkDontShow.Location = new System.Drawing.Point(176, 61);
            this.ChkDontShow.Name = "ChkDontShow";
            this.ChkDontShow.Size = new System.Drawing.Size(127, 17);
            this.ChkDontShow.TabIndex = 3;
            this.ChkDontShow.Text = "Don\'t show this again";
            this.ChkDontShow.UseVisualStyleBackColor = true;
            this.ChkDontShow.CheckedChanged += new System.EventHandler(this.ChkDontShow_CheckedChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(217, 84);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(86, 28);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblServer1Active
            // 
            this.LblServer1Active.AutoSize = true;
            this.LblServer1Active.Enabled = false;
            this.LblServer1Active.Location = new System.Drawing.Point(273, 12);
            this.LblServer1Active.Name = "LblServer1Active";
            this.LblServer1Active.Size = new System.Drawing.Size(27, 13);
            this.LblServer1Active.TabIndex = 5;
            this.LblServer1Active.Text = "ping";
            // 
            // LblServer2Active
            // 
            this.LblServer2Active.AutoSize = true;
            this.LblServer2Active.Enabled = false;
            this.LblServer2Active.Location = new System.Drawing.Point(273, 25);
            this.LblServer2Active.Name = "LblServer2Active";
            this.LblServer2Active.Size = new System.Drawing.Size(27, 13);
            this.LblServer2Active.TabIndex = 6;
            this.LblServer2Active.Text = "ping";
            // 
            // LblServer3Active
            // 
            this.LblServer3Active.AutoSize = true;
            this.LblServer3Active.Enabled = false;
            this.LblServer3Active.Location = new System.Drawing.Point(273, 38);
            this.LblServer3Active.Name = "LblServer3Active";
            this.LblServer3Active.Size = new System.Drawing.Size(27, 13);
            this.LblServer3Active.TabIndex = 7;
            this.LblServer3Active.Text = "ping";
            // 
            // FrmServerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 124);
            this.Controls.Add(this.LblServer3Active);
            this.Controls.Add(this.LblServer2Active);
            this.Controls.Add(this.LblServer1Active);
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
        private System.Windows.Forms.Label LblServer1Active;
        private System.Windows.Forms.Label LblServer2Active;
        private System.Windows.Forms.Label LblServer3Active;
    }
}