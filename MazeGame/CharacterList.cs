using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGame
{
    public class CharacterList
    {
        public static List<Character> characters = new List<Character>(); // list of heros

        string name, job;
        int strength, dexterity, intelligence, attackMod;
        Arsenal weakenesMod = Arsenal.None;
        int basePlayerHP = 25;
        int baseMonHP = 15;
        int warriorArmor = 14;
        int rogueArmor = 12;
        int mageArmor = 10;
        int x;

        public void ChooseJob(int x, string name) //precondition has to be one of these options, we must check the input before we pass the int into this method
        {
            StatRoll();
            if (x == 1)
            {
                strength = strength + 2;
                attackMod = strength - 10;
                characters.Add(new Warrior(name, basePlayerHP + Dice.D8(), strength, dexterity, intelligence, warriorArmor, Arsenal.GreatSword, weakenesMod, true, true, attackMod));
                BattleDisplay.DisplayWarrior();
            }
            else if (x == 2)
            {
                dexterity = dexterity + 2;
                attackMod = dexterity - 10;
                characters.Add(new Rogue(name, basePlayerHP + Dice.D6(), strength, dexterity, intelligence, rogueArmor, Arsenal.Dagger, weakenesMod, true, true, attackMod));
                BattleDisplay.DisplayRogue();
            }
            else if (x == 3)
            {
                intelligence = intelligence + 2;
                attackMod = intelligence - 10;
                characters.Add(new Mage(name, basePlayerHP + Dice.D4(), strength, dexterity, intelligence, mageArmor, Arsenal.Staff, weakenesMod, true, true, attackMod));
                BattleDisplay.DisplayMage();
            }
        }
        public void RandomMonster() //precondition has to be one of these options, we must check the input before we pass the int into this method
        {
            int x = Dice.D3();
            StatRoll();

            if (x == 1)
            {
                attackMod = strength - 10;
                characters.Add(new Troll(name, baseMonHP + Dice.D6(), strength, dexterity, intelligence, warriorArmor, Arsenal.Rock, Arsenal.GreatSword, true, false, attackMod));
            }
            else if (x == 2)
            {
                attackMod = dexterity - 10;
                characters.Add(new Goblin(name, baseMonHP + Dice.D4(), strength, dexterity, intelligence, rogueArmor, Arsenal.Club, Arsenal.Dagger, true, false, attackMod));
            }
            else if (x == 3)
            {
                attackMod = intelligence - 10;
                characters.Add(new Dragon(name, baseMonHP + Dice.D8(), strength, dexterity, intelligence, mageArmor, Arsenal.Claw, Arsenal.Staff, true, false, attackMod));
            }
        }
        public void StatRoll()
        {
            x = Dice.D20();
            if (x <= 10)
            {
                strength = 10;
            }
            else
            {
                strength = x;
            }
            x = Dice.D20();
            if (x <= 10)
            {
                dexterity = 10;
            }
            else
            {
                dexterity = x;
            }
            x = Dice.D20();
            if (x <= 10)
            {
                intelligence = 10;
            }
            else
            {
                intelligence = x;
            }

        }
        //public void DisplayCharacterList()
        //{
        //    foreach (Character c in characters)
        //    {
        //        Console.WriteLine(c);
        //    }
        //}
        public List<Character> ReturnList()
        {
            return characters;
        }

    }
}