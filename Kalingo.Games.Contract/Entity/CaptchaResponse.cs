namespace Kalingo.Games.Contract.Entity
{
    public class CaptchaResponse
    {
        public int Id { get; }

        public string Image { get; }

        public CaptchaResponse(int id, string image)
        {
            Id = id;
            Image = image;
        }
    }
}
