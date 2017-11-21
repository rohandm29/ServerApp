using System.Collections.Generic;
using System.Linq;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesBoomGameState
    {
        public MinesBoomGameState(int userId, int[] randomSequence, int totalGifts, int totalChances)
        {
            GiftsFound = 0;
            UserId = userId;
            RandomSequence = randomSequence;
            TotalGifts = totalGifts;
            TotalChances = totalChances;
            UserSelections = new List<int>();
        }

        public int UserId { get; }

        public int[] RandomSequence { get; }

        public int TotalGifts { get; private set; }

        public int TotalChances { get; private set; }

        public List<int> UserSelections { get; }

        public int GiftsFound { get; set; }

        public bool HasSelection(int selection)
        {
            return RandomSequence.Contains(selection);
        }

        public void DecrementChance()
        {
            TotalChances--;
        }

        public void DecrementGifts()
        {
            TotalGifts--;
            GiftFound();
        }

        public void GiftFound()
        {
            GiftsFound++;
        }

        public void AppendSelection(int selection)
        {
            UserSelections.Add(selection);
        }
    }
}