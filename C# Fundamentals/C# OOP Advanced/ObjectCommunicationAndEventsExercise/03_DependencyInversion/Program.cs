using System;
using System.Collections.Generic;
using P03_DependencyInversion;

namespace P_03_DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calc = new PrimitiveCalculator();
            Stack<IStrategy> stack = new Stack<IStrategy>();
            stack.Push(new AdditionStrategy());


            var input = Console.ReadLine();

            while (input != "End")
            {
                var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "mode")
                {
                    switch (command[1])
                    {
                        case "+":
                            stack.Push(new AdditionStrategy());
                            break;
                        case "-":
                            stack.Push(new SubtractionStrategy());
                            break;
                        case "/":
                            stack.Push(new DivisionStrategy());
                            break;
                        case "*":
                            stack.Push(new MultiplicationStrategy());
                            break;
                    }
                }
                else
                {
                    if (stack.Peek() is AdditionStrategy)
                    {
                        KeepCalculating(command, stack);
                    }
                    else if (stack.Peek() is SubtractionStrategy)
                    {
                        KeepCalculating(command, stack);
                    }
                    else if (stack.Peek() is DivisionStrategy)
                    {
                        KeepCalculating(command, stack);
                    }
                    else if (stack.Peek() is MultiplicationStrategy)
                    {
                        KeepCalculating(command, stack);
                    }

                }
                input = Console.ReadLine();
            }
        }
        private static void KeepCalculating(string[] command, Stack<IStrategy> stack)
        {
            var result = stack.Peek()
                .Calculate(int.Parse(command[0]), int.Parse(command[1]));
            Console.WriteLine(result);
        }
    }
}
