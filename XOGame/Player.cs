using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    internal class Player
    {
        public string Name { get; }
        public char Symbol { get; }

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
        public Tuple<int,int> GetMove()
        {
            int row, column;
            bool CorrectMove = true;

            do
            {
                CorrectMove = true;
                Console.WriteLine($"{Name}, Enter your move (row, column)");
                Console.Write("Enter the row is in {1, 2, 3} : ");
                row = int.Parse(Console.ReadLine());
                Console.Write("Enter the column is in {1, 2, 3} : ");
                column = int.Parse(Console.ReadLine());
                if (!(row == 1 || row == 2 || row == 3) || !(column == 1 || column == 2 || column == 3))
                {
                    Console.WriteLine("The row or column his not correct pls try again ");
                    CorrectMove = false;
                }
            }
            while (!CorrectMove);

            Tuple<int, int> RowAndColumn = Tuple.Create(row, column);

            return RowAndColumn;
        }
    }
}
