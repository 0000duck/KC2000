using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicPlayer.Songs;
using System.Threading;

namespace MusicPlayer.Player
{
    public class CompositionPlayer
    {
        List<InstrumentPlayer> _players;

        public CompositionPlayer(Composition composition)
        {
            _players = new List<InstrumentPlayer>();

            foreach(Instrument instrument in composition.Instruments)
            {
                _players.Add(new InstrumentPlayer(instrument));
            }
        }

        public void Play()
        {
            int milliseconds = 0;
            while (_players.Any(x=>x.IsFinished() == false))
            {
                foreach (InstrumentPlayer player in _players)
                {
                    player.Play(milliseconds);
                }

                DateTime last = DateTime.Now;
                DateTime now = DateTime.Now;
                while((now -last).TotalMilliseconds < 10.0)
                {
                    now = DateTime.Now;
                }
                milliseconds = 10;
                //Thread.Sleep(20);
            }
        }
    }
}
