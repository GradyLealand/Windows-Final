﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Magic_Card_Search
{
    public class CardController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<CardModel> _allCards;
        public ObservableCollection<CardModel> Cards { get; set; }
        private CardModel _selectedCard;
        private string _searchName = "";
        private string _searchSet = "";
        private string _searchConvertedManaCost = "";
        private string _searchType = "";
        private string _searchColor = "";
        private string _searchRarity = "";

        /// <summary>
        /// Color combo box setters
        /// </summary>
        public ComboBoxItem SelectedColor_ComboBoxItem
        {
            get
            {
                ComboBoxItem cmbi = new ComboBoxItem();
                cmbi.Content = _searchColor;
                return cmbi;
            }
            set
            {
                string val = (string)value.Content;
                if (val == "Any")
                    val = "";

                this._searchColor = val;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedColor_ComboBoxItem"));

            }
        }

        /// <summary>
        /// rarity combo box setters
        /// </summary>
        public ComboBoxItem SelectedRarity_ComboBoxItem
        {
            get
            {
                ComboBoxItem cmbi = new ComboBoxItem();
                cmbi.Content = _searchRarity;
                return cmbi;
            }
            set
            {
                string val = (string)value.Content;
                if (val == "Any")
                    val = "";

                this._searchRarity = val;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedRarity_ComboBoxItem"));
            }
        }
        
        public SearchCommand SearchCommand { get; }

        /// <summary>
        /// CardControler constructor
        /// </summary>
        public CardController()
        {
            _allCards = new List<CardModel>();
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
                    CardModel card = _selectedCard;
                    var frame = (Frame)Window.Current.Content;
                    
                    //The go to details page may come from main page or advanced search, so it needs to check the current page's name.
                    if (frame.CurrentSourcePageType == typeof(MainPage))
                    {
                        var page = (MainPage)frame.Content;
                        page.Frame.Navigate(typeof(DetailsPage), card);
                    }
                    else
                    {
                        var page = (AdvancedSearch)frame.Content;
                        page.Frame.Navigate(typeof(DetailsPage), card);
                    }
                   
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
                //clear _allCards();
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

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchName"));
            }
        }
        
        public string SearchSet
        {
            get
            {
                return this._searchSet;
            }
            set
            {
                _searchSet = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchSet"));
            }
        }

        public string SearchConvertedManaCost
        {
            get
            {
                return this._searchConvertedManaCost;
            }
            set
            {
                this._searchConvertedManaCost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchConvertedManaCost"));
            }
        }

        public string SearchType
        {
            get
            {
                return this._searchType;
            }
            set
            {
                this._searchType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchType"));
            }
        }

        public string SearchColor
        {
            get
            {
                return this._searchColor;
            }
            set
            {
                this._searchColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchColor"));
            }
        }

        public string SearchRarity
        {
            get
            {
                return this._searchRarity;
            }
            set
            {
                this._searchRarity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchRarity"));
            }
        }

    }

}





