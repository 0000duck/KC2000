using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Player
{
    public interface IPlayer
    {
        void Play(int milliSeconds);

        bool IsFinished();
    }
}
