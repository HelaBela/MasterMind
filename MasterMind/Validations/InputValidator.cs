using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind
{
    public class InputValidator
    {
        private readonly List<IValidation> _validations;
        private readonly ICommunicationOperations _communicationOperations;

        public InputValidator(List<IValidation> validations, ICommunicationOperations communicationOperations)
        {
            _validations = validations;
            _communicationOperations = communicationOperations;
        }

        public string[] GetValidUserInput()
        {
            var hasAllValidationsPassed = false;
            var input = string.Empty;
            var splitInputLowerCase = new List<string>();

            while (!hasAllValidationsPassed)
            {
                Console.WriteLine(
                    "Type 4 colors from this range: Red, Blue, Green, Orange, Purple, Yellow, separated with a coma: ','");
                input = _communicationOperations.Read();

                splitInputLowerCase = UserInputToLowerCase(input);
                foreach (var validation in _validations)
                {
                    hasAllValidationsPassed = validation.IsValid(splitInputLowerCase);

                    if (!validation.IsValid(splitInputLowerCase))
                    {
                        Console.WriteLine(validation.DisplayErrorMessage());
                    }
                }
            }
            return splitInputLowerCase.ToArray();
        }
        
        private List<string> UserInputToLowerCase(string userInput)
        {
            var splitInput = userInput.Split(",");
            var splitInputList = new List<string>();

            foreach (var word in splitInput)
            {
                var lowerCaseWord = word.ToLower();
                splitInputList.Add(lowerCaseWord);
            }

            return splitInputList;
        }

//        private string CapitalizeFirstLetter(string word)
//        {
//            return word.First().ToString().ToUpper() + word.Substring(1);
//        }
    }
}