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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LstServerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerURL = LstServerSelect.SelectedItem.ToString() + "/updater";
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

            //check if we should show based on chkdontshow
            if (ChkDontShow.Checked)
            {
                MainLogic();
            }

            Pingaling();

        }

        private void Pingaling()
        {
            Ping pingSender = new Ping();
            //      PingReply reply = pingSender.Send(IPAddress "magicorpltd.co.uk", 400);

            //    if (reply.Status == IPStatus.Success)
            //     {
            //          LblServer1Active.Text = Convert.ToString(reply.RoundtripTime);
            //      }
            //      else
            //       {
            LblServer1Active.Text = "Offline";
            LblServer2Active.Text = "Offline";
            LblServer3Active.Text = "Offline";
            //      }
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
                MessageBox.Show(er.Message);

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

        private void MainLogic()
        {

            FrmMain MainFrm = new FrmMain();

            try
            {
                Process.Start("MagiCorpUpdater.exe", "-p:ProxyGUI -v:" + MainFrm.version + " -s:" + ServerURL);
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
