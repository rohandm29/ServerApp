namespace Kalingo.Games.Contract.Entity.User
{
    public class NewUser : UserArgs
    {
        public string Email { get; }

        public string Country { get; }

        public NewUser(string userName, string password, string email, string country) 
            : base(userName, password)
        {
            Email = email;
            Country = country;
        }
    }
}
