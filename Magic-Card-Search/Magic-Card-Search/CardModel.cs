namespace Magic_Card_Search
{
    public class CardModel
    {
        /// <summary>
        /// card name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Card collor(s)
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Card Mana cost
        /// </summary>
        public string Mana { get; set; }
        /// <summary>
        /// Card total mana cost
        /// </summary>
        public string ConvertMana { get; set; }
        /// <summary>
        /// Card trype
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Card rarity
        /// </summary>
        public string Rarity { get; set; }
        /// <summary>
        /// Card image artist
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// Card image URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Card Flavour text
        /// </summary>
        public string Flavor { get; set; }
        /// <summary>
        /// card rull text
        /// </summary>
        public string Text { get; set; }



        /// <summary>
        /// Constructor
        /// </summary>
        public CardModel(string name, string color, string mana, string convertMana, string type, string rarity, string artist, string url, string flavor, string text)
        {
            this.Name = name;
            this.Color = color;
            this.Mana = mana;
            this.ConvertMana = convertMana;
            this.Type = type;
            this.Rarity = rarity;
            this.Artist = artist;
            this.Url = url;
            this.Flavor = flavor;
            this.Text = text;
        }
    }
}
