using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Magic_Card_Search.Commands;

namespace Magic_Card_Search
{
    public class CardController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<CardModel> _allCards = new List<CardModel>();
        public ObservableCollection<CardModel> Cards { get; set; }
        private CardModel _selectedCard;
        private string _search;

        public SearchCommand SearchCommand { get; }

        /// <summary>
        /// Array of all search terms
        /// {setkey, name, color, type, CMC, rarity}
        /// </summary>
        private string[] _searchCriteria = { "ktk", "", "", "", "", "" };

        /// <summary>
        /// CardControler constructor
        /// </summary>
        public CardController()
        {

            Cards = new ObservableCollection<CardModel>();
            //testing api return
            LoadCards();
        }

        public string SearchName
        {
            get
            {
                return _search;

            }
            set
            {
                _search = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Search"));
            }
        }

        //public SearchCommand SaveCommand { get; }

        /// <summary>
        /// Load cards
        /// This method is for testing and not perminant
        /// </summary>
        public async void LoadCards()
        {
            AllCards = await CardUtil.GetCards(_searchCriteria);
        }


        public CardModel SelectedCard
        {
            get
            {
                return _selectedCard;
            }
            set
            {
                _selectedCard = value;
                if (value == null)
                {
                    return;
                }
                else
                {
                    //goto detail page function
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCard"));
            }


        }

        public List<CardModel> AllCards
        {
            get
            {
                return _allCards;
            }
            set
            {
                _allCards = value;
                foreach(CardModel card in _allCards )
                {
                    Cards.Add(card);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllCards"));
            }
        }

    }

}



