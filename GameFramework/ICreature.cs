using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public interface ICreature
    {
        int Health { get; set; }

        EventHandler OnDie { get; set; }
        EventHandler OnGetHit { get; set; }

    }
}
