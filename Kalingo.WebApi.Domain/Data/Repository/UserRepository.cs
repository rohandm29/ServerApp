using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;
using Kalingo.WebApi.Domain.Entity;

namespace Kalingo.WebApi.Domain.Data.Repository
{
    public class UserRepository
    {
        private readonly GetUserQuery _getUser;
        private readonly AddUserCommand _addUser;
        private readonly UpdateUserCommand _updateUser;
        private readonly GetConfigQuery _configQuery;
        private readonly GetUserPlayCountQuery _getUserPlayCount;

        public UserRepository(GetUserQuery getUserQuery, AddUserCommand addUserCommand, UpdateUserCommand updateUser, 
            GetConfigQuery configQuery, GetUserPlayCountQuery getUserPlayCount)
        {
            _getUser = getUserQuery;
            _addUser = addUserCommand;
            _updateUser = updateUser;
            _configQuery = configQuery;
            _getUserPlayCount = getUserPlayCount;
        }

        public async Task<UserEntity> GetUser(UserArgs user)
        {
            return await _getUser.Execute(user);
        }

        public async Task<int> AddUser(NewUserRequest user)
        {
            return await _addUser.Execute(user);
        }

        public async Task UpdateUser(UpdateUserRequest updateUser)
        {
            await _updateUser.Execute(updateUser);
        }

        public async Task<int> GetUserPlayCount(int userId)
        {
            return await _getUserPlayCount.Execute(userId);
        }

        public async Task<Config> GetConfig(int countryId)
        {
            return await _configQuery.Execute(countryId);
        }
    }
}