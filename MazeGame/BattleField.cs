using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGame
{
    public static class BattleField
    {
        static int hitRoll = 0;
        static int attackDice = 0;
        static int totalRoll = 0;
        static double dmgDealt = 0;
        public static void PlayerCombat(List<Character> characters, int attackSelection)
        {

            if (Hit(characters[0].AttackMod, characters[characters.Count - 1].Armor, attackSelection, out hitRoll) == true)
            {
                bool isCrit = false;
                dmgDealt = Damage(characters[0].Weapon, characters[characters.Count - 1].WeaknessMod, characters[0].AttackMod, out attackDice);
                if (attackSelection == 2)
                {
                    dmgDealt = Math.Round(dmgDealt * 1.25,2);
                }
                if (hitRoll == 20)
                {
                    dmgDealt *= 2;
                    isCrit = true;
                }

                characters[characters.Count - 1].HitPoints -= dmgDealt;
                if (characters[characters.Count - 1].HitPoints < 0)
                {
                    characters[characters.Count - 1].HitPoints = 0;
                }
                Console.Clear();
                BattleDisplay.UI(characters);
                if (isCrit == true)
                {
                    Console.WriteLine("\nCritical Hit! You have done double damage!\n");
                }
                Console.WriteLine($"{characters[0].CharacterName} rolled a {hitRoll} breaking through enemy defense.\n" +
                    $"Damage dice roll is {attackDice} using a {characters[0].Weapon} and hit {characters[characters.Count - 1].Job} dealing {dmgDealt} damage!\n");
                
                characters[characters.Count - 1].IsAlive = Death(characters[characters.Count - 1].HitPoints);

            }
            else
            {
                Console.WriteLine($"{characters[0].CharacterName} rolled a {hitRoll} and missed with their {characters[0].Weapon}\n");
            }
        }
        public static void EnemyCombat(List<Character> characters)
        {
            double dmgDealt;

            if (Hit(characters[characters.Count - 1].AttackMod, characters[0].Armor, 1, out hitRoll) == true)
            {
                bool isCrit = false;
                dmgDealt = Damage(characters[characters.Count - 1].Weapon, characters[0].WeaknessMod, characters[characters.Count - 1].AttackMod, out attackDice);
                if (hitRoll == 20)
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
                Console.WriteLine($"{characters[characters.Count - 1].Job} rolled a {hitRoll} breaking through your defenses.\n" +
                    $"Damage dice roll is {attackDice} using a {characters[characters.Count - 1].Weapon} and hit {characters[0].CharacterName} dealing {dmgDealt} damage!\n");

                characters[0].IsAlive = Death(characters[0].HitPoints);

            }
            else
            {
                Console.WriteLine($"{characters[characters.Count - 1].Job} rolled a {hitRoll} and missed with their {characters[characters.Count - 1].Weapon}\n");
}
        }
        public static bool Hit(int attackMod, int Armor, int attackSelection, out int hitRoll)
        {
            
            if (attackSelection == 1)
            {
                hitRoll = Dice.D20();
                totalRoll = hitRoll + attackMod;
                if (totalRoll >= Armor)
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
                totalRoll = hitRoll + attackMod;
                if (totalRoll - 2 >= Armor)
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
