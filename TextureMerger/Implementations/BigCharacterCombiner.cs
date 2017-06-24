using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureMerger.Contracts;
using System.IO;

namespace TextureMerger.Implementations
{
    public class BigCharacterCombiner
    {
        private IFolderCombiner _folderCombiner;

        public BigCharacterCombiner(IFolderCombiner folderCombiner)
        {
            _folderCombiner = folderCombiner;
        }

        public void GenerateCharacter(string characterFolder, string outputFolder)
        {
            if (Directory.Exists(outputFolder))
                Directory.Delete(outputFolder, true);

            Directory.CreateDirectory(outputFolder);

            //standard
            _folderCombiner.CombineFolder("Input\\Big\\StandardBehaviour", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StandardBehaviour");

            //left foot
            _folderCombiner.CombineFolder("Input\\Big\\StepWithLeftFoot", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StepWithLeftFoot");
            _folderCombiner.CombineFolder("Input\\Big\\StepWithLeftFoot", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\StepWithLeftFootH");
            _folderCombiner.CombineFolder("Input\\Big\\StepWithLeftFoot", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\StepWithLeftFootT");

            //right foot
            _folderCombiner.CombineFolder("Input\\Big\\StepWithRightFoot", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StepWithRightFoot");
            _folderCombiner.CombineFolder("Input\\Big\\StepWithRightFoot", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\StepWithRightFootH");
            _folderCombiner.CombineFolder("Input\\Big\\StepWithRightFoot", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\StepWithRightFootT");

            ////RotateLeft
            _folderCombiner.CombineFolder("Input\\Big\\RotateLeft", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\RotateLeft");
            _folderCombiner.CombineFolder("Input\\Big\\RotateLeft", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\RotateLeftH");
            _folderCombiner.CombineFolder("Input\\Big\\RotateLeft", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\RotateLeftT");

            ////RotateRight
            _folderCombiner.CombineFolder("Input\\Big\\RotateRight", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\RotateRight");
            _folderCombiner.CombineFolder("Input\\Big\\RotateRight", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\RotateRightH");
            _folderCombiner.CombineFolder("Input\\Big\\RotateRight", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\RotateRightT");

            ////collapse
            _folderCombiner.CombineFolder("Input\\Big\\LegsCollapse", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\Collapse");
            _folderCombiner.CombineFolder("Input\\Big\\LegsCollapse", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\CollapseH");
            _folderCombiner.CombineFolder("Input\\Big\\LegsCollapse", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\CollapseT");
            _folderCombiner.CombineFolder("Input\\Big\\LegsDestroyedCollapse", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\CollapseL");

            ////on floor
            _folderCombiner.CombineFolder("Input\\Big\\LegsOnFloor", "Input\\" + characterFolder + "\\LyingOnFloor", outputFolder + "\\LyingOnFloor");
            _folderCombiner.CombineFolder("Input\\Big\\LegsOnFloor", "Input\\" + characterFolder + "\\LyingOnFloorH", outputFolder + "\\LyingOnFloorH");
            _folderCombiner.CombineFolder("Input\\Big\\LegsOnFloorL", "Input\\" + characterFolder + "\\LyingOnFloorL", outputFolder + "\\LyingOnFloorL");
            _folderCombiner.CombineFolder("Input\\Big\\LegsOnFloorT", "Input\\" + characterFolder + "\\LyingOnFloorT", outputFolder + "\\LyingOnFloorT");
        }
    }
}
