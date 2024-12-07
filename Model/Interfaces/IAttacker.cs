namespace Warfare.Model.Interfaces
{
    public interface IAttacker
    {
        public void Attack(IDamageable[] availableTargets);
    }
}
