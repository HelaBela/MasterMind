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

            var validations = new List<IValidation>
            {
                new IsNotNullValidator(), 
                new CorrectColorValidator(), 
                new CorrectColorCountValidator()
            };
            
            var userColorProvider = new UserColorsProvider(validations, communication);
            var initialColorsProvider = new InitialColorsProvider(new RandomNumberGenerator());
            var initialColors = initialColorsProvider.ProvideColors();
           
            
            var game = new Game(communication, userColorProvider);
            game.Play(initialColors);

            
        }
    }
}