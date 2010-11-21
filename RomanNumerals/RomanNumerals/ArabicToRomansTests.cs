using System;
using System.Collections.Generic;

using Xunit;
using Xunit.Extensions;

namespace RomanNumerals
{
    public class ArabicToRomansTests
    {
        [Fact]
        public void Arabisch_1_ergibt_I()
        {
            string result = ArabicToRomans.Convert(1);
            Assert.Equal("I", result);
        }

        [Fact]
        public void Arabisch_2_ergibt_II()
        {
            string result = ArabicToRomans.Convert(2);
            Assert.Equal("II", result);
        }

        [Fact]
        public void Arabisch_3_ergibt_III()
        {
            string result = ArabicToRomans.Convert(3);
            Assert.Equal("III", result);
        }

        [Fact]
        public void Arabisch_4_ergibt_IV()
        {
            string result = ArabicToRomans.Convert(4);
            Assert.Equal("IV", result);
        }

        [Fact]
        public void Arabisch_5_ergibt_V()
        {
            string result = ArabicToRomans.Convert(5);
            Assert.Equal("V", result);
        }

        [Fact]
        public void Arabisch_6_ergibt_VI()
        {
            string result = ArabicToRomans.Convert(6);
            Assert.Equal("VI", result);
        }

        [Fact]
        public void Arabisch_7_ergibt_VII()
        {
            string result = ArabicToRomans.Convert(7);
            Assert.Equal("VII", result);
        }

        [Fact]
        public void Arabisch_8_ergibt_VIII()
        {
            string result = ArabicToRomans.Convert(8);
            Assert.Equal("VIII", result);
        }


        [Fact]
        public void Arabisch_9_ergibt_IX()
        {
            string result = ArabicToRomans.Convert(9);
            Assert.Equal("IX", result);
        }


        [Theory]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(13, "XIII")]
        [InlineData(14, "XIV")]
        [InlineData(15, "XV")]
        [InlineData(16, "XVI")]
        [InlineData(17, "XVII")]
        [InlineData(18, "XVIII")]
        [InlineData(19, "XIX")]
        public void Arabisch_10_19_ergibt_Römisch(int arabic, string roman)
        {
            string result = ArabicToRomans.Convert(arabic);
            Assert.Equal(roman, result);
        }

       
        [Theory]
        [InlineData(20, "XX")]
        [InlineData(23, "XXIII")]
        [InlineData(24, "XXIV")]
        [InlineData(25, "XXV")]
        [InlineData(29, "XXIX")]
        public void Arabisch_20_29_ergibt_Römisch(int arabic, string roman)
        {
            string result = ArabicToRomans.Convert(arabic);
            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(49, "XLIX")]
        [InlineData(90, "XC")]
        [InlineData(99, "XCIX")]
        [InlineData(199, "CXCIX")]
        [InlineData(399, "CCCXCIX")]
        [InlineData(499, "CDXCIX")]
        [InlineData(999, "CMXCIX")]
        public void Arabisch_ergibt_Römisch(int arabic, string roman)
        {
            string result = ArabicToRomans.Convert(arabic);
            Assert.Equal(roman, result);
        }

        [Fact]
        public void Arabisch_50_ergibt_L()
        {
            string result = ArabicToRomans.Convert(50);
            Assert.Equal("L", result);
        }

        [Fact]
        public void Arabisch_100_ergibt_C()
        {
            string result = ArabicToRomans.Convert(100);
            Assert.Equal("C", result);
        }

        [Fact]
        public void Arabisch_500_ergibt_D()
        {
            string result = ArabicToRomans.Convert(500);
            Assert.Equal("D", result);
        }

        [Fact]
        public void Arabisch_1000_ergibt_M()
        {
            string result = ArabicToRomans.Convert(1000);
            Assert.Equal("M", result);
        }

    }

    public static class ArabicToRomans
    {

        public static string Convert(int value)
        {
            string numerals = "";

            Translate(ref value, ref numerals, 1000, "M");
            Translate(ref value, ref numerals, 500, "D");
            Translate(ref value, ref numerals, 100, "C");
            Translate(ref value, ref numerals, 50, "L");
            Translate(ref value, ref numerals, 10, "X");
            Translate(ref value, ref numerals, 5, "V");
            Translate(ref value, ref numerals, 1, "I");

            var replacments = new List<Tuple<string, string>>(); 
            replacments.Add(new Tuple<string, string>("IIII","IV"));
            replacments.Add(new Tuple<string, string>("XXXX", "XL"));
            replacments.Add(new Tuple<string, string>("CCCC", "CD"));
            replacments.Add(new Tuple<string, string>("VIV", "IX"));
            replacments.Add(new Tuple<string, string>("LXL", "XC"));
            replacments.Add(new Tuple<string, string>("DCD", "CM"));

            foreach (var replacment in replacments)
            {
                numerals = numerals.Replace(replacment.Item1, replacment.Item2);
            }

            return numerals;
        }


        private static void Translate(ref int value, ref string numerals, int arabic, string roman)
        {
            while (value >= arabic)
            {
                numerals += roman;
                value -= arabic;
            }
        }
    }
}