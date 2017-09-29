using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Room : ARoom
    {
        private int _playerCount;
        private Dictionary<int, APlayer> _players;

        protected Room(int id, int[] types)
        {
            _roomId = id;
            _types = types;
            _playerCount = 0;
            _players = new Dictionary<int, APlayer>();

            EventMgr.Instance.RegistEvent(EventMsg.PlayerExitRoom, OnPlayerExit);
            EventMgr.Instance.RegistEvent(EventMsg.PlayerEnterRoom, OnPlayerJoin);
        }

        protected override bool DestroyRoom()
        {
            _players.Clear();
            _players = null;
            _playerCount = 0;
            _roomId = 0;
            _types = null;

            EventMgr.Instance.RemoveEvent(EventMsg.PlayerExitRoom, OnPlayerExit);
            EventMgr.Instance.RemoveEvent(EventMsg.PlayerEnterRoom, OnPlayerJoin);

            EventMgrArgs args = new EventMgrArgs();
            args.IntPars.Add(_roomId);
            EventMgr.Instance.Notify(EventMsg.DestroyRoom, args);

            return true;
        }

        protected override void OnPlayerExit(EventMgrArgs args)
        {
            int playerId = args.IntPars[0];
            int roomId = args.IntPars[1];
            
            if (roomId == _roomId && _players.ContainsKey(playerId))
            {
                _players.Remove(playerId);
                _playerCount -= 1;
            }
        }

        protected override void OnPlayerJoin(EventMgrArgs args)
        {
            if (_playerCount == 3 || args == null || args.IntPars[1] != _roomId) return;

            int playerId = args.IntPars[0];
            Player player = PlayerMgr.Instance.GetPlayer<Player>(playerId) as Player;
            _players.Add(player.Id, player);
            _playerCount += 1;
        }        
    }
}
