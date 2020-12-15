using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGame
{
    public abstract class Character
    {
        public string CharacterName { get; set; }
        public string Job { get; set; }
        public double HitPoints { get; set; }
        public int Strength { get; set; }
        public int Dex { get; set; }
        public int Intelligence { get; set; }
        public int Armor { get; set; }
        public Arsenal WeaknessMod { get; set; }
        public bool Status { get; set; }
        public bool IsPlayer { get; set; }
        public int AttackMod { get; set; }
        public Arsenal Weapon { get; set; }
        public bool IsAlive { get; set; }

        public Character(string characterName, double hitPoints, int strength, int dex, int intelligence, int armor, Arsenal weaknessMod, bool isAlive, bool isPlayer, int attackMod)
        {
            CharacterName = characterName;
            HitPoints = hitPoints;
            Strength = strength;
            Dex = dex;
            Intelligence = intelligence;
            Armor = armor;
            WeaknessMod = weaknessMod;
            IsAlive = isAlive;
            IsPlayer = isPlayer;
            AttackMod = attackMod;
        }

        public override string ToString()
        {
            return $"Name: {CharacterName,10} |  Job: {Job,10} | HP: {HitPoints, 5} | Str: {Strength, 5} | Dex: {Dex, 5} | Int: {Intelligence, 5} | Armor: {Armor, 5} | Weakness: {WeaknessMod,5} | Weapon: {Weapon,10}\n";
        }
    }
}
