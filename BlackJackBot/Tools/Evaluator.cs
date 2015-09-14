using System.Linq;

namespace BlackJackBot.Tools
{
    static class Evaluator
    {
        public static string GetHandCategory(int[] playerCards)
        {
            if (playerCards.Length > 2) //more than two cards hand are hard hands for the model whatever happens
                return "H";
            else if (IsBlackJack(playerCards))
                return "B";
            else if (IsPair(playerCards))
                return "P";
            else if (IsSoft(playerCards))
                return "S";
            else if (IsHard(playerCards))
                return "H";
            else
                return "n/a";
        }

        public static bool IsPair(int[] playerCards)
        {
            return playerCards[0] == playerCards[1];
        }

        public static bool IsSoft(int[] playerCards)
        {
            return (playerCards[0] == 1 || playerCards[1] ==1) && (playerCards[0] != playerCards[1]);
        }

        public static bool IsHard(int[] playerCards)
        {
            return (playerCards[0] != 1 && playerCards[1] != 1) && (playerCards[0] != playerCards[1]);
        }

        public static bool IsBlackJack(int[] playerCards)
        {
            return (playerCards[0] == 1 && playerCards[1] == 10) || (playerCards[0] == 10 && playerCards[1] == 1);
        }
    }
}
