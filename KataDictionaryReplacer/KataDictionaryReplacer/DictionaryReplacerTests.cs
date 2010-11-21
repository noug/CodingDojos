using System;
using System.Collections.Generic;
using Xunit;

namespace KataDictionaryReplacer
{
    public class DictionaryReplacerTests
    {
        [Fact]
        public void GivenAnEmptyString_YieldsEmptyResult()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string result = DictionaryReplacer.Replace("", dictionary);
            Assert.Empty(result);
        }

        [Fact]
        public void GivenStringWithMatchingKey_ReplacesStringWithValue()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("temp", "temporary");
            string result = DictionaryReplacer.Replace("$temp$", dictionary);
            Assert.Equal("temporary", result);
        }

        [Fact]
        public void GivenStringWithoutMatchingKey_ReturnsString()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("temp", "temporary");
            string result = DictionaryReplacer.Replace("whatever", dictionary);
            Assert.Equal("whatever", result);
        }

        [Fact]
        public void GivenStringWithTwoMatchingKeys_ReplacesStringWithValues()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("temp", "temporary");
            dictionary.Add("name", "Timo Beil");
            string result = DictionaryReplacer.Replace("$temp$ $name$", dictionary);
            Assert.Equal("temporary Timo Beil", result);
        }

        [Fact]
        public void GivenStringWithTwoMatchingKeysAndText_ReplacesOnlyKeysWithValues()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("temp", "temporary");
            dictionary.Add("name", "Timo Beil");
            string result = DictionaryReplacer.Replace("Was $temp$ soll ich machen? $name$", dictionary);
            Assert.Equal("Was temporary soll ich machen? Timo Beil", result);
        }

        [Fact]
        public void GivenStringWithTwoMatchingKeysAndKeyInValue_ReplacesKeyWithValues()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("temp", "temporary");
            dictionary.Add("name", "Timo Beil");
            dictionary.Add("rekursion", "$name$");
            string result = DictionaryReplacer.Replace("$temp$ $name$ $rekursion$", dictionary);
            Assert.Equal("temporary Timo Beil Timo Beil", result);
        }

        [Fact]
        public void GivenDictionaryWithRecursionKeys_ShouldThrowAnArgumentExption()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("temp", "temporary");
            dictionary.Add("rekursion", "$name$");
            dictionary.Add("name", "$rekursion$");
            Assert.Throws<ArgumentException>(() =>
                                                 {
                                                     DictionaryReplacer.Replace("$temp$ $name$ $rekursion$", dictionary);
                                                 });
        }
    }
}