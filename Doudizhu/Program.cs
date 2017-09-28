using System;
using System.Collections.Generic;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            for(int i = 0; i < 3; i++)
            {
                Player p = new Player(i + 101, string.Format("玩家{0}", i + 1));
                players.Add(p);
            }
            Doudizhu ddz = new Doudizhu();
            ddz.Start();
            ddz.AddPlayer(players[0], players[1], players[2]);
            ddz.Licensing();

            foreach (var p in players)
            {
                p.ImgPlayer.ShowCard();
            }

            Console.ReadKey();            
        }
    }
}
