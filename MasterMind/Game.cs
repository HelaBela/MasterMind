using System.Collections.Generic;
using MasterMind.Communication;
using MasterMind.Enum;

namespace MasterMind
{
    public class Game
    {
        private readonly ColorChecker _colorChecker;
        private readonly ICommunicationOperations _communicationOperations;
        private readonly List<Hint> _hints;

        public Game(ColorChecker colorChecker, ICommunicationOperations communicationOperations)
        {
            _colorChecker = colorChecker;
            _communicationOperations = communicationOperations;
            _hints = new List<Hint>();
        }

        private void UpdateHintsList()
        {
            var whiteHints = _colorChecker.SameColorsDifferentPosition();
            var blackHints = _colorChecker.SameColorsSamePosition();

            for (int i = 1; i <= whiteHints; i++)
            {
                _hints.Add(Hint.White);
            }

            for (int i = 1; i <= blackHints; i++)
            {
                _hints.Add(Hint.Black);
            }
        }

        public void Play()
        {
            
            // make a while loop and end to end tests. check the design again
            UpdateHintsList();
            if (_hints.Count > 0)
            {
                foreach (var hint in _hints)
                {
                    _communicationOperations.WriteLine(hint.ToString());
                }
            }
        }
    }
}