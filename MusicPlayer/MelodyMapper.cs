using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer
{
    public class MelodyMapper
    {
        public MelodyNotes Map(MelodyNotes melodyNote)
        {
            switch (melodyNote)
            {
                case MelodyNotes.G4:
                    return MelodyNotes.H0;
                case MelodyNotes.G5:
                    return MelodyNotes.H1;
                case MelodyNotes.G6:
                    return MelodyNotes.H2;
                case MelodyNotes.G7:
                    return MelodyNotes.H3;
                case MelodyNotes.G8:
                    return MelodyNotes.H4;
                case MelodyNotes.G9:
                    return MelodyNotes.E0;
                case MelodyNotes.G10:
                    return MelodyNotes.E1;
                case MelodyNotes.G11:
                    return MelodyNotes.E2;
                case MelodyNotes.G12:
                    return MelodyNotes.E3;
                case MelodyNotes.H5:
                    return MelodyNotes.E0;
                case MelodyNotes.H6:
                    return MelodyNotes.E1;
                case MelodyNotes.H7:
                    return MelodyNotes.E2;
                case MelodyNotes.H8:
                    return MelodyNotes.E3;
                case MelodyNotes.H9:
                    return MelodyNotes.E4;
                case MelodyNotes.H10:
                    return MelodyNotes.E5;
                case MelodyNotes.H11:
                    return MelodyNotes.E6;
                case MelodyNotes.H12:
                    return MelodyNotes.E7;
                default:
                    return melodyNote;
            }

        }
    }
}
