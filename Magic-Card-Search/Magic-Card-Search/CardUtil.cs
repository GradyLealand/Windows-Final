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

            //for each card in the set look to see if they contain the search string
            for (int i = 0; i < size; i++)
            {
                if (search[2] != "")
                {
                    if (unfiltered.Value[i].Colors.Contains(search[2]))
                    {
                        //create a custom card model of that card
                        CardModel card = BuildCardModel(unfiltered.Value[i]);
                        //add it to the list to be returned
                        _allCards.Add(card);
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

        public static CardModel BuildCardModel(Card apiCard)
        {
            CardModel card;

            string name = apiCard.Name;
            string color = "";
            string mana = apiCard.ManaCost;
            string convert = apiCard.Cmc.ToString(); //this will change
            string type = apiCard.Type;
            string rarity = apiCard.Rarity;
            string artist = apiCard.Artist;
            string url = apiCard.ImageUrl.ToString();
            if (apiCard.Colors == null)
            {
                color = "";
            }
            else
            {
                for (int i = 0; i < apiCard.Colors.Length; i++)
                {
                    color += apiCard.Colors[i];
                }
            }


            card = new CardModel(name, color, mana, convert, type, rarity, artist, url);


            return card;
        }

        //get cards form a selected set based on advanced search properties
    }
}
