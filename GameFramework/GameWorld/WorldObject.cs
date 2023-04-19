using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.GameWorld
{
    public class WorldObject
    {
        public bool Lootable { get; set; }
        public string Name { get; set; }
        public bool Removable { get; set; }

        public PositionItem position { get; set; }

        public WorldObject()
        {

        }


    }
}
