namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        public static void Main(string[] arguments)
        {
            const int MaxFieldsWithoutMines = 35;

            string command = string.Empty;
            int row = 0;
            int col = 0;
            int pointCounter = 0;
            char[,] playfield = CreatePlayfield();
            char[,] mines = PutMines();
            bool isStartGame = true;
            bool isOnMines = false;
            bool isWonGame = false;
            List<Score> bestPlayersScore = new List<Score>(6);

            do
            {
                if (isStartGame)
                {
                    Console.WriteLine("Let's play 'Minesweepers'. Try stepping only on the mine-free fields. " +
                    "Command 'top' shows the highscores, 'restart' starts a new game, 'exit' quits the game!");
                    PrintPlayefilds(playfield);
                    isStartGame = false;
                }

                Console.Write("Enter row and colom : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= playfield.GetLength(0) && col <= playfield.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowBestResults(bestPlayersScore);
                        break;
                    case "restart":
                        playfield = CreatePlayfield();
                        mines = PutMines();
                        PrintPlayefilds(playfield);
                        isOnMines = false;
                        isStartGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye-bye!");
                        break;
                    case "turn":

                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                ShowPlayerFieldValue(playfield, mines, row, col);
                                pointCounter++;
                            }

                            if (MaxFieldsWithoutMines == pointCounter)
                            {
                                isWonGame = true;
                            }
                            else
                            {
                                PrintPlayefilds(playfield);
                            }
                        }
                        else
                        {
                            isOnMines = true;
                        }
                        break;
                    default:
                        Console.WriteLine("{0}Error: Invalid Command{0}", Environment.NewLine);
                        break;
                }

                if (isOnMines)
                {
                    PrintPlayefilds(mines);
                    Console.Write("{1}You died with score {0} points. Enter your name:  ", pointCounter, Environment.NewLine);
                    string playerName = Console.ReadLine();
                    Score playerScore = new Score(playerName, pointCounter);

                    if (bestPlayersScore.Count < 5)
                    {
                        bestPlayersScore.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < bestPlayersScore.Count; i++)
                        {
                            if (bestPlayersScore[i].PlayerScore < playerScore.PlayerScore)
                            {
                                bestPlayersScore.Insert(i, playerScore);
                                bestPlayersScore.RemoveAt(bestPlayersScore.Count - 1);
                                break;
                            }
                        }
                    }

                    bestPlayersScore.Sort((Score r1, Score r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    bestPlayersScore.Sort((Score r1, Score r2) => r2.PlayerScore.CompareTo(r1.PlayerScore));
                    ShowBestResults(bestPlayersScore);
                    playfield = CreatePlayfield();
                    mines = PutMines();
                    pointCounter = 0;
                    isOnMines = false;
                    isStartGame = true;
                }

                if (isWonGame)
                {
                    Console.WriteLine("{0}Congratuations! You win and you have opened all {1} fields unharmed!!!", Environment.NewLine, MaxFieldsWithoutMines);
                    PrintPlayefilds(mines);
                    Console.WriteLine("Enter your name: ");
                    string playerName = Console.ReadLine();
                    Score playerScore = new Score(playerName, pointCounter);
                    bestPlayersScore.Add(playerScore);
                    ShowBestResults(bestPlayersScore);
                    playfield = CreatePlayfield();
                    mines = PutMines();
                    pointCounter = 0;
                    isWonGame = false;
                    isStartGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Pres any key to exit the game.");
            Console.Read();
        }

        private static void ShowBestResults(List<Score> playerScore)
        {
            Console.WriteLine("{0}Highscores:", Environment.NewLine);

            if (playerScore.Count > 0)
            {
                for (int i = 0; i < playerScore.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields opened", i + 1, playerScore[i].PlayerName, playerScore[i].PlayerScore);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("{0}No highscore!{0}", Environment.NewLine);
            }
        }

        private static void ShowPlayerFieldValue(char[,] playfield, char[,] mines, int row, int col)
        {
            char mainesCounter = CountMines(mines, row, col);
            mines[row, col] = mainesCounter;
            playfield[row, col] = mainesCounter;
        }

        private static void PrintPlayefilds(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayfield()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playfield = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playfield[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();

            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);

                if (!mines.Contains(randomNumber))
                {
                    mines.Add(randomNumber);
                }
            }

            foreach (int mine in mines)
            {
                int col = (mine / cols);
                int row = (mine % cols);

                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                playfield[col, row - 1] = '*';
            }

            return playfield;
        }

        private static void CalculateFieldValue(char[,] playfield)
        {
            int col = playfield.GetLength(0);
            int row = playfield.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (playfield[i, j] != '*')
                    {
                        char minesCounter = CountMines(playfield, i, j);
                        playfield[i, j] = minesCounter;
                    }
                }
            }
        }

        private static char CountMines(char[,] playfield, int row, int col)
        {
            int count = 0;
            int rows = playfield.GetLength(0);
            int cols = playfield.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playfield[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (playfield[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (playfield[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (playfield[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (playfield[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (playfield[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (playfield[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (playfield[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}