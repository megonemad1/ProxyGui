﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProxyLib;
using System.IO;
using System.Reflection;

namespace ProxyGui
{
    public partial class Form1 : Form
    {
        Proxy _prox;
        public Form1()
        {
            InitializeComponent();
            string path = "ProxyLib.dll";
            if (!File.Exists(path))
                System.IO.File.WriteAllBytes(path, ProxyGui.Properties.Resources.ProxyLib);
            this.Text = "Disconnected";
            this.TxtCientPort.Enabled = false;
            this.TxtHostPort.Enabled = false;
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {

            if (((Button)sender).Text == "Start")
            {
                _prox = new Proxy();
                _prox.SessionStarted += _prox_SessionStarted;
                if (chkAdvanced.Checked)
                    _prox.setCientport(TxtCientPort.Text).setServerport(TxtHostPort.Text);
                else
                    _prox.setCientport("8080").setServerport("22");
                _prox.TurnOffShell(ChkHideShell.Checked).AutoStoreSshkey(ChkSaveKey.Checked).setpassword(TxtPassword.Text).sethost(TxtHostName.Text).setusername(TxtUserName.Text).Verbose(ChkVerbose.Checked);
                _prox.SessionTerminated += _prox_SessionTerminated;
                _prox.Start();
                this.Text = "Connecting";
                button1.Text = "Stop";
            }
            else if (((Button)sender).Text == "Stop")
            {
                button1.Text = "Closing";
                this.Text = "Disconnecting";
                _prox.Stop();

            }
        }

        void _prox_SessionStarted(object source, ProxyInfo e)
        {

            SetControlPropertyThreadSafe(this, "Text", "Connected");
        }

        void _prox_SessionTerminated(object source, ProxyInfo e)
        {
            SetControlPropertyThreadSafe(this, "Text", "Disconnected");
            SetControlPropertyThreadSafe(button1, "Text", "Start");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                BtnStartStop_Click(button1, new EventArgs());
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
                }
                else
                {
                    control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
                }
            }
            catch (System.ObjectDisposedException e)
            {
                Console.WriteLine(e);
            }
        }

        private void chkAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            this.TxtCientPort.Enabled = chkAdvanced.Checked;
            this.TxtHostPort.Enabled = chkAdvanced.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button1.Text == "Stop")
            {
                button1.Text = "Closing";
                this.Text = "Disconnecting";
                _prox.Stop();

            }


            try
            {
                //saveshit
                Properties.Settings.Default.Advanced = chkAdvanced.Checked;
                Properties.Settings.Default.ClientPort = TxtCientPort.Text;
                Properties.Settings.Default.HiddenShell = ChkHideShell.Checked;
                Properties.Settings.Default.SaveKey = ChkSaveKey.Checked;
                Properties.Settings.Default.Host = TxtHostName.Text;
                Properties.Settings.Default.HostPort = TxtHostPort.Text;
                Properties.Settings.Default.Username = TxtUserName.Text;
                Properties.Settings.Default.Verbose = ChkVerbose.Checked;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                Console.WriteLine("Failed to save settings...");
            }
            Console.WriteLine("Saved settings.");




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Magic's save&load shit.
            try
            {
                chkAdvanced.Checked = Properties.Settings.Default.Advanced;
                ChkVerbose.Checked = Properties.Settings.Default.Verbose;
                ChkSaveKey.Checked = Properties.Settings.Default.SaveKey;
                ChkHideShell.Checked = Properties.Settings.Default.HiddenShell;
                TxtCientPort.Text = Properties.Settings.Default.ClientPort;
                TxtHostName.Text = Properties.Settings.Default.Host;
                TxtHostPort.Text = Properties.Settings.Default.HostPort;
                TxtUserName.Text = Properties.Settings.Default.Username;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                Console.WriteLine("Failed to load settings...");
            }
            Console.WriteLine("Loaded settings.");

        }

        private void ChkHideShell_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as CheckBox).Checked)
                TxtPassword.Text = "";
        }
    }
}
