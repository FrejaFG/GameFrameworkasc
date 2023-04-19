using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.GameWorld
{
    [Serializable]
    public class World
    {

        /// <summary>
        /// World size - default value 100^2
        /// </summary>


        public int Width { get; set; }
        public int Height { get; set; }

        public List<WorldObject> Objects { get; set; }

        public List<Creature> Creatures { get; set; }



    }
}
