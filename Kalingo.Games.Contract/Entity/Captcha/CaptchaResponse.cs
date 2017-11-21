namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaResponse
    {
        public int CaptchaId { get; }

        public string Image { get; }

        public CaptchaResponse(int captchaId, string image)
        {
            CaptchaId = captchaId;
            Image = image;
        }
    }
}
