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
        public event EventHandler CanExecuteChanged;
        private CardController cardCon;

        public SearchCommand(CardController cardCon)
        {
            this.cardCon = cardCon;
        }


        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
