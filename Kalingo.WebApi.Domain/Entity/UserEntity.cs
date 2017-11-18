namespace Kalingo.WebApi.Domain.Entity
{
    public class UserEntity
    {
        public int UserId { get; set; }

        public string Password { get; set; }

        public int Gold { get; }

        public int Silver { get; }

        public int CountryId { get; }

        public bool IsActive { get; }

        public UserEntity(int userId, string password, int gold, int silver, int countryId, bool isActive)
        {
            UserId = userId;
            Password = password;
            Gold = gold;
            Silver = silver;
            CountryId = countryId;
            IsActive = isActive;
        }
    }
}
