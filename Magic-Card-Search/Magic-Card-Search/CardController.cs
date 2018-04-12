using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Card_Search
{
    public class CardController
    {

        public List<CardModel> _allCards = new List<CardModel>();

        /// <summary>
        /// Array of all search terms
        /// {setkey, name, color, type, CMC, rarity}
        /// </summary>
        private string[] _serchCriteria = {"ktk", "", "", "", "", ""}; 

        /// <summary>
        /// CardControler constructor
        /// </summary>
        public CardController()
        {
            //testing api return
            LoadCards();
        }

        /// <summary>
        /// Load cards
        /// This method is for testing and not perminant
        /// </summary>
        public async void LoadCards()
        {
            _allCards = await CardUtil.GetCards(_serchCriteria);
        }
    }
}

