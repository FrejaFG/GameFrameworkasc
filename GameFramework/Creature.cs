using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class Creature
    {
        private string _creatureName;
        private int _creatureHitpoint;

        public PositionItem Position { get; set; }
        public Creature()
        {

        }
    }
}
