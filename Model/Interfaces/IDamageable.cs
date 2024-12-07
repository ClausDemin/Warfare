namespace Warfare.Model.Interfaces
{
    public interface IDamageable
    {
        public int Health { get; }
        public bool IsAlive { get; }

        public void TakeDamage(int damage);
    }
}
