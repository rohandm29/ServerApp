using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Services;

namespace Kalingo.WebApi.Processors
{
    public class UserProcessor
    {
        private readonly UserRepository _repository;

        public UserProcessor(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> GetUser(UserArgs userArgs)
        {
            var user = await _repository.GetUser(userArgs);

            if (user == null)
            {
                return UserNotFound();
            }

            if (!Encryption.VerifyHash(userArgs.Password, user.Password))
            {
                return InvalidUser();
            }

            if (!user.IsActive)
            {
                return InactiveUser();
            }

            return ValidUser(user.UserId, user.Gold, user.Silver, user.CountryId);
        }

        public async Task<int> AddUser(NewUserRequest user)
        {
            var userId = await _repository.AddUser(user);

            return userId;
        }

        public async Task UpdateUser(UpdateUserRequest updateUser)
        {
            await _repository.UpdateUser(updateUser);
        }

        public async Task<int> GetLimit(int userId)
        {
            return await _repository.GetUserLimit(userId);
        }

        private static UserResponse ValidUser(int userId, int gold, int silver, int countryId)
        {
            var response = new UserResponse(userId, gold, silver, countryId)
            {
                ErrorCode = UserErrorCodes.Valid
            };

            return response;
        }

        private static UserResponse InvalidUser()
        {
            var response = new UserResponse(0)
            {
                ErrorCode = UserErrorCodes.Invalid
            };

            response.Errors.Add("User details are not valid");

            return response;
        }

        private static UserResponse UserNotFound()
        {
            var response = new UserResponse(0)
            {
                ErrorCode = UserErrorCodes.NotFound
            };

            response.Errors.Add("User not found");

            return response;
        }

        private static UserResponse InactiveUser()
        {
            var response = new UserResponse(0)
            {
                ErrorCode = UserErrorCodes.Inactive
            };

            response.Errors.Add("User not active");

            return response;
        }
    }
}