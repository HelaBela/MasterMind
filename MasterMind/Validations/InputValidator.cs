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

            while (!hasAllValidationsPassed)
            {
                Console.WriteLine("enter 4 colors");
                input = _communicationOperations.Read();
                var splitInput = input.Split(",");
                var lowerCaseWord = string.Empty;
                var splitInputList = new List<string>();

                foreach (var word in splitInput)
                {
                    lowerCaseWord = word.ToLower();
                }

                splitInputList.Add(lowerCaseWord);


                foreach (var validation in _validations)
                {
                    hasAllValidationsPassed = validation.IsValid(splitInputList);

                    if (!validation.IsValid(splitInputList))
                    {
                        Console.WriteLine(validation.DisplayErrorMessage());
                    }
                }
            }

            var inputStringArray = input.Split(",");
            var capitalizedInput = new List<string>();
            foreach (var word in inputStringArray)
            {
                capitalizedInput.Add(CapitalizeFirstLetter(word));
            }

            return capitalizedInput.ToArray();
        }

        private string CapitalizeFirstLetter(string word)
        {

            return word.First().ToString().ToUpper() + word.Substring(1);
        }
    }
}