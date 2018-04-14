using System;
using System.Collections.Generic;
using System.Text;
using KingsGambit.Interfaces;

namespace KingsGambit
{
    public class Footman : IKillable
    {
        private int count;
        public Footman(string name)
        {
            this.Name = name;
            this.IsAlive = true;
            this.count = 0;
        }


        public string Name { get;  set; }

        public string TheKingIsUnderAttack()
        {
            return $"Footman {this.Name} is panicking!";
        }

     
        public bool IsAlive { get;  set; }

        public void Kill(string name)
        {
            count++;

            if (count >= 2)
            {
                this.IsAlive = false;
            }
        }
    }
}
