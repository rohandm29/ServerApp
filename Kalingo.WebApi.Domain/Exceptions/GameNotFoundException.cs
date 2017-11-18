using System;

namespace Kalingo.WebApi.Domain.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public override string Message { get; }

        public GameNotFoundException(string message)
        {
            Message = message;
        }
    }
}
