using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Timers;
using Microsoft.Owin;

namespace Kalingo.WebApi.Middleware
{
    public class Auth
    {
        private readonly ConcurrentDictionary<string, Tuple<string, DateTime>> _tokens;
        private const int OneMin = 1000 * 60;

        public Auth()
        {
            _tokens = new ConcurrentDictionary<string, Tuple<string, DateTime>>();
            var timer = new Timer(OneMin * 10); 
            timer.Elapsed += ClearExpiredToken;
        }

        private void ClearExpiredToken(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var expiredTokens = _tokens.Where(p => p.Value.Item2.AddDays(1) <= DateTime.Now)
                .Select(p => p.Key);

            foreach (var key in expiredTokens)
            {
                Tuple<string, DateTime> value;
                _tokens.TryRemove(key, out value);
            }
        }

        public void GenerateAuth(IOwinResponse contextResponse)
        {
            var tokenTime = DateTime.UtcNow;

            var time = BitConverter.GetBytes(tokenTime.ToBinary());
            var key = Guid.NewGuid().ToByteArray();
            var token = Convert.ToBase64String(key.Concat(time).ToArray());

            var userId = contextResponse.Headers.Get("UserId");

            var tuple = new Tuple<string, DateTime>(token, tokenTime);

            _tokens.TryAdd(userId, tuple);

            contextResponse.Headers.Add("Auth", new[] {token});
        }

        public bool Validate(IOwinRequest request)
        {
            var authHeader = request.Headers.Get("Auth") ?? string.Empty;
            var userIdHeader = request.Headers.Get("UserId") ?? string.Empty;

            Tuple<string, DateTime> tuple;
                
            return _tokens.TryGetValue(userIdHeader, out tuple) && tuple.Item1.Equals(authHeader);
        }
    }
}