namespace Kalingo.Games.Contract.Entity.MinesBoom
{
    public class Settings
    {
        public int CoinTypeId { get; }

        public int MinesCount { get; }

        public int CoinCount { get; }

        public int Chances { get; }

        public bool PlayAgain { get; }

        public Settings(int coinTypeId, int minesCount, int coinCount, int chances, bool playAgain)
        {
            CoinTypeId = coinTypeId;
            MinesCount = minesCount;
            CoinCount = coinCount;
            Chances = chances;
            PlayAgain = playAgain;
        }
    }
}
