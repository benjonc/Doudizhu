using MyGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    // 人偶类，存储卡牌相关
    class ImagePlayer : APlayer, IAddCard, IPlayCard
    {
        protected List<ACard> _cards;
        protected APlayer _master;

        public ImagePlayer(APlayer master)
        {
            _master = master;
            _cards = new List<ACard>();
        }

        public void AddCard(ACard card)
        {
            if (card == null) return;
            if(!_cards.Contains(card))
            {
                _cards.Add(card);
            }
        }

        public bool PlayCard(ACard[] cards)
        {
            if (cards == null) return false;

            return false;
        }

        public void ClearCards()
        {
            _cards.Clear();
        }

        public void ShowCard()
        {
            Console.WriteLine("------------------" + ((Player)_master).Name + "的牌是：");
            SortCard();
            foreach (var card in _cards)
            {
                var c = (PokerCard)card;
                Console.WriteLine(c.Dsc);
            }
            Console.WriteLine(((Player)_master).Name + "的牌结束！------------------");
        }

        private void SortCard()
        {
            for(int i = 0; i < _cards.Count; i++)
            {
                for(int j = i; j < _cards.Count; j++)
                {
                    var c1 = (PokerCard)_cards[i];
                    var c2 = (PokerCard)_cards[j];

                    bool b1 = c1.Value > c2.Value;
                    bool b2 = (c1.Value == c2.Value) && (c1.Type < c2.Type);

                    if (b1 || b2)
                    {
                        var c3 = _cards[i];
                        _cards[i] = _cards[j];
                        _cards[j] = c3;
                    }
                }
            }
        }
    }
}
