using Xunit;

namespace LineCounter.Tests.Acceptance
{
    public class OhneKommentareTests
    {
        [Fact]
        public void TestFile0_hat_3_Zeilen_Code()
        {
            int anzahl = LOC.CountLines("TestFile0.cs");
            Assert.Equal(3, anzahl);
        }
    }
}