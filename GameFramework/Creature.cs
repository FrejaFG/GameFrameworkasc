﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Actions;
using GameFramework.GameWorld;
using GameFramework.Interfaces;

namespace GameFramework
{
    public class Creature : IHittable, ICreature
    {
        /// <summary>
        /// Properties for creature
        /// </summary>
        public int CreatureName { get; set; }
        public int CreatureHitPoint { get; set; }
        public int Health { get; set; }
        private bool dead = false;
        public AttackItem attack { get; set; }
        public EventHandler OnGetHit { get; set; }
        public EventHandler OnDie { get; set; }


        public PositionItem Position { get; set; }
        public Creature()
        {

        }

        /// <summary>
        /// Hitting and killing creature
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="hitpoint"></param>
        public void GetHit(int damage, Creature hitpoint)
        {
            if(dead==false)
            {
                Health--;
                // Is anyone listening?
                if(Health<=0)
                {
                    dead= true;
                }

            }
        }
    }
}
