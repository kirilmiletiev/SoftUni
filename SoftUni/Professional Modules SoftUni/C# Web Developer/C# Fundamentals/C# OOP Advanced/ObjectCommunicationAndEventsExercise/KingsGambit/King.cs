using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingsGambit.Interfaces;

namespace KingsGambit
{
    public class King : IAttacable 
    {
        public King(string name)
        {
            this.Name = name;
            this.List = new List<IKillable>();
        }

        public string Name { get; set; }

        public List<IKillable> List { get; set; }

        public void AddToList(IKillable soldier)
        {
            List.Add(soldier);
        }

        public void KingIsUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            foreach (var soldier in List.Where(s=>s.IsAlive))
            {
                Console.WriteLine(soldier.TheKingIsUnderAttack());
            }
        }
    }
}
