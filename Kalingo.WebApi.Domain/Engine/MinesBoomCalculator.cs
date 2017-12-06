using System.Linq;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Engine
{
    public class MinesBoomCalculator
    {
        public MinesboomSettings MinesboomSettings { get; }

        public MinesBoomCalculator(MinesboomSettings minesboomSettings)
        {
            MinesboomSettings = minesboomSettings;
        }

        public void Calculate(MinesBoomSession mbSession, bool playAgain)
        {
            HasWonAnything(mbSession.GameResult, mbSession.GameState, playAgain);
        }

        private void HasWonAnything(MinesboomSelectionResponse mbResult, MinesBoomGameState mbState, bool playAgain)
        {
            foreach (var setting in MinesboomSettings.Setting.Where(x => x.PlayAgain == playAgain))
            {
                if (mbState.GiftsFound != setting.MinesCount)
                    continue;

                mbResult.HasWon = true;
                mbResult.CoinType = setting.CoinTypeId;
                mbResult.CoinsWon = setting.CoinCount;
            }
        }
    }
}
