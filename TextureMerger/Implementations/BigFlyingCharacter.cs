using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureMerger.Contracts;
using System.IO;

namespace TextureMerger.Implementations
{
    public class BigFlyingCharacter
    {
        private IFolderCombiner _folderCombiner;

        public BigFlyingCharacter(IFolderCombiner folderCombiner)
        {
            _folderCombiner = folderCombiner;
        }

        public void GenerateCharacter(string characterFolder, string outputFolder)
        {
            if (Directory.Exists(outputFolder))
                Directory.Delete(outputFolder, true);

            Directory.CreateDirectory(outputFolder);

            //standard
            _folderCombiner.CombineFolder("Input\\Big\\FlyBoard", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StandardBehaviour");

            _folderCombiner.CombineFolder("Input\\Big\\FlyBoard", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\StandardBehaviourH");
        }
    }
}
