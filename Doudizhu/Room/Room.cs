using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Room : ARoom
    {
        protected Room()
        {
            //EventMgr.Instance.RegistEvent(EventMsg.GameStart);

        }



        public override bool DestroyRoom()
        {

            return base.DestroyRoom();
        }
    }
}
