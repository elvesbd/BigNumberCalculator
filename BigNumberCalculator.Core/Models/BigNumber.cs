using System.Numerics;
using System.Text;

namespace BigNumberCalculator.Core.Models
{
    public class BigNumber
    {
        private readonly List<byte> _digits = [];

        public BigNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || !IsAllDigits(number))
                throw new ArgumentException("Número inválido");

            for (var i = number.Length - 1; i >= 0; i--)
                _digits.Add((byte)(number[i] - '0'));
        }
        
        public BigNumber Add(BigNumber other)
        {
            List<byte> result = [];
            var maxLength = Math.Max(_digits.Count, other._digits.Count);
            byte carry = 0;

            for (var i = 0; i < maxLength; i++)
            {
                var digit1 = i < _digits.Count ? _digits[i] : (byte)0;
                var digit2 = i < other._digits.Count ? other._digits[i] : (byte)0;
                var sum = (byte)(digit1 + digit2 + carry);
                result.Add((byte)(sum % 10));
                carry = (byte)(sum / 10);
            }

            if (carry > 0) result.Add(carry);

            return new BigNumber(result);
        }
        
        private BigNumber(List<byte> result)
        {
            _digits = new List<byte>(result);
        }

        private static bool IsAllDigits(string s)
        {
            return s.All(char.IsDigit);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = _digits.Count - 1; i >= 0; i--)
                sb.Append(_digits[i]);
            return sb.ToString();
        }
    }
}