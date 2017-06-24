using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Sound.Contracts;
using Render.Contracts;
using BaseTypes;

namespace FrameworkImplementations
{
    public class VaryingVisualSound : ISound, IDrawable
    {
        private VisualSound[] _visualSounds;
        private int _index;

        public VaryingVisualSound(VisualSound[] visualSounds)
        {
            _visualSounds = visualSounds;
        }

        void IDrawable.Draw()
        {
            ((IDrawable)_visualSounds[_index]).Draw();
        }

        void ISound.Play()
        {
            ((ISound)_visualSounds[_index]).Play();
        }

        void ISound.Stop()
        {
            ((ISound)_visualSounds[_index]).Stop();
        }

        void ISound.SetPosition(float x, float y, float z)
        {
            _index = (int)MathHelper.GetRandomValueInARange(_visualSounds.Length, false);
            if (_index == _visualSounds.Length)
                _index--;
            ((ISound)_visualSounds[_index]).SetPosition(x, y, z);
        }
    }
}
