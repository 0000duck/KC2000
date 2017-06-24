using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sound.Contracts;

namespace MusicPlayer.Provider
{
    public class BassCreator
    {
        public Dictionary<BassNotes, IComplexSound> CreateBassNotes(ISoundFactory soundFactory, string baseNote)
        {
            double step = 1.0;

            Dictionary<BassNotes, IComplexSound> dictionary = new Dictionary<BassNotes, IComplexSound>();

            dictionary.Add(BassNotes.Silence, new Silence());

            dictionary.Add(BassNotes.E0, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            
            dictionary.Add(BassNotes.E1, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.E1].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.E2, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.E2].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.E3, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.E3].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.E4, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.E4].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A0, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A0].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A1, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A1].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A2, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A2].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A3, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A3].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A4, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A4].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A5, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A5].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A6, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A6].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A7, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A7].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A8, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A8].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A9, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A9].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;

            dictionary.Add(BassNotes.A10, (IComplexSound)soundFactory.LoadSound(baseNote, false));
            dictionary[BassNotes.A10].SetSpeed((float)Math.Pow(2.0, step / 12.0));
            step += 1.0;


            BassMapper mapper = new BassMapper();

            dictionary.Add(BassNotes.E5, dictionary[mapper.Map(BassNotes.E5)]);
            dictionary.Add(BassNotes.E6, dictionary[mapper.Map(BassNotes.E6)]);
            dictionary.Add(BassNotes.E7, dictionary[mapper.Map(BassNotes.E7)]);
            dictionary.Add(BassNotes.E8, dictionary[mapper.Map(BassNotes.E8)]);
            dictionary.Add(BassNotes.E9, dictionary[mapper.Map(BassNotes.E9)]);
            dictionary.Add(BassNotes.E10, dictionary[mapper.Map(BassNotes.E10)]);
            dictionary.Add(BassNotes.E11, dictionary[mapper.Map(BassNotes.E11)]);
            dictionary.Add(BassNotes.E12, dictionary[mapper.Map(BassNotes.E12)]);

            foreach (BassNotes bass in dictionary.Keys)
            {
               // dictionary[bass].Play();
            }
            return dictionary;
        }
    }
}
