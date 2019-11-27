using System.Collections.Generic;
using MasterMind.ColorProviders;
using MasterMind.Communication;
using MasterMind.Enum;
using MasterMind.NumberGenerator;
using MasterMind.Validations;
using Moq;
using NUnit.Framework;

namespace MasterMind.Tests
{
    public class HintsProviderTests
    {
        [Test]
        public void When_2_Colors_Are_Exact_Match_And_1_Color_Is_Matching_But_In_Wrong_Postion_2_Black_And_1_White_Hints_Are_Displayed()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
           
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            var colors = System.Enum.GetValues(typeof(Colors));
            var validations = new List<IValidation> {new IsNotNullValidator(), new CorrectColorValidator(), new CorrectColorCountValidator()};

            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, colors.Length)).Returns(1).Returns(2).Returns(3)
                .Returns(4);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new string[] {"Red", "Blue", "Orange", "Purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            var communicationOperations = new Mock<ICommunicationOperations>();

            var hints = new HintsProvider(colorChecker,communicationOperations.Object);

            //Act

            hints.GiveHints();

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