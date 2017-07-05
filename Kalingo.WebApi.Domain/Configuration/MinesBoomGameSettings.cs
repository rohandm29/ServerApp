using System.Configuration;

namespace Kalingo.WebApi.Domain.Configuration
{
    public class MinesBoomGameSettings
    {
        public MinesBoomGameSettings()
        {
            TotalChances = int.Parse(ConfigurationManager.AppSettings["MbTotalChances"]);

            TotalGifts = int.Parse(ConfigurationManager.AppSettings["MbTotalGifts"]);
        }

        public int TotalGifts { get; }

        public int TotalChances { get; }
    }
}