using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace StalkRSS
{
    public partial class MainWin : Form
    {
        Feed CurrentFeed { get; set; }
        List<Feed> feedList = new List<Feed>();
        BindingSource bs;
        Image[] notifyMode;
        int selectedIndexForContextMenu;
        int selectedIndexForNewsContextMenu;
        
        public MainWin()
        {
            Properties.Settings.Default.Reload();
            InitializeComponent();

            notifyMode = new Image[]
            {
                Properties.Resources.NotifyOn,
                Properties.Resources.NotifyOff
            };

            bs = new BindingSource
            {
                DataSource = feedList
            };
        }

        private void UpdateShowMessage(object sender, EventArgs e) //есть новости
        {
            
            Feed f = (Feed)sender;
            if(Properties.Settings.Default.HasEventsShow)
                notify.ShowBalloonTip(5000, f.Title, "Есть обновления", ToolTipIcon.None);

            if( CurrentFeed!=null && f.Equals(CurrentFeed))
            {
                ShowRSS(feedList.IndexOf(CurrentFeed));
            }
        }

        private void LoadRSSFeed(object sender, EventArgs e) //добавление прошло успешно
        {
            bs.Add((Feed)sender);
            int index = feedList.IndexOf((Feed)sender);
            ListRSS.SelectedIndex = index;
            ShowRSS(index);
            SaveRSS();
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
            using (FileStream fs = new FileStream("stalkrss.dat", FileMode.Create))
            {
                bf.Serialize(fs, feedList);
            }
        }

        private void SaveFormSize()
        {
            Properties.Settings.Default.MainFormSize = this.Size;
            Properties.Settings.Default.HasSetSize = true;       
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

        private void LoadFormSize()
        {
            if(Properties.Settings.Default.HasSetSize)
            {
                this.Size = Properties.Settings.Default.MainFormSize;
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {           
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            LoadFormSize();
            string s = Application.ProductName + " " + Application.ProductVersion;
            Text = notify.Text = s;

            ListRSS.DataSource = bs;
            ListRSS.DisplayMember = "Title";
            TimerForUpdates.Interval = Properties.Settings.Default.UpdateInterval * 60000;


            if (Properties.Settings.Default.HasEventsShow)
            {
                EventSwitch.Text = "Уведомления вкл.";
                EventSwitch.Image = notifyMode[0];
            }
            else
            {
                EventSwitch.Text = "Уведомления выкл.";
                EventSwitch.Image = notifyMode[1];
            }
            
            ContextMenuForList.Items.Insert(0, new ToolStripLabel("..."));
            ContextMenuForNews.Items.Insert(0, new ToolStripLabel("..."));

            //  ContextMenuForList.Items[0].ForeColor = 
            ContextMenuForList.Items[0].ForeColor = Color.FromArgb(239, 127, 26);
            ContextMenuForNews.Items[0].ForeColor = Color.FromArgb(239, 127, 26);

            LoadRSS();
            CheckUpdates();

            if (feedList.Count!=0 && feedList[0]!=null)
            {
                CurrentFeed = feedList[0];
                ShowRSS(0);
            }              
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            SaveFormSize();
            SaveRSS();
            Properties.Settings.Default.Save();
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
                    Status.Text = "Ошибка разбора документа...";
                }
                catch (Exception ex)
                {
                    notify.ShowBalloonTip(5000, "Ошибка", "Не удалось проверить обновления для ленты " + feedList[i].Title + " из-за неизвестной ошибки", ToolTipIcon.Error);
                    notify.ShowBalloonTip(5000, "Ошибка", ex.Message, ToolTipIcon.Error);
                    Status.Text = "Ошибка...";
                }
            }
            ProgressBar.Visible = false;
        }

        private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveRSS();
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
                Application.Exit();
            }
        }

        private void DelFeed_Click(object sender, EventArgs e)
        {
            bs.RemoveAt(ListRSS.SelectedIndex);
            SaveRSS();
            if (feedList.Count == 0)
                ListNews.Items.Clear();
        }

        private void ListRSS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DelFeed.Enabled = (ListRSS.SelectedIndex != -1) ? true : false;
            if (ListRSS.SelectedIndex != -1)
            {
                CurrentFeed = feedList[ListRSS.SelectedIndex];
                ShowRSS(ListRSS.SelectedIndex);
            }
        }

        private void ShowRSS(int element)
        {
            ListNews.Items.Clear();
            StringBuilder newsTitle = new StringBuilder();
            for (int i = 0; i < feedList[element].Items.Count; ++i)
            {
                if (Properties.Settings.Default.PubDateSwitch)
                    newsTitle.Append(feedList[element].Items[i].PubDate + " | ");

                newsTitle.Append(feedList[element].Items[i].Title);
                ListNews.Items.Add(newsTitle.ToString());
                newsTitle.Clear();
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

        private void Events_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HasEventsShow == true)
            {
                Properties.Settings.Default.HasEventsShow = false;
                EventSwitch.Text = "Уведомления выкл.";
                EventSwitch.Image = notifyMode[1];
            }     
            else
            {
                Properties.Settings.Default.HasEventsShow = true;
                EventSwitch.Text = "Уведомления вкл.";
                EventSwitch.Image = notifyMode[0];
            }
                
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void CopyURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = selectedIndexForContextMenu;

            if (i != -1)
            {
                Feed f = feedList[i];
                Clipboard.SetText(f.URL);
            }
        }



        private void ListRSS_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int i = ListRSS.IndexFromPoint(e.X, e.Y);
                Console.WriteLine(i);
                if(i!=-1)
                {
                    selectedIndexForContextMenu = i;
                    ContextMenuForList.Items[0].Text = feedList[i].Title;
                    ContextMenuForList.Show(MousePosition);
                    
                }
                
            }
        }

        private void OpenRSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = selectedIndexForContextMenu;
            if (i != -1)
            {
                Feed f = feedList[i];
                try
                {
                    Process p = Process.Start(f.URL);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Возникла ошибка.\n" + ex.Message);
                }
            }
        }

        private void OpenWebSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = selectedIndexForContextMenu;
            if (i != -1)
            {
                Feed f = feedList[i];
                try
                {
                    Uri uri = new Uri(f.URL);
                    string url = uri.GetLeftPart(UriPartial.Scheme) + uri.Host;
                    Process p = Process.Start(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка.\n" + ex.Message);
                }
            }
        }

        private void копироватьURLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = selectedIndexForNewsContextMenu;

            if (i != -1)
            {
                string link = CurrentFeed.Items[selectedIndexForNewsContextMenu].Link;
                if(!String.IsNullOrWhiteSpace(link))
                    Clipboard.SetText(link);
            }
        }

        private void ListNews_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int i = ListNews.IndexFromPoint(e.X, e.Y);
                Console.WriteLine(i);
                if (i != -1)
                {
                    selectedIndexForNewsContextMenu = i;
                    ContextMenuForNews.Items[0].Text = CreateTitle(CurrentFeed.Items[i].Title);
                    ContextMenuForNews.Show(MousePosition);

                }
            }
        }

        private string CreateTitle(string s)
        {
            string res = s;
            if(res.Length > 15)
            {
                res = res.Substring(0, 15);
                res += "...";
            }
            Console.WriteLine(">>>" + res);
            return res;
        }

        private void открытьВБраузереToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = selectedIndexForNewsContextMenu;
            if (i != -1)
            {  
                try
                {
                    string link = CurrentFeed.Items[selectedIndexForNewsContextMenu].Link;
                    if (!string.IsNullOrWhiteSpace(link))
                            Process.Start(link);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка.\n" + ex.Message);
                }
            }
        }
    }
}
