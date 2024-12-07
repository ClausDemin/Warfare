using Warfare.Model.Interfaces;

namespace Warfare.Model.Abilities
{
    public class DistantAttack : AbstractAbility
    {
        public override event Action<IDamageable>? AbilityUsed;

        public override void Use(IDamageable[] targets, int damage)
        {
            var target = GetRandomTarget(targets);

            AbilityUsed?.Invoke(target);

            target.TakeDamage(damage);
        }
    }
}
