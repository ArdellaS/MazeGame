using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGame
{
    class Warrior : Character

    {

        public Warrior(string characterName, double hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weapon, Arsenal weaknessMod, bool IsAlive, bool IsPlayer, int attackMod)
            :base(characterName, hitPoints, strength, dex, intelligence, armor, weaknessMod, IsAlive, IsPlayer, attackMod)
        {
            this.Job = "Warrior";
            this.Weapon = weapon;
            this.IsPlayer = true;
        }
       
    }
}
