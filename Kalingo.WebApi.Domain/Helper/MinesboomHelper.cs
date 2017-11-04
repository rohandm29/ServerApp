using System.Collections.Generic;
using System.Linq;

namespace Kalingo.WebApi.Domain.Helper
{
    public class MinesboomHelper
    {
        public static IEnumerable<int> GetDifference(int[]sequence, string selection)
        {
            var userSelection = selection.TrimEnd('-').Split('-').Select(int.Parse).ToArray();

            var result = sequence.Except(userSelection);

            return result;
        }
    }
}
