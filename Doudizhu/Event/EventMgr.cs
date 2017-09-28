using MyGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public delegate void MgrEventHandler(EventMgrArgs args);
    //public delegate void GenericEventHandler<T>(T t);
    //public delegate void OneParEventHandler<T>(T t);
    //public delegate void TwoParEventHandler<T1, T2>(T1 t1, T2 t2);
    //public delegate void ThreeParEventHandler<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
    //public delegate void FourParEventHandler<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);
    //public delegate void FiveParEventHandler<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    //public delegate void SixParEventHandler<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);

    public class EventMgrArgs : EventArgs
    {
        public readonly List<int> IntPars;
        public readonly List<string> StrPars;
        public readonly List<float> FotPars;
        public readonly List<bool> BolPars;
        
        public EventMgrArgs()
        {
            IntPars = new List<int>();
            StrPars = new List<string>();
            FotPars = new List<float>();
            BolPars = new List<bool>();
        }

        public void AddIntPar(int intPar)
        {
            IntPars.Add(intPar);
        }

        public void AddStrPar(string strPar)
        {
            StrPars.Add(strPar);
        }

        public void AddFotPar(float fotPar)
        {
            FotPars.Add(fotPar);
        }

        public void AddBolPar(bool bolPar)
        {
            BolPars.Add(bolPar);
        }

    }

    // 消息定义
    enum EventMsg
    {
        SatisfyPlayers,
        PlayerEnterRoom,
        GameStart,

    }

    class EventMgr // : IInstance
    {
        private EventMgr() { }
        private static EventMgr _instance;
        public static EventMgr Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventMgr();

                return _instance;
            }            
        }

        //public T Instance<T>() where T : class, new()
        //{
        //    return ((IInstance)_instance).Instance<T>();
        //}

        private Dictionary<EventMsg, List<MgrEventHandler>> _events;

        // 注册事件      
        public void RegistEvent(EventMsg eventMsg, MgrEventHandler e)
        {
            if (_events == null) _events = new Dictionary<EventMsg, List<MgrEventHandler>>();
            if (e == null) return;

            if (_events.ContainsKey(eventMsg))
                _events[eventMsg].Add(e);
            else
            {
                List<MgrEventHandler> handlers = new List<MgrEventHandler>();
                _events.Add(eventMsg, handlers);
                RegistEvent(eventMsg, e);
            }
        }

        // 通知事件
        public void Notify(EventMsg eventMsg, EventMgrArgs args)
        {
            if (_events.ContainsKey(eventMsg))
            {
                foreach (var eItem in _events[eventMsg]) eItem(args);
            }
        }

        // 移除事件
        public void RemoveEvent(EventMsg eventMsg, MgrEventHandler e)
        {
            if (_events == null) return;
            if (_events.ContainsKey(eventMsg) && _events[eventMsg].Contains(e))
            {
                _events[eventMsg].Remove(e);
            }
        }       
    }
}
