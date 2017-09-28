using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Interface
{
    interface IInsPlayer
    {
        APlayer InsPlayer<T>() where T : APlayer;
    }
}
