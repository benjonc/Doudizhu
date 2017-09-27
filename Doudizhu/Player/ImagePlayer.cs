using Doudizhu.Card;
using Doudizhu.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doudizhu.Player
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
    }
}
