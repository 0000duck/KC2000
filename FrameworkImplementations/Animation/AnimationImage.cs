using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace FrameworkImplementations.Animation
{
    public class AnimationImage : IAnimationImage
    {
        private ITexture _texture;
        private bool _isMirrored;

        public AnimationImage(ITexture texture, bool isMirrored)
        {
            _texture = texture;
            _isMirrored = isMirrored;
        }

        ITexture IAnimationImage.Texture
        {
            get { return _texture; }
        }

        bool IAnimationImage.IsMirrored
        {
            get { return _isMirrored; }
        }
    }
}
