using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class PlayerMgr
    {
        private PlayerMgr() { }
        private static PlayerMgr _instance;
        public static PlayerMgr Instance
        {
            get
            {
                if (_instance == null) _instance = new PlayerMgr();
                return _instance;
            }
        }

        private Dictionary<int, APlayer> _players;

        public APlayer CreatePlayer<T>(int id, string name) where T : APlayer
        {
            if (_players == null) _players = new Dictionary<int, APlayer>();
            if (_players.ContainsKey(id)) return _players[id];

            APlayer p = APlayer.InsPlayer<T>();
            p.Id = id;
            p.Name = name;
            _players.Add(id, p);

            return p;
        }
    }
}
