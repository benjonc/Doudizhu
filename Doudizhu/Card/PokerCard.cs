using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class PokerCard : ACard
    {
        // 全部牌型
        private const int _cardType = 4;
        public PokerCard(int value, int type)
        {
            _value = value;
            _type = type;
            _isShow = false;
        }

        public int Value
        {
            get { return _value; }
        }

        public int Type
        {
            get { return _type; }
        }

        public string Dsc
        {
            get
            {
                if (string.IsNullOrEmpty(_dsc))              
                {
                    string typeDsc1 = "";
                    string typeDsc2 = "";
                    switch (_type)
                    {
                        case 1:
                            typeDsc1 = "红桃";
                            break;
                        case 2:
                            typeDsc1 = "方块";
                            break;
                        case 3:
                            typeDsc1 = "黑桃";
                            break;
                        case 4:
                            typeDsc1 = "梅花";
                            break;
                    }
                    if (_value <= 10 && _value >= 2)
                    {                        
                        _dsc = string.Format("{0} --- {1}", typeDsc1, _value);
                    }
                    else if(_value == 1 || (_value > 10 && _value <= 13 ))
                    {
                        switch(_value)
                        {
                            case 1:
                                typeDsc2 = "A";
                                break;
                            case 11:
                                typeDsc2 = "J";
                                break;
                            case 12:
                                typeDsc2 = "Q";
                                break;
                            case 13:
                                typeDsc2 = "K";
                                break;
                        }
                        _dsc = string.Format("{0} --- {1}", typeDsc1, typeDsc2);
                    }                    
                    else if (_value > 13)
                    {
                        _dsc = _type > 1 ? "大王" : "小王";
                    }
                }
                
                return _dsc;
            }
        }

        public bool IsShow { get { return _isShow; } }

        public void SetShow()
        {
            _isShow = true;
        }

        public int Id
        {
            get
            {
                _id = ((_value - 1) * _cardType) + _type;
                return _id;
            }
        }
    }
}
