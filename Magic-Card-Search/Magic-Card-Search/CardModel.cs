using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Card_Search
{
    public class CardModel
    {
        private string name, color, mana, convertMana, type, rarity, artist, url;

        /// <summary>
        /// Constructor
        /// </summary>
        public CardModel(string name, string color, string mana, string convertMana, string type, string rarity, string artist, string url)
        {
            this.name = name;
            this.color = color;
            this.mana = mana;
            this.convertMana = convertMana;
            this.type = type;
            this.rarity = rarity;
            this.artist = artist;
            this.url = url;
        }
    }
}
