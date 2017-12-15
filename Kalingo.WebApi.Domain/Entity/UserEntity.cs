namespace Kalingo.WebApi.Domain.Entity
{
    public class UserEntity
    {
        public int UserId { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int Gold { get; }

        public int Silver { get; }

        public int Bronze { get; }

        public int CountryId { get; }

        public bool IsActive { get; }

        public UserEntity(int userId, string emailAddress, string password, int gold, int silver, int bronze, int countryId, bool isActive)
        {
            UserId = userId;
            EmailAddress = emailAddress;
            Password = password;
            Gold = gold;
            Silver = silver;
            Bronze = bronze;
            CountryId = countryId;
            IsActive = isActive;
        }
    }
}
