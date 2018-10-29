using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameOver = false;
            Queue<string> firstPlayerAllCards = new Queue<string>(Console.ReadLine().Split());
            Queue<string> secondPlayerAllCards = new Queue<string>(Console.ReadLine().Split());
            int turnCounter = 0;

            while (turnCounter < 1000000 && firstPlayerAllCards.Count > 0 && secondPlayerAllCards.Count > 0 && gameOver == false)
            {
                turnCounter++;
                var firstCard = firstPlayerAllCards.Dequeue();
                var secondCard = secondPlayerAllCards.Dequeue();

                var theFirstPlayerDigit = GetNumber(firstCard);
                var theSecondPlayerDigit = GetNumber(secondCard);

                if (theSecondPlayerDigit > theFirstPlayerDigit)
                {
                    secondPlayerAllCards.Enqueue(secondCard);
                    secondPlayerAllCards.Enqueue(firstCard);

                }
                else if (theFirstPlayerDigit > theSecondPlayerDigit)
                {
                    firstPlayerAllCards.Enqueue(firstCard);
                    firstPlayerAllCards.Enqueue(secondCard);
                }
                else
                {
                    int firstPlayerResultFromChars = 0;
                    int secondPlayerResultFromChars = 0;
                    List<string> list = new List<string>() { firstCard, secondCard };

                    while (gameOver == false)
                    {
                        if (firstPlayerAllCards.Count >= 3 && secondPlayerAllCards.Count >= 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                var firstHand = firstPlayerAllCards.Dequeue();
                                list.Add(firstHand);
                                firstPlayerResultFromChars += GetChar(firstHand);

                                var secondHand = secondPlayerAllCards.Dequeue();
                                list.Add(secondHand);
                                secondPlayerResultFromChars += GetChar(secondHand);
                            }

                            if (firstPlayerResultFromChars > secondPlayerResultFromChars)
                            {
                                AddCardsToWinner(list, firstPlayerAllCards);
                                list.Clear();
                                break;
                            }
                            else if (secondPlayerResultFromChars > firstPlayerResultFromChars)
                            {
                                AddCardsToWinner(list, secondPlayerAllCards);
                                list.Clear();
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            if (firstPlayerAllCards.Count > secondPlayerAllCards.Count)
            {
                Console.WriteLine($"First player wins after {turnCounter} turns");
            }
            else if (secondPlayerAllCards.Count > firstPlayerAllCards.Count)
            {
                Console.WriteLine($"Second player wins after {turnCounter} turns");
            }
            else if (firstPlayerAllCards.Count == secondPlayerAllCards.Count || turnCounter == 1000000)
            {
                Console.WriteLine($"Draw after {turnCounter} turns");
            }
        }

        private static void AddCardsToWinner(List<string> list, Queue<string> PlayerAllCards)
        {
            foreach (string s in list.OrderByDescending(x => GetNumber(x)).ThenByDescending(x => GetChar(x)))
            {
                PlayerAllCards.Enqueue(s);
            }
        }

        private static int GetChar(string peek)
        {
            return peek[peek.Length - 1];
        }


        private static int GetNumber(string peek)
        {
            int num = Convert.ToInt32(peek.Substring(0, peek.Length - 1));
            return num;
        }
    }
}
