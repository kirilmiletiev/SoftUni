using System;
using System.Linq;

namespace KingsGambit
{
    class Program
    {
        static void Main(string[] args)
        {
            var kingName = Console.ReadLine();
            King king = new King(kingName);

            var guards = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var guard in guards)
            {
                RoyalGuard royalGuard = new RoyalGuard(guard);
                king.AddToList(royalGuard);
            }

            var footmans = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var footman in footmans)
            {
                Footman man = new Footman(footman);
                king.AddToList(man);
            }
            // SetUpKingsAnturaje();



            var input = Console.ReadLine();

            while (input != "End")
            {
                var command = input.Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);


                switch (command[0])
                {
                    case "Attack":
                        if (command[1] == "King")
                        {
                            king.KingIsUnderAttack();
                        }
                        break;
                    case "Kill":
                        foreach (var deadSoldier in king.List.Where
                            (s=>s.Name.Equals(command[1])))
                        {
                            deadSoldier.Kill(command[1]);
                            //king.List.Remove(deadSoldier);
                        }
                        break;

                }
                input = Console.ReadLine();

            }


        }

        private static void SetUpKingsAnturaje()
        {
            var kingName = Console.ReadLine();
            King king = new King(kingName);

            var guards = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var guard in guards)
            {
                RoyalGuard royalGuard = new RoyalGuard(guard);
                king.AddToList(royalGuard);
            }

            var footmans = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var footman in footmans)
            {
                Footman man = new Footman(footman);
                king.AddToList(man);
            }
        }
    }
}
