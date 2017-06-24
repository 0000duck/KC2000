using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillCommando.Implementations.Providers
{
    public class MusicDictionaryProvider
    {
        public static Dictionary<FrameworkImplementations.Mainframe.SongProvider.SongType, List<string>> FullVersionSongs = new Dictionary<FrameworkImplementations.Mainframe.SongProvider.SongType, List<string>> 
        { 
            { 
                FrameworkImplementations.Mainframe.SongProvider.SongType.Sad, new List<string> 
                {
                    "Content\\Sound\\Music\\track4.wav", "Content\\Sound\\Music\\track8.wav", "Content\\Sound\\Music\\track14.wav"
                }
            },
            { 
                FrameworkImplementations.Mainframe.SongProvider.SongType.German, new List<string> 
                {
                    "Content\\Sound\\Music\\track17.wav"
                }
            },
            { 
                FrameworkImplementations.Mainframe.SongProvider.SongType.Marrakesch, new List<string> 
                {
                    "Content\\Sound\\Music\\track10.wav"
                }
            },
            { 
                FrameworkImplementations.Mainframe.SongProvider.SongType.Hypnotic, new List<string> 
                {
                    "Content\\Sound\\Music\\track1.wav","Content\\Sound\\Music\\track16.wav","Content\\Sound\\Music\\track15.wav","Content\\Sound\\Music\\track3.wav"
                }
            },
            { 
                FrameworkImplementations.Mainframe.SongProvider.SongType.SpeedMetal, new List<string> 
                {
                    "Content\\Sound\\Music\\track7.wav", "Content\\Sound\\Music\\track13.wav", "Content\\Sound\\Music\\track5.wav"
                }
            },
            { 
                FrameworkImplementations.Mainframe.SongProvider.SongType.MountLogan, new List<string> 
                {
                    "Content\\Sound\\Music\\track18.wav"
                }
            },
            { 
                FrameworkImplementations.Mainframe.SongProvider.SongType.MidTempo, new List<string> 
                {
                    "Content\\Sound\\Music\\track12.wav", "Content\\Sound\\Music\\track6.wav", "Content\\Sound\\Music\\track9.wav","Content\\Sound\\Music\\track19.wav","Content\\Sound\\Music\\track20.wav","Content\\Sound\\Music\\track21.wav"
                }
            }
        };
    }
}
