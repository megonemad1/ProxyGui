using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtech;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.Net.Configuration;


/* 
 *  ____                               ____    __  __  ______     
 * /\  _`\                            /\  _`\ /\ \/\ \/\__  _\    
 * \ \ \L\ \_ __   ___   __  _  __  __\ \ \L\_\ \ \ \ \/_/\ \/    
 *  \ \ ,__/\`'__\/ __`\/\ \/'\/\ \/\ \\ \ \L_L\ \ \ \ \ \ \ \    
 *   \ \ \/\ \ \//\ \L\ \/>  </\ \ \_\ \\ \ \/, \ \ \_\ \ \_\ \__ 
 *    \ \_\ \ \_\\ \____//\_/\_\\/`____ \\ \____/\ \_____\/\_____\
 *     \/_/  \/_/ \/___/ \//\/_/ `/___/> \\/___/  \/_____/\/_____/
 *                                  /\___/                        
 *                                  \/__/   By Rhys P with modifications by James W                    
 *  
 *          CHANGE  LOG   
 *   date    | user  | changelog
 *   --------------------------
 * 09-mar-15 | james | kais demise, versioning, magicorp update, write libs on boot, update form layout, combine to master on gh
 * 09-mar-15 | james | fancy label stuff, login shit fancy shit fucking fancy 
 * 09-mar-15 | rhys  | created logo for form, created kais demise image
 * 
 * 10-mar-15 | james | added high bandwidth server option, cleaning code, new form to select servers and testing characters in version
 * 
 * 16-mar-15 | james | foundationing compression etc
 * 
 * 17-mar-15 | james | security fixes, insert to bypass, password fix
 * 17-mar-15 | james | now pulls update servers from the web, auto checks for update on startup (green if up to date, blue if unknown, red if out of date)
 * 17-mar-15 | james | force update feature (probably only useful for testing but whatever), foundations for a settings button & form
 * 17-mar-15 | rhys  | started proxylib rewrite (security fixes)
 * 29-mar-15 | james | fixed updating, prep for rhys dll rewrite
 * 07/05/2015| rhys  | added new dll verry minor additions also added a lan reset button so it can be reverted manuly
 *             TO  DO
 *URGENT: PW FIXES - fixed
 *Maybe force user to input pw into klink? safer than -pw [applied as tempfix by james]-----
 *added new dll entering pasword now safe... no longer have a shell though need to build one
 *SSH keys
 *-C compression option
 *-i hashkey to login 
 *Poll server for authed logins <encrypted as bin?>
 *Setup ping on serv selection
 *Pull servers from the web [done]
 *inapp changelog
 *
 * 
 * 
 * 
 * */


namespace ProxyGui
{
    public partial class FrmMain : Form
    {
        //!?!?!?!?!?!?!?!?!?!?!??!?!?!?!??!?!?!?!?!?!??!?!?!?!?
        public string version = "120"; //Change me when you change something !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
        //!?!?!?!?!?!?!?!?!?!?!??!?!?!?!??!?!?!?!?!?!??!?!?!?!?

        public string usrmode = "user";


        Proxy _prox;
        public FrmMain()
        {
            InitializeComponent();

            //parenting pictureboxes together
            PicProxyGUI.Controls.Add(PicImproved);


            this.Text = "Disconnected";
            this.TxtCientPort.Enabled = false;
            this.TxtHostPort.Enabled = false;

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                TrayIcon.Visible = true;
                TrayIcon.ShowBalloonTip(500);
                this.Hide();
                this.ShowInTaskbar = false;
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                this.ShowInTaskbar = true;
            }
        }

        private void TrayIcon_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
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
                _prox.sethost(TxtHostName.Text).TurnOffShell(ChkHideShell.Checked).AutoStoreSshkey(ChkSaveKey.Checked).sethost(TxtHostName.Text).Verbose(ChkVerbose.Checked).setlogin(TxtUserName.Text,TxtPassword.Text);
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
            SetControlPropertyThreadSafe(button2, "Enabled", false);

        }

        void _prox_SessionTerminated(object source, ProxyInfo e)
        {
            SetControlPropertyThreadSafe(button2, "Enabled", true);
            SetControlPropertyThreadSafe(this, "Text", "Disconnected");
            SetControlPropertyThreadSafe(button1, "Text", "Start");
            if (_prox.errors.Count > 0)
            {
                MessageBox.Show(_prox.errors.Peek().ToString());
                StreamWriter SW = new StreamWriter("log-latest.txt");
                for (int i = 0; i < _prox.errors.Count; i++)
                {
                    SW.WriteLine(_prox.errors.Dequeue().ToString());
                }
                SW.Close();
                SW.Dispose();
                _prox.resetLan();
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnStartStop_Click(button1, new EventArgs());
            else if (e.KeyCode == Keys.Insert)
            {

                DialogResult SecurityWarning = MessageBox.Show("By clicking OK you accept that anyone may be able to see your password. Do not use this on a public machine where administrators can see the programs you're running.", "SECURITY WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (SecurityWarning == DialogResult.OK)
                {
                    TxtPassword.Enabled = true;
                    LblPWorKEY.Enabled = true;
                    ChkHideShell.Enabled = true;
                    LblHideShell.Enabled = true;
                }
                else
                {
                    TxtPassword.Enabled = false;
                    LblPWorKEY.Enabled = false;
                    ChkHideShell.Enabled = false;
                    LblHideShell.Enabled = false;
                }
            }
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
            if( _prox!=null)
            _prox.Dispose();
            //program updatah
            //    Assembly assembly = Assembly.GetExecutingAssembly();
            //    FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            //   string version = fileVersionInfo.ProductVersion;


            Save();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Version label
            VersionLbl.Text = version;
            VersionLbl.ForeColor = Color.Blue;

            try
            {
                WebClient UpdateClient = new WebClient();
                string webver = UpdateClient.DownloadString("http://rhys.rklyne.net/Updater/ProxyGUI/" + "version.mup");

                if (Convert.ToInt32(webver) > Convert.ToInt32(version))
                {
                    VersionLbl.ForeColor = Color.Red;
                    MessageBox.Show("Update is available.");
                }
                else
                {
                    VersionLbl.ForeColor = Color.Green;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            //Kai'sDemise
            string[] DevUsr = new string[] { "james", "rhys" };
            string[] DebugUsr = new string[] { "kai" };

            if (System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToLower().Split(DevUsr, StringSplitOptions.None).Length > 1)
            {
                PicImproved.Visible = true;
                usrmode = "dev";
                UsrModeLbl.Text = "Developer Mode";
            }
            else if (System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToLower().Split(DebugUsr, StringSplitOptions.None).Length > 1)
            {
                // MessageBox.Show("HI KAI");
                PicImproved.Visible = true;
                PicImproved.Image = Properties.Resources.kai_fun_stuff;  //set this to kais special ver
                usrmode = "debug";
                UsrModeLbl.Text = "Debug Mode";
            }
            else
            {
                usrmode = "user";
                UsrModeLbl.Text = "User Mode";
            }
            //MessageBox.Show(System.Security.Principal.WindowsIdentity.GetCurrent().Name);


            //make sure runtimes exist... placing them on EACH boot (fixing update only updating proxygui.exe)
            try
            {


                //     if (!File.Exists("ProxyLib.dll"))
                //       {
                System.IO.File.WriteAllBytes("ProxyLib.dll", ProxyGui.Properties.Resources.ProxyLib);
                //       }

                //       if (!File.Exists("MagiCorpUpdater.exe"))
                //        {
                System.IO.File.WriteAllBytes("MagiCorpUpdater.exe", ProxyGui.Properties.Resources.MagiCorpUpdater);
                //       }

                //      if (!File.Exists("klink.exe"))
                //      {
                System.IO.File.WriteAllBytes("klink.exe", Properties.Resources.klink);
                //      }
            }
            catch (Exception xe)
            {

                Console.WriteLine(xe.Message);
            }

            LoadSettings();

            //program updatah
            // Process.Start("MagiCorpUpdater.exe","-p: ProxyGUI -v: 100 -s: http://magicorpltd.co.uk/updater");


        }

        private void ChkHideShell_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as CheckBox).Checked)
                TxtPassword.Text = "";
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (usrmode == "dev" | usrmode == "debug")
            {
                FrmServerSelect SelectServer = new FrmServerSelect();
                SelectServer.Show();
            }
            else
            {
                Process.Start("MagiCorpUpdater.exe", "-p:ProxyGUI -v:" + version + " -s:http://magicorpltd.co.uk/Updater");
                Environment.Exit(1);
            }
        }



        private void Save()
        {
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

        private void LoadSettings()
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

        private void chkUseKey_CheckedChanged(object sender, EventArgs e)
        {
            //Use an SSH key instead of password
            if (chkUseKey.Checked)
            {
                LblPWorKEY.Text = "Key Hash: ";
            }
            else
            {
                LblPWorKEY.Text = "Password: ";
            }


        }

        private void chkCompress_CheckedChanged(object sender, EventArgs e)
        {
            //add -C switch to klink
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            //show settings form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _prox.resetLan();
        }


    }
}
