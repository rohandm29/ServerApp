using System;
using System.Collections.Generic;
using System.Linq;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Engine
{
    public class RandomGenerator
    {
        private readonly Random _random;

        public RandomGenerator(int seed = 1)
        {
            _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        }

        public virtual int[] GetSequence(int count, NumberSet set)
        {
            var randomNumbers = new HashSet<int>();

            while (randomNumbers.Count < count)
            {
                var number = _random.Next(set.Start, set.End);

                if (!randomNumbers.Contains(number))
                {
                    randomNumbers.Add(_random.Next(set.Start, set.End));
                }
            }

            return randomNumbers.ToArray();
        }

        public virtual int GetNumber(NumberSet set)
        {
            var number = _random.Next(set.Start, set.End);

            return number;
        }
    }
}
