using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
    public class IsNotNullValidator:IValidation
    {
        public bool IsValid(List<string> userInput)
        {
            foreach (var color in userInput)
            {
                if (color.All(char.IsWhiteSpace)) return false;
            }

            return true;
        }

        public string DisplayErrorMessage()
        {
            return "Error: You need to write something!";
        }
    }
}