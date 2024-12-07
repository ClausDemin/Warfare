using Warfare.Model.Abilities;
using Warfare.Model.Enums;

namespace Warfare.Infrastructure
{
    public class AbilityFactory
    {
        private static int s_maxAttackCount = 3;
        private static int s_maxTargetCount = 3;
        private static float s_damageMultiplyer = 1.5f;

        private Dictionary<SoldierType, Func<AbstractAbility>> _soldierAbilities = new()
        {
            {SoldierType.Conscript, CreateDistantAttack },
            {SoldierType.Marksman, () => CreateAccurateShot(s_damageMultiplyer) },
            {SoldierType.Stormtrooper, () =>  CreateRapidFire(s_maxTargetCount) },
            {SoldierType.Machinegunner, () => CreateSuppressiveFire(s_maxTargetCount)}
        };

        public AbstractAbility Create(SoldierType type)
        {
            return _soldierAbilities[type].Invoke();
        }

        private static AbstractAbility CreateDistantAttack()
        {
            return new DistantAttack();
        }

        private static AbstractAbility CreateAccurateShot(float damageMultiplyer)
        {
            return new AccurateShot(damageMultiplyer);
        }

        private static AbstractAbility CreateRapidFire(int maxAttackCount)
        {
            return new RapidFire(maxAttackCount);
        }

        private static AbstractAbility CreateSuppressiveFire(int maxTargetsCount)
        {
            return new SuppressiveFire(maxTargetsCount);
        }
    }
}
