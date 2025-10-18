using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    internal class Board
    {
        public char[,] grid;
        public int Size { get; private set; }


        public Board(int size = 3)
        {
            Size = size;
            grid = new char[Size, Size];
            InitializeBoard();
        }

        public void InitializeBoard() 
        {

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    grid[i, j] = '.';
                }
            }
        }

        public void DisplayBoard() 
        {
            Console.WriteLine("   1   2   3");
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"{i+1}  ");
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(grid[i,j]);
                    if(j<2) Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("  ---+---+---");
            }
        }

        public void MakeMove(int row, int column, char symbol) 
        {
            if(IsCellEmpty(row-1, column-1)) 
                grid[row-1, column-1] = symbol;
            else
                Console.WriteLine("This cell is not empty, pls try again");

        }

        public bool IsCellEmpty(int row, int column) 
        { 
            return grid[row, column] == ' '; 
        }

        public bool CheckWin(char symbol) 
        {
            for (int i = 0; i < 3; i++)
            {
                if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2] && grid[i, 2] == symbol) 
                    return true;
                if (grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i] && grid[2, i] == symbol)
                    return true;
            }
            if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2] && grid[2, 2] == symbol)
                return true;
            if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0] && grid[2, 0] == symbol)
                return true;
            return false;
        }

        public bool IsBoardFull()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (grid[i, j] == '.') return false;
                }
            }
            return true;
        }

    }

}
