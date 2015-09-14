using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlackJackBot.Tools;

namespace BlackJackBot.Strategies
{
    public class BasicStrategy : IStrategy
    {
        public IEnumerable<string> Model { get; set; }

        public Components.Move GetBestMove(int[] playerCards, int dealerCard)
        {
            if(playerCards.Length >= 2)
            { 
                if (playerCards.Length > 2) //Cases when more than two cards
                {
                    //Sum every card except for Aces
                    //Then add aces as 11, if it blows or stand between 17 and 21, choose 1
                    int numberOfAces = playerCards.Count(a => a == 1);
                    if(numberOfAces > 0)
                    {
                        int sumWhithoutAces = playerCards.Where(c => c != 1).Sum();
                        if (sumWhithoutAces + 11 >= 17 && sumWhithoutAces + 11 <= 21)
                            return Components.Move.Stand;
                        else if (sumWhithoutAces + 11 > 21)
                        {
                            return BrowseModelForAction(playerCards, dealerCard);
                        }
                    }
                    else
                    {
                        //Aggregate all card values
                        playerCards = new[] {playerCards.Sum()};
                    }
                }
                if (Evaluator.IsBlackJack(playerCards)) //Stand if blackjack you moron
                    return Components.Move.Stand;
                else if (Evaluator.IsHard(playerCards) && (playerCards[0] + playerCards[1] <= 7))
                    //Hit if hard and card <= 7
                    return Components.Move.Hit;
                else if (Evaluator.IsHard(playerCards) && (playerCards[0] + playerCards[1] >= 17))
                    //Stand if hard and card >= 17
                    return Components.Move.Stand;
                else
                    return BrowseModelForAction(playerCards, dealerCard);
            }
            else
                throw new ArgumentException("More than one cards are needed to compute a play", "playerCards");
        }

        public void OpenModel(string modelName)
        {

            Model = File.ReadAllLines(modelName);
            //open CSV file
            //Dump that into hashtable ordered
        }


        public Components.Move BrowseModelForAction(int[] playerCards, int dealerCard)
        {
            var handCategory = Evaluator.GetHandCategory(playerCards);
            string line = null;
            switch (handCategory)
            {
                case "H":
                    line =
                        Model.FirstOrDefault(
                            l => l.StartsWith("H;" + (playerCards.Sum()) + ";" + dealerCard));
                    break;
                case "P":
                    line =
                        Model.FirstOrDefault(
                            l => l.StartsWith("P;" + playerCards[0] + "," + playerCards[1] + ";" + dealerCard));
                    break;
                case "S":
                    line =
                        Model.FirstOrDefault(
                            l =>
                                l.StartsWith("S;1," +
                                                (playerCards[0] > playerCards[1] ? playerCards[0] : playerCards[1]) +
                                                ";" + dealerCard));
                    break;
            }
            if (!string.IsNullOrWhiteSpace(line))
            {
                Components.Move move;
                Enum.TryParse(line.Split(';')[3], out move);
                return move;
            }

            return HandleMoveNotFoundInModel();
        }




        public Components.Move HandleMoveNotFoundInModel()
        {
            throw new Exception("Move not found in model");
        }
    }
}
