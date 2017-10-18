using System;
using System.Threading.Tasks;
using System.Web.Http;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Ladders;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Kalingo.WebApi.Processors;

namespace Kalingo.WebApi.Controllers
{
    [RoutePrefix("game")]
    public class GameController : ApiController
    {
        private readonly GameProcessor _processor;

        public GameController(GameProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Creates a new game for a user with the given game type.
        /// </summary>
        /// <param name="gameTypeId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("join")]
        [HttpGet]
        public async Task<IHttpActionResult> Join(int gameTypeId, int userId)
        {
            try
            {
                var gameId = await _processor.ExecuteNewGame(gameTypeId, userId);

                return Ok(gameId);
            }   
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        /// <summary>
        /// Submit the user's selected answer.
        /// </summary>
        /// <param name="gameArgs"></param>
        /// <returns></returns>
        [Route("submit/MinesBoomSession")]
        [HttpPost]
        public async Task<IHttpActionResult> Submit([FromBody] MinesBoomArgs gameArgs)
        {
            try
            {
                var reuslt = (MinesBoomGameResult)await _processor.ExecuteSelection(gameArgs);
                return Ok(reuslt);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        /// <summary>
        /// Submit the user's selected answer.
        /// </summary>
        /// <param name="gameArgs"></param>
        /// <returns></returns>
        [Route("submit/Ladders")]
        [HttpPost]
        public async Task<IHttpActionResult> Submit([FromBody] LaddersGameArgs gameArgs)
        {
            await _processor.ExecuteSelection(gameArgs);
            return Ok();
        }

        /// <summary>
        /// When the game is terminated by user or system.
        /// </summary>
        /// <param name="gameArgs"></param>
        /// <returns></returns>
        [Route("terminate")]
        [HttpPut]
        public async Task<IHttpActionResult> Terminated([FromBody] GameArgs gameArgs)
        {
            return Ok(true);
        }
    }
}
