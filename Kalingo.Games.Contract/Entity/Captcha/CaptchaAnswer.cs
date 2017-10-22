namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaAnswer
    {
        public int Id { get; }

        public string Answer { get; }

        public int GameId { get; }

        public CaptchaAnswer(int id, string answer, int gameId)
        {
            Id = id;
            Answer = answer;
            GameId = gameId;
        }
    }
}
