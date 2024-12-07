using Warfare.Model.Interfaces;
using Warfare.Model.Utils;

namespace Warfare.Model.Abilities
{
    public abstract class AbstractAbility
    {
        public abstract void Use(IDamageable[] targets, int damage);

        public abstract event Action<IDamageable>? AbilityUsed;

        protected IDamageable GetRandomTarget(IDamageable[] targets)
        {
            var targetIndex = UserUtils.Next(0, targets.Length);

            return targets[targetIndex];
        }
    }
}
