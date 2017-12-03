

namespace Kalingo.Games.Contract.Entity.User
{
    public class FbUser
    {
        public string UserName { get; }

        public string Token { get; }

        public FbUser(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }
    }
}