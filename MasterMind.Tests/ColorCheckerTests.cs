using System;
using MasterMind.ColorProviders;
using MasterMind.Enum;
using MasterMind.NumberGenerator;
using Moq;
using NUnit.Framework;

namespace MasterMind.Tests
{
    public class ColorCheckerTests
    {
        private Array _colors;

        [SetUp]
        public void Setup()
        {
            _colors = System.Enum.GetValues(typeof(Colors));
        }

        [TestCase(new[] {"Red", "Blue", "Green", "Green"}, new[] {"Red", "Blue", "Orange", "Purple"}, 2, 0)]
       [TestCase(new[] {"Red", "Blue", "Purple", "Purple"}, new[] {"Purple", "Purple", "Green", "Green"}, 0, 2)]
        public void When_2_Colors_Match_Position_ExactMatchesCount_Returns_2(string[] userColors, string[] initialColors, int expectedExactMatchesCount, int expectedDifferentPositionsMatchsCount
       )
        {
            //Arrange
            
            var colorChecker = new ColorChecker();

            //Act

            var actualExactMatchesCount = colorChecker.ExactMatchesCount(userColors, initialColors);
            var actualDifferentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(expectedExactMatchesCount, actualExactMatchesCount);
            Assert.AreEqual(expectedDifferentPositionsMatchsCount, actualDifferentPositionMatchesCount);

        }

        [Test]
        public void
            When_2_Colors_Are_The_Same_At_Different_Position_ExactMatchesCount_Returns_0_And_DifferentPositionCount_Returns_2()
        {
            //Arrange
            
            var initialColors = new[] {"Purple", "Purple", "Green", "Green"};
            var userColors = new[] {"Red", "Blue", "Purple", "Purple"};

            var colorChecker = new ColorChecker();

            //Act

            var exactMatchesCount = colorChecker.ExactMatchesCount(userColors, initialColors);
            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(0, exactMatchesCount);
            Assert.AreEqual(2, differentPositionMatchesCount);
        }


        [Test]
        public void When_2_Colors_Are_The_Same_At_Same_Positions_DifferentPositionMatchesCount_Returns_0()
        {
            //Arrange
            
            var initialColors =  new[] {"Red", "Blue", "Yellow", "Yellow"};
            var userColors = new[] {"Red", "Blue", "Orange", "Purple"};

            var colorChecker = new ColorChecker();

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(0, differentPositionMatchesCount);
        }


        [Test]
        public void
            When_1_Color_Is_The_Same_At_Different_Position_And_2_Colors_Are_Exact_Matches_ExactMatchesCount_Returns_2()
        {
            //Arrange

            var initialColors = new[] {"Blue", "Green", "Orange", "Purple"};
            var userColors = new[] {"Red", "Blue", "Orange", "Purple"};

            var colorChecker = new ColorChecker();

            //Act

            var sameColorsSamePosition = colorChecker.ExactMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(2, sameColorsSamePosition);
        }

        [Test]
        public void
            When_All_UserColors_Are_Green_And_ComputerColors_Are_3_Reds_And_1_Green_DifferentPositionMatchesCount_Returns_0()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(0).Returns(0).Returns(0)
                .Returns(2);

            var initialColors = new[] {"Red", "Green", "Green", "Green"};
            var userColors = new[] {"Green", "Green", "Green", "Green"};

            var colorChecker = new ColorChecker();

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(0, differentPositionMatchesCount);
        }

        [Test]
        public void
            When_UserColors_Are_3_Greens_1_Red_And_ComputerColors_Are_3_Reds_And_1_Green_DifferentPositionMatchesCount_Returns_2()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(0).Returns(0).Returns(0)
                .Returns(2);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Green", "Green", "Green", "Red"};

            var colorChecker = new ColorChecker();

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(2, differentPositionMatchesCount);
        }

        [Test]
        public void
            When_UserColors_Are_3_Red_And_1_Green_And_ComputerColors_Are_4_Greens_DifferentPositionMatchesCount_Returns_0()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(2).Returns(2).Returns(2)
                .Returns(2);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Red", "Red", "Green"};

            var colorChecker = new ColorChecker();

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(0, differentPositionMatchesCount);
        }


        [Test]
        public void
            When_UserColors_Are_3_Reds_1_And_ComputerColors_Are_4_Greens_ExactMatchesCount_Returns_1()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(2).Returns(2).Returns(2)
                .Returns(2);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Red", "Red", "Green"};

            var colorChecker = new ColorChecker();

            //Act

            var exactMatchesCount = colorChecker.ExactMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(1, exactMatchesCount);
        }


        [Test]
        public void
            When_UserColors_Are_All_Green_And_ComputerColors_Are_3_Reds_1_Green_ExactMatchesCount_Returns_1()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(0).Returns(0).Returns(0)
                .Returns(2);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Green", "Green", "Green", "Green"};

            var colorChecker = new ColorChecker();

            //Act

            var sameColorSamePosition = colorChecker.ExactMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(1, sameColorSamePosition);
        }


        [Test]
        public void
            When_UserColors_Are_2_Green_2_Red_And_ComputerColors_Are_3_Yellow_And_1_Green_DifferentPositionMatchesCount_Returns_0_AndExactMatchesCount_Returns_1()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(5).Returns(5).Returns(5)
                .Returns(2);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Green", "Red", "Red", "Green"};

            var colorChecker = new ColorChecker();

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount(userColors, initialColors);
            var exactMatchesCount = colorChecker.ExactMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(0, differentPositionMatchesCount);
            Assert.AreEqual(1, exactMatchesCount);
        }
    }
}