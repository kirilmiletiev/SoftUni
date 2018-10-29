using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int cost = 0;
            int BulletCost = 0;
            int earned = 0;

            int prisePerBullet = int.Parse(Console.ReadLine());
            int sizeOfGun = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int inteligence= int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>();
            foreach (int bullet in bullets)
            {
                bulletStack.Push(bullet);
            }

            Queue<int> locksQueue = new Queue<int>();
            foreach (int i in locks)
            {
                locksQueue.Enqueue(i);
            }

            var shotCounter = 0;
            bool gameOver = false;

            while (locksQueue.Count>0 && bulletStack.Count>0 && gameOver==false)
            {
                var shoot = bulletStack.Peek();
                var currentLock = locksQueue.Peek();
               


                if (shoot>currentLock)
                {
                    cost += prisePerBullet;///////////////////////


                    Console.WriteLine("Ping!");
                    shotCounter++;
                    bulletStack.Pop();
                    if (bulletStack.Count>0 && shotCounter==sizeOfGun)  /// ili trqbva da e po-golqm ot sizeOfGun
                    {
                        Console.WriteLine("Reloading!");
                        shotCounter = 0;
                    }
                }
                else if(shoot<= currentLock)
                {
                    cost += prisePerBullet; /////////////////

                    Console.WriteLine("Bang!");
                    shotCounter++;
                    bulletStack.Pop();
                    locksQueue.Dequeue();
                    if (bulletStack.Count > 0 && shotCounter == sizeOfGun)  /// ili trqbva da e po-golqm ot sizeOfGun
                    {
                        Console.WriteLine("Reloading!");
                        shotCounter = 0;
                    }

                }

            }

            if (locksQueue.Count>0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${inteligence-cost}");
            }
 

        }
    }
}
