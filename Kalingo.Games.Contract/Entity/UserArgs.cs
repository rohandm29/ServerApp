namespace Kalingo.Games.Contract.Entity
{
    public class UserArgs
    {
        public string UserName { get; }

        public string Password { get; }

        public UserArgs(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
