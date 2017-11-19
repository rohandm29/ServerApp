namespace Kalingo.Games.Contract.Entity
{
    public class CountryResponse
    {
        public int Id { get; }

        public string Name { get; }

        public string Code { get; }

        public CountryResponse(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}
