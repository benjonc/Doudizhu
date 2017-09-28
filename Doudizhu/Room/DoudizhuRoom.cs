using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class DoudizhuRoom : ARoom
    {
        // 根据ID和Types确定房间的描述
        private void CreateDsc()
        {
            _dsc = "";
        }

        // 房间的自己的信息
        // 每一个房间有自己的裁判
        public DoudizhuRoom(int roomId, int[] types)
        {
            _types = types;
            _roomId = roomId;
            CreateDsc();

            _referee = new DoudizhuReferee();

        }

        // 添加玩家
        public void AddPlayer(APlayer player)
        {

        }

        // 房间被销毁
        public bool DestroyRoom()
        {

            return false;
        }

        

    }
}
