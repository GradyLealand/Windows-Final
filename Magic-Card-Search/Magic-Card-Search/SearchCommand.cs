using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Magic_Card_Search
{
    public class SearchCommand : ICommand
    {

        /// <summary>
        /// Array of all search terms
        /// {setkey, name, color, type, CMC, rarity}
        /// </summary>
        private string[] _searchCriteria = { "", "", "", "", "", "" };

        public event EventHandler CanExecuteChanged;
        private CardController cardCon;

        /// <summary>
        /// command constructor
        /// </summary>
        /// <param name="cardCon">Current card controller</param>
        public SearchCommand(CardController cardCon)
        {
            this.cardCon = cardCon;
        }

        /// <summary>
        /// Can Execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object parameter)
        {
            _searchCriteria[0] = cardCon.SearchSet;
            _searchCriteria[1] = cardCon.SearchName;
            _searchCriteria[2] = cardCon.SearchColor;
            _searchCriteria[3] = cardCon.SearchType;
            _searchCriteria[4] = cardCon.SearchConvertedManaCost;
            _searchCriteria[5] = cardCon.SearchRarity;
            List<CardModel> cards = new List<CardModel>();
            cards = await CardUtil.GetCards(_searchCriteria);
            this.cardCon.AllCards = cards;
        }
    }
}
