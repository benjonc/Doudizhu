using MyGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    // todo:
    class InstanceMgr : IInstance
    {
        private InstanceMgr() { }
        private static InstanceMgr _instanceMgr;
        public static InstanceMgr Ins
        {
            get
            {
                if (_instanceMgr == null) _instanceMgr = new InstanceMgr();
                return _instanceMgr;
            }
        }

        public T Instance<T>() where T : class, new()
        {
            return default(T);
        }
    }
}
