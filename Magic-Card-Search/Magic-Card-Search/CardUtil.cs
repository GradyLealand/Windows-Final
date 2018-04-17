using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Magic_Card_Search
{
    public class CardUtil
    {
        // a list of all ccard models recived from the search
        private static List<CardModel> _allCards = new List<CardModel>();

        /// <summary>
        /// Make an API call to get all cards from a specific set
        /// </summary>
        /// <param name="setCode">3 digit code for a card set</param>
        /// <returns>List of MTG API cards</returns>
        public static async Task<Exceptional<List<Card>>> GetCardBySet(string[] search)
        {
            //initialise the cardservice
            CardService service = new CardService();
            //do call
            var result = service.Where(x => x.Set, search[0])
                                .Where(x => x.Name, search[1])
                                .Where(x => x.Type, search[3])
                                .Where(x => x.Cmc, search[4])
                                .Where(x => x.Rarity, search[5])
                                .All();
            var asyncResult = await service.Where(x => x.Set, search[0])
                                .Where(x => x.Name, search[1])
                                .Where(x => x.Type, search[3])
                                .Where(x => x.Cmc, search[4])
                                .Where(x => x.Rarity, search[5])
                                .AllAsync();
            //return API Card lsit
            return asyncResult;
        }

        /// <summary>
        /// Filter cards by name only
        /// </summary>
        /// <param name="name">contained in cards name</param>
        /// <returns>List of custom card models</returns>
        public static async Task<List<CardModel>> GetCards(string[] search)
        {
            Exceptional<List<Card>> unfiltered = await GetCardBySet(search);

            //get the size of all cards in the set
            int size = unfiltered.Value.Count;

            //cear _allCards[]
            _allCards.Clear();

            //for each card in the set look to see if they contain the search string
            for (int i = 0; i < size; i++)
            {
                if (search[2] != "")
                {
                    if(unfiltered.Value[i].Colors != null)
                    {
                        if (unfiltered.Value[i].Colors.Contains(search[2]))
                        {
                            //create a custom card model of that card
                            CardModel card = BuildCardModel(unfiltered.Value[i]);
                            //add it to the list to be returned
                            _allCards.Add(card);
                        }
                    }
                    
                }
                else
                {
                    //create a custom card model of that card
                    CardModel card = BuildCardModel(unfiltered.Value[i]);
                    //add it to the list to be returned
                    _allCards.Add(card);
                }
            }
            return _allCards;
        }

        /// <summary>
        /// CardModel constructor
        /// </summary>
        /// <param name="apiCard">Api card model</param>
        /// <returns>custom card model</returns>
        public static CardModel BuildCardModel(Card apiCard)
        {
            CardModel card;

            //set all to N/A to handle nulls
            string name = "N/A";
            string color = "";
            string mana = "N/A";
            string convert = "N/A";
            string type = "N/A";
            string rarity = "N/A";
            string artist = "N/A";
            string url = "";

            //check for nulls
            if (apiCard.Name != null)
            {
                name = apiCard.Name;
            }

            if (apiCard.Colors != null)
            {
                for (int i = 0; i < apiCard.Colors.Length; i++)
                {
                    color += apiCard.Colors[i];
                }
            }

            if (apiCard.ManaCost != null)
            {
                mana = apiCard.ManaCost;
            }

            if(apiCard.Cmc != null)
            {
                convert = apiCard.Cmc.ToString();
            }

            if(apiCard.Type != null)
            {
                type = apiCard.Type;
            }
            if(apiCard.Rarity != null)
            {
                rarity = apiCard.Rarity;
            }
            if(apiCard.Artist != null)
            {
                artist = apiCard.Artist;
            }
            if(apiCard.ImageUrl != null)
            {
                url = apiCard.ImageUrl.ToString();
            }
            
            card = new CardModel(name, color, mana, convert, type, rarity, artist, url);


            return card;
        }

        //get cards form a selected set based on advanced search properties
    }
}
