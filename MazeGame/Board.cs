using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace MazeGame
{
    public class Board
    {
        public static Random rand = new Random();
        public static int gridWidth = 20;
        public static int gridHeight = 10;
        public static char[,] gridWorld = new char[gridHeight, gridWidth];
        public static int X = XPosition();
        public static int Y = YPosition();
        public static int mon1X = XPosition();
        public static int mon1Y = YPosition();
        public static int mon2X = XPosition();
        public static int mon2Y = YPosition();
        public static CharacterList characterList = new CharacterList();



        public static int XPosition()
        {
            int xAxis = rand.Next(0, 20);
            return xAxis;
        }
        public static int YPosition()
        {
            int yAxis = rand.Next(0, 10);
            return yAxis;
        }

        public static void BoardMovement()
        {
            var doorHeight = YPosition();
            var doorWidth = XPosition();


            while (true)
            {
                if (true)
                {

                }
                //if (X == doorWidth && Y == doorHeight)
                //{
                //    doorHeight = YPosition();
                //    doorWidth = XPosition();
                //}
                for (int i = 0; i < gridHeight; i++)
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        gridWorld[i, j] = '*';
                    }
                }
                gridWorld[doorHeight, doorWidth] = 'O';
                //gridWorld[door, door] = '}';
                var player = gridWorld[Y, X] = 'I';
                var enemy1 = gridWorld[mon1Y, mon1X] = 'X';
                //var enemy2 = gridWorld[mon2Y, mon2X] = 'X';
                if ((Y == mon1Y && X == mon1X) || (X == doorWidth && Y == doorHeight))
                {
                    if (X == doorWidth && Y == doorHeight)
                    {
                        doorHeight = YPosition();
                        doorWidth = XPosition();
                    }
                    characterList.RandomMonster();
                    Console.WriteLine($"A {characterList.ReturnList()[1].Job} approaches for a fight!\n\nPress enter to start the fight!");
                    Console.ReadLine();
                    Console.Clear();
                    BattleDisplay.UI(characterList.ReturnList());

                    while (characterList.ReturnList()[0].IsAlive)
                    {
                        int attackSelection;
                        Console.Clear();

                        BattleDisplay.UI(characterList.ReturnList());
                        Console.WriteLine("Please Select your attack 1-2 \n1: Light Attack \n2: Heavy Attack");
                        attackSelection = ValidateInput(0, 2);
                        BattleField.PlayerCombat(characterList.ReturnList(), attackSelection);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        BattleDisplay.UI(characterList.ReturnList());

                        if (characterList.ReturnList()[characterList.ReturnList().Count - 1].IsAlive)
                        {
                            BattleField.EnemyCombat(characterList.ReturnList());
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                        }
                        else
                        {
                            break;
                            //characterList.RandomMonster();
                            //Console.WriteLine($"A new {characterList.ReturnList()[characterList.ReturnList().Count - 1].Job} has joined the fray!\n");
                            //BattleField.AddHealth(characterList.ReturnList());
                        }
                    }
                    Console.WriteLine($"YOU DIED! GAME OVER!\nYou have defeated {characterList.ReturnList().Count - 2} monters!\n\n");
                    BattleDisplay.DisplayDead(characterList.ReturnList());

                }
                Console.Clear();
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
                if (key == ConsoleKey.UpArrow && Y > 0)
                {
                    Y--;
                }
                else if (key == ConsoleKey.DownArrow && Y < gridHeight - 1)
                {
                    Y++;
                }
                else if (key == ConsoleKey.LeftArrow && X > 0)
                {
                    X--;
                }
                else if (key == ConsoleKey.RightArrow && X < gridWidth - 1)
                {
                    X++;
                }
                var step1 = rand.Next(1, 5);
                var step2 = rand.Next(1, 5);

                //monster 1 movement
                if (step1 == 1 && mon1Y > 0)
                {
                    mon1Y--;
                }
                else if (step1 == 2 && mon1Y < 10)
                {
                    mon1Y++;

                }
                else if (step1 == 3 && mon1X > 0)
                {
                    mon1X--;

                }
                else if (step1 == 4 && mon1X < 10)
                {
                    mon1X++;

                }

                //monster 2 movement
                //if (step2 == 1 && mon2Y > 0)
                //{
                //    mon2Y--;
                //    InBounds(mon2Y, mon2X);
                //}
                //else if (step2 == 2 && mon2Y < 10)
                //{
                //    mon2Y++;
                //    InBounds(mon2Y, mon2X);
                //}
                //else if (step2 == 3 && mon2X > 0)
                //{
                //    mon2X--;
                //    InBounds(mon2Y, mon2X);
                //}
                //else if (step2 == 4 && mon2X < 20)
                //{
                //    mon2X++;
                //    InBounds(mon2Y, mon2X);
                //}

            }
        }


        public static void InBounds(int Y, int X)
        {
            //TODO: Make it work
            //keeps monster inbounds
            if (Y < 0)
            {
                Y = 0;
            }
            else if (Y > 10)
            {
                Y = 10;
            }
            if (X < 0)
            {
                X = 0;
            }
            else if (X > 20)
            {
                X = 20;
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

                //characterList.RandomMonster();
                //Console.WriteLine($"A {characterList.ReturnList()[1].Job} approaches for a fight!\n\nPress enter to start the fight!");
                //Console.ReadLine();
                //Console.Clear();
                //BattleDisplay.UI(characterList.ReturnList());


                //while (characterList.ReturnList()[0].IsAlive)
                //{
                //    int attackSelection;
                //    Console.Clear();

                //    BattleDisplay.UI(characterList.ReturnList());
                //    Console.WriteLine("Please Select your attack 1-2 \n1: Light Attack \n2: Heavy Attack");
                //    attackSelection = ValidateInput(0, 2);
                //    BattleField.PlayerCombat(characterList.ReturnList(), attackSelection);
                //    Console.WriteLine("Press enter to continue");
                //    Console.ReadLine();
                //    Console.Clear();
                //    BattleDisplay.UI(characterList.ReturnList());
                //    if (characterList.ReturnList()[characterList.ReturnList().Count - 1].IsAlive)
                //    {
                //        BattleField.EnemyCombat(characterList.ReturnList());
                //        Console.WriteLine("Press enter to continue");
                //        Console.ReadLine();
                //    }
                //    else
                //    {
                //        characterList.RandomMonster();
                //        Console.WriteLine($"A new {characterList.ReturnList()[characterList.ReturnList().Count - 1].Job} has joined the fray!\n");
                //        BattleField.AddHealth(characterList.ReturnList());
                //    }
                //}
                //Console.WriteLine($"YOU DIED! GAME OVER!\nYou have defeated {characterList.ReturnList().Count - 2} monters!\n\n");
                //BattleDisplay.DisplayDead(characterList.ReturnList());

            } while (Continue());

        }

        public static void MonsterFight()
        {

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


