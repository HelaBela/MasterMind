using System.Collections.Generic;
using MasterMind.ColorProviders;
using MasterMind.Communication;
using MasterMind.Validations;
using Moq;
using NUnit.Framework;

namespace MasterMind.Tests.EndToEndTests
{
    public class GameTests
    {
        [Test]
        public void When_User_Guesses_All_Colors_Game_Stops_And_Win_Message_Is_Displayed()
        {
            //arrange
            var consoleOperations = new Mock<ICommunicationOperations>();
            var initialColors = new[] {"Green", "Red", "Blue", "Orange"};
            var validations = new List<IValidation>
            {
                new IsNotNullValidator(),
                new CorrectColorValidator(),
                new CorrectColorCountValidator()
            };

            var userColorsProvider = new UserColorsProvider(validations, consoleOperations.Object);
            var game = new Game(consoleOperations.Object, userColorsProvider);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green, Red, Blue, Orange");


            //act
            game.Play(initialColors);


            //assert

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "You won! Congratulations :)"))));
        }

        [Test]
        public void When_User_Guesses_3_Colors_In_The_Same_Position_3_Hints_Saying_Black_Are_Displayed()
        {
            //arrange
            var consoleOperations = new Mock<ICommunicationOperations>();
            var initialColors = new[] {"Green", "Red", "Blue", "Orange"};
            var validations = new List<IValidation>
            {
                new IsNotNullValidator(),
                new CorrectColorValidator(),
                new CorrectColorCountValidator()
            };

            var userColorsProvider = new UserColorsProvider(validations, consoleOperations.Object);
            var game = new Game(consoleOperations.Object, userColorsProvider);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green, Blue, Blue, Orange")
                .Returns("Green, Red, Blue, Orange");


            //act
            game.Play(initialColors);

            //assert

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Black"))));
            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Black"))));
            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Black"))));
        }

        [Test]
        public void
            When_User_Guesses_3_Colors_In_Different_Position_And_1_In_Correct_Position_3_Hints_Saying_White__And_One_Black_Is_Displayed()
        {
            //arrange
            var consoleOperations = new Mock<ICommunicationOperations>();
            var initialColors = new[] {"Green", "Red", "Blue", "Orange"};
            var validations = new List<IValidation>
            {
                new IsNotNullValidator(),
                new CorrectColorValidator(),
                new CorrectColorCountValidator()
            };

            var userColorsProvider = new UserColorsProvider(validations, consoleOperations.Object);
            var game = new Game(consoleOperations.Object, userColorsProvider);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Blue, Red, Orange, Green")
                .Returns("Green, Red, Blue, Orange");


            //act
            game.Play(initialColors);


            //assert

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Black"))));
            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Black"))));
            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Black"))));
            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "White"))));
        }
    }
}