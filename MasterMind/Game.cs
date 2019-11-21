using System.Collections.Generic;

namespace MasterMind
{
    public class Game
    {
        private ColorChecker _colorChecker;
        private ICommunicationOperations _communicationOperations;
        private List<Hint> _hints;

        public Game(ColorChecker colorChecker, ICommunicationOperations communicationOperations)
        {
            _colorChecker = colorChecker;
            _communicationOperations = communicationOperations;
            _hints = new List<Hint>();
        }

        private void UpdateHintsList()
        {
           var whiteHints =   _colorChecker.SameColorsDifferentPosition();
           var blackHints = _colorChecker.SameColorsSamePosition();
           
           for (int i = 0; i <= whiteHints; i++)
           {
               _hints.Add(Hint.White);
           }
           
           for (int i = 0; i <= blackHints; i++)
           {
               _hints.Add(Hint.Black);
           }
        }

        public void GiveTheHint()
        {
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