using NUnit.Framework;

namespace CodingDojoTennis
{
    [TestFixture]
    public class  PlayerTests
    {
        [Test]
        public void New_Player_Score_Should_Love()
        {
            var player = new Player();
            Assert.AreEqual(Score.Love,player.Score);
        }

        [Test]
        public void With_new_Player_and_Scored_Score_Should_Fifteen()
        {
            var player = new Player();
            player.Scored();
            Assert.AreEqual(Score.Fifteen, player.Score);
        }

    }
}