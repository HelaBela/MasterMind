using System;
using System.Collections.Generic;
using MasterMind;
using MasterMind.ColorProviders;
using MasterMind.Enum;
using MasterMind.NumberGenerator;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class ColorCheckerTests
    {
        private Array _colors;

        [SetUp]
        public void Setup()
        {
            _colors = Enum.GetValues(typeof(Colors));
        }

        [Test]
        public void When_2_Colors_Match_Position_ExactMatchesCount_Returns_2()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();

            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);

            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(1).Returns(2).Returns(3)
                .Returns(4);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Blue", "Orange", "Purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var exactMatchesCount = colorChecker.ExactMatchesCount();

            //Assert

            Assert.AreEqual(2, exactMatchesCount);
        }

        [Test]
        public void
            When_2_Colors_Are_The_Same_At_Different_Position_ExactMatchesCount_Returns_0_And_DifferentPositionCount_Returns_2()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();

            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);


            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(4).Returns(4).Returns(2)
                .Returns(2);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Blue", "Purple", "Purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var exactMatchesCount = colorChecker.ExactMatchesCount();
            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount();

            //Assert

            Assert.AreEqual(0, exactMatchesCount);
            Assert.AreEqual(2, differentPositionMatchesCount);
        }


        [Test]
        public void When_2_Colors_Are_The_Same_At_Same_Positions_DifferentPositionMatchesCount_Returns_0()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(0).Returns(1).Returns(5)
                .Returns(5);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Blue", "Orange", "Purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount();

            //Assert

            Assert.AreEqual(0, differentPositionMatchesCount);
        }


        [Test]
        public void
            When_1_Color_Is_The_Same_At_Different_Position_And_2_Colors_Are_Exact_Matches_ExactMatchesCount_Returns_2()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(1).Returns(2).Returns(3)
                .Returns(4);

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Blue", "Orange", "Purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var sameColorsSamePosition = colorChecker.ExactMatchesCount();

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

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Green", "Green", "Green", "Green"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount();

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

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount();

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

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount();

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

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var exactMatchesCount = colorChecker.ExactMatchesCount();

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

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var sameColorSamePosition = colorChecker.ExactMatchesCount();

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

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var differentPositionMatchesCount = colorChecker.DifferentPositionMatchesCount();
            var exactMatchesCount = colorChecker.ExactMatchesCount();

            //Assert

            Assert.AreEqual(0, differentPositionMatchesCount);
            Assert.AreEqual(1, exactMatchesCount);
        }
    }
}