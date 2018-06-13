using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StalkRSS
{
    public partial class Viewer : Form
    {
        StringBuilder Result { get; set; }
        public Viewer(ItemRSS item)
        {
            InitializeComponent();
            
            Result = new StringBuilder();
            Result.Append($"<b>{item.Title}</b>");
            Result.Append($"<p>{item.PubDate}</p>");
            Result.Append("<hr>");
            Result.Append($"<p>{item.Description}</p>");
            Result.Append("<hr>");
            Result.Append($"<p>Ссылка: <a href=\"{item.Link}\">{item.Link}</a></p>");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            browser.DocumentText = Result.ToString();
        }

        private void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if(!(e.Url.ToString().Equals("about:blank", StringComparison.InvariantCultureIgnoreCase)))
            {
                 e.Cancel = true;
                 Process defBrowser = Process.Start(e.Url.ToString());
            }

        }
    }
}
