using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace MasterMind
{
    public class PlayerInput
    {
        private readonly ICommunicationOperations _communicationOperations;

        public PlayerInput(ICommunicationOperations communicationOperations)
        {
            _communicationOperations = communicationOperations;
        }


        public string[] GetColors()
        {
            _communicationOperations.WriteLine(
                "Type 4 colors from this range: Red, Blue, Green, Orange, Purple, Yellow, separated with a coma: ',' ");
            var userInput = _communicationOperations.Read();
            while (!IsInputValid(userInput))
            {
                userInput = _communicationOperations.Read();
            }

            var userColorsArray = ProcessUserInput(userInput);


            return userColorsArray;
        }

        private bool IsInputValid(string input)
        {
            if (input == string.Empty) return false;
            
            var chosenColors = ProcessUserInput(input);
            var correctColors = new List<Colors>();
//            var commaCounter = input.Split(',').Length;
            var comaCounter = input.Count(s => s == ',');

            if (comaCounter == 3)
            {
                foreach (var choice in chosenColors)
                {
                    if (!Enum.TryParse(choice, out Colors color))
                    {
                        if (choice == string.Empty)
                        {
                            _communicationOperations.WriteLine("Error: you must pass 4 colours!");
                            return false;
                        }

                        _communicationOperations.WriteLine("Error: you have given an invalid colour!");
                        return false;
                    }

                    correctColors.Add(color);
                }
            }
            else if (comaCounter < 4 && correctColors.Count < 2)
            {
                _communicationOperations.WriteLine(
                    "Please separate your colors with a coma.");
                return false;
            }

            //|| chosenColors.Any(s=>s==string.Empty ->for no code rep

            if (correctColors.Count != 4)
            {
                _communicationOperations.WriteLine("Error: you must pass 4 colours!");
                return false;
            }

            return true;
        }

        private string[] ProcessUserInput(string input)
        {
            if (input != null)
            {
                var returnedArray = input.Split(",").Select(s => s.Trim()).ToArray();
                var capitalizedWordsArray = new List<string>();

                foreach (var word in returnedArray)
                {
                    var capitalizedWord = CapitalizeFirstLetter(word);
                    capitalizedWordsArray.Add(capitalizedWord);
                }

                return capitalizedWordsArray.ToArray();
            }
            
            return new string[1];
            
        }

        private string CapitalizeFirstLetter(string word)
        {
            var wordInLowerCase = word.ToLower();

            return wordInLowerCase.First().ToString().ToUpper() + wordInLowerCase.Substring(1);
        }
    }
}