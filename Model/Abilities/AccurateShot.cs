using Warfare.Model.Interfaces;

namespace Warfare.Model.Abilities
{
    public class AccurateShot : AbstractAbility
    {
        private float _damageMultiplyer;

        public AccurateShot(float damageMultipyer)
        {
            _damageMultiplyer = damageMultipyer;
        }

        public override void Use(IAbilityCaster caster, IDamageable[] targets, int damage)
        {

            var target = GetRandomTarget(targets);

            PrintInfo(caster, target);

            target.TakeDamage((int) Math.Round(damage * _damageMultiplyer));
        }
    }
}
