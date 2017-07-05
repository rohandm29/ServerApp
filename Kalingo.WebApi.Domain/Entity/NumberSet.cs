namespace Kalingo.WebApi.Domain.Entity
{
    public class NumberSet
    {
        public int Start { get; }
        public int End { get; }

        public NumberSet(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}