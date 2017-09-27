using Doudizhu.Card;
using Doudizhu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doudizhu.Referee
{
    // 斗地主裁判类
    class DoudizhuReferee : AReferee, ICheckBigger
    {

        public bool CheckBigger(List<ACard> cards1, List<ACard> cards2)
        {
            if(cards1 == null || cards2 == null)
            {
                return false;
            }

            // 1. 单张比较
            // 2. 单张连牌比较
            // 3. 多张连牌比较
            // 4. 炸弹比较

            if(cards1.Count == cards2.Count)
            {
                for(int i = 0; i < cards1.Count; i++)
                {
                    var card1 = cards1[i];
                }
            }
            return false;
        }

        // 检测牌型
        private int CheckType(List<ACard> cards)
        {
            if (cards == null) return 0;
            if (cards.Count == 1) return 1;
            if(cards.Count > 1)
            {

            }

            return 0;
        }

    }
}
