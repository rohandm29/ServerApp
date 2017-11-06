using System.Linq;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesBoomGameState
    {
        public MinesBoomGameState(int[] randomSequence, int totalGifts, int totalChances)
        {
            GiftsFound = 0;
            RandomSequence = randomSequence;
            TotalGifts = totalGifts;
            TotalChances = totalChances;
        }

        public int[] RandomSequence { get; }

        public int TotalGifts { get; private set; }

        public int TotalChances { get; private set; }

        public string UserSelections { get; private set; }

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
            UserSelections += $"{selection}-";
        }
    }
}