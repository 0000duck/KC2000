using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LevelEditor.Contracts;

namespace LevelEditor.Elements
{
    public class ImageListProvider : INameListProvider
    {
        private List<string> List { set; get; }

        public ImageListProvider(string rootPath)
        {
            List = new List<string>();

            foreach (string fileName in Directory.GetFiles(rootPath))
            {
                if (fileName.EndsWith("bmp") || fileName.EndsWith("png") || fileName.EndsWith("jpg"))
                    List.Add(fileName);
            }
        }

        public List<string> GetList()
        {
            return List;
        }
    }
}
