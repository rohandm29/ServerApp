using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Engine
{
    public class RandomProvider
    {
        private readonly RandomGenerator _randomGenerator;

        public RandomProvider(RandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        public int[] CreateRandomSequenceForMinesBoom()
        {
            var randomSequence = _randomGenerator.GetSequence(5, new NumberSet(1, 16)); // fetch from db config

            //var randomSequence = GetDelimatedSequence(randomArray);

            return randomSequence;
        }

        public static string GetDelimatedSequence(IEnumerable<int> randomArray)
        {
            return string.Join("-", randomArray);
        }
    }
}
