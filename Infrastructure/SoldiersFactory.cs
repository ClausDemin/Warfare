using Warfare.Model;
using Warfare.Model.Abilities;
using Warfare.Model.Enums;

namespace Warfare.Infrastructure
{
    public class SoldiersFactory
    {
        private SoldierBuilder _builder;
        private SoldierStatsProvider _statsProvider;
        private AbilityFactory _abilityFactory;

        public SoldiersFactory() 
        {
            _statsProvider = new SoldierStatsProvider();
            _abilityFactory = new AbilityFactory();

            var defaultType = SoldierType.Conscript;

            _builder = new SoldierBuilder
            (
                _statsProvider.GetHealth(defaultType),
                _statsProvider.GetDamage(defaultType),
                _statsProvider.GetArmor(defaultType),
                _abilityFactory.Create(defaultType)
            );
        }

        public Soldier Create(SoldierType type) 
        { 
            var soldier = _builder
                .Reset()
                .AddHealth(_statsProvider.GetHealth(type))
                .AddDamage(_statsProvider.GetDamage(type))
                .AddArmor(_statsProvider.GetArmor(type))
                .AddAbility(_abilityFactory.Create(type))
                .Build(type);

            return soldier;
        }
    }
}
