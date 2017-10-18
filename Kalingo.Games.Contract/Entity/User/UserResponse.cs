using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalingo.Games.Contract.Entity.User
{
    public class UserResponse
    {
        public int UserId { get; set; }

        public int Gold { get; }

        public int Silver { get; }

        public int CountryId { get; }

        public UserCodes ErrorCode { get; private set; }

        public List<string> Errors { get;  } = new List<string>();

        public UserResponse(int userId, int gold, int silver, int countryId)
        {
            UserId = userId;
            Gold = gold;
            Silver = silver;
            CountryId = countryId;
        }

        public static UserResponse ValidUser(int userId, int gold, int silver, int countryId)
        {
            var response = new UserResponse(userId, gold, silver, countryId)
            {
                ErrorCode = UserCodes.Valid
            };
            
            return response;
        }

        public static UserResponse InvalidUser()
        {
            var response = new UserResponse(0, 0, 0, 0)
            {
                ErrorCode = UserCodes.Invalid
            };

            response.Errors.Add("User details are not valid");

            return response;
        }

        public static UserResponse InactiveUser(int userId, int gold, int silver, int countryId)
        {
            var response = new UserResponse(userId, gold, silver, countryId)
            {
                ErrorCode = UserCodes.Inactive
            };

            return response;
        }
    }
}
