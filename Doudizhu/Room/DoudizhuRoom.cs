using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class DoudizhuRoom : Room
    {
        // 房间的自己的信息
        // 每一个房间有自己的裁判
        public DoudizhuRoom(int id, int[] types) : base(id, types)
        {
            _types = types;
            _roomId = id;
            CreateDsc();

            _referee = new DoudizhuReferee();
        }

        public DoudizhuReferee Referee
        {
            get { return _referee as DoudizhuReferee; }

        // 根据ID和Types确定房间的描述
        private void CreateDsc()
        {
            _dsc = "";
        }
    }
}
