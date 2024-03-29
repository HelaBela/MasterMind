using System.Collections.Generic;

namespace MasterMind.Validations
{
    public class CorrectColorCountValidator : IValidation
    {
        public bool IsValid(List<string> userInput)
        {
            if (userInput.Count != 4)
            {
                return false;
            }

            return true;
        }

        public string DisplayErrorMessage()
        {
            return "Error: you must pass 4 colours!";
        }
    }
}