using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.State
{
    public class ChangeState
    {
        public List<Decision> Decision { get; set; }
        public ChangeState IdleState { get; set; }
        public ChangeState AttackState { get; set; }
        public ChangeState DefenseState { get; set; }

        public ChangeState()
        {
            Decision.Clear();
            Decision = new List<Decision>();
        }
    }
}
