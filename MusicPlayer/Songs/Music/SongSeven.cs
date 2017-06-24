using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Songs.Music
{
    public class SongSeven : Song
    {
        public SongSeven()
        {
            BassNoteCollection Efast9 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 80,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,
                }
            };
            BassNoteCollection Ebreakdown9 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,
                    BassNotes.E0,BassNotes.E0,BassNotes.E0,
                }
            };

            BassNoteCollection Afast9 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 80,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,
                    BassNotes.A0,BassNotes.A0,BassNotes.A0,
                }
            };

            BassNoteCollection Efast2 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 80,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E0,BassNotes.E0
                }
            };

            BassNoteCollection Afast2 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 80,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A0,BassNotes.A0
                }
            };

            BassNoteCollection E3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3
                }
            };

            BassNoteCollection Ebreak3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 600,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3
                }
            };

            BassNoteCollection A3 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A3
                }
            };

            BassNoteCollection E6 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E6
                }
            };

            BassNoteCollection A6 = new BassNoteCollection
            {
                MilliSecondsPerBeat = 300,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A6
                }
            };

            BassNoteCollection E3fast = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E3
                }
            };

            BassNoteCollection A3fast = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A3
                }
            };

            BassNoteCollection E6fast = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E6
                }
            };

            BassNoteCollection A6fast = new BassNoteCollection
            {
                MilliSecondsPerBeat = 200,
                MilliSecondsPerSound = 160,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.A6
                }
            };

            BassNoteCollection bassStair = new BassNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                BassLine = new List<BassNotes> 
                {
                    BassNotes.E10,BassNotes.E9,BassNotes.E8,BassNotes.E7,
                    BassNotes.E9,BassNotes.E8,BassNotes.E7,BassNotes.E6,
                    BassNotes.E8,BassNotes.E7,BassNotes.E6,BassNotes.E5,
                    BassNotes.E6,BassNotes.E5,BassNotes.E4,BassNotes.E3,
                    BassNotes.E5,BassNotes.E4,BassNotes.E3,BassNotes.E2,
                }
            };

            BassLine = new List<BassNoteCollection>();
            List<BassNoteCollection> tempBassList = new List<BassNoteCollection>();

            List<BassNoteCollection> tempBassListA = new List<BassNoteCollection>();

            tempBassList.Add(Efast9);
            tempBassList.Add(E3);
            tempBassList.Add(Efast9);
            tempBassList.Add(E6);

            tempBassList.Add(Efast2);
            tempBassList.Add(E3fast);
            tempBassList.Add(Efast2);
            tempBassList.Add(E6fast);

            tempBassList.Add(Efast2);
            tempBassList.Add(E3fast);
            tempBassList.Add(Efast2);
            tempBassList.Add(E6fast);

            tempBassListA.Add(Afast9);
            tempBassListA.Add(A3);
            tempBassListA.Add(Afast9);
            tempBassListA.Add(A6);

            tempBassListA.Add(Afast2);
            tempBassListA.Add(A3fast);
            tempBassListA.Add(Afast2);
            tempBassListA.Add(A6fast);

            tempBassListA.Add(Afast2);
            tempBassListA.Add(A3fast);
            tempBassListA.Add(Afast2);
            tempBassListA.Add(A6fast);

            //song begins
            BassLine.AddRange(tempBassList);
            BassLine.AddRange(tempBassList);
            BassLine.AddRange(tempBassList);
            BassLine.AddRange(tempBassList);
            BassLine.AddRange(tempBassList);

            BassLine.Add(bassStair);
            BassLine.Add(bassStair);

            BassLine.AddRange(tempBassList);
            BassLine.Add(bassStair);
            BassLine.Add(bassStair);
            BassLine.AddRange(tempBassListA);
            BassLine.AddRange(tempBassListA);

            BassLine.Add(Ebreakdown9);
            BassLine.Add(Ebreak3);
            BassLine.Add(Ebreakdown9);
            BassLine.Add(Ebreak3);
            BassLine.Add(bassStair);
            BassLine.Add(bassStair);
            BassLine.Add(Ebreakdown9);
            BassLine.Add(Ebreak3);
            BassLine.Add(Ebreakdown9);
            BassLine.Add(Ebreak3);

            MelodyNoteCollection melodyBreak = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = ((900 + 300) * 2) + ((200 + 200) * 4),
                MilliSecondsPerSound = 110,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };
            MelodyNoteCollection melodyBreakStair = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 5 * 4 *100,
                MilliSecondsPerSound = 110,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.Silence
                }
            };

            MelodyNoteCollection melodyOne = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                    MelodyNotes.E5,MelodyNotes.E7,MelodyNotes.E5,MelodyNotes.E8,
                }
            };

            MelodyNoteCollection melodyStair = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,
                    MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,
                    MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,
                }
            };

            MelodyNoteCollection melodyStairFive = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E10,MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E5,
                    MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,
                    MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,
                }
            };
            MelodyNoteCollection melodyStair2Five = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E5,
                    MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,
                    MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,MelodyNotes.E1,
                    MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,MelodyNotes.E1,
                }
            };

            MelodyNoteCollection melodyThree = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                }
            };

            MelodyNoteCollection melodyThree2 = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                    MelodyNotes.E2,MelodyNotes.E10,MelodyNotes.E4,MelodyNotes.E9,
                    MelodyNotes.E0,MelodyNotes.E12,MelodyNotes.E1,MelodyNotes.E11,
                }
            };

            MelodyNoteCollection melodyStairTwo = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E9,MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,
                    MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,
                    MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,
                    MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,MelodyNotes.E1,
                }
            };

            MelodyNoteCollection melodyStairThree = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E8,MelodyNotes.E7,MelodyNotes.E6,MelodyNotes.E5,
                    MelodyNotes.E6,MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,
                    MelodyNotes.E5,MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,
                    MelodyNotes.E4,MelodyNotes.E3,MelodyNotes.E2,MelodyNotes.E1,
                    MelodyNotes.E3,MelodyNotes.E2,MelodyNotes.E1,MelodyNotes.E0,
                }
            };

            MelodyNoteCollection melodyTwo = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 100,
                MilliSecondsPerSound = 100,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                    MelodyNotes.H3,MelodyNotes.H5,MelodyNotes.H3,MelodyNotes.H6,
                }
            };

            MelodyNoteCollection melodyFour = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 110,
                MilliSecondsPerSound = 110,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E1,MelodyNotes.E3,MelodyNotes.E1,MelodyNotes.E4,
                    MelodyNotes.E1,MelodyNotes.E3,MelodyNotes.E1,MelodyNotes.E4,
                    MelodyNotes.E1,MelodyNotes.E3,MelodyNotes.E1,MelodyNotes.E4,
                    MelodyNotes.E1,MelodyNotes.E3,MelodyNotes.E1,MelodyNotes.E4,
                }
            };
            MelodyNoteCollection melodyFive = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 110,
                MilliSecondsPerSound = 110,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.E4,MelodyNotes.E6,MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E4,MelodyNotes.E6,MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E4,MelodyNotes.E6,MelodyNotes.E4,MelodyNotes.E7,
                    MelodyNotes.E4,MelodyNotes.E6,MelodyNotes.E4,MelodyNotes.E7,
                }
            };
            MelodyNoteCollection melodySix = new MelodyNoteCollection
            {
                MilliSecondsPerBeat = 110,
                MilliSecondsPerSound = 110,
                Melody = new List<MelodyNotes> 
                {
                    MelodyNotes.G4,MelodyNotes.G6,MelodyNotes.G4,MelodyNotes.G7,
                    MelodyNotes.G4,MelodyNotes.G6,MelodyNotes.G4,MelodyNotes.G7,
                    MelodyNotes.G4,MelodyNotes.G6,MelodyNotes.G4,MelodyNotes.G7,
                    MelodyNotes.G4,MelodyNotes.G6,MelodyNotes.G4,MelodyNotes.G7,
                }
            };

            Guitar = new List<MelodyNoteCollection>();
            PitchedGuitar = new List<MelodyNoteCollection>();

            PitchedGuitar.Add(melodyBreak);
            PitchedGuitar.Add(melodyOne);
            PitchedGuitar.Add(melodyOne);
            PitchedGuitar.Add(melodyStair);
            PitchedGuitar.Add(melodyStair);
            PitchedGuitar.Add(melodyOne);
            PitchedGuitar.Add(melodyBreakStair);
            PitchedGuitar.Add(melodyBreakStair);
            PitchedGuitar.Add(melodyStair);
            PitchedGuitar.Add(melodyStairTwo);
            PitchedGuitar.Add(melodyOne);
            PitchedGuitar.Add(melodyStairThree);
            PitchedGuitar.Add(melodyStair);
            PitchedGuitar.Add(melodyOne);
            PitchedGuitar.Add(melodyStairFive);
            PitchedGuitar.Add(melodyStair2Five);
            PitchedGuitar.Add(melodyStair);
            PitchedGuitar.Add(melodyStair);
            PitchedGuitar.Add(melodyStairFive);
            PitchedGuitar.Add(melodyStair2Five);





            Guitar.Add(melodyBreak);
            Guitar.Add(melodyBreak);

            Guitar.Add(melodyTwo);
            Guitar.Add(melodyStairTwo);
            Guitar.Add(melodyStairTwo);
            Guitar.Add(melodyTwo);
            Guitar.Add(melodyStairTwo);
            Guitar.Add(melodyStair);
            Guitar.Add(melodyStairTwo);
            Guitar.Add(melodyStairThree);
            Guitar.Add(melodyTwo);
            Guitar.Add(melodyStair);
            Guitar.Add(melodyStairTwo);
            Guitar.Add(melodyTwo);
        }
    }
}
