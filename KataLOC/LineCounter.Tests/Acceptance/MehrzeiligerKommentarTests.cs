using Xunit;

namespace LineCounter.Tests.Acceptance
{
    public class MehrzeiligerKommentarTests
    {
        [Fact]
        public void TestFile2_hat_3_Code_Zeilen()
        {
            Assert.Equal(3, LOC.CountLines("TestFile2.cs"));
        }

        [Fact]
        public void TestFile3_hat_3_Code_Zeilen()
        {
            Assert.Equal(3, LOC.CountLines("TestFile3.cs"));
        }
    }
}