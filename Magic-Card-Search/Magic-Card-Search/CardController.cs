using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic_Card_Search.Commands;

namespace Magic_Card_Search
{
    public class CardController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<CardModel> _allCards = new List<CardModel>();

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

            Cards = new ObservableCollection<CardModel>();
            //testing api return
            LoadCards();
        }

        public string Search
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

        public SearchCommand SaveCommand { get; }

        /// <summary>
        /// Load cards
        /// This method is for testing and not perminant
        /// </summary>
        public async void LoadCards()
        {
            _allCards = await CardUtil.GetCards(_serchCriteria);
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
    
    }

}

