using Warfare.Model.Interfaces;
using Warfare.Model.Utils;

namespace Warfare.Model.Abilities
{
    public class AccurateShot : AbstractAbility
    {
        private float _damageMultiplyer;

        public AccurateShot(float damageMultipyer)
        {
            _damageMultiplyer = damageMultipyer;
        }

        public override event Action<IDamageable>? AbilityUsed;

        public override void Use(IDamageable[] targets, int damage)
        {

            var target = GetRandomTarget(targets);
            
            AbilityUsed?.Invoke(target);

            target.TakeDamage((int) Math.Round(damage * _damageMultiplyer));
        }
    }
}
