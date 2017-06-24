using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    class Song8: Song
    {
        public Song8()
        {

            BassNoteCollection ADur = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 150,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E5,BassNotes.A7,BassNotes.E5,BassNotes.A7,
                    BassNotes.E5,BassNotes.A7,BassNotes.E5,BassNotes.A7,
                    BassNotes.E5,BassNotes.A7,BassNotes.E5,BassNotes.A7,
                    BassNotes.E5,BassNotes.A7,BassNotes.E5,BassNotes.A7,
                }
            };
            BassNoteCollection HMol = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 150,
                BassLine = new List<BassNotes> 
                {   
                    BassNotes.E7,BassNotes.A9,BassNotes.E7,BassNotes.A9,
                    BassNotes.E7,BassNotes.A9,BassNotes.E7,BassNotes.A9,
                    BassNotes.E7,BassNotes.A9,BassNotes.E7,BassNotes.A9,
                    BassNotes.E7,BassNotes.A9,BassNotes.E7,BassNotes.A9,
                }
            };

            BassNoteCollection DDur = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 150,
                BassLine = new List<BassNotes> 
                {   
                    BassNotes.E10,BassNotes.A0,BassNotes.E10,BassNotes.A0,
                    BassNotes.E10,BassNotes.A0,BassNotes.E10,BassNotes.A0,
                    BassNotes.E10,BassNotes.A0,BassNotes.E10,BassNotes.A0,
                    BassNotes.E10,BassNotes.A0,BassNotes.E10,BassNotes.A0,
                }
            };

            BassNoteCollection CDur = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 150,
                BassLine = new List<BassNotes> 
                {   
                    BassNotes.A3,BassNotes.A7,BassNotes.A3,BassNotes.A7,
                    BassNotes.A3,BassNotes.A7,BassNotes.A3,BassNotes.A7,
                    BassNotes.A3,BassNotes.A7,BassNotes.A3,BassNotes.A7,
                    BassNotes.A3,BassNotes.A7,BassNotes.A3,BassNotes.A7,
                }
            };

            BassNoteCollection EMol = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 150,
                BassLine = new List<BassNotes> 
                {   
                    BassNotes.E0,BassNotes.A2,BassNotes.E0,BassNotes.A2,
                    BassNotes.E0,BassNotes.A2,BassNotes.E0,BassNotes.A2,
                    BassNotes.E0,BassNotes.A2,BassNotes.E0,BassNotes.A2,
                    BassNotes.E0,BassNotes.A2,BassNotes.E0,BassNotes.A2,
                }
            };

            BassLine = new List<BassNoteCollection>();

            //strophe
            BassLine.Add(HMol);
            BassLine.Add(ADur);
            BassLine.Add(HMol);
            BassLine.Add(ADur);
            BassLine.Add(HMol);
            BassLine.Add(DDur);
            BassLine.Add(HMol);
            BassLine.Add(DDur);

            BassLine.Add(EMol);
            BassLine.Add(CDur);
            BassLine.Add(EMol);
            BassLine.Add(CDur);

            BassLine.Add(DDur);
            BassLine.Add(HMol);
            BassLine.Add(DDur);
            BassLine.Add(HMol);

            BassLine.Add(ADur);

            MelodyNoteCollection melodyHmol = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G7,MelodyNotes.G7,MelodyNotes.G7,MelodyNotes.G7,
                    MelodyNotes.G7,MelodyNotes.G7,MelodyNotes.G7,MelodyNotes.G7,
                    MelodyNotes.G7,MelodyNotes.G7,MelodyNotes.G7,MelodyNotes.G7,
                    MelodyNotes.G7,MelodyNotes.G7,MelodyNotes.G7,MelodyNotes.G7,
                }
            };
            MelodyNoteCollection melodyEmol = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                    MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,MelodyNotes.G0,
                }
            };
            MelodyNoteCollection melodyAdur = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G6,MelodyNotes.G6,MelodyNotes.G6,MelodyNotes.G6,
                    MelodyNotes.G6,MelodyNotes.G6,MelodyNotes.G6,MelodyNotes.G6,
                    MelodyNotes.G6,MelodyNotes.G6,MelodyNotes.G6,MelodyNotes.G6,
                    MelodyNotes.G6,MelodyNotes.G6,MelodyNotes.G6,MelodyNotes.G6,
                }
            };
            MelodyNoteCollection melodyDdur = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G11,
                    MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G11,
                    MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G11,
                    MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G11,MelodyNotes.G11,
                }
            };
            MelodyNoteCollection melodyCdur = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                    MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,MelodyNotes.E0,
                }
            };

            Guitar = new List<MelodyNoteCollection>();

            Guitar.Add(melodyHmol);
            Guitar.Add(melodyAdur);
            Guitar.Add(melodyHmol);
            Guitar.Add(melodyAdur);
            Guitar.Add(melodyHmol);
            Guitar.Add(melodyDdur);
            Guitar.Add(melodyHmol);
            Guitar.Add(melodyDdur);

            Guitar.Add(melodyEmol);
            Guitar.Add(melodyCdur);
            Guitar.Add(melodyEmol);
            Guitar.Add(melodyCdur);

            Guitar.Add(melodyDdur);
            Guitar.Add(melodyHmol);
            Guitar.Add(melodyDdur);
            Guitar.Add(melodyHmol);

            Guitar.Add(melodyAdur);
        }
    }
}
