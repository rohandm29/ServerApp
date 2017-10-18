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

        public UserRepository(GetUserQuery getUserQuery, AddUserCommand addUserCommand, UpdateUserCommand updateUser)
        {
            _getUser = getUserQuery;
            _addUser = addUserCommand;
            _updateUser = updateUser;
        }

        public async Task<UserEntity> GetUser(UserArgs user)
        {
            return await _getUser.Execute(user);
        }

        public async Task<int> AddUser(NewUser user)
        {
            return await _addUser.Execute(user);
        }

        public async Task UpdateUser(UpdateUser updateUser)
        {
            await _updateUser.Execute(updateUser);
        }
    }
}