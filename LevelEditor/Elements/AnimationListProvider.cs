using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using LevelEditor.Contracts;

namespace LevelEditor.Elements
{
    public class AnimationListProvider : INameListProvider
    {
         private List<string> List { set; get; }

         public AnimationListProvider(string rootPath)
        {
            List = new List<string>();

            foreach (string directory in Directory.GetDirectories(rootPath))
            {
                if (!directory.Contains("."))
                    List.Add(directory);
            }
        }

        public List<string> GetList()
        {
            return List;
        }
    }
}
