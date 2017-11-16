namespace Kalingo.Games.Contract.Entity.User
{
    public class NewUserRequest : UserArgs
    {
        public string Email { get; }

        public string Country { get; }

        public NewUserRequest(string userName, string password, string email, string country) 
            : base(userName, password)
        {
            Email = email;
            Country = country;
        }
    }
}
