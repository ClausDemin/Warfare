using Warfare.Model.Abilities;
using Warfare.Model.Enums;
using Warfare.Model.Stats;

namespace Warfare.Infrastructure
{
    public class SoldierStatsProvider
    {
        private int minHealth = 0;
        private int minArmor = 0;
        private int maxArmor = 100;

        private Dictionary<SoldierType, int> _soldiersHealth = new()
        {
            {SoldierType.Conscript, 120},
            {SoldierType.Marksman, 100},
            {SoldierType.Stormtrooper, 130},
            {SoldierType.Machinegunner, 140}
        };

        private Dictionary<SoldierType, int[]> _soldiersDamage = new() 
        {
            {SoldierType.Conscript, new int[] {10, 14} },
            {SoldierType.Marksman, new int[] {20, 25 } },
            {SoldierType.Stormtrooper, new int[] {16, 20 } },
            {SoldierType.Machinegunner, new int[] {16, 18} }
        };

        private Dictionary<SoldierType, int> _soldiersArmor = new()
        {
            {SoldierType.Conscript, 10},
            {SoldierType.Marksman, 5},
            {SoldierType.Stormtrooper, 15},
            {SoldierType.Machinegunner, 20}
        };

        public Health GetHealth(SoldierType type) 
        {
            return new Health(minHealth, _soldiersHealth[type]);
        }

        public Damage GetDamage(SoldierType type) 
        { 
            var minDamage = _soldiersDamage[type][0];
            var maxDamage = _soldiersDamage[type][1];

            return new Damage(minDamage, maxDamage);
        }

        public Armor GetArmor(SoldierType type) 
        {
            return new Armor(minArmor, maxArmor, _soldiersArmor[type]);
        }
    }
}
