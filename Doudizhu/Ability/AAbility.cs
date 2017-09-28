using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    // 玩家能力类
    abstract class AAbility
    {
        // 如果是斗地主，则Ability就是拥有能玩斗地主的能力
        // 如果是其他的，则Ability对应其他能力
        // 他需要知道的数据，比如：货币、积分等。
        // 每种能力需要知道的数据可能会不同
    }
}
