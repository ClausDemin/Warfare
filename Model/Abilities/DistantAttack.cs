using Warfare.Model.Interfaces;

namespace Warfare.Model.Abilities
{
    public class DistantAttack : AbstractAbility
    {
        public override void Use(IAbilityCaster caster, IDamageable[] targets, int damage)
        {
            var target = GetRandomTarget(targets);

            PrintInfo(caster, target);

            target.TakeDamage(damage);
        }
    }
}
