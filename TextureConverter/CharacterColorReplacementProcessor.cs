using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using TextureConverter.Contracts;

namespace TextureConverter
{
    public class CharacterColorReplacementProcessor
    {
        private IBitmapColorReplacer _bitmapColorReplacer;
        private IReplacementColor _transparencyColor;

        public CharacterColorReplacementProcessor(IBitmapColorReplacer bitmapColorReplacer, IReplacementColor transparencyColor)
        {
            _bitmapColorReplacer = bitmapColorReplacer;
            _transparencyColor = transparencyColor;
        }

        public void ProcessAllBitmapsInFolder(string sourceDirectory, string outputDirectory, IList<IReplacementColor> replacementColors)
        {
            if (Directory.Exists(outputDirectory))
                Directory.Delete(outputDirectory, true);

            ProcessAllBitmapsAndSubfoldersInFolder(sourceDirectory, outputDirectory, sourceDirectory, outputDirectory, replacementColors);
        }

        private void ProcessAllBitmapsAndSubfoldersInFolder(string sourcemainDirectory, string outputmainDirectory, string sourceTempDirectory, string outputTempDirectory, IList<Contracts.IReplacementColor> replacementColors)
        {
            if (!Directory.Exists(outputTempDirectory))
            {
                Directory.CreateDirectory(outputTempDirectory);
            }

            foreach (string fileName in Directory.GetFiles(sourceTempDirectory, "*.png"))
            {
                int number = 1;
                foreach (Contracts.IReplacementColor color in replacementColors)
                {
                    Bitmap bitmap = new Bitmap(fileName);

                    List<Contracts.IReplacementColor> colors = new List<IReplacementColor>();
                    colors.Add(_transparencyColor);
                    colors.Add(color);

                    Bitmap bitmapNewColors = _bitmapColorReplacer.ReplaceColors(bitmap, colors);

                    string outputFileName = fileName.Replace(sourcemainDirectory, outputmainDirectory);
                    outputFileName = outputFileName.Substring(0, outputFileName.Length - 5) + number.ToString() + ".png";

                    bitmapNewColors.Save(outputFileName);
                    number++;
                }
            }

            foreach (string directory in Directory.GetDirectories(sourceTempDirectory))
            {
                string outputDirectory = directory.Replace(sourcemainDirectory, outputmainDirectory);
                ProcessAllBitmapsAndSubfoldersInFolder(sourcemainDirectory, outputmainDirectory, directory, outputDirectory, replacementColors);
            }
        }
    }
}
