using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Microsoft.Owin.Testing;

namespace Kalingo.WebApi.AcceptanceTests.WebApi.Support
{
    public class StartUpTestServer
    {
        private static TestServer _testServer;
        private static HttpClient _httpClient;

        public void StartServer()
        {
            _testServer = TestServer.Create<OwinTestConf>();
            _httpClient = new HttpClient(_testServer.Handler);
        }
        
        public async Task<T> SendRequest<T>(string action, GameArgs gameArgs)
        {
            try
            {
                var message = HttpRequestFactory.GetRequestMessage(action, gameArgs);

                var response = await _httpClient.SendAsync(message);

                var result = await response.Content.ReadAsAsync<T>();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DisposeServer()
        {
            _testServer.Dispose();
            _httpClient.Dispose();
        }
    }
}
