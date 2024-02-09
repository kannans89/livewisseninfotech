using GameCoreLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TictacToeConsoleApp
{
    public class TictacToeGameController
    {

        private Board board;
        private ResultAnalyzer analyzer;
        private Player[] players;
        private Game game;

        public TictacToeGameController()
        {
            board = new Board();
            analyzer = new ResultAnalyzer(board);
            players = new Player[2];
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the TicTacToe game");
            Console.WriteLine("Enter first player name:");
            string firstPlayerName = Console.ReadLine();
            Console.WriteLine("Enter second player name:");
            string secondPlayerName = Console.ReadLine();
            Console.WriteLine($"Let's begin the game, all the best to: {firstPlayerName} and {secondPlayerName}");
            PrintBoard(board);

            players[0] = new Player { Name = firstPlayerName, Mark = MarkType.X };


            players[1] = new Player { Name = secondPlayerName, Mark = MarkType.O };


            game = new Game(board, players,analyzer);

            while (game.Status == ResultType.InProgress || game.Status == ResultType.NotStarted)
            {
                Console.WriteLine("Game in progress......");
                Console.WriteLine($"Current player is: {game.CurrentPlayer.Name}");
                Console.WriteLine("Enter the cell position:");
                int cellPosition = int.Parse(Console.ReadLine());
                game.Play(cellPosition);

                PrintBoard(board);
            }

            Console.WriteLine($"Game is over. Winner is {game.CurrentPlayer.Name}");
        }

        void PrintBoard(IBoard board)
        {

            int cell = 0;
            foreach (Cell c in board.Cells)
            {

                Console.Write(c.Mark + "\t");
                cell += 1;
                if (cell == 3 || cell == 6)
                    Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("======================");

        }
    }
}
