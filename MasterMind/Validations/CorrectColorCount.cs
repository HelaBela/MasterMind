using System.Collections.Generic;

namespace MasterMind
{
    public class CorrectColorCount : IValidation
    {
        public bool IsValid(List<string> userInput)
        {
            var colorValidator = new CorrectColorValidator();

            if (colorValidator.IsValid(userInput))
            {
                if (userInput.Count != 4)
                {
                    return false;
                }
            }

            return true;
        }

        public string DisplayErrorMessage()
        {
            return "Error: you must pass 4 colours!";
        }
    }
}