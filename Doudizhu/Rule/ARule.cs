using Doudizhu.Card;
using Doudizhu.Player;
using Doudizhu.Referee;
using Doudizhu.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doudizhu.Rule
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
