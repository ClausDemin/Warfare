﻿namespace Warfare.Infrastructure
{
    public class SoldierConfig
    {
        public SoldierConfig(int health, int minDamage, int maxDamage, int armor)
        {
            Health = health;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Armor = armor;
        }

        public int Health { get; }
        public int MinDamage { get; }
        public int MaxDamage { get; }
        public int Armor { get; }
    }
}
