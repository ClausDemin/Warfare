namespace Warfare.Model.Stats
{
    public class Health
    {
        private int _minValue;
        private int _maxValue;

        public Health(int minValue, int maxValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(minValue);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxValue);
            ArgumentOutOfRangeException.ThrowIfLessThan(maxValue, minValue);

            _minValue = minValue;
            _maxValue = maxValue;
            Current = maxValue;
        }

        public event Action<int>? ValueChanged;
        public event Action? Died;
        public int Current { get; private set; }

        public void ReduceHealth(int amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);

            if (Current - amount < _minValue)
            {
                amount = Current;
            }

            Current -= amount;

            ValueChanged?.Invoke(-amount);

            if (Current == _minValue) 
            {
                Died?.Invoke();
            }
        }

        public void RestoreHealth(int amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);

            if (Current + amount > _maxValue)
            {
                amount = _maxValue - Current;
            }

            Current += amount;

            ValueChanged?.Invoke(amount);
        }
    }
}
