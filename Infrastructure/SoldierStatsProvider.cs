using Warfare.Model.Enums;
using Warfare.Model.Stats;

namespace Warfare.Infrastructure
{
    public class SoldierStatsProvider
    {
        private int minHealth = 0;
        private int minArmor = 0;
        private int maxArmor = 100;

        private Dictionary<SoldierType, SoldierConfig> _soldiersStats = new()
        {
            {SoldierType.Conscript, new SoldierConfig(120, 10, 14, 10)},
            {SoldierType.Marksman, new SoldierConfig(100, 20, 25, 5)},
            {SoldierType.Stormtrooper, new SoldierConfig(130, 16, 20, 15)},
            {SoldierType.Machinegunner, new SoldierConfig(140, 16, 18, 20)}
        };

        public Health GetHealth(SoldierType type) 
        {
            return new Health(minHealth, _soldiersStats[type].Health);
        }

        public Damage GetDamage(SoldierType type) 
        { 
            return new Damage(_soldiersStats[type].MinDamage, _soldiersStats[type].MaxDamage);
        }

        public Armor GetArmor(SoldierType type) 
        {
            return new Armor(minArmor, maxArmor, _soldiersStats[type].Armor);
        }
    }
}
