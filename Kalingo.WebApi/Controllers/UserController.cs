using System.Net;
using System.Net.Http;
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

            if (userEntity.Code == UserCodes.Valid || userEntity.Code == UserCodes.Inactive)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, userEntity);
                response.Headers.Add("UserId", userEntity.UserId.ToString());
                return ResponseMessage(response);
            }

            return NotFound();
        }

        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddUser(NewUserRequest user)
        {
            var addUserResponse = await _processor.AddUser(user);

            return Ok(addUserResponse);
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
