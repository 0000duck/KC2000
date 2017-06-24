using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations
{
    public class ResourceComposition : IContentDisposer
    {
        private IResourceCleaner _textures;
        private IResourceCleaner _sounds;

        public ResourceComposition(IResourceCleaner textures, IResourceCleaner sounds)
        {
            _textures = textures;
            _sounds = sounds;
        }

        void IContentDisposer.DisposeTextures()
        {
            _textures.Clear();
        }

        void IContentDisposer.DisposeSounds()
        {
            _sounds.Clear();
        }
    }
}
