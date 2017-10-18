namespace Kalingo.WebApi.Domain.Entity
{
    public class UserEntity
    {
        public int UserId { get; set; }

        public string Password { get; set; }

        public int GoldCoins { get; }

        public int SilverCoins { get; }

        public int CountryId { get; }

        public UserEntity(int userId, string password, int goldCoins, int silverCoins, int countryId)
        {
            UserId = userId;
            Password = password;
            GoldCoins = goldCoins;
            SilverCoins = silverCoins;
            CountryId = countryId;
        }
    }
}
