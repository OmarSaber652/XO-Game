using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    internal class Game
    {
        public Board board;
        public Player player1;
        public Player player2;
        public Player currentPlayer;
        public bool gameOver;
        public Player winner;


        public Game()
        {
            board = new Board();
            Console.Write("Enter name of player 1 : ");
            string name1 = Console.ReadLine();
            Console.Write("Enter name of player 2 : ");
            string name2 = Console.ReadLine();
            player1 = new Player(name1, 'x');
            player2 = new Player(name2, 'o');
            currentPlayer = player1;
            gameOver = false;
            winner = null;
        }
        
        public void StartGame()
        {
            while (!gameOver)
            {
                board.DisplayBoard();
                Tuple<int, int> Move = currentPlayer.GetMove();
                board.MakeMove(Move.Item1, Move.Item2, currentPlayer.Symbol);
                CheckGameStatus();
                if (gameOver) break;
                else SwitchPlayer();
            }
            Console.WriteLine();
            board.DisplayBoard();
            Console.WriteLine();
            DisplayResult();
        }
        public void SwitchPlayer()
        {
            if (currentPlayer == player1) currentPlayer = player2;
            else currentPlayer = player1;
        }
        public void CheckGameStatus()
        {
            if (board.CheckWin(currentPlayer.Symbol))
            {
                winner = currentPlayer;
                gameOver = true;
            }
            else if (board.IsBoardFull())
            {
                winner = null;
                gameOver = true;
            }
        }
        public void DisplayResult()
        {
            if (winner == null)
            {
                Console.WriteLine("The game ended in a draw!");
            }
            else
            {
                Console.WriteLine($"The winner is {winner.Name}!");
            }
        }
    }
}
