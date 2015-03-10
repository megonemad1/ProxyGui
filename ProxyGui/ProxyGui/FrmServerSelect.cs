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
        }

        private void FrmServerSelect_Load(object sender, EventArgs e)
        {

        }



        private void Save()
        {
            Properties.Settings.Default.Serv_URL = LstServerSelect.SelectedItem.ToString();
            Properties.Settings.Default.Serv_DontShow = ChkDontShow.Checked;
            Properties.Settings.Default.Serv_Remember = ChkRemember.Checked;
        }

        private void Load()
        {
            LstServerSelect.SelectedItem = Properties.Settings.Default.Serv_URL;
            ChkDontShow.Checked = Properties.Settings.Default.Serv_DontShow;
            ChkRemember.Checked = Properties.Settings.Default.Serv_Remember;
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
            this.Close();

            try
            {
                foreach (Process Killme in Process.GetProcessesByName("ProxyGUI"))
                    Killme.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ChkRemember_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChkDontShow_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
