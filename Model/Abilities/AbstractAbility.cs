using Warfare.Model.Interfaces;
using Warfare.Model.Utils;

namespace Warfare.Model.Abilities
{
    public abstract class AbstractAbility
    {
        public abstract void Use(IAbilityCaster caster,IDamageable[] targets, int damage);

        protected IDamageable GetRandomTarget(IDamageable[] targets)
        {
            var targetIndex = UserUtils.Next(0, targets.Length);

            return targets[targetIndex];
        }

        protected void PrintInfo(IAbilityCaster caster,IDamageable target)
        {
            var targetType = (target as Soldier)?.Type;
            var casterType = (caster as Soldier)?.Type;

            Console.WriteLine($"Боец {casterType} атакует бойца {targetType}");
        }
    }
}
