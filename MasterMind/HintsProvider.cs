using System.Collections.Generic;
using MasterMind.Communication;
using MasterMind.Enum;

namespace MasterMind
{
    public class HintsProvider
    {
       // private readonly ColorChecker _colorChecker;
      
        private readonly List<Hint> _hints;

        public HintsProvider()
        {
            _hints = new List<Hint>();
        }

        public List<string> GiveHints(string[] userColours, string[] initialColours)
        {
            UpdateHintsList(userColours, initialColours);
            
            var hints = new List<string>();

            if (_hints.Count > 0)
            {
                foreach (var hint in _hints)
                {
                   hints.Add(hint.ToString());
                }
            }

            return hints;
        }

        private void UpdateHintsList(string[] userColours, string[] initialColours)
        {
            var colorChecker = new ColorChecker();
            var whiteHints = colorChecker.DifferentPositionMatchesCount(userColours, initialColours);
            var blackHints = colorChecker.ExactMatchesCount(userColours, initialColours);

            for (int i = 1; i <= whiteHints; i++)
            {
                _hints.Add(Hint.White);
            }

            for (int i = 1; i <= blackHints; i++)
            {
                _hints.Add(Hint.Black);
            }
        }
    }
}