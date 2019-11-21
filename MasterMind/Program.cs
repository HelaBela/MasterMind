using System;
using System.Collections.Generic;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            var communication = new ConsoleOperations();

            var validations = new List<IValidation> {new IsNotNullValidator(), new CorrectColorValidator(), new CorrectColorCountValidator()};
            var validator = new InputValidator(validations,communication);

            var userColors = validator.GetValidUserInput();
            var initialColorsProvider = new InitialColorsProvider(new RandomNumberGenerator());
            var initialColors = initialColorsProvider.PickRandomColors();
            var colorChecker = new ColorChecker(userColors, initialColors);

            var foo = colorChecker.SameColorsDifferentPosition();
            
            communication.WriteLine($"{foo}");
            
            //var game = new Game(colorChecker, communication);
            
            //game.GiveTheHint();
            
            //var player = new PlayerInput(communication);
//           player.GetColors();
        }
    }
}