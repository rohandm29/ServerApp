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

            var isValid = user != null && Encryption.VerifyHash(userArgs.Password, user.Password);

            return isValid
                ? UserResponse.ValidUser(user.UserId, user.Gold, user.Silver, user.CountryId)
                : UserResponse.InvalidUser();
        }

        public async Task<int> AddUser(NewUserRequest user)
        {
            return await _repository.AddUser(user);
        }

        public async Task UpdateUser(UpdateUserRequest updateUser)
        {
            await _repository.UpdateUser(updateUser);
        }

        public async Task<int> GetLimit(int userId)
        {
            return await _repository.GetUserLimit(userId);
        }
    }
}