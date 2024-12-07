using Warfare.Model;
using Warfare.Model.Abilities;
using Warfare.Model.Enums;
using Warfare.Model.Stats;

namespace Warfare.Infrastructure
{
    public class SoldierBuilder
    {
        private Health _defaultHealth;
        private Damage _defaultDamage;
        private Armor _defaultArmor;
        private AbstractAbility _defaultAbility;

        private Health? _health;
        private Damage? _damage;
        private Armor? _armor;
        private AbstractAbility? _ability;

        public SoldierBuilder(Health defaultHealth, Damage defaultDamage, Armor defaultArmor, AbstractAbility defaultAbility) 
        { 
            _defaultHealth = defaultHealth; 
            _defaultDamage = defaultDamage;
            _defaultArmor = defaultArmor;
            _defaultAbility = defaultAbility;
        }

        public SoldierBuilder Reset() 
        { 
            _health = null;
            _damage = null;
            _armor = null;
            _ability = null;

            return this;
        }

        public SoldierBuilder AddHealth(Health health) 
        { 
            _health = health;

            return this;
        }

        public SoldierBuilder AddDamage(Damage damage) 
        { 
            _damage = damage;

            return this;
        }

        public SoldierBuilder AddArmor(Armor armor) 
        { 
            _armor = armor;

            return this;
        }

        public SoldierBuilder AddAbility(AbstractAbility ability) 
        { 
            _ability = ability;

            return this;
        }

        public Soldier Build(SoldierType type) 
        {
            var health = _health ?? _defaultHealth;
            var damage = _damage ?? _defaultDamage;
            var armor = _armor ?? _defaultArmor;
            var ability = _ability ?? _defaultAbility;

            return new Soldier(type, health, damage, armor, ability);
        }
    }
}
