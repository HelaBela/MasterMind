using System;
using System.Collections.Generic;
using MasterMind;
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
        public void When_2_Colors_Match_Position_SameColorsSamePosition_Returns_2()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();

            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);

            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(1).Returns(2).Returns(3)
                .Returns(4);

            var initialColors = initialColorsProvider.PickRandomColors();
            var userColors = new string[] {"red", "blue", "orange", "purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var sameColorsSamePosition = colorChecker.SameColorsSamePosition();

            //Assert

            Assert.AreEqual(2, sameColorsSamePosition);
        }

        [Test]
        public void When_2_Colors_Are_The_Same_At_Different_Position_SameColorsSamePosition_Returns_0()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();

            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);


            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(4).Returns(4).Returns(2)
                .Returns(2);

            var initialColors = initialColorsProvider.PickRandomColors();
            var userColors = new string[] {"red", "blue", "purple", "purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var sameColorsSamePosition = colorChecker.SameColorsSamePosition();

            //Assert

            Assert.AreEqual(0, sameColorsSamePosition);
        }


        [Test]
        public void When_2_Colors_Are_The_Same_At_Different_Positions_SameColorDifferentPosition_Returns_2()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();

            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);


            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(1).Returns(0).Returns(5)
                .Returns(5);

            var initialColors = initialColorsProvider.PickRandomColors();
            var userColors = new string[] {"red", "blue", "orange", "purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var sameColorsSamePosition = colorChecker.SameColorsDifferentPosition();

            //Assert

            Assert.AreEqual(2, sameColorsSamePosition);
        }

        [Test]
        public void When_2_Colors_Are_The_Same_At_Same_Positions_SameColorDifferentPosition_Returns_0()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(0).Returns(1).Returns(5)
                .Returns(5);

            var initialColors = initialColorsProvider.PickRandomColors();
            var userColors = new string[] {"red", "blue", "orange", "purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var sameColorsSamePosition = colorChecker.SameColorsDifferentPosition();

            //Assert

            Assert.AreEqual(0, sameColorsSamePosition);
        }


        [Test]
        public void
            When_1_Color_Is_The_Same_At_Same_Position_And_2_Same_Colors_Are_At_Different_Position_SameColorDifferentPosition_Returns_2()
        {
            //Arrange

            var randomNumberGenerator = new Mock<INumberGenerator>();
            var initialColorsProvider = new InitialColorsProvider(randomNumberGenerator.Object);
            randomNumberGenerator.SetupSequence(s => s.RandomNumber(0, _colors.Length)).Returns(1).Returns(2).Returns(3)
                .Returns(4);

            var initialColors = initialColorsProvider.PickRandomColors();
            var userColors = new string[] {"red", "blue", "orange", "purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var sameColorsSamePosition = colorChecker.SameColorsSamePosition();

            //Assert

            Assert.AreEqual(2, sameColorsSamePosition);
        }
    }
}