using MyGame.Interface;

namespace MyGame
{
    // 游戏房间抽象类
    abstract class ARoom
    {
        protected int _roomId;
        protected int[] _types;
        protected string _dsc;
        protected AReferee _referee;

        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public int[] Types
        {
            get { return _types; }
            set { _types = value; }
        }

        public static ARoom InsRoom<T>() where T : ARoom
        {
            return null;
        }

        protected virtual void OnPlayerExit(EventMgrArgs args)
        {
            
        }

        protected virtual void OnPlayerJoin(EventMgrArgs args)
        {
           
        }

        protected virtual bool DestroyRoom()
        {
            return false;
        }
    }
}
