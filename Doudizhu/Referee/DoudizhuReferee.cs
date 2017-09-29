using System;
using MyGame.Interface;
using System.Collections.Generic;

namespace MyGame
{
    // 斗地主裁判类
    class DoudizhuReferee : AReferee, ICheckBigger
    {
        // 玩家的数量
        public const int PLAYERCOUNT = 3;
        // 牌的数量
        public const int CARDSCOUNT = 54;
        // 发牌的间隔数量（只读或者私有）
        public int LicensingInterval = 1;
        // 地主标记牌（只读）
        public ACard DizhuMarkCard { get { return _dizhuMarkCard; } }
        // 地主剩余三张牌（判断条件是否显示（只读））
        public List<ACard> DizhuCards { get { return _dizhuCards; } }

        private int _readyCnt = 0;
        private int _roomId = 0;
        private ACard _dizhuMarkCard;
        private List<ACard> _dizhuCards;
        private ImagePlayer _player1, _player2, _player3;

        private Random GetRandom()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Random random = new Random(Convert.ToInt32(ts.TotalSeconds));
            return random;
        }

        private void OnPlayerReady(EventMgrArgs args)
        {
            _roomId = args.IntPars[0];
            if (_readyCnt == 3)
            {
                EventMgrArgs argsPar = new EventMgrArgs();
                argsPar.IntPars.Add(10);
                EventMgr.Instance.Notify(EventMsg.GameStart, argsPar);
            }
            _readyCnt += 1;
        }

        public DoudizhuReferee()
        {
            _cards = new List<ACard>();

            EventMgr.Instance.RegistEvent(EventMsg.PlayerReady, OnPlayerReady);
        }

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

        public PokerCard GetCardById(int cardId)
        {
            foreach(var card in _cards)
            {
                var card1 = (PokerCard)card;
                if(card1.Id == cardId)
                {
                    return card1;
                }
            }
            return null;
        }

        // 发牌
        public void Licensing(List<ACard> cards)
        {
            int cardCount = cards.Count - 1;
            while(cardCount >= 0)
            {
                for (int i = 1; i <= PLAYERCOUNT; i++)
                {
                    for (int j = 0; j < LicensingInterval; j++)
                    {
                        PokerCard card = (PokerCard)cards[cardCount];
                        cardCount -= 1;
                        switch (i)
                        {
                            case 1:
                                _player1.AddCard(card.Id);
                                break;
                            case 2:
                                _player2.AddCard(card.Id);
                                break;
                            case 3:
                                _player3.AddCard(card.Id);
                                break;
                        }
                    }
                }
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

        // 创建卡牌
        private void CreateCards()
        {
            for (int i = 1; i < 15; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    if ((i > 13 && j < 3) || i <= 13)
                    {
                        PokerCard card = new PokerCard(i, j);
                        _cards.Add(card);
                    }
                }
            }
        }

        // 随机卡牌
        private void RandomCards()
        {
            // 洗牌
            if (_cards == null || _cards.Count != CARDSCOUNT) return;
            int index = CARDSCOUNT;
            Random random = GetRandom();
            while (index >= 0)
            {                
                int randIndex = random.Next(0, index);
                var card = _cards[randIndex];
                _cards.Remove(card);
                _cards.Insert(_cards.Count - 1, card);
                index -= 1;
            }

            // 随机地主主牌
            int dizhuMark = random.Next(0, CARDSCOUNT - 3);
            var markCard = _cards[dizhuMark] as PokerCard;
            markCard.SetShow();
        }
    }
}
