using Warfare.Model.Utils;

namespace Warfare.Model.Stats
{
    public class Damage
    {
        private int _minValue;
        private int _maxValue;

        public Damage(int minValue, int maxValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(minValue);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxValue);
            ArgumentOutOfRangeException.ThrowIfLessThan(maxValue, minValue);

            _minValue = minValue;
            _maxValue = maxValue;
        }

        public int Value => GetDamage();

        private int GetDamage() 
        { 
            return UserUtils.Next(_minValue, _maxValue + 1);
        }
    }
}
