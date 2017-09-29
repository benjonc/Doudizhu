using System;
using System.Collections.Generic;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建房间（房间内创建裁判）
            DoudizhuRoom room = RoomMgr.Ins.CreateRoom<DoudizhuRoom>(1) as DoudizhuRoom;

            // 创建玩家
            List<Player> players = new List<Player>();
            for(int i = 0; i < 3; i++)
            {
                Player p = PlayerMgr.Instance.CreatePlayer<Player>(i + 101, string.Format("玩家{0}", i + 1)) as Player;                
                players.Add(p);

                // 进入房间
                p.JoinRoom(1);
            }            
            

            Console.ReadKey();            
        }
    }
}
