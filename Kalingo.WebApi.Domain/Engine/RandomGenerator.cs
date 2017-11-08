using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Engine
{
    public class RandomGenerator
    {
        private readonly Random random;

        public RandomGenerator(int seed = 1)
        {
            random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        }

        public virtual int[] GetSequence(int count, NumberSet set)
        {
            var randomNumbers = new HashSet<int>();

            while (randomNumbers.Count < count)
            {
                var number = random.Next(set.Start, set.End);

                if (!randomNumbers.Contains(number))
                {
                    randomNumbers.Add(random.Next(set.Start, set.End));
                }
            }

            return randomNumbers.ToArray();
        }

        public virtual int GetNumber(NumberSet set)
        {
            var number = random.Next(set.Start, set.End);

            return number;
        }
    }
}
