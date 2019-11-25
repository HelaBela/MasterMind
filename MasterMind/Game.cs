using MasterMind.ColorProviders;
using MasterMind.Communication;

namespace MasterMind
{
    public class Game
    {
        private readonly ICommunicationOperations _communicationOperations;
        private UserColorsProvider _userColorsProvider;
        private int _counter;

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
                var colorChecker = new ColorChecker(userColors, initialColors);
                var hints = new HintsProvider(colorChecker, _communicationOperations);
                hints.GiveHints();
                _counter++;

                if (_counter == 60)
                {
                    _communicationOperations.WriteLine("You lost. Only 60 attempts allowed.");
                } 

                if (colorChecker.SameColorsSamePosition() == 4)
                {
                    _communicationOperations.WriteLine("You won! Congratulations :)");
                    thereIsNoWinner = false;
                }
            }
            
        }
    }
}