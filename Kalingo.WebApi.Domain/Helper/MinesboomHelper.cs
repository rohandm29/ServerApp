using System.Collections.Generic;
using System.Linq;

namespace Kalingo.WebApi.Domain.Helper
{
    public class MinesboomHelper
    {
        public static IEnumerable<int> GetDifference(int[]sequence, List<int> selection)
        {
            var userSelection = selection.ToArray();

            var result = sequence.Except(userSelection);

            return result;
        }
    }
}
