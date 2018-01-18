using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var treppe = InitializeMAtrix();
            ShotSnake(treppe);
            Console.WriteLine(string.Join(Environment.NewLine, treppe.Select(r => string.Join(string.Empty, r))));
        }

        private static void ShotSnake(char[][] matrix)
        {
            var shotData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var row = shotData[0];
            var col = shotData[1];
            var radius = shotData[2];

            for (int i = 0; i < matrix.Length; i++) // Process shot impact
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (IsCellShooted(i, j, row, col, radius))
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }

            for (int j = 0; j < matrix[0].Length; j++) // Fall down all cells above the impact zone
            {
                for (int i = matrix.Length - 1; i > 0; i--)
                {
                    if (matrix[i][j] == ' ' && matrix[i - 1][j] != ' ')
                    {
                        CellFallsDown(matrix, i, j);
                    }
                }
            }
        }

        private static void CellFallsDown(char[][] matrix, int row, int col)
        {
            while (row < matrix.Length)
            {
                if (matrix[row][col] == ' ')
                {
                    var temp = matrix[row - 1][col];
                    matrix[row - 1][col] = matrix[row][col];
                    matrix[row][col] = temp;
                    row++;
                }
                else
                {
                    return;
                }
            }
        }

        private static bool IsCellShooted(int i, int j, int impactRow, int impactCol, int impactRadius)
        {
            var distance = Math.Sqrt((i - impactRow) * (i - impactRow) + (j - impactCol) * (j - impactCol));
            return distance <= impactRadius;
        }

        private static char[][] InitializeMAtrix()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrx = new char[dimensions[0]][].Select(r => r = new char[dimensions[1]]).ToArray();

            var snake = new Queue<char>(Console.ReadLine().ToCharArray());

            // Spread the snake over the stairs
            for (int i = matrx.Length - 1; i >= 0; i--)
            {
                for (int j = matrx[i].Length - 1; j >= 0; j--)
                {
                    matrx[i][j] = snake.Dequeue();
                    snake.Enqueue(matrx[i][j]);
                }

                i--;

                if (i < 0)
                {
                    break;
                }

                for (int j = 0; j < matrx[i].Length; j++)
                {
                    matrx[i][j] = snake.Dequeue();
                    snake.Enqueue(matrx[i][j]);
                }
            }

            return matrx;
        }
    }
}