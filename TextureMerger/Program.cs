using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureMerger.Implementations;

namespace TextureMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterGenerator characterGenerator = new CharacterGenerator(new FolderCombiner(new ImageCombiner()));

            //characterGenerator.GenerateCharacter("SoldierShotGun", "Output\\SoldierShotGun");
            //characterGenerator.GenerateCharacter("SoldierRocket", "Output\\SoldierRocket");
            //characterGenerator.GenerateCharacter("SoldierPistol", "Output\\SoldierPistol");


            //BigCharacterCombiner characterGeneratorBig = new BigCharacterCombiner(new FolderCombiner(new ImageCombiner()));
            //characterGeneratorBig.GenerateCharacter("SoldierMG", "Output\\SoldierMG");


            //BigFlyingCharacter characterGeneratorFly = new BigFlyingCharacter(new FolderCombiner(new ImageCombiner()));
            //characterGeneratorFly.GenerateCharacter("FlyingSoldierFlameThrower", "Output\\FlyingSoldierFlameThrower");

            //NinjaGenerator characterGeneratorN = new NinjaGenerator(new FolderCombiner(new ImageCombiner()));
            //characterGeneratorN.GenerateCharacter("Ninja", "Output\\Ninja");

            //TankCombiner characterGeneratorT = new TankCombiner(new FolderCombiner(new ImageCombiner()));
            //characterGeneratorT.GenerateCharacter("Seargent", "Output\\SoldierTank");

            RobotCombiner characterGeneratorRobot = new RobotCombiner(new FolderCombiner(new ImageCombiner()));
            characterGeneratorRobot.GenerateCharacter("Robot", "Output\\SoldierRobot");

            //RobotCombiner characterGeneratorRobot2 = new RobotCombiner(new FolderCombiner(new ImageCombiner()));
            //characterGeneratorRobot2.GenerateCharacter("LastRobot", "Output\\LastRobot");
        }
    }
}
