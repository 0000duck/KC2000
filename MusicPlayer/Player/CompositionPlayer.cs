using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicPlayer.Songs;
using System.Diagnostics;

namespace MusicPlayer.Player
{
    public class CompositionPlayer
    {
        List<IPlayer> _players;

        public CompositionPlayer(Composition composition, IPlayer pitchPlayer)
        {
            _players = new List<IPlayer>();

            foreach(Instrument instrument in composition.Instruments)
            {
                _players.Add(new InstrumentPlayer(instrument));
            }
            _players.Add(pitchPlayer);
        }

        public void Play()
        {
            int milliseconds = 0;
            while (_players.Any(x=>x.IsFinished() == false))
            {
                foreach (IPlayer player in _players)
                {
                    player.Play(milliseconds);
                }

                Stopwatch watch = new Stopwatch();
                watch.Start();

                while(watch.ElapsedMilliseconds < 10)
                {
                    int x = 1000000 / 65454545 * 3433 + 43545;
                }

                milliseconds = 10;
            }
        }
    }
}
