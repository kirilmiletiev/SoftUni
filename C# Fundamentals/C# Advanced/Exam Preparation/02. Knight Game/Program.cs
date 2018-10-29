using System;
using System.Security.Cryptography.X509Certificates;

namespace _02._Knight_Game
{
    class Program
    {
        public static int pub = 0;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            pub = size;
            char[][] matrx = new Char[size][];

            ///fill the matrx 
            for (int i = 0; i < size; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                matrx[i] = new char[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    matrx[i][j] = line[j];
                }
            }

            int maxRow = 0;
            int maxCol = 0;
            int maxAttackedPositions = 0;
            int result = 0;

            do
            {
                if (maxAttackedPositions > 0)
                {
                    matrx[maxRow][maxCol] = '0';
                    result++;
                    maxAttackedPositions = 0;
                }
                int currentAttPos = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrx[row][col] == 'K')
                        {
                            currentAttPos = CalcCurrentAttPos(row, col, matrx);
                            if (currentAttPos > maxAttackedPositions)
                            {
                                maxAttackedPositions = currentAttPos;
                                maxRow = row;
                                maxCol = col;
                                currentAttPos = 0;
                            }
                        }
                    }
                }


            } while (maxAttackedPositions != 0);

            Console.WriteLine(result);
        }

        private static bool IsInMatrx(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        private static int CalcCurrentAttPos(int row, int col, char[][] matrx)
        {
            int currentAttPositons = 0;


            if (IsInMatrx(row - 2, col - 1, pub))
            {
                if (IsPositionIsKnight(row - 2, col - 1, matrx)) currentAttPositons++;
            }
            if (IsInMatrx(row - 2, col + 1, pub))
            {
                if (IsPositionIsKnight(row - 2, col + 1, matrx)) currentAttPositons++;
            }
            if (IsInMatrx(row - 1, col - 2, pub))
            {
                if (IsPositionIsKnight(row - 1, col - 2, matrx)) currentAttPositons++;
            }
            if (IsInMatrx(row - 1, col + 2, pub))
            {
                if (IsPositionIsKnight(row - 1, col + 2, matrx)) currentAttPositons++;
            }
            if (IsInMatrx(row + 1, col - 2, pub))
            {
                if (IsPositionIsKnight(row + 1, col - 2, matrx)) currentAttPositons++;
            }
            if (IsInMatrx(row + 1, col + 2, pub))
            {
                if (IsPositionIsKnight(row + 1, col + 2, matrx)) currentAttPositons++;
            }
            if (IsInMatrx(row + 2, col - 1, pub))
            {
                if (IsPositionIsKnight(row + 2, col - 1, matrx)) currentAttPositons++;
            }
            if (IsInMatrx(row + 2, col + 1, pub))
            {
                if (IsPositionIsKnight(row + 2, col + 1, matrx)) currentAttPositons++;
            }
            return currentAttPositons;
        }

        private static bool IsPositionIsKnight(int row, int col, char[][] matrx)
        {
            bool isKnight;
            if (matrx[row][col] == 'K')
            {
                isKnight = true;
            }
            else
            {
                isKnight = false;
            }
            return isKnight;
        }
    }
}
