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
        private string _searchName;

        public SearchCommand SearchCommand { get; }

        

        /// <summary>
        /// CardControler constructor
        /// </summary>
        public CardController()
        {
            //initialise commands
            SearchCommand = new SearchCommand(this);

            //initialise displayable cards list
            Cards = new ObservableCollection<CardModel>();
        }


        //public SearchCommand SaveCommand { get; }

        /// <summary>
        /// Load cards
        /// This method is for testing and not perminant
        /// </summary>
        public async void LoadCards(String[] sArry)
        {
            AllCards = await CardUtil.GetCards(sArry);
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
                //clear cards list
                _allCards.Clear();
                _allCards = value;

                //clear display list
                Cards.Clear();
                foreach (CardModel card in _allCards )
                {
                    //copy list into display list
                    Cards.Add(card);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllCards"));
            }
        }


        public string SearchName
        {
            get
            {
                return _searchName;

            }
            set
            {
                _searchName = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Search"));
            }
        }

    }

}



