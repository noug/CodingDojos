using Xunit;

namespace LineCounter.Tests.Acceptance
{
    public class CompleteTestCaseTest
    {
        [Fact]
        public void CompleteTest_Case_Hat_23_Zeilen()
        {
            Assert.Equal(23, LOC.CountLines("CompleteTestCase.cs"));
        }
    }
}