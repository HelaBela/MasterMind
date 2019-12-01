using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
    public class ColorChecker
    {
        private List<string> ExactMatchesList(string[] userColours, string[] initialColours)
        {
            return initialColours.Where((t, i) => t == userColours[i]).ToList();
        }

        public int ExactMatchesCount(string[] userColours, string[] initialColours)
        {
            var sameColorSamePosition = ExactMatchesList(userColours, initialColours);
            return sameColorSamePosition.Count;
        }

        public int DifferentPositionMatchesCount(string[] userColours, string[] initialColours)
        {
            var exactMatches = ExactMatchesList(userColours, initialColours);

            var computerColorsWithoutExactMatches = new List<string>();
            foreach (var color in initialColours)
            {
                computerColorsWithoutExactMatches.Add(color);

                if (exactMatches.Contains(color))
                {
                    computerColorsWithoutExactMatches.Remove(color);
                }
            }

            var differentPositionMatchesCount = 0;

            foreach (var color in userColours)
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