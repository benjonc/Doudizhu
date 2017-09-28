using System;
using System.Collections.Generic;


namespace MyGame
{
    // 游戏规则抽象类
    abstract class ARule
    {
        // 专属裁判
        protected AReferee _referee;
        // 专属卡片数量
        protected List<ACard> _cards;
        // 专属玩家
        protected List<APlayer> _players;
        // 专属房间
        protected ARoom _room;

    }
}
