using System.Collections.Generic;

namespace Kalingo.Games.Contract.Entity.User
{
    public class UserResponse
    {
        private int UserId { get; }

        private int Gold { get; }

        private int Silver { get; }

        private int CountryId { get; }

        private int PromoId { get; }

        public UserErrorCodes ErrorCode { get; set; }

        public List<string> Errors { get; set; }

        public UserResponse(int userId, int gold = 0, int silver = 0, int countryId = 0, int promoId = 0)
        {
            UserId = userId;
            Gold = gold;
            Silver = silver;
            CountryId = countryId;
            PromoId = promoId;
        }
    }
}
