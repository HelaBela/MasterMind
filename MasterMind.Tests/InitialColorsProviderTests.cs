using System.Reflection;
using MasterMind;
using MasterMind.ColorProviders;
using MasterMind.NumberGenerator;
using NUnit.Framework;
using Moq;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Can_Provide_4_random_Colors_In_Array()
        {
            //arrange
            var randomChooser = new Mock<INumberGenerator>();
            randomChooser.SetupSequence(s => s.RandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1).Returns(2)
                .Returns(2).Returns(0);
            
            var initialColorProvider = new InitialColorsProvider(randomChooser.Object);
            
            //act 

            var expectedColors = new string[] {"blue", "green", "green", "red"};

            var randomColors = initialColorProvider.ProvideColors();
            
            //assert
            Assert.AreEqual(expectedColors, randomColors);
        }
    }
}