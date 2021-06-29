﻿using MazeGame.Helpers;

namespace MazeGame.Heroes
{
    public class Mage : Character
    {
        public Mage(string characterName, double hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weapon, Arsenal weaknessMod, bool IsAlive, bool IsPlayer, int attackMod)
                : base(characterName, hitPoints, strength, dex, intelligence, armor, weaknessMod, IsAlive, IsPlayer, attackMod)
        {
            this.Job = "Mage";
            this.Weapon = weapon;
            this.IsPlayer = true;
        }
    }
}
