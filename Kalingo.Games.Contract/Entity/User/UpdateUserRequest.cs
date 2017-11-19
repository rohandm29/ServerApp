namespace Kalingo.Games.Contract.Entity.User
{
    public class UpdateUserRequest
    {
        public int UserId { get; }

        public string Email { get; }

        public int CountryId { get; }

        public UpdateUserRequest(int userId, string email, int countryId) 
        {
            UserId = userId;
            Email = email;
            CountryId = countryId;
        }
    }
}
