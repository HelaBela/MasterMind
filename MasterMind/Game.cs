using System.Linq;
using MasterMind.ColorProviders;
using MasterMind.Communication;

namespace MasterMind
{
    public class Game
    {
        private readonly ICommunicationOperations _communicationOperations;
        private UserColorsProvider _userColorsProvider;
        private int _counter;

        private const int MaxTries = 60;

        public Game(ICommunicationOperations communicationOperations, UserColorsProvider userColorsProvider)
        {
            _communicationOperations = communicationOperations;
            _userColorsProvider = userColorsProvider;
        }
        
      

        public void Play(string[] initialColors)
        {
            var thereIsNoWinner = true;

         
           
            while (thereIsNoWinner)
            {
                var userColors = _userColorsProvider.ProvideColors();
                var hintsProvider = new HintsProvider();
                var hints = hintsProvider.GiveHints(userColors, initialColors);
                _counter++;

                foreach (var hint in hints)
                {
                    _communicationOperations.WriteLine(hint);
                }

                if (_counter == MaxTries)
                {
                    _communicationOperations.WriteLine("You lost. Only 60 attempts allowed.");
                    break;
                }

                if ( hints.Count == 4)
                {
                    _communicationOperations.WriteLine("You won! Congratulations :)");
                    thereIsNoWinner = false;
                }
            }
        }
    }

//    public static class Constants
//    {
//        public const int MaxRetries = 60;
//        public const int NumberOfColours = 60;
//    }
}