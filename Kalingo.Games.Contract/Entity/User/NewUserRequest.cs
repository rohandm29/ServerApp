namespace Kalingo.Games.Contract.Entity.User
{
    public class NewUserRequest : UserArgs
    {
        public string Email { get; }

        public int CountryId { get; }

        public NewUserRequest(string userName, string password, string email, int countryId) 
            : base(userName, password)
        {
            Email = email;
            CountryId = countryId;
        }
    }
}
