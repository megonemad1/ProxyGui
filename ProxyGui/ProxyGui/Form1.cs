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
using System.Windows;
using System.Diagnostics;

namespace ProxyGui
{
    public partial class Form1 : Form
    {
        string version = "102"; //change me when you change something
        Proxy _prox;
        public Form1()
        {
            InitializeComponent();
            //   string path = "ProxyLib.dll";
            if (!File.Exists("ProxyLib.dll"))
                System.IO.File.WriteAllBytes("ProxyLib.dll", ProxyGui.Properties.Resources.ProxyLib);
            if (!File.Exists("MagiCorpUpdater.exe"))
                System.IO.File.WriteAllBytes("MagiCorpUpdater.exe", ProxyGui.Properties.Resources.MagiCorpUpdater);
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
                _prox.SessionTerminated += _prox_SessionTerminated;
                _prox.setCientport(chkAdvanced.Checked ? TxtCientPort.Text : "22").sethost(TxtHostName.Text).setpassword(TxtPassword.Text).setServerport(chkAdvanced.Checked ? TxtHostPort.Text : "8080").setusername(TxtUserName.Text).Verbose(ChkVerbose.Checked);
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
                this.Text = "Disconnecting";
                _prox.Stop();

            }

            //program updatah
            //    Assembly assembly = Assembly.GetExecutingAssembly();
            //    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            //   string version = fileVersionInfo.ProductVersion;


            try
            {
                //saveshit
                Properties.Settings.Default.Advanced = chkAdvanced.Checked;
                Properties.Settings.Default.ClientPort = TxtCientPort.Text;
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

            //program updatah
            // Process.Start("MagiCorpUpdater.exe","-p: ProxyGUI -v: 100 -s: http://magicorpltd.co.uk/updater");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("MagiCorpUpdater.exe", "-p:ProxyGUI -v:" + version + " -s:http://magicorpltd.co.uk/updater");
            this.Close();
        }
    }
}
