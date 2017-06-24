using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using System.IO;
using BaseTypes;
using Render.Contracts;

namespace FrameworkImplementations.Animation
{
    public class AnimationLoader : IAnimationLoader
    {
        private ITextureLoader TextureLoader { set; get; }

        public AnimationLoader(ITextureLoader textureLoader)
        {
            TextureLoader = textureLoader;
        }

        public IAnimation LoadAnimation(string folderName)
        {
            if (DirectoryContainsPerspectives(folderName))
            {
                return new PerspectiveAnimation(LoadPerspectives(folderName));
            }
            else
            {
                return new Animation(LoadTextureList(folderName));
            }
        }

        public bool TryLoadAnimation(string animationPath, out IAnimation animation)
        {
            animation = null;

            if (!Directory.Exists(animationPath))
                return false;

            if (DirectoryContainsPerspectives(animationPath))
            {
                animation = new PerspectiveAnimation(LoadPerspectives(animationPath));
            }
            else
            {
                animation = new Animation(LoadTextureList(animationPath));
            }
            return true;
        }

        private Dictionary<Degree, List<ITexture>> LoadPerspectives(string animationPath)
        {
            Dictionary<Degree, List<ITexture>> textures = new Dictionary<Degree, List<ITexture>>();

            foreach(Degree degree in Enum.GetValues(typeof(Degree)))
            {
                string degreeFolderName = animationPath + "\\" + degree.ToString();

                if (Directory.Exists(degreeFolderName))
                {
                    textures.Add(degree, LoadTextureList(degreeFolderName));
                }
            }

            return textures;
        }

        private bool DirectoryContainsPerspectives(string animationPath)
        {
            return Directory.GetDirectories(animationPath).Any(x => x.Contains("Degree"));
        }

        private List<ITexture> LoadTextureList(string folderName)
        {
            List<ITexture> textures = new List<ITexture>();

            foreach (string fileName in GetSortedFilenames(Directory.GetFiles(folderName)))
            {
                textures.Add(TextureLoader.LoadTexture(fileName, false));
            }

            return textures;
        }

        string[] GetSortedFilenames(string[] filenames)
        {
            if (filenames.Count() < 10)
                return filenames;

            Dictionary<int, string> namesWithIndex = new Dictionary<int, string>();

            foreach(string filename in filenames)
            {
                string digitPart = filename.Split('\\').Last();
                digitPart = digitPart.Substring(0, digitPart.Length - 4);

                int index = int.Parse(digitPart);

                namesWithIndex.Add(index, filename);
            }

            string[] sortedFilenames = new string[filenames.Count()];

            for (int i = 1; i <= namesWithIndex.Keys.Count; i++)
            {
                sortedFilenames[i - 1] = namesWithIndex[i];
            }

            return sortedFilenames.ToArray();
        }
    }
}
