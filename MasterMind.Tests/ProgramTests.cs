using System.Collections.Generic;
using MasterMind;
using MasterMind.ColorProviders;
using MasterMind.Communication;
using MasterMind.Validations;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class ProgramTests
    {
        [Test]
        public void When_User_Guesses_All_Numbers_Winning_Message_Is_Displayed()
        {
            //arrange
            var consoleOperations = new Mock<ICommunicationOperations>();

            var validations = new List<IValidation>
                {new CorrectColorValidator(), new CorrectColorCountValidator(), new IsNotNullValidator()};
            var validator = new UserColorsProvider(validations, consoleOperations.Object);


            consoleOperations.SetupSequence(s => s.Read()).Returns("Green, Red, Blue, Pink").Returns("Green, Red, Blue, Blue");

            //act 

            var colors = validator.ProvideColors();
            var expectedColors = new string[] {"green", "red", "blue", "blue"};

            //assert

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Type 4 colors from this range: Red, Blue, Green, Orange, Purple, Yellow, separated with a coma: ','"))));
            
          
            Assert.AreEqual(expectedColors, colors);
        }
    }
}