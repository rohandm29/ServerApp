namespace Kalingo.Games.Contract.Entity
{
    public class Config
    {
        public int TotalChances { get; }
        public int TotalGifts { get; }
        public bool PlayAgainEnabled { get; }
        public bool InterstitialMode { get; }
        public bool MaintenanceMode { get; }
        public int DailyPlayCount { get; }

        public Config(int totalChances, int totalGifts, bool playAgainEnabled, bool interstitialMode, bool maintenanceMode, int dailyPlayCount)
        {
            TotalChances = totalChances;
            TotalGifts = totalGifts;
            PlayAgainEnabled = playAgainEnabled;
            InterstitialMode = interstitialMode;
            MaintenanceMode = maintenanceMode;
            DailyPlayCount = dailyPlayCount;
        }
    }
}
