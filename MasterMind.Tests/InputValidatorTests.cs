using System.Collections.Generic;
using MasterMind;
using MasterMind.ColorProviders;
using MasterMind.Communication;
using MasterMind.Validations;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class InputValidatorTests
    {
        [Test]
        public void User_Provides_Colors_GetValidUserInput_Returns_Chosen_Colors_Array()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();
            var validations = new List<IValidation>
                {new CorrectColorValidator(), new CorrectColorCountValidator(), new IsNotNullValidator()};
            var validator = new UserColorsProvider(validations, consoleOperations.Object);
            
            consoleOperations.SetupSequence(s => s.Read()).Returns("green,red,blue,orange");

            //act 

            var colors = validator.ProvideColors();
            var expectedColors = new string[] {"green", "red", "blue", "orange"};
            
            //assert

            Assert.AreEqual(expectedColors, colors);
        }
        
        [Test]
        public void User_Provides_Colors_With_Extra_Space_GetValidUserInput_Returns_Chosen_Colors()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();
            var validations = new List<IValidation>
                {new CorrectColorValidator(), new CorrectColorCountValidator(), new IsNotNullValidator()};
            var validator = new UserColorsProvider(validations, consoleOperations.Object);
            
            consoleOperations.SetupSequence(s => s.Read()).Returns("Green    ,Red    ,Blue , Orange");

            //act 

            var colors = validator.ProvideColors();
            var expectedColors = new string[] {"green", "red", "blue", "orange"};
            
            //assert

            Assert.AreEqual(expectedColors, colors);
        }
        
        [Test]
        public void User_Provides_Colors_Without_Coma_Separator_And_Is_Prompted_To_Give_Colors_Again()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();
            var validations = new List<IValidation>
                {new CorrectColorValidator(), new CorrectColorCountValidator(), new IsNotNullValidator()};
            var validator = new UserColorsProvider(validations, consoleOperations.Object);
            
            consoleOperations.SetupSequence(s => s.Read()).Returns("Green Red Blue Orange").Returns("Green ,Red ,Blue, Red");

            //act 

            var colors = validator.ProvideColors();
            var expectedColors = new string[] {"green", "red", "blue", "red"};
            
            //assert
            
            Assert.AreEqual(expectedColors, colors);
            
            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Type 4 colors from this range: Red, Blue, Green, Orange, Purple, Yellow, separated with a coma: ','"))));
            Assert.AreEqual(expectedColors, colors);
        }
        
        [Test]
        public void User_Provides_5_Colors_And_User_Is_Promped_To_Priovide_New_Colors()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var validations = new List<IValidation>
                {new CorrectColorValidator(), new CorrectColorCountValidator(), new IsNotNullValidator()};
            var validator = new UserColorsProvider(validations, consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green, Red, Blue, Orange, Purple").Returns(" Red, Blue, Orange, Red");

            //act 

            var colors = validator.ProvideColors();
            var expectedColors = new string[] {"red", "blue", "orange", "red"};

            //assert

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Type 4 colors from this range: Red, Blue, Green, Orange, Purple, Yellow, separated with a coma: ','"))));
            
          
            Assert.AreEqual(expectedColors, colors);
        }
        
        [Test]
        public void User_Provides_3_Colors_From_The_List_And_One_Wrong_Color_And_Is_Prompted_To_Provided_Colors_From_List()
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
        
        [Test]
        public void User_Provides_Colors_Using_Capital_Letters_Randomly_GetValidUserInput_Returns_Chosen_Colors_Array()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var validations = new List<IValidation>
                {new CorrectColorValidator(), new CorrectColorCountValidator(), new IsNotNullValidator()};
            var validator = new UserColorsProvider(validations, consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("GrEEn, REd, blue, bluE");

            //act 

            var colors = validator.ProvideColors();
            var expectedColors = new string[] {"green", "red", "blue", "blue"};

            //assert
            
            Assert.AreEqual(expectedColors, colors);
        }

        
        
        }

    }
