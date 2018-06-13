using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace StalkRSS
{
    public partial class MainWin : Form
    {
        Feed CurrentFeed { get; set; }
        List<Feed> feedList = new List<Feed>();
        BindingSource bs;
        public MainWin()
        {
            Properties.Settings.Default.Reload();
            InitializeComponent();
            bs = new BindingSource
            {
                DataSource = feedList
            };
            ListRSS.DataSource = bs;
            ListRSS.DisplayMember = "Title";
            TimerForUpdates.Interval =  Properties.Settings.Default.UpdateInterval * 60000;

        }

        private void UpdateShowMessage(object sender, EventArgs e)
        {
            Feed f = (Feed)sender;
            notify.ShowBalloonTip(5000, f.Title, "Есть обновления", ToolTipIcon.None);
        }

        private void LoadRSSFeed(object sender, EventArgs e)
        {
            bs.Add((Feed)sender);
        }

        private async void addRSS_Click(object sender, EventArgs e)
        {
            bool res = Uri.TryCreate(UrlRSS.Text, UriKind.Absolute, out Uri UriResult);
            if (res==false)
            {
                UrlRSS.Text = UrlRSS.Text.Insert(0, "http://");
            }

            try
            {
                Feed newFeed = new Feed(UrlRSS.Text);

                if (feedList.Contains(newFeed))
                    throw new AlreadyExistsFeedException();

                newFeed.Update += UpdateShowMessage;
                newFeed.Loaded += LoadRSSFeed;
                
                await newFeed.LoadFeed(); 
            }
            catch (AlreadyExistsFeedException)
            {
                MessageBox.Show("Вы уже читаете эту ленту.", "Добавление ленты");
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("При добавлении ленты возникла сетевая ошибка. Возможно, соединение отсутствует или цензурируется. ", "Добавление ленты");           
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("При добавлении ленты возникла сетевая ошибка. Возможно, соединение отсутствует или цензурируется. ", "Добавление ленты");
            }
            catch (System.Xml.XmlException)
            {
                MessageBox.Show("При добавлении ленты возникла ошибка разбора документа. Возможно, Вы ввели адрес веб-страницы, а не RSS-ленты. ", "Добавление ленты");
            }
            catch (Exception ex)
            {
                MessageBox.Show("При добавлении ленты возникла ошибка. Возможно, адрес набран неправильно.\n" + ex.Message, "Добавление ленты");
            }
            finally
            {
                UrlRSS.Clear();
            }
        }

        private void listNews_DoubleClick(object sender, EventArgs e)
        {
            if(ListRSS.SelectedIndex!=-1)
            {
                if(ListNews.SelectedIndex!=-1)
                {
                    Viewer v = new Viewer(CurrentFeed.Items[ListNews.SelectedIndex]);
                    v.Show();
                }
            }
        }

        private void SaveRSS()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("stalkrss.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, feedList);
            }
        }

        private void LoadRSS()
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("stalkrss.dat", FileMode.Open))
                {
                    feedList = (List<Feed>)bf.Deserialize(fs);
                    for (int i=0;i<feedList.Count;i++)
                    {
                        feedList[i].Update += UpdateShowMessage;
                        feedList[i].Loaded += LoadRSSFeed;
                    }
                    bs.DataSource = feedList;
                    
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            string s = Application.ProductName + " " + Application.ProductVersion;
            Text = notify.Text = s;
            LoadRSS();
            CheckUpdates();
        }

        private void MinimizeToTray()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void ShowFromTray()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckUpdates();
        }

        private async void CheckUpdates()
        {
            Status.Text = "Обновление...";
            ProgressBar.Visible = true;
            if(feedList.Count==0)
            {
                Status.Text = "Новости еще не обновлялись...";
            }

            for (int i = 0; i < feedList.Count; ++i)
            {
                try
                {
                    await feedList[i].UpdateFeed();
                    Status.Text = String.Format("Последнее обновление выполнено в {0} ", DateTime.Now.ToLongTimeString());           
                }
                catch (System.Net.WebException)
                {
                    notify.ShowBalloonTip(5000, "Ошибка подключения", "Не удалось проверить обновления для ленты " + feedList[i].Title + " из-за проблем с сетью.", ToolTipIcon.Warning);
                    Status.Text = "Ошибка соединения...";
                }

                catch (System.Net.Sockets.SocketException)
                {
                    notify.ShowBalloonTip(5000, "Ошибка подключения", "Не удалось проверить обновления для ленты " + feedList[i].Title + " из-за проблем с сетью.", ToolTipIcon.Warning);
                    Status.Text = "Ошибка соединения...";
                }
                catch (System.Xml.XmlException)
                {
                    MessageBox.Show("При обновлении ленты возникла ошибка разбора документа. Возможно, адрес ленты изменился ", "Добавление ленты");
                }
                catch (Exception ex)
                {
                    notify.ShowBalloonTip(5000, "Ошибка", "Не удалось проверить обновления для ленты " + feedList[i].Title + " из-за неизвестной ошибки", ToolTipIcon.Error);
                    notify.ShowBalloonTip(5000, "Ошибка", ex.Message, ToolTipIcon.Error);
                }
            }
            ProgressBar.Visible = false;
        }

        private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                MinimizeToTray();
            }
        }

        private void Notify_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                MinimizeToTray();

            }
            else if (WindowState == FormWindowState.Minimized)
            {
                ShowFromTray();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Закрыть {Application.ProductName}?\nВы перестанете получать уведомления о новостях, пока не запустите приложение.", "Закрыть?", MessageBoxButtons.OKCancel);
            if(dialogResult == DialogResult.OK)
            {
                SaveRSS();
                Application.Exit();
            }
        }

        private void DelFeed_Click(object sender, EventArgs e)
        {
            bs.RemoveAt(ListRSS.SelectedIndex);
        }

        private void ListRSS_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelFeed.Enabled = (ListRSS.SelectedIndex != -1) ? true : false;
            if (ListRSS.SelectedIndex != -1)
            {
                ListNews.Items.Clear();
                StringBuilder newsTitle = new StringBuilder();
                for (int i = 0; i < feedList[ListRSS.SelectedIndex].Items.Count; ++i)
                {
                    if (Properties.Settings.Default.PubDateSwitch)
                        newsTitle.Append(feedList[ListRSS.SelectedIndex].Items[i].PubDate + " | ");
                    newsTitle.Append(feedList[ListRSS.SelectedIndex].Items[i].Title);
                    ListNews.Items.Add(newsTitle.ToString());
                    newsTitle.Clear();
                }
                CurrentFeed = feedList[ListRSS.SelectedIndex];
            }
        }

        private void UrlRSS_TextChanged(object sender, EventArgs e)
        {
            AddFeed.Enabled = (String.IsNullOrWhiteSpace(UrlRSS.Text)) ? false : true;
        }

        private void Notify_BalloonTipClicked(object sender, EventArgs e)
        {
            ShowFromTray();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow psw = new SettingsWindow();
            psw.ShowDialog();
            TimerForUpdates.Interval = Properties.Settings.Default.UpdateInterval * 60000;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            CheckUpdates();
        }
    }
}
