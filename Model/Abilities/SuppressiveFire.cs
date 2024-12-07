using Warfare.Model.Interfaces;

namespace Warfare.Model.Abilities
{
    public class SuppressiveFire : AbstractAbility
    {
        private int _maxTargetsCount;

        public SuppressiveFire(int maxTargetsCount) 
        { 
            _maxTargetsCount = maxTargetsCount;
        }

        public override void Use(IAbilityCaster caster, IDamageable[] targets, int damage)
        {
            foreach (var target in GetTargets(targets, _maxTargetsCount)) 
            {
                PrintInfo(caster, target);

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
