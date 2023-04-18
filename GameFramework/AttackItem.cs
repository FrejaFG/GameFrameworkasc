using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class AttackItem : IHittable
    {
        private int hitpoint;
        private string name;
        private Range range;

        EventHandler IHittable.OnGetHit 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        public void GetHit(int damage, Creature hitpoint)
        {
            throw new NotImplementedException();
        }

        public EventHandler OnGetHit()
        {
            return OnGetHit;
        }
    }
}
