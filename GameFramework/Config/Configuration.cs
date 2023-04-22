using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Config
{
    public class Configuration
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Configuration() 
        {
            XCoordinate = 0;
            YCoordinate = 0;
        }
    }
}
