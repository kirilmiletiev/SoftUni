using System;
using System.Collections.Generic;
using System.Text;
using KingsGambit.Interfaces;

namespace KingsGambit
{
    public class RoyalGuard : IKillable
    {
        private int count ;

        public RoyalGuard(string name)
        {
            this.Name = name;
            this.IsAlive = true;
            this.count = 0;
        }

        public string Name { get; set; }

        public string TheKingIsUnderAttack()
        {
            return $"Royal Guard {this.Name} is defending!";
        }

        public bool IsAlive { get; set; }

        public void Kill(string name)
        {
            count++;

            if (count>=3)
            {
                this.IsAlive = false;
            }
           
        }
    }
}
