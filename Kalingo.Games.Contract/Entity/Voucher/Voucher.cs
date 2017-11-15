﻿namespace Kalingo.Games.Contract.Entity.Voucher
{
    public class Voucher
    {
        public int Id { get; }

        public string Description { get; }

        public string Name { get; } 

        public int Worth { get; }

        public int Coins { get; }

        public Voucher(int id, string description, string name, int worth, int coins)
        {
            Id = id;
            Description = description;
            Name = name;
            Worth = worth;
            Coins = coins;
        }
    }
}
