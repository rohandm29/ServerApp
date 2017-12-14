using System.Linq;
using Kalingo.WebApi.Domain.Entity;
using Microsoft.Azure;

namespace Kalingo.WebApi.Domain.Configuration
{
    public class MinesBoomGameSettings
    {
        public MinesboomSettings MinesboomSettings { get; }

        public MinesBoomGameSettings(MinesboomSettings minesboomSettings)
        {
            MinesboomSettings = minesboomSettings;

            TotalChances = minesboomSettings.Setting.Max(x => x.Chances); // int.Parse(CloudConfigurationManager.GetSetting("MbTotalChances"));

            TotalGifts = minesboomSettings.Setting.Max(x => x.MinesCount);  //int.Parse(CloudConfigurationManager.GetSetting("MbTotalGifts"));
        }

        public int TotalGifts { get; }

        public int TotalChances { get; }
    }
}