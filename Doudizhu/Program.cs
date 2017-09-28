using System;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 3; i++)
            {
                Player p = new Player(i + 101, string.Format("玩家{0}", i + 1));
            }
            Doudizhu ddz = new Doudizhu();
            ddz.Start();

            Console.ReadKey();
        }
    }
}
