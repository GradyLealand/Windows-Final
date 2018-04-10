using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtgApiManager;
using MtgApiManager.Lib.Service;

namespace Magic_Card_Search
{
    public class CardUtil
    {
        // a list of all ccard models recived from the search
        private static List<CardModel> _allCards = new List<CardModel>();

        
        public static async void GetSet(string setCode)
        {
            SetService service = new SetService();
            var result = service.Find("ktk");
            var asyncResult = await service.FindAsync("ktk");
        }
        
        public static async Task<List<CardModel>> GetCardsByName()
        {
            GetSet("ktk");
            return _allCards;
        }

        //get cards form a selected set based on advanced search properties
    }
}
