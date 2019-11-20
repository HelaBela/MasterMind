using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
    public class CorrectColorValidator : IValidation
    {
        public bool IsValid(List<string> userInput)
        {
            foreach (var color in userInput)
            {
                var isAColor = Enum.TryParse(color, out Colors validColour);

                if (!isAColor && !color.All(char.IsWhiteSpace)) return false;
            }

            return true;
        }

        public string DisplayErrorMessage()
        {
            return "Error: you have given an invalid colour!";
        }
    }
}