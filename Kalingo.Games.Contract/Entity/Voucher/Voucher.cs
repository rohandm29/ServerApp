namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class Voucher
    {
        public int Id { get; } 

        public string Name { get; } 

        public int Worth { get; }

        public int Coins { get; }

        public Voucher(int id, string name, int worth, int coins)
        {
            Id = id;
            Name = name;
            Worth = worth;
            Coins = coins;
        }
    }
}
