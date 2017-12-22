

namespace Kalingo.Games.Contract.Entity.User
{
    public class FbUser
    {
        public string UserName { get; }

        public string Token { get; }

        public string EmailAddress { get; }

        public int CountryId { get; set; }

        public string DeviceId { get; }

        public string Version { get; }

        public FbUser(string userName, string token, string emailAddress, int countryId, string deviceId, string version)
        {
            UserName = userName;
            Token = token;
            EmailAddress = emailAddress;
            CountryId = countryId;
            DeviceId = deviceId;
            Version = version;
        }
    }
}