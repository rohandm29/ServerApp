﻿namespace Kalingo.Games.Contract.Entity
{
    public class Config
    {
        public int TotalChances { get; }

        public int TotalGifts { get; }

        public bool PlayAgainEnabled { get; }

        public bool InterstitialMode { get; }

        public bool MixedMode { get; set; }

        public bool MaintenanceMode { get; }

        public int DailyPlayCount { get; }

        public string InterstitialAdUnit { get; set; }

        public string RewardedAdUnit { get; set; }

        public Config(int totalChances, int totalGifts, bool playAgainEnabled, bool interstitialMode, bool mixedMode, bool maintenanceMode, int dailyPlayCount, string interstitialAdUnit, string rewardedAdUnit)
        {
            TotalChances = totalChances;
            TotalGifts = totalGifts;
            PlayAgainEnabled = playAgainEnabled;
            InterstitialMode = interstitialMode;
            MixedMode = mixedMode;
            MaintenanceMode = maintenanceMode;
            DailyPlayCount = dailyPlayCount;
            InterstitialAdUnit = interstitialAdUnit;
            RewardedAdUnit = rewardedAdUnit;

        }
    }
}
