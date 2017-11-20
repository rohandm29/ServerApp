namespace Kalingo.Games.Contract.Entity
{
    public class Config
    {
        public int TotalChances { get; }
        public int TotalGifts { get; }
        public bool PlayAgainEnabled { get; }
        public bool InterstitialMode { get; }
        public bool MaintenanceMode { get; }

        public Config(int totalChances, int totalGifts, bool playAgainEnabled, bool interstitialMode, bool maintenanceMode)
        {
            TotalChances = totalChances;
            TotalGifts = totalGifts;
            PlayAgainEnabled = playAgainEnabled;
            InterstitialMode = interstitialMode;
            MaintenanceMode = maintenanceMode;
        }
    }
}
