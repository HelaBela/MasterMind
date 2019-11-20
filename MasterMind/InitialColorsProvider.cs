using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class InitialColorsProvider
    {
        private INumberGenerator _numberGenerator;

        public InitialColorsProvider(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public string[] PickRandomColors()
        {
            var initialColors = new List<string>();

            var values = Enum.GetValues(typeof(Colors));

            for (int i = 0; i < 4; i++)
            {
                var randomColor = (Colors) values.GetValue(_numberGenerator.RandomNumber(0, values.Length));

                initialColors.Add(randomColor.ToString());
            }

            return initialColors.ToArray();
        }
    }
}