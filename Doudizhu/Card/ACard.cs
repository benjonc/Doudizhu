using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    abstract class ACard
    {
        // 卡片的抽象类
        // 可以是扑克牌
        // 可以是麻将
        // 可以是象棋 等等
        protected int _value;
        protected int _type;
        protected string _dsc;
    }
}
