using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.MinesBoom;
using Newtonsoft.Json;

namespace Kalingo.WebApi.AcceptanceTests.WebApi.Support
{
    public class HttpRequestFactory
    {
        private const string baseUrl = "http://testserver";

        public static HttpRequestMessage GetRequestMessage(string action, GameArgs gameArgs)
        {
            switch (action.ToLower())
            {
                case "join":
                    return new HttpRequestMessage(
                        HttpMethod.Get,
                        new Uri($"{baseUrl}/game/join?gameTypeId={gameArgs.GameTypeId}&userId={gameArgs.UserId}"));
                    
                case "submit":
                    var message = new HttpRequestMessage(
                        HttpMethod.Post,
                        new Uri($"{baseUrl}/game/submit/MinesBoomSession"));
                    message.Content = new StringContent(JsonConvert.SerializeObject(gameArgs), Encoding.UTF8, "application/json");
                    //message.Content = new ObjectContent(typeof(MinesBoomArgs), (MinesBoomArgs)gameArgs, new JsonMediaTypeFormatter());

                    return message;

                case "terminate":
                    return new HttpRequestMessage(
                        HttpMethod.Post,
                        new Uri($"{baseUrl}/game/terminate"));

                default: return new HttpRequestMessage(); ;
            }
        }
    }
}
