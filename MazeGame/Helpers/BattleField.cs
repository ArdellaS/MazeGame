using System;
using System.Collections.Generic;
using MazeGame.Set_Up;

namespace MazeGame.Helpers
{
    public static class BattleField
    {
        static int _hitRoll;
        static int _attackDice;
        static int _totalRoll;
        static double _dmgDealt;
        public static void PlayerCombat(List<Character> characters, int attackSelection)
        {

            if (Hit(characters[0].AttackMod, characters[^1].Armor, attackSelection, out _hitRoll))
            {
                bool isCrit = false;
                _dmgDealt = Damage(characters[0].Weapon, characters[^1].WeaknessMod, characters[0].AttackMod, out _attackDice);
                if (attackSelection == 2)
                {
                    _dmgDealt = Math.Round(_dmgDealt * 1.25, 2);
                }
                if (_hitRoll == 20)
                {
                    _dmgDealt *= 2;
                    isCrit = true;
                }

                characters[^1].HitPoints -= _dmgDealt;
                if (characters[^1].HitPoints < 0)
                {
                    characters[^1].HitPoints = 0;
                }
                Console.Clear();
                BattleDisplay.UI(characters);
                if (isCrit == true)
                {
                    Console.WriteLine("\nCritical Hit! You have done double damage!\n");
                }
                Console.WriteLine($"{characters[0].CharacterName} rolled a {_hitRoll} breaking through enemy defense.\n" +
                    $"Damage dice roll is {_attackDice} using a {characters[0].Weapon} and hit {characters[^1].Job} dealing {_dmgDealt} damage!\n");

                characters[^1].IsAlive = Death(characters[^1].HitPoints);

            }
            else
            {
                Console.WriteLine($"{characters[0].CharacterName} rolled a {_hitRoll} and missed with their {characters[0].Weapon}\n");
            }
        }
        public static void EnemyCombat(List<Character> characters)
        {
            if (Hit(characters[^1].AttackMod, characters[0].Armor, 1, out _hitRoll))
            {
                bool isCrit = false;
                var dmgDealt = Damage(characters[^1].Weapon, characters[0].WeaknessMod, characters[^1].AttackMod, out _attackDice);
                if (_hitRoll == 20)
                {
                    dmgDealt *= 2;
                    isCrit = true;
                }

                characters[0].HitPoints -= dmgDealt;
                if (characters[0].HitPoints < 0)
                {
                    characters[0].HitPoints = 0;
                }

                Console.Clear();
                BattleDisplay.UI(characters);
                if (isCrit == true)
                {
                    Console.WriteLine("\nCritical Hit! Monster does double damage!\n");
                }
                Console.WriteLine($"{characters[^1].Job} rolled a {_hitRoll} breaking through your defenses.\n" +
                    $"Damage dice roll is {_attackDice} using a {characters[^1].Weapon} and hit {characters[0].CharacterName} dealing {dmgDealt} damage!\n");

                characters[0].IsAlive = Death(characters[0].HitPoints);

            }
            else
            {
                Console.WriteLine($"{characters[^1].Job} rolled a {_hitRoll} and missed with their {characters[^1].Weapon}\n");
            }
        }
        public static bool Hit(int attackMod, int Armor, int attackSelection, out int hitRoll)
        {

            if (attackSelection == 1)
            {
                hitRoll = Dice.D20();
                _totalRoll = hitRoll + attackMod;
                if (_totalRoll >= Armor)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                hitRoll = Dice.D20();
                _totalRoll = hitRoll + attackMod;
                if (_totalRoll - 2 >= Armor)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }
        public static double Damage(Arsenal weapon, Arsenal weaknessMod, int attackMod, out int attackDice)
        {
            double damage;
            if (weapon == Arsenal.GreatSword || weapon == Arsenal.Rock)
            {
                attackDice = Dice.D4();
                damage = attackDice + attackMod;
            }
            else if (weapon == Arsenal.Dagger || weapon == Arsenal.Club)
            {
                attackDice = Dice.D6();
                damage = attackDice + attackMod;
            }
            else if (weapon == Arsenal.Staff || weapon == Arsenal.Claw)
            {
                attackDice = Dice.D8();
                damage = attackDice + attackMod;
            }
            else
            {
                Console.WriteLine("This weapon does not exist");
                damage = 0;
                attackDice = 0;
            }
            if (weaknessMod == weapon)
            {
                damage = Math.Round(damage * 1.25);
            }
            return damage;
        }

        public static bool Death(double hitPoints)
        {
            if (hitPoints <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void AddHealth(List<Character> characters)
        {
            int x = Dice.D6();
            if (characters[0].HitPoints + x >= 50)
            {
                Console.WriteLine("You found a potion and regained health to 50");
                characters[0].HitPoints = 50;
            }
            else
            {
                Console.WriteLine($"You found a potion on the slain monster. Health +{x}");
                characters[0].HitPoints += x;
            }
            Console.WriteLine("Press enter to take the potion");
            Console.ReadLine();
        }
    }
}
