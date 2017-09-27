using Doudizhu.Player;
using Doudizhu.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doudizhu.Interface
{
    interface ICreateRoom
    {
        /// <summary>
        /// 创建房间
        /// </summary>
        /// <param name="type"> 房间类型 </param>
        /// <param name="playerId"> 玩家ID </param>
        /// <returns> roomId </returns>
        int CreateRoom(int type1, int type2);
    }
}
