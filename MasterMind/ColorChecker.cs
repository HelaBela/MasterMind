using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
    public class ColorChecker
    {
        private readonly string[] _userColors;
        private readonly string[] _initialColors;

        public ColorChecker(string[] userColors, string[] initialColors)
        {
            _userColors = userColors;
            _initialColors = initialColors;
        }

        public int SameColorsSamePosition()
        {
            var sameColorsSamePosition = 0;

            for (int i = 0; i < _initialColors.Length; i++)
            {
                if (_initialColors[i] == _userColors[i])
                {
                    sameColorsSamePosition++;
                }
            }

            return sameColorsSamePosition;
        }

        public int SameColorsDifferentPosition()
        {
            var sameColorsDifferentPosition = 0;
            

            foreach (var color in _initialColors)
            {
                if (_userColors.Contains(color))
                {
                    sameColorsDifferentPosition++;
                }
            }
            
            for (int i = 0; i < _initialColors.Length; i++)
            {
                if (_initialColors[i] == _userColors[i])
                {
                    sameColorsDifferentPosition--;
                }
            }
            
            return sameColorsDifferentPosition;
        }
    }
}