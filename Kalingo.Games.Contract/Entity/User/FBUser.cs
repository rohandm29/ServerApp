

namespace Kalingo.Games.Contract.Entity.User
{
    public class FbUser
    {
        public string UserName { get; }

        public string Token { get; }

        public int CountryId { get; set; }

        public FbUser(string userName, string token, int countryId)
        {
            UserName = userName;
            Token = token;
            CountryId = countryId;
        }
    }
}