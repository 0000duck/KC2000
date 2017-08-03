using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaletteApplier
{
    class DirectoryParser
    {
        public void ApplyPaletteForDirectory(string sourceDirectory, string outputDirectory)
        {
            if (Directory.Exists(outputDirectory))
                Directory.Delete(outputDirectory, true);
            Directory.CreateDirectory(outputDirectory);

            ProcessAllBitmapsAndSubfoldersInFolder(sourceDirectory, outputDirectory, sourceDirectory, outputDirectory);
        }

        private void ProcessAllBitmapsAndSubfoldersInFolder(string sourcemainDirectory, string outputmainDirectory, string sourceTempDirectory, string outputTempDirectory)
        {
            if (!Directory.Exists(outputTempDirectory))
            {
                Directory.CreateDirectory(outputTempDirectory);
            }

            PaletteAplier paletteAplier = new PaletteAplier();
            foreach (string fileName in Directory.GetFiles(sourceTempDirectory, "*.png"))
            {
                ApplyPaletteForBitmap(sourcemainDirectory, outputmainDirectory, paletteAplier, fileName);
            }
            foreach (string fileName in Directory.GetFiles(sourceTempDirectory, "*.bmp"))
            {
                ApplyPaletteForBitmap(sourcemainDirectory, outputmainDirectory, paletteAplier, fileName);
            }

            foreach (string directory in Directory.GetDirectories(sourceTempDirectory))
            {
                string outputDirectory = directory.Replace(sourcemainDirectory, outputmainDirectory);
                ProcessAllBitmapsAndSubfoldersInFolder(sourcemainDirectory, outputmainDirectory, directory, outputDirectory);
            }
        }

        private static void ApplyPaletteForBitmap(string sourcemainDirectory, string outputmainDirectory, PaletteAplier paletteAplier, string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);

            Bitmap bitmapNewColors = paletteAplier.Apply(bitmap);

            //   bitmapNewColors.MakeTransparent(Color.White);

            string outputFileName = fileName.Replace(sourcemainDirectory, outputmainDirectory);

            bitmapNewColors.Save(outputFileName);
            bitmap.Dispose();
            bitmapNewColors.Dispose();
        }
    }
}
