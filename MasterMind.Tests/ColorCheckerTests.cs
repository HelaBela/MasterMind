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
        public void When_2_Colors_Match_Position_SameColorsSamePosition_Returns_2()
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

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Blue", "Purple", "Purple"};

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

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Blue", "Orange", "Purple"};

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

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Blue", "Orange", "Purple"};

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

            var initialColors = initialColorsProvider.ProvideColors();
            var userColors = new[] {"Red", "Blue", "Orange", "Purple"};

            var colorChecker = new ColorChecker(userColors, initialColors);

            //Act

            var sameColorsSamePosition = colorChecker.SameColorsSamePosition();

            //Assert

            Assert.AreEqual(2, sameColorsSamePosition);
        }

        [Test]
        public void
            When_User_Provides_All_Colors_Green_And_Computer_Gives_3_Reds_And_One_Green_SameColorDifferentPosition_Returns_0()
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

            var sameColorDifferentPosition = colorChecker.SameColorsDifferentPosition();

            //Assert

            Assert.AreEqual(0, sameColorDifferentPosition);
        }
        
        [Test]
        public void
            When_User_Provides_3Reds_One_Green_Computer_Provides_4Greens_SameColorDifferentPosition_Returns_1()
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

            var sameColorDifferentPosition = colorChecker.SameColorsDifferentPosition();

            //Assert

            Assert.AreEqual(0, sameColorDifferentPosition);
        }
        
        
        [Test]
        public void
            When_User_Provides_3Reds_One_Green_Computer_Provides_4Greens_SameColorSamePosition_Returns_1()
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

            var sameColorSamePosition= colorChecker.SameColorsSamePosition();

            //Assert

            Assert.AreEqual(1, sameColorSamePosition);
        }

        
        

        [Test]
        public void
            When_User_Provides_All_Colors_Green_And_Computer_Gives_3_Reds_And_One_Green_SameColorSamePosition_Returns_1()
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

            var sameColorSamePosition = colorChecker.SameColorsSamePosition();

            //Assert

            Assert.AreEqual(1, sameColorSamePosition);
        }
        

        [Test]
        public void
            When_User_Provides_Green_Red_Red_Green_And_Computer_Provides_5_Yellow_And_Green_SameColorDifferentPosition_Returns_0()
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

            var sameColorDifferentPosition = colorChecker.SameColorsDifferentPosition();

            //Assert

            Assert.AreEqual(0, sameColorDifferentPosition);
        }

        [Test]
        public void
            When_User_Provides_Green_Red_Red_Green_And_Computer_Provides_5_Yellow_And_Green_SameColorSamePosition_Returns_1()
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

            var sameColorSamePosition = colorChecker.SameColorsSamePosition();

            //Assert

            Assert.AreEqual(1, sameColorSamePosition);
        }
    }
}