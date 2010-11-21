using KataRomanNumerals;
using Xunit;

namespace KataRomanNumeralsTests
{
    public class DigitValidatorTests
    {
        private DigitValidator validator;

        public DigitValidatorTests()
        {
            validator = new DigitValidator(4);
        }

        [Fact]
        public void String_with_4_chars_should_pass()
        {
            validator.Validate("1234");
        }
        
        [Fact]
        public void String_with_5_chars_should_throw_exception()
        {
            Assert.Throws<ValidationException>(() => validator.Validate("12345"));
        }

        [Fact]
        public void String_with_3_chars_should_throw_exception()
        {
            Assert.Throws<ValidationException>(() => validator.Validate("abc"));
        }

        [Fact]
        public void Empty_String_should_throw_exception()
        {
            Assert.Throws<ValidationException>(() => validator.Validate(""));
        }

    }
}