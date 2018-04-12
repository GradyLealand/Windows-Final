using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Card_Search
{
    public class CardModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Mana { get; set; }
        public string ConvertMana { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public string Artist { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CardModel(string name, string color, string mana, string convertMana, string type, string rarity, string artist, string url)
        {
            this.Name = name;
            this.Color = color;
            this.Mana = mana;
            this.ConvertMana = convertMana;
            this.Type = type;
            this.Rarity = rarity;
            this.Artist = artist;
            this.Url = url;
        }
    }
}
