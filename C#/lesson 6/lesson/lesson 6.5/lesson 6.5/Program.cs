using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6._5
{
    class Matrix
    {
        private double[,] data;

        public int Rows { get; }
        public int Columns { get; }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            data = new double[rows, columns];
        }

        public double this[int row, int col]
        {
            get { return data[row, col]; }
            set { data[row, col] = value; }
        }

        public void FillRandom()
        {
            Random rand = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    data[i, j] = rand.NextDouble() * 100;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{data[i, j]:F2}\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Matrix matrix = new Matrix(3, 4);
            matrix.FillRandom();
            matrix.Print();
        }
    }
}
