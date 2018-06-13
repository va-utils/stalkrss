using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalkRSS
{
    [Serializable]
    class ItemsRSS : List<ItemRSS>
    {
        new public bool Contains(ItemRSS item)
        {
            foreach(ItemRSS checkItem in this)
            {
                if (item.Title == checkItem.Title)
                    return true;
            }
            return false;
        }

        public ItemRSS GetItemRSS(string title)
        {
            foreach(ItemRSS item in this)
            {
                if(item.Title == title)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
