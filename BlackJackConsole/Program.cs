using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new BlackJackBot.Strategies.BasicStrategy();
            b.OpenModel(BlackJackBot.Resources.Models.BasicStrategy);
            var move = b.GetBestMove(new []{1,1}, 10);
            move = b.GetBestMove(new[] { 5, 4 },  6);
            move = b.GetBestMove(new[] { 3, 2 }, 6);
            move = b.GetBestMove(new[] { 4, 10 }, 10);
            move = b.GetBestMove(new[] { 1, 7 }, 10);
            move = b.GetBestMove(new[] { 1,4,3 }, 10);
        }
    }
}
