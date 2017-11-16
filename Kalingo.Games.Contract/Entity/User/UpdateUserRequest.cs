namespace Kalingo.Games.Contract.Entity.User
{
    public class UpdateUserRequest
    {
        public int UserId { get; }

        public string Email { get; }

        public string Country { get; }

        public UpdateUserRequest(int userId, string email, string country) 
        {
            UserId = userId;
            Email = email;
            Country = country;
        }
    }
}
