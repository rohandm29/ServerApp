﻿using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Domain.Data.Cache;
using Kalingo.WebApi.Domain.Engine;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Services
{
    public class MinesBoomService
    {
        private readonly MinesBoomVerificationEngine _verifier;
        private readonly MinesBoomCache _mbCache;

        public MinesBoomService(MinesBoomVerificationEngine verifier, MinesBoomCache mbCache)
        {
            _verifier = verifier;
            _mbCache = mbCache;
        }

        public async Task<MinesBoomSession> ProcessSelection(MinesBoomArgs mbArgs)
        {
            var mbSession = await _verifier.CheckUserSelection(mbArgs);

            UpdateGameStateAndResult(mbSession);
            
            CacheCurrentSelection(mbArgs.SelectedOption, mbSession);

            SetDifferenceIfNeeded(mbSession);
            
            return mbSession;
        }

        private static void UpdateGameStateAndResult(MinesBoomSession mbSession)
        {
            DecrementGiftsIfWon(mbSession);

            DecrementLifes(mbSession);

            UpdateGameResult(mbSession);
        }

        private static void DecrementGiftsIfWon(MinesBoomSession mbSession)
        {
            if (mbSession.GameResult.SelectionCorrect)
            {
                mbSession.GameState.DecrementGifts();
            }
        }

        // Decrement TotalChances
        private static void DecrementLifes(MinesBoomSession mbSession)
        {
            mbSession.GameState.DecrementChance();
        }

        private static void UpdateGameResult(MinesBoomSession mbSession)
        {
            mbSession.GameResult.TotalChances = mbSession.GameState.TotalChances;
            mbSession.GameResult.TotalGifts = mbSession.GameState.TotalGifts;
            mbSession.GameResult.HasWon = mbSession.GameState.TotalGifts == 0;
        }

        private static void SetDifferenceIfNeeded(MinesBoomSession mbSession)
        {
            if (mbSession.GameState.TotalChances == 0)
            {
                var missedSelection = Helper.MinesboomHelper.GetDifference(mbSession.GameState.RandomSequence, mbSession.GameState.UserSelections);
                mbSession.GameResult.RandomSequence = RandomProvider.GetDelimatedSequence(missedSelection);
            }
        }

        private void CacheCurrentSelection(int selectedOption, MinesBoomSession mbSession)
        {
            mbSession.GameState.AppendSelection(selectedOption);

            _mbCache.Update(mbSession.GameId, mbSession.GameState);
        }
    }
}
