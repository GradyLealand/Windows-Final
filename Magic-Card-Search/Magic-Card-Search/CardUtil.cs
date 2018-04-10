using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtgApiManager;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;

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
        public static async Task<Exceptional<List<Card>>> GetCardBySet(string setCode)
        {
            //initialise the cardservice
            CardService service = new CardService();
            //do call
            var result = service.Where(x => x.Set, "ktk")
                              .All();
            var asyncResult = await service.Where(x => x.Set, "ktk")
                                        .AllAsync();
            //return API Card lsit
            return asyncResult;
        }
        
        /// <summary>
        /// Filter cards by name only
        /// </summary>
        /// <param name="name">contained in cards name</param>
        /// <returns>List of custom card models</returns>
        public static async Task<List<CardModel>> GetCardsByName(string name)
        {
            Exceptional<List<Card>> unfiltered = await GetCardBySet("ktk");

            //get the size of all cards in the set
            int size = unfiltered.Value.Count;

            //for each card in the set look to see if they contain the search string
            for(int i = 0; i < size; i++)
            {
                //if the search string is in the cards name
                if(unfiltered.Value[i].Name.ToString().Contains(name))
                {
                    //create a custom card model of that card
                    CardModel card = new CardModel(unfiltered.Value[i].Name.ToString());
                    //add it to the list to be returned
                    _allCards.Add(card);
                }              
            }
            return _allCards;
        }

        //get cards form a selected set based on advanced search properties
    }
}
