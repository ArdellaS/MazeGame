using System;
using System.Collections.Generic;
using MazeGame.Set_Up;

namespace MazeGame
{
   public static class Program
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 45);
            
            Board board = new Board();

            board.GamePlay();

        }

       
    }
}
