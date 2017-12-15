namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaResponse
    {
        public int CaptchaId { get; private set; }

        public string Image { get; private set; }

        public CaptchaResponse(int captchaId, string image)
        {
            CaptchaId = captchaId;
            Image = image;
        }

        public void Update()
        {
            Image = Image.Substring(0, 10) + Image;
        }
    }
}
