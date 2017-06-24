using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureMerger.Contracts;
using System.IO;

namespace TextureMerger.Implementations
{
    public class RobotCombiner
    {
        private IFolderCombiner _folderCombiner;

        public RobotCombiner(IFolderCombiner folderCombiner)
        {
            _folderCombiner = folderCombiner;
        }

        public void GenerateCharacter(string characterFolder, string outputFolder)
        {
            if (Directory.Exists(outputFolder))
                Directory.Delete(outputFolder, true);

            Directory.CreateDirectory(outputFolder);

            //standard
            _folderCombiner.CombineFolder("Input\\Metal\\StandardBehaviour", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StandardBehaviour");

            //left foot
            _folderCombiner.CombineFolder("Input\\Metal\\MetalLegLeftFoot", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StepWithLeftFoot");

            //right foot
            _folderCombiner.CombineFolder("Input\\Metal\\MetalLegRightFoot", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StepWithRightFoot");

            //dead
            _folderCombiner.CombineFolder("Input\\Metal\\StandardBehaviour", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\LyingOnFloor");
        }
    }
}
