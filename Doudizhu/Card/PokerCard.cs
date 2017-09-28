using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class PokerCard : ACard
    {
        public PokerCard(int value, int type)
        {
            _value = value;
            _type = type;          
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
                    string typeDsc = "";
                    switch(_type)
                    {
                        case 1:
                            typeDsc = "红桃";
                            break;
                        case 2:
                            typeDsc = "方块";
                            break;
                        case 3:
                            typeDsc = "黑桃";
                            break;
                        case 4:
                            typeDsc = "梅花";
                            break;
                    }
                    _dsc = string.Format("{0} --- {1}", typeDsc, _value);
                }
                
                return _dsc;
            }
        }

    }
}
