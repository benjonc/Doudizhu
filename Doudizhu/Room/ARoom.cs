using MyGame.Interface;

namespace MyGame
{
    // 游戏房间抽象类
    abstract class ARoom : IDestroyRoom
    {
        protected int _roomId;
        protected int[] _types;
        protected string _dsc;
        protected AReferee _referee;

        public virtual bool DestroyRoom()
        {
            return false;
        }
    }
}
