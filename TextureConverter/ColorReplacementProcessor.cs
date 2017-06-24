using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using TextureConverter.Contracts;

namespace TextureConverter
{
    public class ColorReplacementProcessor
    {
        private IBitmapColorReplacer _bitmapColorReplacer;

        public ColorReplacementProcessor(IBitmapColorReplacer bitmapColorReplacer)
        {
            _bitmapColorReplacer = bitmapColorReplacer;
        }

        public void ProcessAllBitmapsInFolder(string sourceDirectory, string outputDirectory, IList<IReplacementColor> replacementColors)
        {
            if (Directory.Exists(outputDirectory))
                Directory.Delete(outputDirectory, true);

            ProcessAllBitmapsAndSubfoldersInFolder(sourceDirectory, outputDirectory, sourceDirectory, outputDirectory, replacementColors);
        }

        private void ProcessAllBitmapsAndSubfoldersInFolder(string sourcemainDirectory, string outputmainDirectory, string sourceTempDirectory, string outputTempDirectory, IList<IReplacementColor> replacementColors)
        {
            if (!Directory.Exists(outputTempDirectory))
            {
                Directory.CreateDirectory(outputTempDirectory);
            }

            foreach (string fileName in Directory.GetFiles(sourceTempDirectory, "*.png"))
            {
                Bitmap bitmap = new Bitmap(fileName);

                Bitmap bitmapNewColors = _bitmapColorReplacer.ReplaceColors(bitmap, replacementColors);

             //   bitmapNewColors.MakeTransparent(Color.White);

                string outputFileName = fileName.Replace(sourcemainDirectory, outputmainDirectory);

                bitmapNewColors.Save(outputFileName);
            }

            foreach (string directory in Directory.GetDirectories(sourceTempDirectory))
            {
                string outputDirectory = directory.Replace(sourcemainDirectory, outputmainDirectory);
                ProcessAllBitmapsAndSubfoldersInFolder(sourcemainDirectory, outputmainDirectory, directory, outputDirectory, replacementColors);
            }
        }
    }
}
