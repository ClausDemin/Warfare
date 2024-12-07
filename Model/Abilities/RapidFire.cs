
using Warfare.Model.Interfaces;

namespace Warfare.Model.Abilities
{
    public class RapidFire : AbstractAbility
    {
        private int _maxAttackCount;

        public override event Action<IDamageable>? AbilityUsed;

        public RapidFire(int maxAttackCount)
        {
            _maxAttackCount = maxAttackCount;
        }

        public override void Use(IDamageable[] targets, int damage)
        {
            foreach (var target in targets)
            {
                if (target.IsAlive)
                {
                    AbilityUsed?.Invoke(target);

                    target.TakeDamage(damage);
                }
            }
        }

        public IDamageable[] GetTargets(IDamageable[] targets)
        {
            if (targets.Length < _maxAttackCount)
            {
                return targets;
            }
            else
            {
                var result = new List<IDamageable>();

                while (result.Count < _maxAttackCount)
                {
                    var target = GetRandomTarget(targets);

                    result.Add(target);
                }

                return result.ToArray();
            }
        }
    }
}
