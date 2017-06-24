using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;

namespace FrameworkImplementations.Mainframe
{
    public class SongProvider : ISongProvider
    {
        public enum SongType
        {
            Sad = 1,
            Hypnotic = 2,
            German = 3,
            Marrakesch = 4,
            MidTempo = 5,
            MountLogan = 6,
            SpeedMetal = 7
        }

        private Dictionary<SongType, List<string>> _songsByType;

        public SongProvider(Dictionary<SongType, List<string>> songsByType)
        {
            _songsByType = songsByType;
        }

        string ISongProvider.GetSongFileName(int levelId)
        {
            switch (levelId)
            {
                case 7:
                case 16:
                case 24:
                case 28:
                    return GetSong(SongType.Sad);
                case 6:
                case 15:
                case 5:
                case 23:
                    return GetSong(SongType.Hypnotic);
                case 9:
                    return GetSong(SongType.MountLogan);
                case 8:
                case 18:
                case 14:
                case 27:
                case 25:
                    return GetSong(SongType.SpeedMetal);
                case 20:
                    return GetSong(SongType.German);
                case 19:
                    return GetSong(SongType.Marrakesch);
                default:
                    return GetSong(SongType.MidTempo);
            }
        }

        private string GetSong(SongType type)
        {
            List<string> songs = _songsByType[type];

            int index = (int)MathHelper.GetRandomValueInARange(songs.Count, false);
            if (index == songs.Count)
                index--;

            return songs[index];
        }
    }
}
