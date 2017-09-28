using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGame
{
    class Doudizhu : ARule
    {
        // 1.卡片固定数量
        // 2.专属斗地主的裁判
        // 3.玩家数量       
        #region non public atrbility
        private DoudizhuReferee _ddzReferee;
        #endregion

        #region public atribility
        public const int CARDSCOUNT = 54;
        #endregion

        #region public function
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
                if (_cards != null && _cards.Count == 54)
                {
                    RandomCards();
                    return _cards;
                }
                return null;
            }
        }

        public void Start()
        {
            EventMgr.Instance.Notify(EventMsg.GameStart, null);
        }

        public void Licensing()
        {
            _ddzReferee.Licensing(Cards);
        }

        public void AddPlayer(Player p1, Player p2, Player p3)
        {
            _ddzReferee.AddPlayer(p1.ImgPlayer, p2.ImgPlayer, p3.ImgPlayer);
        }

        #endregion

        #region non public function
        private void CreateCards()
        {
            _cards = new List<ACard>();
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

        private void RandomCards()
        {
            if (_cards == null || _cards.Count != CARDSCOUNT) return;
            int index = CARDSCOUNT;
            while (index >= 0)
            {
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                Random random = new Random(Convert.ToInt32(ts.TotalSeconds));
                int randIndex = random.Next(0, index);
                var card = _cards[randIndex];
                _cards.Remove(card);
                _cards.Insert(_cards.Count - 1, card);
                index -= 1;
            }
        }

        private void CreateReferee()
        {
            _ddzReferee = new DoudizhuReferee();
        }
        #endregion

    }
}
