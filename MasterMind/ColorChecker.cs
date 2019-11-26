using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
    public class ColorChecker
    {
        private readonly string[] _userColors;
        private readonly string[] _computerColors;

        public ColorChecker(string[] userColors, string[] computerColors)
        {
            _userColors = userColors;
            _computerColors = computerColors;
        }

        private List<string> ExactMatchesList()
        {
            var sameColorsSamePosition = new List<string>();

            for (int i = 0; i < _computerColors.Length; i++)
            {
                if (_computerColors[i] == _userColors[i])
                {
                    sameColorsSamePosition.Add(_computerColors[i]);
                }
            }

            return sameColorsSamePosition;
        }

        public int ExactMatchesCount()
        {
            var sameColorSamePosition = ExactMatchesList();
            return sameColorSamePosition.Count;
        }

        public int DifferentPositionMatchesCount()
        {
            var exactMatches = ExactMatchesList();

            var computerColorsWithoutExactMatches = new List<string>();

            foreach (var color in _computerColors)
            {
                computerColorsWithoutExactMatches.Add(color);

                if (exactMatches.Contains(color))
                {
                    computerColorsWithoutExactMatches.Remove(color);
                }
            }

            var differentPositionMatchesCount = 0;

            foreach (var color in _userColors)
            {
                if (computerColorsWithoutExactMatches.Contains(color))
                {
                    differentPositionMatchesCount++;
                    computerColorsWithoutExactMatches.Remove(color);
                }
            }

            return differentPositionMatchesCount;
        }
    }
}