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

        public void Calculate(MinesBoomSession mbSession)
        {
            HasWonAnything(mbSession.GameResult, mbSession.GameState);
        }

        private void HasWonAnything(MinesboomSelectionResponse mbResult, MinesBoomGameState mbState)
        {
            foreach (var setting in MinesboomSettings.Setting)
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
