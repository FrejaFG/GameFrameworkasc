using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Interfaces
{
    public interface ICreature
    {
        public int Health { get; set; }

        public EventHandler OnDie { get; set; }
        public EventHandler OnGetHit { get; set; }

    }
}
