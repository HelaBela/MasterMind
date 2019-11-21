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
            var splitInputLowerCase = new List<string>();
            var listOfPassedValidations = new List<IValidation>();

            while (listOfPassedValidations.Count != _validations.Count)
            {
                var input = GetUserInput();
                listOfPassedValidations = new List<IValidation>();
                splitInputLowerCase = UserInputToLowerCase(input);
                foreach (var validation in _validations)
                {
                    if (!validation.IsValid(splitInputLowerCase))
                    {
                        Console.WriteLine(validation.DisplayErrorMessage());
                        break;
                    }
                    else listOfPassedValidations.Add(validation);
                }
            }

            return splitInputLowerCase.ToArray();
        }

        private string GetUserInput()
        {
            _communicationOperations.WriteLine(
                "Type 4 colors from this range: Red, Blue, Green, Orange, Purple, Yellow, separated with a coma: ','");
            var input = _communicationOperations.Read();
            return input;
        }

        private List<string> UserInputToLowerCase(string userInput)
        {
            var splitInput = userInput.Split(",").Select(s => s.Trim());
            var splitInputList = new List<string>();

            foreach (var word in splitInput)
            {
                var lowerCaseWord = word.ToLower();
                splitInputList.Add(lowerCaseWord);
            }

            return splitInputList;
        }

       
    }
}