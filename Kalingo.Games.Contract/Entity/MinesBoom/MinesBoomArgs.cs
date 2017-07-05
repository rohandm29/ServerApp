namespace Kalingo.Games.Contract.Entity.MinesBoom
{
    public class MinesBoomArgs : GameArgs
    {
        private const int MinesboomGameId = 2;

        /// <summary>
        /// Arguments for MinesBoomSession
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        /// <param name="selectedOption"></param>
        public MinesBoomArgs(int gameId, int userId, int selectedOption)
            :base(gameId, userId, MinesboomGameId)
        {
            SelectedOption = selectedOption;
        }

        public int SelectedOption { get;}
    }
}
