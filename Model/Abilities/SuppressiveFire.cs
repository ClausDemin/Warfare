using Warfare.Model.Interfaces;

namespace Warfare.Model.Abilities
{
    public class SuppressiveFire : AbstractAbility
    {
        private int _maxTargetsCount;

        public override event Action<IDamageable>? AbilityUsed;

        public SuppressiveFire(int maxTargetsCount) 
        { 
            _maxTargetsCount = maxTargetsCount;
        }

        public override void Use(IDamageable[] targets, int damage)
        {
            foreach (var target in GetTargets(targets, _maxTargetsCount)) 
            { 
                AbilityUsed?.Invoke(target);

                target.TakeDamage(damage);
            }
        }

        public IDamageable[] GetTargets(IDamageable[] targets, int maxTargetsCount) 
        {
            if (targets.Length < maxTargetsCount)
            {
                return targets;
            }
            else 
            { 
                var result = new HashSet<IDamageable>();

                while (result.Count < maxTargetsCount) 
                {
                    var target = GetRandomTarget(targets);

                    if (result.Contains(target) == false) 
                    { 
                        result.Add(target);
                    }
                }

                return result.ToArray();
            }
        }
    }
}
