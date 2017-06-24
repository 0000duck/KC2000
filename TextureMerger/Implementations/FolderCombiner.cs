using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureMerger.Contracts;
using System.IO;
using System.Drawing;

namespace TextureMerger.Implementations
{
    public class FolderCombiner : IFolderCombiner
    {
        private IImageCombiner _imageCombiner;

        private List<string> _degreeConstants = new List<string> { "Degree_0", "Degree_45", "Degree_90", "Degree_135", "Degree_180", "Degree_225", "Degree_270", "Degree_315"};

        public FolderCombiner(IImageCombiner imageCombiner)
        {
            _imageCombiner = imageCombiner;
        }

        void IFolderCombiner.CombineFolder(string lowerBodyFolder, string upperBodyFolder, string targetFolder)
        {
            foreach (string degree in _degreeConstants)
            {
                MergeFolderContent(lowerBodyFolder + "\\" + degree, upperBodyFolder + "\\" + degree, targetFolder + "\\" + degree);
            }
        }

        private void MergeFolderContent(string lowerBodyFolder, string upperBodyFolder, string targetFolder)
        {
            if (!Directory.Exists(lowerBodyFolder) || !Directory.Exists(upperBodyFolder))
                return;

            Directory.CreateDirectory(targetFolder);

            string[] upperBodyFileNames = Directory.GetFiles(upperBodyFolder);
            
            if (upperBodyFileNames.Count() == 1)
            {
                Bitmap upperBody = new Bitmap(upperBodyFileNames[0]);

                foreach (string fileName in Directory.GetFiles(lowerBodyFolder))
                {
                    Bitmap lowerBody = new Bitmap(fileName);

                    Bitmap result = _imageCombiner.CombineBitmaps(lowerBody, upperBody);
                    result.Save(targetFolder + "\\" + fileName.Split('\\').Last());
                }
            }
            else
            {
                foreach (string fileName in Directory.GetFiles(lowerBodyFolder))
                {
                    Bitmap lowerBody = new Bitmap(fileName);

                    string upperBodyFileName = upperBodyFileNames[0].Substring(0, upperBodyFileNames[0].Length - 5);
                    upperBodyFileName += fileName.Substring(fileName.Length - 5, 5);

                    Bitmap upperBody = new Bitmap(upperBodyFileName);

                    Bitmap result = _imageCombiner.CombineBitmaps(lowerBody, upperBody);
                    result.Save(targetFolder + "\\" + fileName.Split('\\').Last());
                }
            }
        }
    }
}
