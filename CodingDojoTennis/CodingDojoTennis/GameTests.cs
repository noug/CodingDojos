using NUnit.Framework;

namespace CodingDojoTennis
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void New_Game_Should_Score_equals_0_0()
        {
            var game = new Game();
            Assert.AreEqual(Score.Love, game.PlayerOne.Score);
            Assert.AreEqual(Score.Love, game.PlayerTwo.Score);
        }

        [Test]
        public void When_Score_is_0_0_then_game_is_not_over()
        {
            var game = new Game();
            Assert.IsFalse(game.IsOver);
        }

        [Test]
        public void When_Score_is_40_0_and_Player1_scores_then_game_end()
        {
            var game = new Game();
            game.PlayerOne.Score = Score.Forty;
            game.PlayerTwo.Score = Score.Love;
            game.ScorePlayerOne();
            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void When_Score_is_0_40_and_Player2_scores_then_game_end()
        {
            var game = new Game();
            game.PlayerOne.Score = Score.Love;
            game.PlayerTwo.Score = Score.Forty;
            game.ScorePlayerTwo();
            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void When_Score_is_40_30_and_Player1_scores_then_game_end()
        {
            var game = new Game();
            game.PlayerOne.Score = Score.Forty;
            game.PlayerTwo.Score = Score.Thirty;
            game.ScorePlayerOne();
            Assert.IsTrue(game.IsOver);
        }


        [Test]
        public void When_Score_is_40_40_and_Player1_scores_then_game_not_ended()
        {
            var game = new Game();
            DeuceGame(game);
            game.ScorePlayerOne();
            Assert.IsFalse(game.IsOver);
        }

        private void DeuceGame(Game game)
        {
            game.PlayerOne.Score = Score.Forty;
            game.PlayerTwo.Score = Score.Forty;
        }

        [Test]
        public void When_Score_is_40_40_and_Player1_scores_then_Player1_Score_is_45()
        {
            var game = new Game();
            DeuceGame(game);
            game.ScorePlayerOne();
            Assert.AreEqual(Score.Advantage, game.PlayerOne.Score);
        }

        [Test]
        public void When_Score_is_40_40_and_Player2_scores_then_Player2_Score_is_45()
        {
            var game = new Game();
            DeuceGame(game);
            game.ScorePlayerTwo();
            Assert.AreEqual(Score.Advantage, game.PlayerTwo.Score);
        }


        [Test]
        public void When_Score_is_40_40_and_Player1_scores_two_times_then_game_ends()
        {
            var game = new Game();
            DeuceGame(game);
            game.ScorePlayerOne();
            game.ScorePlayerOne();
            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void When_Score_is_40_40_and_Player2_scores_two_times_then_game_ends()
        {
            var game = new Game();
            DeuceGame(game);
            game.ScorePlayerTwo();
            game.ScorePlayerTwo();
            Assert.IsTrue(game.IsOver);
        }


        [Test]
        public void When_Player1_has_Advantage_and_Player2_scores_then_score_is_not_ended()
        {
            var game = new Game();
            DeuceGame(game);
            game.ScorePlayerOne();
            game.ScorePlayerTwo();
            Assert.IsFalse(game.IsOver);
        }

        [Test]
        public void When_Player1_has_Advantage_and_Player2_scores_then_score_is_40_40()
        {
            var game = new Game();
            DeuceGame(game);
            game.ScorePlayerOne();
            game.ScorePlayerTwo();
            Assert.AreEqual(Score.Forty, game.PlayerOne.Score);
            Assert.AreEqual(Score.Forty, game.PlayerTwo.Score);
        }
    }
}