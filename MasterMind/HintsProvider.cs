using System.Collections.Generic;
using System.Linq;
using MasterMind.ColorProviders;
using MasterMind.Communication;
using MasterMind.Enum;

namespace MasterMind
{
    public class HintsProvider
    {
        private readonly ColorChecker _colorChecker;
        private readonly ICommunicationOperations _communicationOperations;
        private readonly List<Hint> _hints;

        public HintsProvider(ColorChecker colorChecker, ICommunicationOperations communicationOperations)
        {
            _colorChecker = colorChecker;
            _communicationOperations = communicationOperations;
            _hints = new List<Hint>();
        }

        public void GiveHints()
        {
            UpdateHintsList();

            if (_hints.Count > 0)
            {
                foreach (var hint in _hints)
                {
                    _communicationOperations.WriteLine(hint.ToString());
                }
            }
        }

        private void UpdateHintsList()
        {
            var whiteHints = _colorChecker.DifferentPositionMatchesCount();
            var blackHints = _colorChecker.ExactMatchesCount();

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