using System;
using System.Threading;
using MazeGame.Helpers;

namespace MazeGame.Set_Up
{
    public class Board
    {
        public static Random rand = new Random();
        public static int gridWidth = 20;
        public static int gridHeight = 10;
        public static char[,] gridWorld = new char[gridHeight, gridWidth];
        public static int xPosition = XPosition();
        public static int yPosition = YPosition();
        public static int mon1X = XPosition();
        public static int mon1Y = YPosition();
        public static CharacterList characterList = new CharacterList();

        public static int XPosition()
        {
            return rand.Next(0, 20);
        }

        public static int YPosition()
        {
            return rand.Next(0, 10);
        }

        public static void BoardMovement()
        {
            var doorHeight = YPosition();
            var doorWidth = XPosition();
            var ringCount = 0;

            while (true)
            {
                //generates * floor grid
                for (int i = 0; i < gridHeight; i++)
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        gridWorld[i, j] = '*';
                    }
                }

                //door character
                gridWorld[doorHeight, doorWidth] = 'O';

                //player character
                gridWorld[yPosition, xPosition] = 'I';

                //monster character
                gridWorld[mon1Y, mon1X] = 'X';

                //checks if fight should begin
                if (yPosition == mon1Y && xPosition == mon1X)
                {
                    Fight(ringCount);
                }

                //checks if character gets ring
                if (xPosition == doorWidth && yPosition == doorHeight)
                {
                    doorHeight = YPosition();
                    doorWidth = XPosition();
                    ringCount++;
                }

                Console.Clear();
                Console.WriteLine("Collect the rings!\n");

                //manages movement board
                for (int i = 0; i < gridHeight; i++)
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        Console.Write(gridWorld[i, j]);
                    }

                    Console.WriteLine();
                }

                var key = PressAnyKeyToContinue();

                //character movement
                if (key == ConsoleKey.UpArrow && yPosition > 0)
                {
                    yPosition--;
                }
                else if (key == ConsoleKey.DownArrow && yPosition < gridHeight - 1)
                {
                    yPosition++;
                }
                else if (key == ConsoleKey.LeftArrow && xPosition > 0)
                {
                    xPosition--;
                }
                else if (key == ConsoleKey.RightArrow && xPosition < gridWidth - 1)
                {
                    xPosition++;
                }

                //monster 1 movement
                var step1 = rand.Next(1, 5);

                if (step1 == 1 && mon1Y >= 2)
                {
                    mon1Y--;
                }
                else if (step1 == 2 && mon1Y <= 8)
                {
                    mon1Y++;
                }
                else if (step1 == 3 && mon1X > 2)
                {
                    mon1X--;
                }
                else if (step1 == 4 && mon1X < 8)
                {
                    mon1X++;
                }
            }
        }

        public static void Fight(int ringCount)
        {
            characterList.RandomMonster();
            Console.WriteLine($"A {characterList.ReturnList()[1].Job} approaches for a fight!\n\nPress enter to start the fight!");
            Console.ReadLine();
            Console.Clear();
            BattleDisplay.UI(characterList.ReturnList());

            while (characterList.ReturnList()[0].IsAlive)
            {
                Console.Clear();

                BattleDisplay.UI(characterList.ReturnList());
                Console.WriteLine("Please Select your attack 1-2 \n1: Light Attack \n2: Heavy Attack");
                var attackSelection = ValidateInput(0, 2);
                BattleField.PlayerCombat(characterList.ReturnList(), attackSelection);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                BattleDisplay.UI(characterList.ReturnList());

                if (characterList.ReturnList()[^1].IsAlive)
                {
                    BattleField.EnemyCombat(characterList.ReturnList());
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            if (!characterList.ReturnList()[0].IsAlive)
            {
                Console.Clear();
                Console.WriteLine($"YOU DIED! GAME OVER!\nYou have defeated {characterList.ReturnList().Count - 2} monsters and collected {ringCount} rings!!\n\n");
                BattleDisplay.DisplayDead(characterList.ReturnList());
                Console.WriteLine("Press anykey to restart...");
                Console.Read();
            }
        }
        public void GamePlay()
        {
            do
            {
                Console.Clear();
                characterList.ReturnList().Clear();
                string name = EnterName();
                int charSelection = SelectCharacter();

                characterList.ChooseJob(charSelection, name);
                Console.WriteLine($"Hello, {characterList.ReturnList()[0].CharacterName}. You have selected a {characterList.ReturnList()[0].Job}. \n");
                Thread.Sleep(2000);

                BoardMovement();

            } while (Continue());

        }

        public static ConsoleKey PressAnyKeyToContinue()
        {

            Console.WriteLine("\nPress any Key to Continue...");

            return Console.ReadKey(true).Key;

        }
        private static bool Continue()
        {
            char c;
            do
            {
                Console.WriteLine("Would you like to create a new adventurer and slay more monsters? Y/N");
                c = Console.ReadKey().KeyChar;
                if (c == 'n' || c == 'N')
                {
                    return false;
                }
            } while (c != 'y' && c != 'Y');

            return true;
        }

        public static int ValidateInput(int x, int y)
        {
            int input;
            bool worked;
            do
            {
                worked = int.TryParse(Console.ReadLine(), out input);
                if (!worked || input > y || input <= x)
                {
                    Console.WriteLine("Sorry, this is not a valid input. Please try again.");
                    worked = false;
                }
            } while (!worked);
            return input;
        }
        static int SelectCharacter()
        {
            bool worked;
            int characterChoice;
            Console.Write("Please select your character: Enter 1-3\n1: Warrior\n2: Rogue\n3: Mage\n >> ");

            do
            {
                worked = int.TryParse(Console.ReadLine(), out characterChoice);
                if (!worked || characterChoice > 3 || characterChoice <= 0)
                {
                    Console.WriteLine("Sorry, this is not a valid input. Please try again.");
                    worked = false;
                }
            } while (!worked);
            return characterChoice;
        }
        static string EnterName()
        {
            Console.Write("Please enter your name:\n >> ");
            return Console.ReadLine();
        }
    }
}


