namespace Frameplate.Security.Encryption.Salters
{
    using System;
    using System.Linq;

    public class RandomSalter : ISalter
    {
        private static readonly Random Random = new Random();

        private readonly int _length;

        public RandomSalter()
        {
            _length = 8;
        }

        public RandomSalter(int length)
        {
            _length = length;
        }

        public string GenerateSalt()
        {
            var saltBytes = Enumerable.Range(0, _length)
                .Select(_ => (byte) Random.Next())
                .ToArray();

            return Convert.ToBase64String(saltBytes);
        }
    }
}