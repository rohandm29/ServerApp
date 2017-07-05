using System.Threading.Tasks;
using System.Web.Http;
using Kalingo.WebApi.Processors;

namespace Kalingo.WebApi.Controllers
{
    [RoutePrefix("user")]
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
        /// <param name="userName"></param>
        /// <returns></returns>
        [Route("GetData")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserId(string userName)
        {
            var userValid = await _processor.GetUserId(userName);

            return Ok(userValid);
        }

        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddUser(string username, string password)
        {
            return Ok(12345);
        } 

        /// <summary>
        /// Update the user details.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPatch]
        public async Task<IHttpActionResult> UpdateUser(string username, string password)
        {
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
    }
}
