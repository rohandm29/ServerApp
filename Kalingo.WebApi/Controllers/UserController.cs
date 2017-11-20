using System.Threading.Tasks;
using System.Web.Http;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.User;
using Kalingo.WebApi.Processors;

namespace Kalingo.WebApi.Controllers
{
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        private readonly UserProcessor _processor;

        public UserController(UserProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Gets the usersId if valid user.
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [Route("Get")]
        [HttpPost]
        public async Task<IHttpActionResult> GetUser(UserArgs user)
        {
            var userEntity = await _processor.GetUser(user);

            return Ok(userEntity);
        }

        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddUser(NewUserRequest user)
        {
            var userId = await _processor.AddUser(user);

            return Ok(userId);
        } 

        /// <summary>
        /// Update the user details.
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPatch]
        public async Task<IHttpActionResult> UpdateUser(UpdateUserRequest updateUser)
        {
            await _processor.UpdateUser(updateUser);

            return Ok(true);
        }

        /// <summary>
        /// Delete a user account
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteUser(int userId)
        {
            return Ok(true);
        }

        [Route("GetLimit")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserLimit(int userId)
        {
            var limit = await _processor.GetLimit(userId);
            return Ok(limit);
        }
    }
}
