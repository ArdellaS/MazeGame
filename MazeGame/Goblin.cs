using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGame
{
    class Goblin : Character

    {
        
        public Goblin(string characterName, double hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weapon, Arsenal weaknessMod, bool IsAlive, bool IsPlayer, int attackMod)
            : base(characterName, hitPoints, strength, dex, intelligence, armor, weaknessMod, IsAlive, IsPlayer, attackMod)
        {
            this.Job = "Goblin";
            this.Weapon = weapon;
            this.WeaknessMod = Arsenal.Dagger;
        }
     
    }
}
