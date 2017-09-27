using Doudizhu.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doudizhu.Rule.Doudizhu
{
    class Doudizhu : ARule
    {
        // 1.卡片固定数量
        // 2.专属斗地主的裁判
        // 3.玩家数量

        public const int CARDSCOUNT = 54;

        public Doudizhu()
        {
            // 创建专属于斗地主的卡片
            CreateCards();
            // 创建专属于斗地主的裁判
            CreateReferee();
        }

        public List<ACard> Cards
        {
            get
            {
                if(_cards != null && _cards.Count == 54)
                {
                    RandomCards();
                    return _cards;
                }
                return null;
            }
        }

        private void CreateCards()
        {
            for (int i = 1; i < 15; i++)
            {
                for (int j = 1; j < 5; j++)
                {                    
                    if ((i > 13 && j < 3) || i <= 13 )
                    {
                        PokerCard card = new PokerCard(i, j);
                        _cards.Add(card);
                    }
                }
            }
        }

        private void RandomCards()
        {
            if (_cards == null || _cards.Count != CARDSCOUNT) return;
            int index = CARDSCOUNT;
            while(index >= 0)
            {
                Random random = new Random();
                int randIndex = random.Next(0, index);
                var card = _cards[randIndex];
                _cards.Insert(_cards.Count - 1, card);
                index -= 1;
            }
        }

        private void CreateReferee()
        {

        }
      

    }
}
