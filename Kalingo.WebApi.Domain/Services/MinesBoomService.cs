using System.Threading.Tasks;
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

            return mbSession;
        }

        private static void UpdateGameStateAndResult(MinesBoomSession mbSession)
        {
            DecrementGiftsIfWon(mbSession);

            DecrementLifes(mbSession);

            UpdateGameResult(mbSession.GameResult, mbSession.GameState);
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

        private static void UpdateGameResult(MinesBoomGameResult mbGameResult, MinesBoomGameState mbGameState)
        {
            mbGameResult.TotalChances = mbGameState.TotalChances;
            mbGameResult.TotalGifts = mbGameState.TotalGifts;

            mbGameResult.HasWon = mbGameState.TotalGifts == 0;

            if (mbGameState.TotalChances == 0)
                mbGameResult.RandomSequence = RandomProvider.GetDelimatedSequence(mbGameState.RandomSequence);
        }

        private void CacheCurrentSelection(int selectedOption, MinesBoomSession mbSession)
        {
            mbSession.GameState.AppendSelection(selectedOption);

            _mbCache.Update(mbSession.GameId, mbSession.GameState);
        }
    }
}
