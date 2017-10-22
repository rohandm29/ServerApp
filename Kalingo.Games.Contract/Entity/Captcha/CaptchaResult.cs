namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaResult
    {
        public int Id { get; }

        public bool Match { get; }

        public int GameId { get; }

        public CaptchaResult(int id, int gameId, bool match)
        {
            Id = id;
            Match = match;
            GameId = gameId;
        }
    }
}
