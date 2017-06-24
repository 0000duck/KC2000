using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;

namespace MusicPlayer.Provider
{
    public class MelodyCreator
    {
        public Dictionary<MelodyNotes, IComplexSound> CreateBassNotes(ISoundFactory soundFactory, string baseNote, double step)
        {
            Dictionary<MelodyNotes, IComplexSound> dictionary = new Dictionary<MelodyNotes, IComplexSound>();

            dictionary.Add(MelodyNotes.Silence, new Silence());

            dictionary.Add(MelodyNotes.G0, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.G0].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.G1, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.G1].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.G2, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.G2].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.G3, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.G3].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H0, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.H0].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H1, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.H1].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H2, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.H2].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H3, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.H3].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(MelodyNotes.H4, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[MelodyNotes.H4].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            

            for (MelodyNotes note = MelodyNotes.E0; note <= MelodyNotes.E12; note++)
            {
                dictionary.Add(note, (IComplexSound)soundFactory.LoadSound(baseNote, false));
                dictionary[note].SetSpeed((float)Math.Pow(2.0, step / 12.0));
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
