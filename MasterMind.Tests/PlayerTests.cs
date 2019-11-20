using MasterMind;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class PlayerTests
    {
        [Test]
        public void User_Provides_Colors_GetColor_Returns_Chosen_Colors_Array()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var player = new PlayerInput(consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green,Red,Blue,Orange");

            //act 

            var expectedColors = new string[] {"Green", "Red", "Blue", "Orange"};

            var colors = player.GetColors();

            //assert

            Assert.AreEqual(expectedColors, colors);
            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Type 4 colors from this range: Red, Blue, Green, Orange, Purple, Yellow, separated with a coma: ',' "))));
        }

        [Test]
        public void User_Provides_Colors_With_Extra_Space_GetColor_Returns_Chosen_Colors_Array()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var player = new PlayerInput(consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green, Red,     Blue,Orange");

            //act 

            var expectedColors = new string[] {"Green", "Red", "Blue", "Orange"};

            var colors = player.GetColors();

            //assert

            Assert.AreEqual(expectedColors, colors);
        }

        [Test]
        public void User_Provides_Colors_Without_Coma_Separator()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var player = new PlayerInput(consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green Red Blue Orange").Returns("Green ,Red ,Blue, Orange");

            //act 
            var expectedColors = new string[] {"Green", "Red", "Blue", "Orange"};

            var colors = player.GetColors();

            //assert

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Please separate your colors with a coma."))));
            Assert.AreEqual(expectedColors, colors);
        }

        [Test]
        public void User_Provides_5_And_Correct_Message_Is_Displayed()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var player = new PlayerInput(consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green, Red, Blue, Orange, Purple").Returns(" Red, Blue, Orange, Purple");

            //act 

            var colors = player.GetColors();

            //assert
            
            //validate that colors.count is 4, 

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Error: you must pass 4 colours!"))));
        }
        
        [Test]
        public void User_Provides_3_Colors_And_Correct_Message_Is_Displayed()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var player = new PlayerInput(consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green, Red, Blue, Orange, Purple").Returns(" Red, Blue, Orange, Purple");

            //act 

            var colors = player.GetColors();

            //assert
            
            //validate that colors.count is 4, 

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c == "Error: you must pass 4 colours!"))));
        }

        [Test]
        public void User_Provides_3_Colors_From_The_List_And_One_Other_Color_And_Is_Prompted_To_Provided_Colors_From_List()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var player = new PlayerInput(consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("Green, Red, Blue, Pink").Returns("Green, Red, Blue, Blue");

            //act 

            var colors = player.GetColors();
            var expectedColors = new string[] {"Green", "Red", "Blue", "Blue"};

            //assert

            consoleOperations.Verify(
                m => m.WriteLine((It.Is<string>(c => c =="Error: you have given an invalid colour!"))));
            Assert.AreEqual(expectedColors, colors);
        }
        
        
        [Test]
        public void User_Provides_Answer_Randomly_Using_Capital_Letters_And_It_Passes()
        {
            //arrange

            var consoleOperations = new Mock<ICommunicationOperations>();

            var player = new PlayerInput(consoleOperations.Object);

            consoleOperations.SetupSequence(s => s.Read()).Returns("GrEEn, REd, blue, bluE");

            //act 

            var colors = player.GetColors();
            var expectedColors = new string[] {"Green", "Red", "Blue", "Blue"};

            //assert
            
            Assert.AreEqual(expectedColors, colors);
        }
    }
}