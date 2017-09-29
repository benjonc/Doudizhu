using MyGame.Interface;
using System;
using System.Collections.Generic;


namespace MyGame
{
    class Player : APlayer, IRoom
    {
        private ImagePlayer _imgPlayer;

        private int _roomId;

        public int RoomId
        {
            get { return _roomId; }
        }
        

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Player(int id, string name)
        {
            _id = id;
            _name = name;

            EventMgr.Instance.RegistEvent(EventMsg.GameStart, OnGameStart);

            ImagePlayer imgPlayer = new ImagePlayer(this);
            SetImagePlayer(imgPlayer);
        }
        
        public void SetImagePlayer(ImagePlayer imgPlayer)
        {
            _imgPlayer = imgPlayer;
        }

        public ImagePlayer ImgPlayer
        {
            get { return _imgPlayer; }            
        }

        public void ClearImgPlayer()
        {
            _imgPlayer = null;
        }

        public int CreateRoom(int type1, int type2)
        {
            return 0;
        }

        public bool JoinRoom(int roomId)
        {
            EventMgrArgs args = new EventMgrArgs();
            args.IntPars.Add(_id);
            args.IntPars.Add(roomId);
            EventMgr.Instance.Notify(EventMsg.PlayerEnterRoom, args);

            _roomId = roomId;

            return false;
        }

        public bool ExitRoom(int roomId)
        {
            return false;
        }

        private void OnGameStart(EventMgrArgs args)
        {
            Console.WriteLine("游戏开始了" + _name);
        }
    }
}
