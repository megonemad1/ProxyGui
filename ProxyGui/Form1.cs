using System;
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
            this.Text = "Disconected";
            this.TxtCientPort.Enabled = false;
            this.TxtHostPort.Enabled = false;
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            
            if (((Button)sender).Text=="Start")
            {   
                _prox = new Proxy();
                _prox.SessionStarted += _prox_SessionStarted;
                _prox.SessionTerminated+=_prox_SessionTerminated;
                _prox.setCientport(chkAdvanced.Checked? TxtCientPort.Text:"22").sethost(TxtHostName.Text).setpassword(TxtPassword.Text).setServerport(chkAdvanced.Checked?TxtHostPort.Text:"8080").setusername(TxtUserName.Text).Verbose(ChkVerbose.Checked);
                _prox.SessionTerminated += _prox_SessionTerminated;
                _prox.Start();
                this.Text = "connecting";
                button1.Text = "Stop";
            }
            else if (((Button)sender).Text == "Stop")
            {
                button1.Text = "Closing";
                this.Text = "Disconecting";
                _prox.Stop();
                
            }
        }

        void _prox_SessionStarted(object source, ProxyInfo e)
        {
            
            SetControlPropertyThreadSafe(this, "Text", "Conected");
        }

        void _prox_SessionTerminated(object source, ProxyInfo e)
        {
            SetControlPropertyThreadSafe(this, "Text", "Disconected");
            SetControlPropertyThreadSafe(button1, "Text", "Start");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode==Keys.Enter)
            BtnStartStop_Click(button1, new EventArgs());
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
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
                this.Text = "Disconecting";
                _prox.Stop();

            }
        }
    }
}
