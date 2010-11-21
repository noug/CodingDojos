using Xunit;

namespace LineCounter.Tests
{
    public class CodeZeilenTests
    {
        private CodeChecker codeText;

        public CodeZeilenTests()
        {
            codeText = new CodeChecker();
        }

        [Fact]
        public void Leere_Zeile_ist_kein_Code()
        {
            codeText.GetCodeLines(@"").ShouldBeEqualTo(0);
        }

        [Fact]
        public void Zeile_mit_einem_Buchstaben_ist_Code()
        {
            codeText.GetCodeLines(@"x").ShouldBeEqualTo(1);
        }

        [Fact]
        public void Zeile_mit_Leerzeichen_ist_kein_Code()
        {
            codeText.GetCodeLines("         ").ShouldBeEqualTo(0);
        }

        [Fact]
        public void Zeile_mit_zwei_Slashes_am_Anfang_ist_kein_Code()
        {
            codeText.GetCodeLines("// Hihih").ShouldBeEqualTo(0);
        }

        [Fact]
        public void Zeile_mit_Leerzeichen_und_zwei_Slashes_am_Anfang_ist_kein_Code()
        {
            codeText.GetCodeLines("    // Hihih").ShouldBeEqualTo(0);
        }

        [Fact]
        public void Zeile_mit_Leerzeichen_und_Code_am_Anfang_sowie_zwei_Slashes_am_Ende_ist_Code()
        {
            codeText.GetCodeLines("  if () {  // Hihih").ShouldBeEqualTo(1);
        }

        [Fact]
        public void Zeile_mit_nur_einem_Komentarblock_ist_keine_Code()
        {
            codeText.GetCodeLines("  /* Hihih */").ShouldBeEqualTo(0);
        }
        [Fact]
        public void Zwei_Zeilen_mit_nur_einem_Komentarblock_ist_keine_Code()
        {
            codeText.GetCodeLines(" /* Hihih \n Haha*/").ShouldBeEqualTo(0);
        }
    }
}