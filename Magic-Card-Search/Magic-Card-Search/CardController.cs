using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Card_Search
{
    public class CardController
    {

        private List<CardModel> _allCards = new List<CardModel>();

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
            _allCards = await CardUtil.GetCardsByName("a");
        }
    }
}

