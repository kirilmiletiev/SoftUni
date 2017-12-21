using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] data = Console.ReadLine().ToCharArray();

            if (data.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Queue<char> leftPart = new Queue<char>();
            Stack<char> rightPart = new Stack<char>();
            bool isSame = false;

            for (int chara = 0; chara < data.Length; chara++)
            {
                if (chara < data.Length / 2)
                    leftPart.Enqueue(data[chara]);
                else
                    rightPart.Push(data[chara]);
            }

            for (int chara = 0; chara < leftPart.Count; chara++)
            {
                char currLeft = leftPart.Dequeue();
                char currRight = rightPart.Pop();
                char matchWith;

                switch (currLeft)
                {
                    case '{':
                        matchWith = '}';
                        break;
                    case '(':
                        matchWith = ')';
                        break;
                    case '[':
                        matchWith = ']';
                        break;
                    default:
                        matchWith = '!';
                        break;
                }

                if (matchWith.Equals(currRight))
                    isSame = true;
                else
                    isSame = false;
            }

            if (isSame)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}