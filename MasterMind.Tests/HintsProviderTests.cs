using System.Collections.Generic;
using MasterMind.ColorProviders;
using MasterMind.Communication;
using MasterMind.Enum;
using MasterMind.NumberGenerator;
using Moq;
using NUnit.Framework;

namespace MasterMind.Tests
{
    public class HintsProviderTests
    {
        [Test]
        public void When_2_Colors_Are_Exact_Match_And_1_Color_Is_Matching_But_In_Wrong_Position_2_Black_And_1_White_Hints_Are_Displayed()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
           
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            var colors = System.Enum.GetValues(typeof(Colors));

            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, colors.Length)).Returns(1).Returns(2).Returns(3)
                .Returns(4);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new [] {"Red", "Blue", "Orange", "Purple"};

            var hintsProvider = new HintsProvider();

            //Act

           var hints = hintsProvider.GiveHints(userColors,initialColors);
     

            //Assert
            Assert.AreEqual("White", hints[0], "The first hint should be white");
            Assert.AreEqual("Black", hints[1], "The second hint should be black");
            Assert.AreEqual("Black", hints[2], "The third hint should be black");

        }
    }
}