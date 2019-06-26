using System;

namespace Tests
{
    public class CustomRandom : Random
    {
        private readonly int[] _values = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        public override int Next()
        {
            int index = base.Next(0, _values.Length);

            return _values[index];
        }
    }
}