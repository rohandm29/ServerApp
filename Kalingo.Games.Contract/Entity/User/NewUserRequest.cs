namespace Kalingo.Games.Contract.Entity.User
{
    public class NewUserRequest : UserArgs
    {
        public string Email { get; }

        public int CountryId { get; }

        public string DeviceId { get; }

        public string Version { get; }

        public NewUserRequest(string userName, string password, string email, int countryId, string deviceId, string version) 
            : base(userName, password)
        {
            Email = email;
            CountryId = countryId;
            DeviceId = deviceId;
            Version = version;
        }
    }
}
