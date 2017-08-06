using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicPlayer.Provider
{
    public class PitchFactorProvider
    {
        public Dictionary<MelodyNotes, float> CreateBassNotes(double step = 15.0)
        {
            Dictionary<MelodyNotes, float> dictionary = new Dictionary<MelodyNotes, float>();

            dictionary.Add(MelodyNotes.G0, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.G1, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.G2, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.G3, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H0, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H1, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H2, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H3, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H4, (float)Math.Pow(2.0, step / 12.0));
            step += 1.0;



            for (MelodyNotes note = MelodyNotes.E0; note <= MelodyNotes.E12; note++)
            {
                dictionary.Add(note, (float)Math.Pow(2.0, step / 12.0));
                step += 1.0;
            }

            MelodyMapper mapper = new MelodyMapper();

            dictionary.Add(MelodyNotes.G4, dictionary[mapper.Map(MelodyNotes.G4)]);
            dictionary.Add(MelodyNotes.G5, dictionary[mapper.Map(MelodyNotes.G5)]);
            dictionary.Add(MelodyNotes.G6, dictionary[mapper.Map(MelodyNotes.G6)]);
            dictionary.Add(MelodyNotes.G7, dictionary[mapper.Map(MelodyNotes.G7)]);
            dictionary.Add(MelodyNotes.G8, dictionary[mapper.Map(MelodyNotes.G8)]);
            dictionary.Add(MelodyNotes.G9, dictionary[mapper.Map(MelodyNotes.G9)]);
            dictionary.Add(MelodyNotes.G10, dictionary[mapper.Map(MelodyNotes.G10)]);
            dictionary.Add(MelodyNotes.G11, dictionary[mapper.Map(MelodyNotes.G11)]);
            dictionary.Add(MelodyNotes.G12, dictionary[mapper.Map(MelodyNotes.G12)]);

            dictionary.Add(MelodyNotes.H5, dictionary[mapper.Map(MelodyNotes.H5)]);
            dictionary.Add(MelodyNotes.H6, dictionary[mapper.Map(MelodyNotes.H6)]);
            dictionary.Add(MelodyNotes.H7, dictionary[mapper.Map(MelodyNotes.H7)]);
            dictionary.Add(MelodyNotes.H8, dictionary[mapper.Map(MelodyNotes.H8)]);
            dictionary.Add(MelodyNotes.H9, dictionary[mapper.Map(MelodyNotes.H9)]);
            dictionary.Add(MelodyNotes.H10, dictionary[mapper.Map(MelodyNotes.H10)]);
            dictionary.Add(MelodyNotes.H11, dictionary[mapper.Map(MelodyNotes.H11)]);
            dictionary.Add(MelodyNotes.H12, dictionary[mapper.Map(MelodyNotes.H12)]);

            return dictionary;
        }

    }
}
