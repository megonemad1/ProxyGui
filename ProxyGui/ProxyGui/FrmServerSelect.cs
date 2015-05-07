using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace ProxyGui
{
    public partial class FrmServerSelect : Form
    {
        string ServerURL;

        public FrmServerSelect()
        {
            InitializeComponent();
        }

        private void BtnProceed_Click(object sender, EventArgs e)
        {
            MainLogic();
        }

        private void BtnForceUpd_Click(object sender, EventArgs e)
        {
            MainLogic(true);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LstServerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerURL = LstServerSelect.SelectedItem.ToString() + "/Updater";
            Save();
        }

        private void ChkRemember_CheckedChanged(object sender, EventArgs e)
        {
            Save();
        }

        private void ChkDontShow_CheckedChanged(object sender, EventArgs e)
        {
            Save();
        }

        private void FrmServerSelect_Load(object sender, EventArgs e)
        {
            LoadSettings();
            PullFromWeb();
            //check if we should show based on chkdontshow
            ///       if (ChkDontShow.Checked)
            //    {
            //      MainLogic();
            //}

        }

        private void PullFromWeb()
        {
            try
            {
                WebClient UpdateClient = new WebClient();
                string Servers = UpdateClient.DownloadString("http://rhys.rklyne.net/Updater/ProxyGUI/" + "servers.mup");
                string[] parts = Servers.Split(',');

                foreach (string part in parts)
                {
                    Console.WriteLine(part);
                    LstServerSelect.Items.Add(part);
                }
            }
            catch (Exception X)
            {

                MessageBox.Show(X.Message);
            }

        }

        private void Save()
        {
            try
            {
                Properties.Settings.Default.Serv_URL = LstServerSelect.SelectedItem.ToString();

                Properties.Settings.Default.Serv_DontShow = ChkDontShow.Checked;
                Properties.Settings.Default.Serv_Remember = ChkRemember.Checked;
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);

            }


        }

        private void LoadSettings()
        {
            ChkRemember.Checked = Properties.Settings.Default.Serv_Remember;

            //only load if remember was asked for
            if (ChkRemember.Checked)
            {
                LstServerSelect.SelectedItem = Properties.Settings.Default.Serv_URL;
                ChkDontShow.Checked = Properties.Settings.Default.Serv_DontShow;
            }
        }

        private void MainLogic(bool force = false)
        {

            FrmMain MainFrm = new FrmMain();

            try
            {

                string version = MainFrm.version;
                if (force)
                    version = "001";
                Process.Start("MagiCorpUpdater.exe", "-p:ProxyGUI -v:" + version + " -s:" + ServerURL);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            MainFrm.Close();
            Environment.Exit(1);
            this.Close();

            /*      try
                  {
                      foreach (Process Killme in Process.GetProcessesByName("ProxyGUI"))
                          Killme.Kill();
                  }
                  catch (Exception ex)
                  {
                      Console.WriteLine(ex.Message);
                  }
                  */
        }




    }
}
