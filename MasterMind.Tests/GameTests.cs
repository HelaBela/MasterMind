using System;
using MasterMind;
using MasterMind.ColorProviders;
using MasterMind.Communication;
using MasterMind.Enum;
using MasterMind.NumberGenerator;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void When_2_Colors_Match_Position_SameColorsSamePosition_Returns_2()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();

            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            var _colors = Enum.GetValues(typeof(Colors));

            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(1).Returns(2).Returns(3)
                .Returns(4);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new string[] {"Red", "Blue", "Orange", "Purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            var communicationOperations = new Mock<ICommunicationOperations>();

            var game = new Game(colorChecker,communicationOperations.Object);

            //Act

            game.Play();

            //Assert

            communicationOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "White"))));
            communicationOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Black"))));
            communicationOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Black"))));

        }
    }
}