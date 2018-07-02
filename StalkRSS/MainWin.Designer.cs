namespace StalkRSS
{
    partial class MainWin
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StartUpdate = new System.Windows.Forms.ToolStripButton();
            this.Settings = new System.Windows.Forms.ToolStripButton();
            this.About = new System.Windows.Forms.ToolStripButton();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.EventSwitch = new System.Windows.Forms.ToolStripButton();
            this.ListNews = new System.Windows.Forms.ListBox();
            this.AddFeed = new System.Windows.Forms.Button();
            this.UrlRSS = new System.Windows.Forms.TextBox();
            this.ListRSS = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DelFeed = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.TimerForUpdates = new System.Windows.Forms.Timer(this.components);
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.настроитьПроксиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Lavender;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ListNews, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AddFeed, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.UrlRSS, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ListRSS, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DelFeed, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(851, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartUpdate,
            this.Settings,
            this.About,
            this.Exit,
            this.EventSwitch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(851, 30);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // StartUpdate
            // 
            this.StartUpdate.Image = ((System.Drawing.Image)(resources.GetObject("StartUpdate.Image")));
            this.StartUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartUpdate.Name = "StartUpdate";
            this.StartUpdate.Size = new System.Drawing.Size(89, 27);
            this.StartUpdate.Text = "Обновить";
            this.StartUpdate.Click += new System.EventHandler(this.Update_Click);
            // 
            // Settings
            // 
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(95, 27);
            this.Settings.Text = "Настройки";
            this.Settings.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // About
            // 
            this.About.Image = ((System.Drawing.Image)(resources.GetObject("About.Image")));
            this.About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(110, 27);
            this.About.Text = "О программе";
            this.About.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(69, 27);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EventSwitch
            // 
            this.EventSwitch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.EventSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EventSwitch.Name = "EventSwitch";
            this.EventSwitch.Size = new System.Drawing.Size(110, 27);
            this.EventSwitch.Text = "Уведомления вкл.";
            this.EventSwitch.ToolTipText = "Уведомления";
            this.EventSwitch.Click += new System.EventHandler(this.Events_Click);
            // 
            // ListNews
            // 
            this.ListNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListNews.FormattingEnabled = true;
            this.ListNews.HorizontalScrollbar = true;
            this.ListNews.Location = new System.Drawing.Point(5, 35);
            this.ListNews.Margin = new System.Windows.Forms.Padding(5);
            this.ListNews.Name = "ListNews";
            this.tableLayoutPanel1.SetRowSpan(this.ListNews, 5);
            this.ListNews.Size = new System.Drawing.Size(543, 336);
            this.ListNews.TabIndex = 4;
            this.ListNews.DoubleClick += new System.EventHandler(this.listNews_DoubleClick);
            // 
            // AddFeed
            // 
            this.AddFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddFeed.Enabled = false;
            this.AddFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddFeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddFeed.Location = new System.Drawing.Point(558, 95);
            this.AddFeed.Margin = new System.Windows.Forms.Padding(5);
            this.AddFeed.Name = "AddFeed";
            this.AddFeed.Size = new System.Drawing.Size(288, 25);
            this.AddFeed.TabIndex = 2;
            this.AddFeed.TabStop = false;
            this.AddFeed.Text = "Добавить ленту";
            this.AddFeed.UseVisualStyleBackColor = true;
            this.AddFeed.Click += new System.EventHandler(this.addRSS_Click);
            // 
            // UrlRSS
            // 
            this.UrlRSS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrlRSS.Location = new System.Drawing.Point(558, 65);
            this.UrlRSS.Margin = new System.Windows.Forms.Padding(5);
            this.UrlRSS.Name = "UrlRSS";
            this.UrlRSS.Size = new System.Drawing.Size(288, 20);
            this.UrlRSS.TabIndex = 1;
            this.UrlRSS.TextChanged += new System.EventHandler(this.UrlRSS_TextChanged);
            // 
            // ListRSS
            // 
            this.ListRSS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListRSS.FormattingEnabled = true;
            this.ListRSS.Location = new System.Drawing.Point(558, 165);
            this.ListRSS.Margin = new System.Windows.Forms.Padding(5);
            this.ListRSS.Name = "ListRSS";
            this.ListRSS.Size = new System.Drawing.Size(288, 206);
            this.ListRSS.TabIndex = 3;
            this.ListRSS.SelectedIndexChanged += new System.EventHandler(this.ListRSS_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(558, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Добавьте новую ленту:";
            // 
            // DelFeed
            // 
            this.DelFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DelFeed.Enabled = false;
            this.DelFeed.Location = new System.Drawing.Point(558, 130);
            this.DelFeed.Margin = new System.Windows.Forms.Padding(5);
            this.DelFeed.Name = "DelFeed";
            this.DelFeed.Size = new System.Drawing.Size(288, 25);
            this.DelFeed.TabIndex = 6;
            this.DelFeed.Text = "Удалить ленту";
            this.DelFeed.UseVisualStyleBackColor = true;
            this.DelFeed.Click += new System.EventHandler(this.DelFeed_Click);
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status,
            this.ProgressBar});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(851, 20);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(16, 15);
            this.Status.Text = "...";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ProgressBar.MarqueeAnimationSpeed = 20;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 14);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // TimerForUpdates
            // 
            this.TimerForUpdates.Enabled = true;
            this.TimerForUpdates.Interval = 60000;
            this.TimerForUpdates.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notify
            // 
            this.notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify.BalloonTipText = "StalkRSS";
            this.notify.BalloonTipTitle = "StalkRSS";
            this.notify.ContextMenuStrip = this.trayMenu;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "StalkRSS";
            this.notify.Visible = true;
            this.notify.BalloonTipClicked += new System.EventHandler(this.Notify_BalloonTipClicked);
            this.notify.DoubleClick += new System.EventHandler(this.Notify_DoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настроитьПроксиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(150, 70);
            // 
            // настроитьПроксиToolStripMenuItem
            // 
            this.настроитьПроксиToolStripMenuItem.Name = "настроитьПроксиToolStripMenuItem";
            this.настроитьПроксиToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.настроитьПроксиToolStripMenuItem.Text = "Настройки";
            this.настроитьПроксиToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 396);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWin";
            this.Text = "...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
            this.Load += new System.EventHandler(this.MainWin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AddFeed;
        private System.Windows.Forms.TextBox UrlRSS;
        private System.Windows.Forms.ListBox ListRSS;
        private System.Windows.Forms.ListBox ListNews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TimerForUpdates;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button DelFeed;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripMenuItem настроитьПроксиToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton StartUpdate;
        private System.Windows.Forms.ToolStripButton Settings;
        private System.Windows.Forms.ToolStripButton About;
        private System.Windows.Forms.ToolStripButton Exit;
        private System.Windows.Forms.ToolStripButton EventSwitch;
    }
}

