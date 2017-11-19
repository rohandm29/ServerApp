namespace Kalingo.Games.Contract.Entity
{
    public class CountryResponse
    {
        public int Id { get; }

        public string Name { get; }

        public CountryResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
