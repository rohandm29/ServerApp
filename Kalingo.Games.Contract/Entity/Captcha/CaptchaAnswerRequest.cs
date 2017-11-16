namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaAnswerRequest
    {
        public int Id { get; }

        public string Answer { get; }

        public int GameId { get; }

        public CaptchaAnswerRequest(int id, string answer, int gameId)
        {
            Id = id;
            Answer = answer;
            GameId = gameId;
        }
    }
}
