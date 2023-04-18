using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public interface IHittable
    {
        EventHandler OnGetHit { get; set; }

        void GetHit(int damage, Creature hitpoint);
    }
}
