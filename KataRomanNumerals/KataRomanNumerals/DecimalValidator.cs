using System;

namespace KataRomanNumerals
{
    public class DecimalValidator : IValidator
    {
        public void Validate(string input)
        {
            int value;
            if (!int.TryParse(input, out value))
            {
                throw new ValidationException();
            }
        }
    }
}