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
        [TestCase(new[] {"Red", "Blue", "Orange", "Purple"}, new[] {"Red", "Blue", "Yellow", "Yellow"}, 2, 0)]
        [TestCase(new[] {"Red", "Blue", "Orange", "Purple"}, new[] {"Blue", "Green", "Orange", "Purple"}, 2, 1)]
        [TestCase(new[] {"Green", "Green", "Green", "Green"}, new[] {"Red", "Green", "Green", "Green"}, 3, 0)]
        [TestCase(new[] {"Green", "Green", "Green", "Red"}, new[] {"Red", "Red", "Red", "Green"}, 0, 2)]
        [TestCase(new[] {"Red", "Red", "Red", "Green"}, new[] {"Green", "Green", "Green", "Green"}, 1, 0)]
        [TestCase(new[] {"Green", "Green", "Green", "Green"}, new[] {"Red", "Red", "Red", "Green"}, 1, 0)]
        [TestCase( new[] {"Green", "Red", "Red", "Green"}, new[] {"Yellow", "Yellow", "Yellow", "Green"}, 1, 0)]
        public void When_2_Colors_Match_Position_ExactMatchesCount_Returns_2(string[] userColors,
            string[] initialColors, int expectedExactMatchesCount, int expectedDifferentPositionsMatchsCount
        )
        {
            //Arrange

            var colorChecker = new ColorChecker();

            //Act

            var actualExactMatchesCount = colorChecker.ExactMatchesCount(userColors, initialColors);
            var actualDifferentPositionMatchesCount =
                colorChecker.DifferentPositionMatchesCount(userColors, initialColors);

            //Assert

            Assert.AreEqual(expectedExactMatchesCount, actualExactMatchesCount);
            Assert.AreEqual(expectedDifferentPositionsMatchsCount, actualDifferentPositionMatchesCount);
        }
    }
}