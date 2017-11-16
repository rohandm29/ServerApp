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
        private readonly GetUserLimitQuery _getUserLimitQuery;

        public UserRepository(GetUserQuery getUserQuery, AddUserCommand addUserCommand, UpdateUserCommand updateUser, GetUserLimitQuery getUserLimitQuery)
        {
            _getUser = getUserQuery;
            _addUser = addUserCommand;
            _updateUser = updateUser;
            _getUserLimitQuery = getUserLimitQuery;
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

        public async Task<int> GetUserLimit(int userId)
        {
            return await _getUserLimitQuery.Execute(userId);
        }
    }
}