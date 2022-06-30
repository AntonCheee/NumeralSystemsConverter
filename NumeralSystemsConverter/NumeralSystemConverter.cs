using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeralSystemsConverter
{
    public class NumeralSystemConverter
    {
        private const int LAMBDA_CHAR_SYMBOL = 55;
        public static string ConvertNumber(string value, int numeralSystemFrom, int numeralSystemTo)
        {
            value = value.ToUpper();
            ValidateValue(value, numeralSystemFrom, numeralSystemTo);

            int decValue = ConvertToDex(value, numeralSystemFrom);
            return ConvertToSpecifiedNumeralSystem(decValue, numeralSystemTo);
        }

        private static int ConvertToDex(string value, int numeralSystemFrom)
        {
            int dexValue = 0;
            int degree = value.Length - 1;

            foreach (char i in value)
            {
                int symbol = Char.IsDigit(i) ? Convert.ToInt32(i.ToString()) : Convert.ToInt32((i - LAMBDA_CHAR_SYMBOL).ToString());
                dexValue += symbol * (int)Math.Pow(numeralSystemFrom, degree);
                degree--;
            }

            return dexValue;
        }

        private static string ConvertToSpecifiedNumeralSystem(int dexValue, int numeralSystemTo)
        {
            StringBuilder result = new StringBuilder();

            do
            {
                int reminder = dexValue % numeralSystemTo;
                string symbol = (reminder <= 9 && reminder >= 0) ? reminder.ToString() : ((char)(reminder + LAMBDA_CHAR_SYMBOL)).ToString();

                result.Insert(0, symbol);

                dexValue /= numeralSystemTo;
            }
            while (dexValue != 0);


            return result.ToString();
        }

        private static void ValidateValue(string value, int numeralSystemFrom, int numeralSystemTo)
        {
            if (numeralSystemFrom < 2 || numeralSystemTo < 2)
            {
                throw new ArgumentException("Numeral system should be more than 1");
            }

            foreach (char item in value)
            {
                if (numeralSystemFrom <= 10 && (item < '0' || item > (char)(numeralSystemFrom - 1 + '0')))
                {
                    throw new ArgumentException($"{item} not correspond to {numeralSystemFrom} numeral system");
                }
                else if (numeralSystemFrom > 10 && ((item < 'A' && !Char.IsDigit(item)) || item > (char)(numeralSystemFrom - 1 + LAMBDA_CHAR_SYMBOL)))
                {
                    throw new ArgumentException($"{item} not correspond to {numeralSystemFrom} numeral system");
                }
            }
        }
    }
}
