using System.Collections.Generic;
using BlackJackBot.Tools;

namespace BlackJackBot.Strategies
{
    interface IStrategy
    {
        IEnumerable<string> Model { get; set; }
        Components.Move GetBestMove(int[] playerCards, int dealerCard);
        void OpenModel(string modelName);

        Components.Move BrowseModelForAction(int[] playerCards, int dealerCard);

        Components.Move HandleMoveNotFoundInModel();


    }
}
