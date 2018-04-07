using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtgApiManager;
using MtgApiManager.Lib.Service;

namespace Magic_Card_Search
{
    class ApiUtil
    {
        // a list of all ccard models recived from the search
        List<CardModel> _allCards;

        //get cards based from selected set where there names contain
        public async void GetByName(string name, string series)
        {
            //create card service
            CardService service = new CardService();
        }

        //get cards form a selected set based on advanced search properties
    }
}
