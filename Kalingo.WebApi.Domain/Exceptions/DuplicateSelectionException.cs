using System;

namespace Kalingo.WebApi.Domain.Exceptions
{
    public class DuplicateSelectionException : Exception
    {
        public override string Message { get; }

        public DuplicateSelectionException(string message)
        {
            Message = message;
        }
    }
}
