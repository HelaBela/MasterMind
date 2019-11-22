using System.Collections.Generic;
using MasterMind.Enum;
using MasterMind.NumberGenerator;

namespace MasterMind.ColorProviders
{
    public class InitialColorsProvider:IColorProvider
    {
        private readonly INumberGenerator _numberGenerator;

        public InitialColorsProvider(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public string[] ProvideColors()
        {
            var initialColors = new List<string>();

            var values = System.Enum.GetValues(typeof(Colors));

            for (int i = 0; i < 4; i++)
            {
                var randomColor = (Colors) values.GetValue(_numberGenerator.RandomNumber(0, values.Length));

                initialColors.Add(randomColor.ToString());
            }

            return initialColors.ToArray();
        }
    }
}