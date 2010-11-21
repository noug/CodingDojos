using KataRomanNumerals;
using Xunit;
using Xunit.Extensions;

namespace KataRomanNumeralsTests
{
    public class DecimalToRomanConverterTests
    {
        private DecimalToRomanConverter converter;

        public DecimalToRomanConverterTests()
        {
            converter = new DecimalToRomanConverter();
        }

        [Fact]
        public void Input_1_should_output_I()
        {
            var result = converter.Convert("1");
            Assert.Equal("I", result);
        }

        [Fact]
        public void Input_2_should_output_II()
        {
            var result = converter.Convert("2");
            Assert.Equal("II", result);
        }

        [Fact]
        public void Input_3_should_output_III()
        {
            var result = converter.Convert("3");
            Assert.Equal("III", result);
        }

        [Fact]
        public void Input_5_should_output_V()
        {
            var result = converter.Convert("5");
            Assert.Equal("V", result);
        }

        [Fact]
        public void Input_6_should_output_VI()
        {
            var result = converter.Convert("6");
            Assert.Equal("VI", result);
        }

        [Fact]
        public void Input_7_should_output_VII()
        {
            var result = converter.Convert("7");
            Assert.Equal("VII", result);
        }

        [Fact]
        public void Input_9_should_output_VIIII()
        {
            var result = converter.Convert("9");
            Assert.Equal("VIIII", result);
        }

        [Fact]
        public void Input_10_should_output_X()
        {
            var result = converter.Convert("10");
            Assert.Equal("X", result);
        }

        [Fact]
        public void Input_12_should_output_XII()
        {
            var result = converter.Convert("12");
            Assert.Equal("XII", result);
        }

        [Fact]
        public void Input_15_should_output_XV()
        {
            var result = converter.Convert("15");
            Assert.Equal("XV", result);
        }

        [Fact]
        public void Input_16_should_output_XVI()
        {
            TestOutput("16", "XVI");
        }

        [Fact]
        public void Input_19_should_output_XVIIII()
        {
            TestOutput("19", "XVIIII");
        }

        [Fact]
        public void Input_20_should_output_XX()
        {
            TestOutput("20", "XX");
        }

        [Fact]
        public void Input_24_should_output_XXIIII()
        {
            TestOutput("24", "XXIIII");
        }

        [Fact]
        public void Input_30_should_output_XXX()
        {
            TestOutput("30", "XXX");
        }

        [Fact]
        public void Input_35_should_output_XXXV()
        {
            TestOutput("35", "XXXV");
        }

        [Fact]
        public void Input_37_should_output_XXXVII()
        {
            TestOutput("37", "XXXVII");
        }

        [Theory]
        [InlineData("50", "L")]
        [InlineData("55", "LV")]
        [InlineData("65", "LXV")]
        [InlineData("50", "L")]
        [InlineData("99", "LXXXXVIIII")]
        public void Input_50_to_99_should_output(string dec, string roman)
        {
            TestOutput(dec, roman);
        }

        [Theory]
        [InlineData("100", "C")]
        [InlineData("150", "CL")]
        [InlineData("199", "CLXXXXVIIII")]
        public void Input_100_to_199_should_output(string dec, string roman)
        {
            TestOutput(dec, roman);
        }

        [Theory]
        [InlineData("200", "CC")]
        [InlineData("300", "CCC")]
        [InlineData("400", "CCCC")]
        [InlineData("499", "CCCCLXXXXVIIII")]
        public void Input_200_to_499_should_output(string dec, string roman)
        {
            TestOutput(dec, roman);
        }

        [Theory]
        [InlineData("1984", "MDCCCCLXXXIIII")]
        public void Input_1000_to_2000_should_output(string dec, string roman)
        {
            TestOutput(dec, roman);
        }

        [Fact]
        public void Input_ASDfD_should_throw_exception()
        {
            Assert.Throws<ValidationException>(() => TestOutput("ASDfD", ""));
        }

        private void TestOutput(string decimalNumber, string romanNumber)
        {
            var result = converter.Convert(decimalNumber);
            Assert.Equal(romanNumber, result);
        }
    }
}