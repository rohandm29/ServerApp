using System.Configuration;
using Microsoft.Azure;

namespace Kalingo.WebApi.Domain.Configuration
{
    public class MinesBoomGameSettings
    {
        public MinesBoomGameSettings()
        {
            TotalChances = int.Parse(CloudConfigurationManager.GetSetting("MbTotalChances"));

            TotalGifts = int.Parse(CloudConfigurationManager.GetSetting("MbTotalGifts"));
        }

        public int TotalGifts { get; }

        public int TotalChances { get; }
    }
}