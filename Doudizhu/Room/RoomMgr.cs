using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class RoomMgr
    {
        private RoomMgr() { }
        private static RoomMgr _ins;
        public static RoomMgr Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new RoomMgr();
                return _ins;
            }
        }

        private Dictionary<int, ARoom> _rooms;

        public ARoom CreateRoom<T>(int roomId) where T : ARoom
        {
            if (_rooms == null) _rooms = new Dictionary<int, ARoom>();

            ARoom r = ARoom.InsRoom<Room>();
            r.RoomId = roomId;
            r.Types = null;
            _rooms.Add(r.RoomId, r);

            return r;
        }

        public ARoom GetRoomById(int id)
        {
            if (_rooms == null) return null;
            if (_rooms.ContainsKey(id))
                return _rooms[id];
            return null;
        }

    }
}
