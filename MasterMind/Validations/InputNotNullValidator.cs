using System;
using System.Collections.Generic;

namespace MasterMind
{
    public class InputIsNotNullValidator:IValidation
    {
        public bool IsValid(List<string> userInput)
        {
            if (userInput.Count == 1 && userInput.Contains(String.Empty) )
            {
                return false;
            }

            return true;
        }

        public string DisplayErrorMessage()
        {
            return
                "Error: You need to type something!";
        }
    }
}