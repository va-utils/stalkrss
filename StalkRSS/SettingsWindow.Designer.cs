namespace StalkRSS
{
    partial class SettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ProxyURL = new System.Windows.Forms.TextBox();
            this.ProxyName = new System.Windows.Forms.TextBox();
            this.ProxyPass = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ProxyPort = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.PubDateSwitch = new System.Windows.Forms.CheckBox();
            this.ProxySwitch = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ProxyURL, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProxyName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ProxyPass, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.SaveButton, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.ProxyPort, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.UpdateInterval, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.PubDateSwitch, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.ProxySwitch, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 339);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(554, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Если Ваше Интернет-соединение работает через прокси-сервер или цензурируется, Вы " +
    "можете настроить его в этом окне.\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP или доменное имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Порт:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Имя:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Пароль:";
            // 
            // ProxyURL
            // 
            this.ProxyURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyURL.Location = new System.Drawing.Point(283, 73);
            this.ProxyURL.Name = "ProxyURL";
            this.ProxyURL.Size = new System.Drawing.Size(274, 20);
            this.ProxyURL.TabIndex = 2;
            // 
            // ProxyName
            // 
            this.ProxyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyName.Location = new System.Drawing.Point(283, 143);
            this.ProxyName.Name = "ProxyName";
            this.ProxyName.Size = new System.Drawing.Size(274, 20);
            this.ProxyName.TabIndex = 4;
            // 
            // ProxyPass
            // 
            this.ProxyPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyPass.Location = new System.Drawing.Point(283, 178);
            this.ProxyPass.Name = "ProxyPass";
            this.ProxyPass.PasswordChar = '*';
            this.ProxyPass.Size = new System.Drawing.Size(274, 20);
            this.ProxyPass.TabIndex = 5;
            this.ProxyPass.UseSystemPasswordChar = true;
            // 
            // SaveButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SaveButton, 2);
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveButton.Location = new System.Drawing.Point(3, 291);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(554, 45);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Сохранить настройки";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ProxyPort
            // 
            this.ProxyPort.Location = new System.Drawing.Point(283, 108);
            this.ProxyPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.ProxyPort.Name = "ProxyPort";
            this.ProxyPort.Size = new System.Drawing.Size(120, 20);
            this.ProxyPort.TabIndex = 3;
            this.ProxyPort.ValueChanged += new System.EventHandler(this.ProxyPort_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label7, 2);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(554, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Другие настройки:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(274, 30);
            this.label8.TabIndex = 13;
            this.label8.Text = "Интервал обновления(мин):";
            // 
            // UpdateInterval
            // 
            this.UpdateInterval.Location = new System.Drawing.Point(283, 261);
            this.UpdateInterval.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.UpdateInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpdateInterval.Name = "UpdateInterval";
            this.UpdateInterval.Size = new System.Drawing.Size(120, 20);
            this.UpdateInterval.TabIndex = 6;
            this.UpdateInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PubDateSwitch
            // 
            this.PubDateSwitch.AutoSize = true;
            this.PubDateSwitch.Location = new System.Drawing.Point(3, 233);
            this.PubDateSwitch.Name = "PubDateSwitch";
            this.PubDateSwitch.Size = new System.Drawing.Size(208, 17);
            this.PubDateSwitch.TabIndex = 14;
            this.PubDateSwitch.Text = "Показывать дату и время новостей";
            this.PubDateSwitch.UseVisualStyleBackColor = true;
            // 
            // ProxySwitch
            // 
            this.ProxySwitch.AutoSize = true;
            this.ProxySwitch.Location = new System.Drawing.Point(3, 38);
            this.ProxySwitch.Name = "ProxySwitch";
            this.ProxySwitch.Size = new System.Drawing.Size(182, 17);
            this.ProxySwitch.TabIndex = 1;
            this.ProxySwitch.Text = "Работать через прокси (HTTP)";
            this.ProxySwitch.UseVisualStyleBackColor = true;
            this.ProxySwitch.CheckedChanged += new System.EventHandler(this.ProxySwitch_CheckedChanged);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 339);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsWindow";
            this.Text = "Настройки сети";
            this.Load += new System.EventHandler(this.ProxySettingsWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ProxySwitch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ProxyURL;
        private System.Windows.Forms.TextBox ProxyName;
        private System.Windows.Forms.TextBox ProxyPass;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.NumericUpDown ProxyPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown UpdateInterval;
        private System.Windows.Forms.CheckBox PubDateSwitch;
    }
}