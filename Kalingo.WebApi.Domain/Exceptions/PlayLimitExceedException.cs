using System;

namespace Kalingo.WebApi.Domain.Exceptions
{
    public class PlayLimitExceedException : Exception
    {
        public override string Message { get; }

        public PlayLimitExceedException(string message)
        {
            Message = message;
        }
    }
}
