using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Config
{
    public class StateConfiguration
    {
        public string StateType { get; set; }

        public StateConfiguration() 
        {
            StateType = "Default state";
        }

    }
}
