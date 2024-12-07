namespace Warfare.Model.Stats
{
    public class Armor
    {
        private int _minValue;
        private int _maxValue;

        public int Value { get; private set; }

        public Armor(int minValue, int maxValue, int value) 
        {
            ArgumentOutOfRangeException.ThrowIfNegative(minValue);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxValue);
            ArgumentOutOfRangeException.ThrowIfLessThan(maxValue, minValue);

            _minValue = minValue;
            _maxValue = maxValue;
            
            Value = value;
        }

        public int ReduceDamage(int pureDamage) 
        {
            float damageReducePercentage = 1 - ((float) Value / _maxValue);

            float damage = damageReducePercentage * pureDamage;

            if (damage == 0) 
            {
                damage = 1;
            }

            return (int) damage;
        }
    }
}
