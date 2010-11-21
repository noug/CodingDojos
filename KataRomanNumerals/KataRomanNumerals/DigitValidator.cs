using System;

namespace KataRomanNumerals
{
    public class DigitValidator : IValidator
    {
        private readonly int digits;

        public DigitValidator(int digits)
        {
            this.digits = digits;
        }

        public void Validate(string input)
        {
            if (input.Length!=digits)
            {
                throw new ValidationException();
            }
        }
    }
}