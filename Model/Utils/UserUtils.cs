namespace Warfare.Model.Utils
{
    public static class UserUtils
    {
        private static readonly Random _random = new Random();

        public static int Next(int minValue, int maxValue) 
        { 
            return _random.Next(minValue, maxValue);
        }
    }
}
