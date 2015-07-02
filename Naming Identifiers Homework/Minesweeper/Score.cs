namespace Minesweeper
{
    public class Score
    {
        public Score()
        {

        }

        public Score(string playerName, int playerScore)
        {
            this.PlayerName = playerName;
            this.PlayerScore = playerScore;
        }

        public string PlayerName { get; set; }

        public int PlayerScore { get; set; }

    }
}