using System;

namespace CodingDojoTennis
{
    public class Game
    {
        private bool isOver;

        public Game()
        {
            PlayerOne = new Player();
            PlayerTwo = new Player();
        }

        public Player PlayerTwo { get; private set; }

        public Player PlayerOne { get; private set; }


        public bool IsOver
        {
            get
            {
                if (PlayerOne.Score == Score.Game){
                    return true;
                }
                if (PlayerTwo.Score == Score.Game){
                    return true;
                }
                return false;
            }
        }

        private void ScorePlayerAgainst(Player player, Player playerAgainst)
        {
            player.Scored();

            if (player.Score == Score.Advantage && playerAgainst.Score == Score.Advantage)
            {
                player.Score = Score.Forty;
                playerAgainst.Score = Score.Forty;
            }
            else if (player.Score == Score.Advantage && playerAgainst.Score < Score.Forty){
                player.Score = Score.Game;
            }
        }

        public void ScorePlayerOne()
        {
            ScorePlayerAgainst(PlayerOne, PlayerTwo);
        }

        public void ScorePlayerTwo()
        {
            ScorePlayerAgainst(PlayerTwo, PlayerOne);
        }
    }
}