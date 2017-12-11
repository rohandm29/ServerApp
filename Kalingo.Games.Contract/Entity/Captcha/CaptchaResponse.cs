namespace Kalingo.Games.Contract.Entity.Captcha
{
    public class CaptchaResponse
    {
        public int CaptchaId { get; }

        public string Image { get; private set; }

        public CaptchaResponse(int captchaId, string image)
        {
            CaptchaId = captchaId;
            Image = Append(image);
        }

        private string Append(string image)
        {
            return  image.Substring(0, 10) + image;
        }
    }
}
