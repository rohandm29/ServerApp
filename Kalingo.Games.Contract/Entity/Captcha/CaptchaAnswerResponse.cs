namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaAnswerResponse
    {
        public int Id { get; }

        public bool Match { get; }

        public int GameId { get; }

        public CaptchaAnswerResponse(int id, int gameId, bool match)
        {
            Id = id;
            Match = match;
            GameId = gameId;
        }
    }
}
