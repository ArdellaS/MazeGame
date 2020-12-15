using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGame
{
    class Dragon : Character

    {
       
        public Dragon(string characterName, double hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weapon, Arsenal weaknessMod, bool IsAlive, bool IsPlayer, int attackMod)
            : base(characterName, hitPoints, strength, dex, intelligence, armor, weaknessMod, IsAlive, IsPlayer, attackMod)
        {
            this.Job = "Dragon";
            this.Weapon = weapon;
            this.WeaknessMod = Arsenal.Staff;
        }
        //public override string ToString()
        //{
        //    return $"{"",15} | " + base.ToString();
        //}
    }
}
