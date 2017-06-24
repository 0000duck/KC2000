using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer
{
    public class BassMapper
    {
        public BassNotes Map(BassNotes note)
        {
            switch(note)
            {   
                case BassNotes.E5:
                    return BassNotes.A0;
                case BassNotes.E6:
                    return BassNotes.A1;
                case BassNotes.E7:
                    return BassNotes.A2;
                case BassNotes.E8:
                    return BassNotes.A3;
                case BassNotes.E9:
                    return BassNotes.A4;
                case BassNotes.E10:
                    return BassNotes.A5;
                case BassNotes.E11:
                    return BassNotes.A6;
                case BassNotes.E12:
                    return BassNotes.A7;
                default:
                    return note;
            }
        }
    }
}
