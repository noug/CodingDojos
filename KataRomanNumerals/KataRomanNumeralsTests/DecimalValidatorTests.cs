using KataRomanNumerals;
using Xunit;

namespace KataRomanNumeralsTests
{
    public class DecimalValidatorTests
    {
        private DecimalValidator validator;

        public DecimalValidatorTests()
        {
            validator = new DecimalValidator();
        }

        [Fact]
        public void Test_2000_should_pass()
        {
            validator.Validate("2000");
        }

        [Fact]
        public void Test_ASDGH_should_throw_exception()
        {
            Assert.Throws<ValidationException>(() => validator.Validate("ASDGH"));
            
        }

        [Fact]
        public void Test_2340_23_should_throw_exception()
        {
            Assert.Throws<ValidationException>(() => validator.Validate("2340,23"));
        }

        [Fact]
        public void Test_2340_23_with_point_should_throw_exception()
        {
            Assert.Throws<ValidationException>(() => validator.Validate("2340.23"));
        }

    }
}