using System;
using System.Collections.Generic;

namespace MazeGame
{
   public static class Program
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 45);

            CharacterList characterList = new CharacterList();
            Board board = new Board();

            board.GamePlay();

        }

       
    }
}
