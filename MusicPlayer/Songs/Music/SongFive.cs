using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class SongFive : Song
    {
        public SongFive()
        {
            BassNoteCollection E = new BassNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 50,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.Silence,BassNotes.Silence,BassNotes.Silence,
                }
            };

            BassNoteCollection BassLine1 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E5,BassNotes.E7,BassNotes.E4,BassNotes.E6,
                    BassNotes.E3,BassNotes.E5,BassNotes.E2,BassNotes.E4,
                }
            };

            BassNoteCollection Eslow = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E10,BassNotes.E9,BassNotes.E7,
                    BassNotes.E5,BassNotes.E7,BassNotes.E9,BassNotes.E7,
                    BassNotes.E5,BassNotes.E3,BassNotes.E5,BassNotes.E7,
                }
            };

            BassLine = new List<BassNoteCollection>();

            //strophe
            //BassLine.Add(E);
            //BassLine.Add(BassLine1);
            //BassLine.Add(E);
            //BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);

            BassLine.Add(Eslow);
            BassLine.Add(Eslow);

            BassLine.Add(E);
            BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);

            BassLine.Add(Eslow);
            BassLine.Add(Eslow);
            //BassLine.Add(Eslow);
            //BassLine.Add(Eslow);

            BassLine.Add(E);
            BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);

            BassLine.Add(Eslow);
            BassLine.Add(Eslow);
            //BassLine.Add(Eslow);
            //BassLine.Add(Eslow);

            BassLine.Add(E);
            BassLine.Add(BassLine1);
            BassLine.Add(E);
            BassLine.Add(BassLine1);

            BassLine.Add(Eslow);
            BassLine.Add(Eslow);
            BassLine.Add(Eslow);
            BassLine.Add(Eslow);
            //BassLine.Add(Eslow);
            //BassLine.Add(Eslow);
            ///////////////////////////////////////////////////////

            MelodyNoteCollection stille = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = ((2400 + 800) * 2) + (20 * 200 *2),
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            MelodyNoteCollection strophe = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                }
            };

            MelodyNoteCollection strophe2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E12,MelodyNotes.E9,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E8,MelodyNotes.E9,
                }
            };

            MelodyNoteCollection strophe3 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E0,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E7,MelodyNotes.E0,MelodyNotes.E5,
                    MelodyNotes.E0,MelodyNotes.E7,MelodyNotes.E0,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E0,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E7,MelodyNotes.E0,MelodyNotes.E5,
                    MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E0,MelodyNotes.E9,
                }
            };
            MelodyNoteCollection refrain = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 80,
                MilliSecondsPerSound = 50,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,

                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,

                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E10,
                    MelodyNotes.E8
                }
            };
            MelodyNoteCollection refrainfinale = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 50,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,

                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E10,MelodyNotes.E12,
                }
            };

            MelodyNoteCollection finale = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,

                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                    MelodyNotes.E10,MelodyNotes.E11,MelodyNotes.E10,MelodyNotes.E11,
                }
            };
            Guitar = new List<MelodyNoteCollection>();

            Guitar.Add(stille);

            Guitar.Add(strophe);
            Guitar.Add(strophe2);
            Guitar.Add(strophe);
            Guitar.Add(strophe2);
            Guitar.Add(strophe);
            Guitar.Add(strophe2);
            Guitar.Add(strophe);
            Guitar.Add(strophe2);

            Guitar.Add(refrain);
            Guitar.Add(refrain);

            Guitar.Add(strophe3);
            Guitar.Add(strophe2);
            Guitar.Add(strophe3);
            Guitar.Add(strophe2);
            Guitar.Add(strophe3);
            Guitar.Add(strophe2);
            Guitar.Add(strophe3);
            Guitar.Add(strophe2);

            Guitar.Add(refrain);
            Guitar.Add(refrain);

            Guitar.Add(strophe);
            Guitar.Add(strophe2);
            Guitar.Add(strophe);
            Guitar.Add(strophe2);

            Guitar.Add(refrain);
            Guitar.Add(refrain);
            Guitar.Add(refrainfinale);
            Guitar.Add(refrainfinale);
            //Melody.Add(refrainfinale);
            //Melody.Add(refrainfinale);
        }

    }
}
