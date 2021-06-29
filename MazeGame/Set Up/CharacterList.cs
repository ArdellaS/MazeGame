using System.Collections.Generic;
using MazeGame.Enemies;
using MazeGame.Helpers;
using MazeGame.Heroes;

namespace MazeGame.Set_Up
{
    public class CharacterList
    {
        // list of heroes
        public static List<Character> characters = new List<Character>();

        string _name;
        int _strength, _dexterity, _intelligence, _attackMod;
        Arsenal weakenesMod = Arsenal.None;
        int basePlayerHP = 25;
        int baseMonHP = 15;
        int warriorArmor = 14;
        int rogueArmor = 12;
        int mageArmor = 10;
        int x;

        public void ChooseJob(int baseStats, string name) //precondition has to be one of these options, we must check the input before we pass the int into this method
        {
            StatRoll();
            if (baseStats == 1)
            {
                _strength += 2;
                _attackMod = _strength - 10;
                characters.Add(new Warrior(name, basePlayerHP + Dice.D8(), _strength, _dexterity, _intelligence, warriorArmor, Arsenal.GreatSword, weakenesMod, true, true, _attackMod));
                BattleDisplay.DisplayWarrior();
            }
            else if (baseStats == 2)
            {
                _dexterity += 2;
                _attackMod = _dexterity - 10;
                characters.Add(new Rogue(name, basePlayerHP + Dice.D6(), _strength, _dexterity, _intelligence, rogueArmor, Arsenal.Dagger, weakenesMod, true, true, _attackMod));
                BattleDisplay.DisplayRogue();
            }
            else if (baseStats == 3)
            {
                _intelligence += 2;
                _attackMod = _intelligence - 10;
                characters.Add(new Mage(name, basePlayerHP + Dice.D4(), _strength, _dexterity, _intelligence, mageArmor, Arsenal.Staff, weakenesMod, true, true, _attackMod));
                BattleDisplay.DisplayMage();
            }
        }
        public void RandomMonster() //precondition has to be one of these options, we must check the input before we pass the int into this method
        {
            int x = Dice.D3();
            StatRoll();

            if (x == 1)
            {
                _attackMod = _strength - 10;
                characters.Add(new Troll(_name, baseMonHP + Dice.D6(), _strength, _dexterity, _intelligence, warriorArmor, Arsenal.Rock, Arsenal.GreatSword, true, false, _attackMod));
            }
            else if (x == 2)
            {
                _attackMod = _dexterity - 10;
                characters.Add(new Goblin(_name, baseMonHP + Dice.D4(), _strength, _dexterity, _intelligence, rogueArmor, Arsenal.Club, Arsenal.Dagger, true, false, _attackMod));
            }
            else if (x == 3)
            {
                _attackMod = _intelligence - 10;
                characters.Add(new Dragon(_name, baseMonHP + Dice.D8(), _strength, _dexterity, _intelligence, mageArmor, Arsenal.Claw, Arsenal.Staff, true, false, _attackMod));
            }
        }
        public void StatRoll()
        {
            var strengthRoll = Dice.D20();
            _strength = strengthRoll <= 10 ? 10 : strengthRoll;
            
            var dexRoll = Dice.D20();
            _dexterity = dexRoll <= 10 ? 10 : dexRoll;
            
            var intRoll = Dice.D20();
            _intelligence = intRoll <= 10 ? 10 : intRoll;

        }
        
        public List<Character> ReturnList()
        {
            return characters;
        }

    }
}