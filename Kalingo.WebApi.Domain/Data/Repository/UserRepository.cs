using System.Threading.Tasks;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;

namespace Kalingo.WebApi.Domain.Data.Repository
{
    public class UserRepository
    {
        private readonly GetUserQuery _getUserQuery;

        public UserRepository(GetUserQuery getUserQuery)
        {
            _getUserQuery = getUserQuery;
        }

        public async Task<int> GetUser(string userName)
        {
            return await _getUserQuery.Execute(userName);
        }
    }
}