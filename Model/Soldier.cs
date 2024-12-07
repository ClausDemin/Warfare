using Warfare.Model.Abilities;
using Warfare.Model.Enums;
using Warfare.Model.Interfaces;
using Warfare.Model.Stats;

namespace Warfare.Model
{
    public class Soldier: IAttacker, IDamageable, IAbilityCaster
    {
        private Health _health;
        private Damage _damage;
        private Armor _armor;
        private AbstractAbility _ability;

        public Soldier(SoldierType type, Health health, Damage damage, Armor armor, AbstractAbility ability) 
        { 
            _health = health;
            _damage = damage;
            _armor = armor;
            _ability = ability;
            Type = type;

            IsAlive = true;
            _health.ValueChanged += OnHealthChanged;
            _health.Died += OnDeath;
        }

        public event Action<SoldierType, int>? DamageTaken;
        public event Action<Soldier>? Died;

        public SoldierType Type {get;}

        public int Health => _health.Current;

        public bool IsAlive { get; private set; } 

        public void TakeDamage(int damage)
        {
            damage = _armor.ReduceDamage(damage);

            _health.ReduceHealth(damage);
        }

        public void Attack(IDamageable[] availableTargets)
        {
            _ability.Use(this, availableTargets, _damage.Value);
        }

        private void OnDeath() 
        { 
            IsAlive = false;
            _health.ValueChanged -= OnHealthChanged;
            
            Died?.Invoke(this);
        }

        private void OnHealthChanged(int amount) 
        {
            if (amount < 0) 
            {
                DamageTaken?.Invoke(Type, -amount);
            }
        }
    }
}
