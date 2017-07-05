using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Kalingo.WebApi.Domain.Data.Repository;

namespace Kalingo.WebApi.Processors
{
    public class UserProcessor
    {
        private readonly UserRepository _repository;

        public UserProcessor(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> GetUserId(string userName)
        {
            return await _repository.GetUser(userName);
        }
    }
}