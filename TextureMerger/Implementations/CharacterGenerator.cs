using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureMerger.Contracts;
using System.IO;

namespace TextureMerger.Implementations
{
    public class CharacterGenerator
    {
        private IFolderCombiner _folderCombiner;

        public CharacterGenerator(IFolderCombiner folderCombiner)
        {
            _folderCombiner = folderCombiner;
        }

        public void GenerateCharacter(string characterFolder, string outputFolder)
        {
            if (Directory.Exists(outputFolder))
                Directory.Delete(outputFolder, true);

            Directory.CreateDirectory(outputFolder);

            //standard
            _folderCombiner.CombineFolder("Input\\StandardBehaviour", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StandardBehaviour");         
            //_folderCombiner.CombineFolder("Input\\StandardBehaviour", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\StandardBehaviourH");
            //_folderCombiner.CombineFolder("Input\\StandardBehaviour", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\StandardBehaviourT");
            //_folderCombiner.CombineFolder("Input\\StandardBehaviour", "Input\\" + characterFolder + "\\TorsoA", outputFolder + "\\StandardBehaviourA");
            
            //_folderCombiner.CombineFolder("Input\\LegsDestroyed", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StandardBehaviourLe");

            //left foot
            _folderCombiner.CombineFolder("Input\\StepWithLeftFoot", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StepWithLeftFoot");         
            _folderCombiner.CombineFolder("Input\\StepWithLeftFoot", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\StepWithLeftFootH");
            _folderCombiner.CombineFolder("Input\\StepWithLeftFoot", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\StepWithLeftFootT");
            _folderCombiner.CombineFolder("Input\\StepWithLeftFoot", "Input\\" + characterFolder + "\\TorsoA", outputFolder + "\\StepWithLeftFootA");

            //right foot
            _folderCombiner.CombineFolder("Input\\StepWithRightFoot", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\StepWithRightFoot");
            _folderCombiner.CombineFolder("Input\\StepWithRightFoot", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\StepWithRightFootH");
            _folderCombiner.CombineFolder("Input\\StepWithRightFoot", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\StepWithRightFootT");
            _folderCombiner.CombineFolder("Input\\StepWithRightFoot", "Input\\" + characterFolder + "\\TorsoA", outputFolder + "\\StepWithRightFootA");

            //ducked
            _folderCombiner.CombineFolder("Input\\LegsDucked", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\Ducked");
            _folderCombiner.CombineFolder("Input\\LegsDucked", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\DuckedH");
            _folderCombiner.CombineFolder("Input\\LegsDucked", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\DuckedT");
            _folderCombiner.CombineFolder("Input\\LegsDucked", "Input\\" + characterFolder + "\\TorsoA", outputFolder + "\\DuckedA");

            //RotateLeft
            _folderCombiner.CombineFolder("Input\\RotateLeft", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\RotateLeft");
            _folderCombiner.CombineFolder("Input\\RotateLeft", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\RotateLeftH");
            _folderCombiner.CombineFolder("Input\\RotateLeft", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\RotateLeftT");
            _folderCombiner.CombineFolder("Input\\RotateLeft", "Input\\" + characterFolder + "\\TorsoA", outputFolder + "\\RotateLeftA");

            //RotateRight
            _folderCombiner.CombineFolder("Input\\RotateRight", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\RotateRight");
            _folderCombiner.CombineFolder("Input\\RotateRight", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\RotateRightH");
            _folderCombiner.CombineFolder("Input\\RotateRight", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\RotateRightT");
            _folderCombiner.CombineFolder("Input\\RotateRight", "Input\\" + characterFolder + "\\TorsoA", outputFolder + "\\RotateRightA");

            //collapse
            _folderCombiner.CombineFolder("Input\\LegsCollapse", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\Collapse");
            _folderCombiner.CombineFolder("Input\\LegsCollapse", "Input\\" + characterFolder + "\\TorsoH", outputFolder + "\\CollapseH");
            _folderCombiner.CombineFolder("Input\\LegsCollapse", "Input\\" + characterFolder + "\\TorsoT", outputFolder + "\\CollapseT");
            _folderCombiner.CombineFolder("Input\\LegsCollapse", "Input\\" + characterFolder + "\\TorsoA", outputFolder + "\\CollapseA");
            _folderCombiner.CombineFolder("Input\\LegsDestroyedCollapse", "Input\\" + characterFolder + "\\Torso", outputFolder + "\\CollapseL");

            //on floor
            _folderCombiner.CombineFolder("Input\\LegsOnFloor", "Input\\" + characterFolder + "\\LyingOnFloor", outputFolder + "\\LyingOnFloor");
            _folderCombiner.CombineFolder("Input\\LegsOnFloorA", "Input\\" + characterFolder + "\\LyingOnFloorA", outputFolder + "\\LyingOnFloorA");
            _folderCombiner.CombineFolder("Input\\LegsOnFloorH", "Input\\" + characterFolder + "\\LyingOnFloorH", outputFolder + "\\LyingOnFloorH");
            _folderCombiner.CombineFolder("Input\\LegsOnFloorL", "Input\\" + characterFolder + "\\LyingOnFloorL", outputFolder + "\\LyingOnFloorL");
            _folderCombiner.CombineFolder("Input\\LegsOnFloorT", "Input\\" + characterFolder + "\\LyingOnFloorT", outputFolder + "\\LyingOnFloorT");
        }
    }
}
