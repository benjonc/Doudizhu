using System;
using MyGame.Interface;
using System.Collections.Generic;

namespace MyGame
{
    // 斗地主裁判类
    class DoudizhuReferee : AReferee, ICheckBigger
    {
        private ImagePlayer _player1, _player2, _player3;

        public enum CardsType
        {
            One,                        // 单张
            Ones,                       // 连牌
            Two,                        // 对子
            Twos,                       // 连对
            Three,                      // 三张不带
            Threes1,                    // 三带1
            Threes2,                    // 三带2
            Threes3,                    // 飞机不带
            Threes4,                    // 飞机带3个单
            Threes5,                    // 飞机带3个双
            Four,                       // 炸弹
            Fours1,                     // 四带两单
            Fours2,                     // 四带两对            
            King1,                      // 小王
            King2,                      // 大王
            Kings,                      // 王炸
        }

        public void AddPlayer(ImagePlayer p1, ImagePlayer p2, ImagePlayer p3)
        {
            _player1 = p1;
            _player2 = p2;
            _player3 = p3;
        }

        public void Licensing(List<ACard> cards)
        {
            int cardCount = cards.Count - 1;
            while(cardCount >= 0)
            {
                PokerCard card1 = (PokerCard)cards[cardCount];
                _player1.AddCard(card1);
                cardCount -= 1;

                PokerCard card2 = (PokerCard)cards[cardCount];
                _player2.AddCard(card2);
                cardCount -= 1;

                PokerCard card3 = (PokerCard)cards[cardCount];
                _player3.AddCard(card3);
                cardCount -= 1;
            }
        }


        public bool CheckBigger(List<ACard> oldCards, List<ACard> newCards)
        {
            if (oldCards == null && newCards != null) return true;
            if (oldCards != null && newCards == null) return false;             

            // 1. 单张比较
            // 2. 单张连牌比较
            // 3. 多张连牌比较
            // 4. 炸弹比较

            if(oldCards.Count == newCards.Count)
            {
                for(int i = 0; i < oldCards.Count; i++)
                {
                    var card1 = oldCards[i];
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
            { }

            return 0;
        }
    }
}
