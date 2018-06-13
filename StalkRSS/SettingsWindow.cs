using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;

namespace StalkRSS
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void ProxySettingsWindow_Load(object sender, EventArgs e)
        { 

            UpdateInterval.Value = Properties.Settings.Default.UpdateInterval;
            ProxySwitch.Checked = Properties.Settings.Default.ProxySwitch;
            ProxyName.Text = Properties.Settings.Default.ProxyName;
            ProxyPort.Value = Properties.Settings.Default.ProxyPort;
            ProxyURL.Text = Properties.Settings.Default.ProxyURL;
            ProxyChange((ProxySwitch.Checked) ? true : false);
            PubDateSwitch.Checked = Properties.Settings.Default.PubDateSwitch;
            byte[] barr_pass = Convert.FromBase64String(Properties.Settings.Default.ProxyPass);
            ProxyPass.Text = Encoding.UTF8.GetString(barr_pass);
        }

        private void ProxyChange(bool state)
        {
                ProxyURL.Enabled = state;
                ProxyName.Enabled = state;
                ProxyPort.Enabled = state;
                ProxyPass.Enabled = state;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //--сохранение пароля
            byte[] barr_pass = Encoding.UTF8.GetBytes(ProxyPass.Text);
            string pass = Convert.ToBase64String(barr_pass);
            Properties.Settings.Default.ProxyPass = pass;
            //------------------

            Properties.Settings.Default.UpdateInterval = Convert.ToInt32(UpdateInterval.Value);
            Properties.Settings.Default.ProxyName = ProxyName.Text;
            Properties.Settings.Default.ProxyURL = ProxyURL.Text;
            Properties.Settings.Default.ProxyPort = Convert.ToInt32(ProxyPort.Value);
            Properties.Settings.Default.ProxySwitch = ProxySwitch.Checked;
            Properties.Settings.Default.PubDateSwitch = PubDateSwitch.Checked;
            Properties.Settings.Default.Save();



            Close();
        }

        private void ProxySwitch_CheckedChanged(object sender, EventArgs e)
        {
            ProxyChange((ProxySwitch.Checked) ? true : false);
            
        }

        private void ProxyPort_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
