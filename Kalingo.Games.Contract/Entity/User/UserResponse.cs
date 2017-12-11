using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.User
{
    public class UserResponse
    {
        public int UserId { get; }

        public int Gold { get; }

        public int Silver { get; }

        public int CountryId { get; }

        public string EmailAddress { get; set; }

        public int PromoId { get; }

        public Config MbConfig { get; set; }

        public UserCodes Code { get; set; }

        public List<string> Errors { get; set; }

        public UserResponse(int userId, string emailAddress ="", Config config = null, int gold = 0, int silver = 0, int countryId = 0, int promoId = 0)
        {
            UserId = userId;
            Gold = gold;
            Silver = silver;
            CountryId = countryId;
            EmailAddress = emailAddress;
            PromoId = promoId;
            MbConfig = config;
            Errors = new List<string>();
        }
    }
}
