using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace FrameworkImplementations
{
    public class TextureCache : ITextureLoader, IResourceCleaner
    {
        private class LoadedTexture
        {
            public ITexture Texture { set; get; }

            public string FileName { set; get; }
        }

        private ITextureLoader TextureLoader { set; get; }

        private List<LoadedTexture> LoadedTextures { set; get; }

        public TextureCache(ITextureLoader textureLoader)
        {
            TextureLoader = textureLoader;
            LoadedTextures = new List<LoadedTexture>();
        }

        ITexture ITextureLoader.LoadTexture(string texturePath, bool mipMap)
        {
            LoadedTexture loadedTexture = LoadedTextures.Find(x=>x.FileName.Equals(texturePath));

            if (loadedTexture == null)
            {
                ITexture texture = TextureLoader.LoadTexture(texturePath, mipMap);
                loadedTexture = new LoadedTexture { Texture = texture, FileName = texturePath };
                LoadedTextures.Add(loadedTexture);
            }

            return loadedTexture.Texture;
        }

        void ITextureLoader.DeleteTexture(ITexture texture)
        {
            TextureLoader.DeleteTexture(texture);
        }

        void IResourceCleaner.Clear()
        {
            foreach (LoadedTexture loadedTexture in LoadedTextures)
            {
                TextureLoader.DeleteTexture(loadedTexture.Texture);
            }

            LoadedTextures.Clear();
        }
    }
}
