using System.Linq;

namespace Kalingo.WebApi.Domain.Entity
{
    public class MinesBoomGameState
    {
        public MinesBoomGameState(int[] randomSequence, int totalGifts, int totalChances)
        {
            RandomSequence = randomSequence;
            TotalGifts = totalGifts;
            TotalChances = totalChances;
        }

        public bool HasSelection(int selection)
        {
            return RandomSequence.Contains(selection);
        }

        public void DecrementChance()
        {
            TotalChances--;
        }

        public void IncrementWin()
        {
            TotalWins++;

            TotalGifts--;
        }

        public void AppendSelection(int selection)
        {
            UserSelections += $"{selection}-";
        }

        public int[] RandomSequence { get; }

        public int TotalGifts { get; private set; }

        public int TotalChances { get; private set; }

        public int TotalWins { get; private set; }

        public string UserSelections { get; private set; } 
    }
}