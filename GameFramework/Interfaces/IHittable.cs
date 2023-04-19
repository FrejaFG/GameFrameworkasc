using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Interfaces
{
    public interface IHittable
    {
        public EventHandler OnGetHit { get; set; }

        public void GetHit(int damage, Creature hitpoint);
    }
}
