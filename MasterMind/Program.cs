using System;
using System.Collections.Generic;
using MasterMind.ColorProviders;
using MasterMind.Communication;
using MasterMind.NumberGenerator;
using MasterMind.Validations;

namespace MasterMind
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var communication = new ConsoleOperations();

            var validations = new List<IValidation> {new IsNotNullValidator(), new CorrectColorValidator(), new CorrectColorCountValidator()};
            var userColorProvider = new UserColorsProvider(validations,communication);

            var userColors = userColorProvider.ProvideColors();
            var initialColorsProvider = new InitialColorsProvider(new RandomNumberGenerator());
            var initialColors = initialColorsProvider.ProvideColors();
            
            var colorChecker = new ColorChecker(userColors, initialColors);

            var game = new Game(colorChecker, communication);
            
            game.Play();

        }
    }
}