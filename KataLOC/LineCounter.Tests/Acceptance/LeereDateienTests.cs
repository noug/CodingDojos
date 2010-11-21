using Xunit;

namespace LineCounter.Tests.Acceptance
{
    public class LeereDateienTests
    {
        [Fact]
        public void TestFileEmpty_hat_0_Zeilen_Code()
        {
            Assert.Equal(0, LOC.CountLines("TestFileEmpty.cs"));
        }
    }
}