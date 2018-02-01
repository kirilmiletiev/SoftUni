using System;
using System.Linq;

namespace _9._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = InitializeMatrix();
            matrix = ExecuteCommands(matrix);
            PrintAliveCells(matrix);
        }

        private static void PrintAliveCells(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i].Where(c => c != -1)));
            }
        }

        private static int[][] ExecuteCommands(int[][] matrix)
        {
            var command = Console.ReadLine().Trim();

            while (command != "Nuke it from orbit")
            {
                var commandDetails = command
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var hitRow = commandDetails[0];
                var hitColumn = commandDetails[1];
                var hitWaveRadius = commandDetails[2];

                matrix = DestroyMatrix(matrix, hitRow, hitColumn, hitWaveRadius);

                command = Console.ReadLine().Trim();
            }

            return matrix;
        }

        private static int[][] DestroyMatrix(int[][] matrix, int hitRow, int hitCol, int hitWave)
        {
            // Mark destroyed part of the column
            for (int row = hitRow - hitWave; row <= hitRow + hitWave; row++)
            {
                if (IsInMatrix(row, hitCol, matrix))
                {
                    matrix[row][hitCol] = -1;
                }
            }

            // Mark destroyed part of the row
            for (int col = hitCol - hitWave; col <= hitCol + hitWave; col++)
            {
                if (IsInMatrix(hitRow, col, matrix))
                {
                    matrix[hitRow][col] = -1;
                }
            }

            // Remove destroyed cells
            for (int i = 0; i < matrix.Length; i++)
            {
                // Remove destroyed cells if there is ones
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 0)
                    {
                        matrix[i] = matrix[i].Where(n => n > 0).ToArray();
                        break;
                    }
                }
                

                // Remove empty rows
                if (matrix[i].Count() < 1)
                {
                    matrix = matrix.Take(i).Concat(matrix.Skip(i + 1)).ToArray();
                    i--;
                }
            }

            return matrix;
        }

        private static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }

        private static int[][] InitializeMatrix()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var currentCellNumber = 1;
            var matrix = new int[dimensions[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[dimensions[1]];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = currentCellNumber;
                    currentCellNumber++;
                }
            }

            return matrix;
        }
    }
}
//var size = Console.ReadLine()
//    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToArray();
//int[][] matrx = new int[size[0]][];

//int counter = 1;
//for (int i = 0; i < size[0]; i++)
//{
//    matrx[i] = new int[size[1]];
//    for (int j = 0; j < size[1]; j++)
//    {
//        matrx[i][j] = counter;
//        counter++;
//    }
//}

//var command = Console.ReadLine();
//while (command != "Nuke it from orbit")
//{
//    var splittedCommand = command
//        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
//        .Select(int.Parse)
//        .ToArray();
//    var commandRow = splittedCommand[0];
//    var commandCol = splittedCommand[1];
//    var radius = splittedCommand[2];

//    try
//    {
//        var reminder = 0;

//        //if (commandCol + radius + reminder >= size[1])
//        //{
//        //    radius = size[1] %commandRow;
//        //}
//        Console.WriteLine($"RADIUS: {radius}");


//        for (int i = 0; i < radius; i++)
//        {
//           if (commandCol + radius + reminder >= size[1])
//           {
//               radius = size[1] %commandRow;
//           }

//            matrx[commandRow][commandCol + reminder] = 0;
//            matrx[commandRow][commandCol - radius + reminder] = 0;
//            reminder++;
//        }

//    }
//    catch (Exception e)
//    {
//        Console.WriteLine("Kurche");
//        // Console.WriteLine(radius);
//    }


//    command = Console.ReadLine();
//}


//foreach (int[] ints in matrx)
//{
//    foreach (var i in ints)
//    {
//        Console.Write($"{i} ");
//    }
//    Console.WriteLine();
//}

