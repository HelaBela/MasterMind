using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Validations
{
    public class IsNotNullValidator : IValidation
    {
        public bool IsValid(List<string> userInput)
        {
            return userInput.All(color => !color.All(char.IsWhiteSpace));
        }

        public string DisplayErrorMessage()
        {
            return "Error: You need to write something!";
        }
    }
}