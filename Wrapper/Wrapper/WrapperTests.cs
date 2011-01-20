using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Wrapper
{
    public class WrapperTests : IDisposable
    {
        private string original;
        private string result;

        [Fact]
        public void Test_Column_72()
        {
            string expected =
                "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy\n" +
                "eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam\n" +
                "voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet\n" +
                "clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit\n" +
                "amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam\n" +
                "nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat,\n" +
                "sed diam voluptua. At vero eos et accusam et justo duo dolores et ea\n" +
                "rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem\n" +
                "ipsum dolor sit amet.";
            original = Text.LoremIpsum;
            result = LineWrapper.Wrap(Text.LoremIpsum, 72);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Can_Break_Two_Words_with_Column_2()
        {
            original = "aa aa";
            result = LineWrapper.Wrap(original, 2);
            Assert.Equal("aa\naa", result);
        }

        [Fact]
        public void Dont_Break_One_Word_with_Column_2()
        {
            original = "aaaa";
            result = LineWrapper.Wrap(original, 2);
            Assert.Equal("aaaa", result);
        }

        [Fact]
        public void Can_Break_Three_Words_with_Column_2()
        {
            original = "aaa bb ccc";
            result = LineWrapper.Wrap(original, 2);
            Assert.Equal("aaa\nbb\nccc", result);
        }

        [Fact]
        public void Can_Break_Five_Words_with_Column_2()
        {
            original = "aaa b c d eee";
            result = LineWrapper.Wrap(original, 2);
            Assert.Equal("aaa\nb\nc\nd\neee", result);
        }

        [Fact]
        public void Can_Break_Three_Small_Words_with_Column_3()
        {
            original = "a b c";
            result = LineWrapper.Wrap(original, 3);
            Assert.Equal("a b\nc", result);
        }

        [Fact]
        public void Dont_Break_DoubleSpaces_in_Line()
        {
            original = "aa  bb cc c";
            result = LineWrapper.Wrap(original, 6);
            Assert.Equal("aa  bb\ncc c", result);
        }

        [Fact]
        public void Empy_String_result_in_Empty_String()
        {
            original = "";
            result = LineWrapper.Wrap(original, 6);
            Assert.Equal("", result);
        }

        [Fact]
        public void Lots_of_Spaces_at_EndOf_Line_should_removed()
        {
            original = "a      ";
            result = LineWrapper.Wrap(original, 4);
            Assert.Equal("a", result);
        }

        [Fact]
        public void Multiple_Lines_with_Lots_of_Spaces__at_EndOf_Line_should_removed()
        {
            original = "a      b               c       d                   e  ";
            result = LineWrapper.Wrap(original, 4);
            Assert.Equal("a\nb\nc\nd\ne", result);
        }

        [Fact]
        public void Lots_of_Spaces_at_Start_of_Line_should_removed()
        {
            original = "                e";
            result = LineWrapper.Wrap(original, 4);
            Assert.Equal("e", result);
        }
        public void Dispose()
        {
            DebugWrite(original);
            DebugWrite(result);
        }

        private void DebugWrite(string text)
        {
            Console.WriteLine("!" + text.Replace("\n", "\\n") + "!");
        }
    }

    public class LineWrapper
    {
        public static string Wrap(string text, int columns)
        {
            var words = SplitWords(text);
            return string.Join("\n", WrapWords(words, columns));
        }

        private static IEnumerable<string> WrapWords(IEnumerable<string> words, int columns)
        {
            var sb = new StringBuilder();
            foreach (var word in words) {
                if (WordExceedsLine(sb, word, columns)) {
                    yield return sb.ToString().Trim();
                    sb.Clear();
                }
                if (sb.Length != 0)
                    sb.Append(' ');
                sb.Append(word);
            }
            if (sb.Length == 0)
                yield break;
            yield return sb.ToString().Trim();
        }

        private static bool WordExceedsLine(StringBuilder sb, string word, int columns)
        {
            if (sb.Length == 0) {
                return false;
            }
            return (sb.Length + word.Length + 1) > columns;
        }

        private static IEnumerable<string> SplitWords(string text)
        {
            return text.Split(new[] {' '});
        }
    }
}