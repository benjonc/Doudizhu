﻿using Doudizhu.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doudizhu.Interface
{
    interface ICheckBigger
    {
        bool CheckBigger(List<ACard> cards1, List<ACard> cards2);
    }
}
