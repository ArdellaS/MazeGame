using System;
using System.Collections.Generic;
using MazeGame.Helpers;

namespace MazeGame.Set_Up
{
    public static class BattleDisplay
    {
        public static void UI(List<Character> characters)
        {
            LineBreak();
            HealthBar(characters);
            FightCount(characters);
            LineBreak();
            DisplayMonster(characters);
            LineBreak();
            StatBar(characters);
            LineBreak();
        }

        private static void DisplayMonster(List<Character> characters)
        {
            if (characters[^1].Job == "Troll")
            {
                Console.WriteLine(TrollArt());
            }
            else if (characters[^1].Job == "Goblin")
            {
                Console.WriteLine(GoblinArt());
            }
            else
            {
                Console.WriteLine(DragonArt());
            }
        }

        public static void DisplayWarrior()
        {
            Console.Clear();
            LineBreak();
            Console.WriteLine(WarriorArt());
            LineBreak();
        }
        public static void DisplayRogue()
        {
            Console.Clear();
            LineBreak();
            Console.WriteLine(RogueArt());
            LineBreak();
        }
        public static void DisplayMage()
        {
            Console.Clear();
            LineBreak();
            Console.WriteLine(MageArt());
            LineBreak();
        }
        public static void DisplayDead(List<Character> characters)
        {
            if (characters.Count > 2)
            {
                Console.WriteLine($"These are all the monsters slain by {characters[0].CharacterName} the {characters[0].Job}.");

                foreach (Character c in characters)
                {
                    if (c.IsAlive == false && c.IsPlayer == false)
                    {
                        Console.WriteLine($"Job: {c.Job,10} | Str: {c.Strength,5} | Dex: {c.Dex,5} | Int: {c.Intelligence,5} | Armor: {c.Armor,5}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No monsters slain, better luck next time!");
            }
        }
        public static void HealthBar(List<Character> characters)
        {
            Console.Write($"{characters[0].CharacterName,-30}{"",50}{characters[^1].Job,30}\n");
            Console.Write($"HP: {characters[0].HitPoints,-26}{"",50}{"HP: " + characters[^1].HitPoints,30}\n");
            Console.Write($"{PlayerBar(characters),-55}{EnemyBar(characters),55}\n");
        }
        public static void FightCount(List<Character> characters)
        {
            Console.WriteLine($"{"Fight: ",55}{characters.Count - 1}");
        
        }
        public static void StatBar(List<Character> characters)
        {
            Console.Write($"{"Job: " + characters[0].Job,-30}{"",50}{"Job: " + characters[^1].Job,30}\n");
            Console.Write($"{"Str: " + characters[0].Strength,-30}{"",50}{"Str: " + characters[^1].Strength,30}\n");
            Console.Write($"{"Dex: " + characters[0].Dex,-30}{"",50}{"Dex: " + characters[^1].Dex,30}\n");
            Console.Write($"{"Int: " + characters[0].Intelligence,-30}{"",50}{"Int: " + characters[^1].Intelligence,30}\n");
            Console.Write($"{"Armor: " + characters[0].Armor,-30}{"",50}{"Armor: " + characters[^1].Armor,30}\n");
            Console.Write($"{"Weak To: " + characters[0].WeaknessMod,-30}{"",50}{"Weak To: " + characters[^1].WeaknessMod,30}\n\n");

        }
        public static void LineBreak()
        {
            for (int i = 0; i < 110; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        public static string PlayerBar(List<Character> characters)
        {
            string bar = "";
            for (int j = 0; j < characters[0].HitPoints; j++)
            {
                bar += "=";
            }

            return bar;
        }
        public static string EnemyBar(List<Character> characters)
        {
            string bar = "";
            for (int j = 0; j < characters[^1].HitPoints; j++)
            {
                bar += "=";
            }

            return bar;
        }
        public static string DragonArt()
        {
            string x = "";
            for (int i = 0; i < 30; i++)
            {
                x += " ";
            }
            return
x + "            .==.        .==.\n" +
x + "           //`^\\      //^`\\\n" +
x + "          // ^ ^\\(\\__/)/^ ^^\\\\\n" +
x + "         //^ ^^ ^/6  6\\ ^^ ^ \\\\\n" +
x + "        //^ ^^ ^/( .. )\\^ ^ ^ \\\\\n" +
x + "       // ^^ ^/\\| v\"\"v |/\\^ ^ ^\\\\\n" +
x + "      // ^^/\\/ /  `~~`  \\ \\/\\^ ^\\\n" +
x + "      \\\\^ /_ /  / IIII\\  \\_  \\^ //\n" +
x + "       \\\\/  / ((IIIIII))\\  \\//\n" +
x + "          ^  /\\  \\IIII /  /  \\  ^\n" +
x + "          \\  ((((`\"\"`))))  \\/\n" +
x + "          .--'  /\\_______/\\  `--.\n" +
x + "         ((((--'           '--))))\n";

        }
        public static string WarriorArt()
        {
            string x = "";
            for (int i = 0; i < 40; i++)
            {
                x += " ";
            }
            return
x + "      /\\ \n" +
x + "      ||\n" +
x + "      ||\n" +
x + "      ||\n" +
x + "      ||           { }\n" +
x + "      ||          .--.\n" +
x + "      ||         /.--.\\  \n" +
x + "      ||         |====|    \n" +
x + "      ||         |`::`|    \n" +
x + "     _|| _.-;`\\.... /`; -.    \n" +
x + "      /\\   /  | ...::...|  \\\n" +
x + "      |:'\\ |   /'''::'''\\   |\n" +
x + "       \\ /\\; -,/\\   ::   /\\--; \n" +
x + "        \\ <` >  >._::_.<,< __ > \n" +
x + "         `\"\"`  /         \\|  | \n" +
x + "               |          |\\::/ \n" +
x + "               |          |/||| \n" +
x + "               |___ /\\___| '''\n" +
x + "                \\_ || _ / \n" +
x + "                < _ >< _ > \n" +
x + "                 |  ||  | \n" +
x + "                 |  ||  | \n" +
x + "               _\\.:||:./ _\n" +
x + "              / ____ /\\____\\  \n";
        }
        public static string GoblinArt()
        {
            string x = "";
            for (int i = 0; i < 25; i++)
            {
                x += " ";
            }
            return
x + "                ,      _.._     ,\n" +
x + "               (`._.\"`    `\"._.') \n" +
x + "                '._          _.' /\\\n" +
x + "                  | /`-.  .- '\\ |__          \n" +
x + "                  | (_()_\\/_()_)|\\          \n" +
x + "                  ;   ,____,    ;  \\         \n" +
x + "                  \\ / VvvV\\  /    \\\\  \n" +
x + "                  /`'._`\"\"`_.'     \\\\ \n" +
x + "                 /  .  `--'           \\\\\n" +
x + "                /  / `-,       _.----'   \\  ;\n" +
x + "               /  /     )     /  .--------`\\ \n" +
x + "              /  /.----'     /  /      \n" +
x + "             /  /| _    _,| (--\\ _______\n" +
x + "            /  / |   \\`\"\"`  \\\\\\         \\\n" +
x + "           / /`  |    |      \\\\\\____     \\\n" +
x + "          / /    ;    |              /   /\n" +
x + "         / / _    \\  /              /  `/`\n" +
x + "        / _\\/ (    | |             /   .'_\n" +
x + "        | ( \\  '--'  \\           .'  (__)`\\\n" +
x + "          \\\\  `-------'         /________.'\n" +
x + "          `\\\\";
        }

        public static string TrollArt()
        {
            string x = "";
            for (int i = 0; i < 25; i++)
            {
                x += " ";
            }
            return
x + "                         / \\             / \\\n" +
x + "                        /  \\|   .- '_,. //   \\   \n" +
x + "                       ||   |.- \"   \" -.|  ||\n" +
x + "                       ||  /  -.\\ //.- \\   || \n" +
x + "                        \\_ |  /o`^'o\\  | _ //\n" +
x + "                         `--|`\" / \\\"` | \n" +
x + "                        .--.; |\\__\"__/| ;.--.\n" +
x + "                    _.-'     \\ \\/^\\/ //     `-.\n" +
x + "              _.--'          \\       //          `--._\n" +
x + "            /`            _   \\ -.- //   _            `\\\n" +
x + "           <     _,..--''`|    \\ `\"`/    |`''--.., _   >`\n" +
x + "           _\\  ``--..__   \\     `'`     / __..--``    /\n" +
x + "          / '-.__     ``' -;    / \\    ; -'``   __.-'  \\\n" +
x + "         |     ``''--..  \'-' | '-' / ..--''``             _ |\n" +
x + "         \\     '-.       /   |/--|--\\|   \\       .-' /\n" +
x + "          '-._    ' -._ /    | ---| ---|    \\  _.- '    _.-'\n" +
x + "              `'-._   ' / / / / ---| ---\\ \\ \\ \'   _.-'`\n" +
x + "                   '-./ / / / \\`---`/ \\ \\ \\ \\.-'\n" +
x + "                       `)` `  / '---'\\  ` `(`\n" +
x + "                  /`     |       |     `\\\n" +
x + "                     /  /  | |       | |  \\  \\\n" +
x + "                 .--'  /   | '.     .' |   \\  '-\" + -.\n" +
x + "                / _____ /|  / \\._\\   / _./ \\  |\\_____\\\n" +
x + "               (/ (/ '     \\) (/     `\\)      \\)";
        }

        public static string MageArt()
        {
            string x = "";
            for (int i = 0; i < 40; i++)
            {
                x += " ";
            }
            return
x + "                      .            (*  . ). .)  .\n" +
x + "                     /:\\          ((. *.).\n" +
x + "                    /:.:\\            .  .  )  *\n" +
x + "                   /:.:.:\\       .*   /.  .    *\n" +
x + "                  | wwWWWww |         /   .\n" +
x + "                  (((\"\"\")))       / \n" +
x + "                  (. @ @ .)         /\n" +
x + "                   (((_)))      __ /\n" +
x + "                 .-)))o(((-.    |:.\\\n" +
x + "                /.:((()))):.:\\  /.:.\\\n" +
x + "               /.:.:)))((:.:.:\\/.:.:.|\n" +
x + "              /.:.:.((()).:.:./.:.\\.:|\n" +
x + "             /.:.:.:.))((:.:.:.:./  \\|\n" +
x + "            /.:.:.:Y: ((().Y.:.:./\n" +
x + "            /.:.:.:/:.:)).:\\:.:.|\n" +
x + "           /.:.:.:/|.:.(.:.:\\:./\n" +
x + "         /.:.:.:/ |:.:.:.:.|\'\n" +
x + "         `;.:./   |.:.:.:.:|       \n" +
x + "           |./ '  |:.:.:.:.|          \n" +
x + "                  |:.:.:.:.|           \n" +
x + "                  |.:.:.:.:|       \n" +
x + "                  |:.:.:.:.|\n" +
x + "                 /:.:.:.:.:.\\\n" +
x + "                |.:.:.:.:.:.:|\n" +
x + "                |:.:.:.:.:.:.|\n" +
x + "                `-:.:.:.:.:.-'\n";
        }
        public static string RogueArt()
        {
            string x = "";
            for (int i = 0; i < 40; i++)
            {
                x += " ";
            }
            return
x + "               .- \" -.    _\n" +
x + "               / /\\_ \\    |\\\n" +
x + "              / /')'\\ \\  / /\n" +
x + "             (  \\ = /  )/\\ /\n" +
x + "              )  ) ((/      \\\n" +
x + "             (_.;`\"`;._)    | \n" +
x + "            / (  \\|/  )     |\n" +
x + "           /  /\\-'^' -/\\   |\n" +
x + "           |  \\| )=@= ( \\_ /\n" +
x + "           |  /\\/     \\\n" +
x + "           | /\\ \\     ;\n" +
x + "            \\(//'     |\n" +
x + "             \\/       |\n" +
x + "             |      / /\n" +
x + "             |     /\\_\\\n" +
x + "             |  _/   \\ \\\n" +
x + "             /| |   | |\\\n" +
x + "             \\| |   | | |\n" +
x + "              / \\`-'/ \\\n" +
x + "              `-'   ' -`\n";
        }

    }
}
