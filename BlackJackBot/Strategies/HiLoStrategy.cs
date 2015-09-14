using System;
using System.Collections.Generic;
using BlackJackBot.Tools;

namespace BlackJackBot.Strategies
{
    class HiLoStrategy : IStrategy
    {

        public Tools.Components.Move GetBestMove(int[] playerCards, int dealerCard)
        {
            throw new NotImplementedException();
        }

        public void OpenModel(string modelName)
        {
            throw new NotImplementedException();
        }


        public Components.Move BrowseModelForAction(int[] playerCards, int dealerCard)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Model
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public Components.Move HandleMoveNotFoundInModel()
        {
            throw new NotImplementedException();
        }
    }
}
