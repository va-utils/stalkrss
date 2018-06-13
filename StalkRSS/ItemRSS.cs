using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StalkRSS
{
    [Serializable]
    public class ItemRSS
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public string PubDate { get; private set; }

        public ItemRSS(XmlNode xmlitem)
        {
            foreach(XmlNode tag in xmlitem.ChildNodes)
            {
                switch(tag.Name)
                {
                    case "title":
                        Title = tag.InnerText;
                        break;
                    case "link":
                        Link = tag.InnerText;
                        break;
                    case "description":
                        Description = tag.InnerText;
                        break;
                    case "pubDate":
                        PubDate = tag.InnerText;
                        break;
                }
            }
        }
    }
}
