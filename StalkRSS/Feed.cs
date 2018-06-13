using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace StalkRSS
{
    [Serializable]
    public class AlreadyExistsFeedException : Exception
    {
        public AlreadyExistsFeedException() { }
        public AlreadyExistsFeedException(string message) : base(message) { }
        public AlreadyExistsFeedException(string message, Exception inner) : base(message, inner) { }
        protected AlreadyExistsFeedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    class Feed
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public ItemsRSS Items { get; private set; }
        public string LastPubDate { get; private set; }
        public string URL { get; private set; }


        [field: NonSerialized]
        public event EventHandler Update;

        [field: NonSerialized]
        public event EventHandler Loaded;

        [field: NonSerialized]
        public event EventHandler StartLoad;

        [field: NonSerialized]
        public event EventHandler EndLoad;

        public Feed(string url)
        {
            LastPubDate = string.Empty;
            this.URL = url;
        }

        public override bool Equals(object obj)
        {
            if(obj is Feed && obj!=null)
            {
                Feed tmp = (Feed)obj;
                if (this.URL == tmp.URL)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.URL.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Title} {URL}";
        }

        public async Task LoadFeed()
        {
            XmlTextReader xmlReader;
            WebClient wc = new WebClient();
            System.IO.Stream stream = null ;
            if (Properties.Settings.Default.ProxySwitch)
            {
                WebProxy wp = new WebProxy(Properties.Settings.Default.ProxyURL, Properties.Settings.Default.ProxyPort);
                byte[] barr_pass = Convert.FromBase64String(Properties.Settings.Default.ProxyPass);
                string pass = Encoding.UTF8.GetString(barr_pass);
                wp.Credentials = new NetworkCredential(Properties.Settings.Default.ProxyName, pass);
                wc.Proxy = wp;
                pass = null;
            }

            stream = await wc.OpenReadTaskAsync(URL);

            if (stream == null)
                return;
            
            xmlReader = new XmlTextReader(stream);
                        
            XmlDocument xmlDocument = new XmlDocument();
            Items = new ItemsRSS();
            try
            {
                xmlDocument.Load(xmlReader);
                xmlReader.Close();
                XmlNode channelXmlNode = xmlDocument.GetElementsByTagName("channel")[0];
                LastPubDate = xmlDocument.GetElementsByTagName("pubDate")[0].InnerText;
                if (channelXmlNode != null)
                {
                    StartLoad?.Invoke(this, new EventArgs());
                    foreach (XmlNode channelNode in channelXmlNode.ChildNodes)
                    {
                        switch (channelNode.Name)
                        {
                            case "title":
                                Title = channelNode.InnerText;
                                break;
                            case "description":
                                Description = channelNode.InnerText;
                                break;
                            case "link":
                                Link = channelNode.InnerText;
                                break;
                            case "item":
                                ItemRSS chanItem = new ItemRSS(channelNode);
                                Items.Add(chanItem);
                                break;
                        }
                    }
                    Loaded?.Invoke(this, new EventArgs());
                }
                else
                {
                    throw new Exception("RSS not found");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                EndLoad?.Invoke(this, new EventArgs());
                xmlReader.Close();
            }
        }

        public async Task UpdateFeed()
        {
            string newPubDate = string.Empty;
            System.IO.Stream stream = null;
            XmlTextReader xmlReader;
            
            WebClient wc = new WebClient();


            if (Properties.Settings.Default.ProxySwitch)
            {
                WebProxy wp = new WebProxy(Properties.Settings.Default.ProxyURL, Properties.Settings.Default.ProxyPort);
                byte[] barr_pass = Convert.FromBase64String(Properties.Settings.Default.ProxyPass);
                string pass = Encoding.UTF8.GetString(barr_pass);
                wp.Credentials = new NetworkCredential(Properties.Settings.Default.ProxyName, pass);
                wc.Proxy = wp;
                pass = null;
            }

            stream = await wc.OpenReadTaskAsync(URL);

            if (stream == null) return;
            xmlReader = new XmlTextReader(stream);

            XmlDocument xmlDocument = new XmlDocument();
            
            try
            {
                xmlDocument.Load(xmlReader);
                xmlReader.Close();
                XmlNode channelXmlNode = xmlDocument.GetElementsByTagName("channel")[0];
                newPubDate = xmlDocument.GetElementsByTagName("pubDate")[0].InnerText;
                if (newPubDate.Equals(LastPubDate))
                {
                    return;
                }
                Update?.Invoke(this, new EventArgs());
                LastPubDate = newPubDate;
                Items = new ItemsRSS();
                if (channelXmlNode != null)
                {
                    StartLoad?.Invoke(this, new EventArgs());
                    foreach (XmlNode channelNode in channelXmlNode.ChildNodes)
                    {
                        switch (channelNode.Name)
                        {
                            case "item":
                                ItemRSS chanItem = new ItemRSS(channelNode);
                                Console.WriteLine("chanItem = " + chanItem.PubDate);
                                Console.WriteLine("LastPubDate = " + LastPubDate);
                                Items.Add(chanItem);
                                break;
                        }
                    }
                }
                else
                {
                    throw new Exception("RSS not found");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                EndLoad?.Invoke(this, new EventArgs());
                xmlReader.Close();
            }
            
        }
        
    }
}
