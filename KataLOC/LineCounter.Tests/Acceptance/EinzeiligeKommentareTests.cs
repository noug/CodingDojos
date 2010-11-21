using Xunit;

namespace LineCounter.Tests.Acceptance
{
    public class EinzeiligeKommentareTests
    {
        [Fact]
        public void TestFile1_hat_3_Zeilen_Code()
        {
            Assert.Equal(3,LOC.CountLines("TestFile1.cs"));
        }
    }
}