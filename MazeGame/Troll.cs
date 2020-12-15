using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGame
{
    class Troll : Character

    {
        
        public Troll(string characterName, double hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weapon, Arsenal weaknessMod, bool IsAlive, bool IsPlayer, int attackMod)
            : base(characterName, hitPoints, strength, dex, intelligence, armor, weaknessMod, IsAlive, IsPlayer, attackMod)
        {
            this.Job = "Troll";
            this.Weapon = weapon;
            this.WeaknessMod = Arsenal.GreatSword;
        }
        //public override string ToString()
        //{
        //    return $"{"",15} | " + base.ToString();
        //}
    }
}
