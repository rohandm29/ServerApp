

namespace Kalingo.Games.Contract.Entity.User
{
    public class FbUser
    {
        public string UserName { get; }

        public string Token { get; }

        public int CountryId { get; set; }

        public string DeviceId { get; }

        public string Version { get; }

        public FbUser(string userName, string token, int countryId, string deviceId, string version)
        {
            UserName = userName;
            Token = token;
            CountryId = countryId;
            DeviceId = deviceId;
            Version = version;
        }
    }
}