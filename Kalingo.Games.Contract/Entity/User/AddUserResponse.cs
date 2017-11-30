namespace Kalingo.Games.Contract.Entity.User
{
    public class AddUserResponse
    {
        public UserCodes Code { get; }

        public AddUserResponse(UserCodes code)
        {
            Code = code;
        }
    }
}
