namespace CodingDojoTennis
{
    public class Player
    {
        public Score Score { get; set; }

        public void Scored()
        {
            Score++;
        }
    }
}