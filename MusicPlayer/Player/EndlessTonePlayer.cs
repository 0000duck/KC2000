using Sound.Contracts;
using System;
using System.Collections.Generic;


namespace MusicPlayer.Player
{
    public class EndlessTonePlayer : IPlayer
    {
        private Dictionary<MelodyNotes, float> _pitchfactors;
        private IComplexSound _sound;
        private int _millisecondsPerTone;
        private int _noteIndex;
        private int _durationOfCurrentNote;
        private MelodyNotes[] _notes;

        public EndlessTonePlayer(Dictionary<MelodyNotes, float> pitchfactors, 
            IComplexSound sound, 
            int millisecondsPerTone,
            MelodyNotes[] notes)
        {
            _pitchfactors = pitchfactors;
            _sound = sound;
            _millisecondsPerTone = millisecondsPerTone;
            _notes = notes;
            _sound.Play();
        }

        public bool IsFinished()
        {
            if (_noteIndex >= _notes.Length)
                return true;

            return false;
        }

        public void Play(int milliSeconds)
        {
            if (IsFinished())
                return;

            float pitch = 1;
            float targetPitchFactor = 1;

            if (_durationOfCurrentNote >= _millisecondsPerTone)
            {
                _noteIndex++;
                if (IsFinished())
                    return;

                targetPitchFactor = _pitchfactors[_notes[_noteIndex]];
                _durationOfCurrentNote = 0;
            }
            else
            {
                targetPitchFactor = _pitchfactors[_notes[_noteIndex]];
                pitch = targetPitchFactor;

            }
            _sound.SetSpeed(pitch);

            _durationOfCurrentNote += milliSeconds;
        }
    }
}
