using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Engine
{
    public class MinesBoomCalculator
    {
        public MinesboomSettings MbSettings { get; }

        public MinesBoomCalculator(MinesboomSettings mbSettings)
        {
            MbSettings = mbSettings;
        }

        public void Calculate(MinesBoomSession mbSession)
        {
            HasWonAnything(mbSession.GameResult, mbSession.GameState);
        }

        private void HasWonAnything(MinesBoomGameResult mbResult, MinesBoomGameState mbState)
        {
            foreach (var setting in MbSettings.Setting)
            {
                if (mbState.GiftsFound != setting.MinesCount)
                    continue;

                mbResult.HasWon = true;
                mbResult.CoinType = setting.CoinTypeId;
                mbResult.CoinsWon = setting.MinesCount;
            }
        }
    }
}
