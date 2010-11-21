using System;
using System.Collections.Generic;
using System.Text;

namespace KataRomanNumerals
{
    public class DecimalToRomanConverter : IConverter
    {
        private StringBuilder stringBuilder;

        public DecimalToRomanConverter()
        {
            stringBuilder = new StringBuilder();
            validators = new List<IValidator>();
        }

        private readonly IList<IValidator> validators;


        public string Convert(string input)
        {
            int value = int.Parse(input);

            value = AddRomanChars(value, stringBuilder, 1000, "M");
            value = AddRomanChars(value, stringBuilder, 500, "D");
            value = AddRomanChars(value, stringBuilder, 100, "C");
            value = AddRomanChars(value, stringBuilder, 50, "L");
            value = AddRomanChars(value, stringBuilder, 10, "X");
            value = AddRomanChars(value, stringBuilder, 5, "V");
            AddRomanChars(value, stringBuilder, 1, "I");
            return stringBuilder.ToString();
        }


        private int AddRomanChars(int value, StringBuilder stringBuilder, int step, string romanChar)
        {
            while (value >= step)
            {
                stringBuilder.Append(romanChar);
                value -= step;
            }
            return value;
        }
    }
}