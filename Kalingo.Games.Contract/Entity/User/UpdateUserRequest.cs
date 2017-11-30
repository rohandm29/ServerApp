namespace Kalingo.Games.Contract.Entity.User
{
    public class UpdateUserRequest
    {
        public string UserId { get; }

        public string Email { get; }

        public int CountryId { get; }

        public UpdateUserRequest(string userId, string email, int countryId) 
        {
            UserId = userId;
            Email = email;
            CountryId = countryId;
        }
    }
}
