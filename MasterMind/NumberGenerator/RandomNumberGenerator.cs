using System;

namespace MasterMind.NumberGenerator
{
    public class RandomNumberGenerator : INumberGenerator
    {
        public int RandomNumber(int min, int oneLessThanMax)
        {
            var number = new Random().Next(min, oneLessThanMax);

            return number;
        }
    }
}