
using MyGame.Interface;

namespace MyGame
{
    // 抽象玩家类
    abstract class APlayer
    {
        protected int _id;
        protected string _name;
        protected int _gold;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public static APlayer InsPlayer<T>() where T : APlayer
        {
            return null;
        }
    }
}
