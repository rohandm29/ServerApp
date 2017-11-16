namespace Kalingo.Games.Contract.Entity.MinesBoom
{
    public class MinesboomSelectionRequest : GameArgs
    {
        private const int MinesboomGameId = 1;

        /// <summary>
        /// Arguments for MinesBoomSession
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="userId"></param>
        /// <param name="selectedOption"></param>
        public MinesboomSelectionRequest(int gameId, int userId, int selectedOption)
            :base(gameId, userId, MinesboomGameId)
        {
            SelectedOption = selectedOption;
        }

        public int SelectedOption { get;}
    }
}
