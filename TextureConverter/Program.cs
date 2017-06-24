using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureConverter.Contracts;
using TextureConverter.Implementations;
using TextureConverter.Providers;

namespace TextureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //for stndard textures
            //ColorReplacementProcessor processor = new ColorReplacementProcessor(new BitmapColorReplacer());
            //List<IReplacementColor> list = new List<IReplacementColor> { new WhiteToTransparencyChanger() };
            //processor.ProcessAllBitmapsInFolder("mixedstuff", "mixedstuffOutput", list);

            //ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\SoldierShotGun",
            //"SoldierShotGun", new StandardReplacementColorProvider());

            //ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\SoldierRocket",
            //    "SoldierRocket", new BulletProofReplacementColorProvider());

            //ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\SoldierPistol",
            //    "SoldierPistol", new StandardReplacementColorProvider());

            //ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\SoldierMG",
            //    "SoldierMG", new GiantReplacementColorProvider());

            //ReplaceColorsForSoldierWithoutScenario("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\Ninja",
            //    "Ninja", new NinjaColorProvider());

            //ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\FlyingSoldierFlameThrower",
            //  "FlyingSoldierFlameThrower", new GiantReplacementColorProvider());

            //ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Input\\Helicopter",
            //  "Helicopter", new HelicopterReplacementColorProvider());

            //ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\SoldierTank",
            //    "SoldierTank", new GiantReplacementColorProvider());

            //ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\SoldierRobot",
            //    "SoldierRobot", new GiantReplacementColorProvider());

            ReplaceColorsForSoldier("C:\\Users\\Eingeschränkt\\Documents\\Visual Studio 2010\\Projects\\TextureMerger\\bin\\Debug\\Output\\LastRobot",
                "LastRobot", new GiantReplacementColorProvider());
            //CharacterColorReplacementProcessor processorCharacters = new CharacterColorReplacementProcessor(new BitmapColorReplacer(), new WhiteToTransparencyChanger());
            //List<IReplacementColor> list = new List<IReplacementColor> 
            //{  
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Black),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.White),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Blue),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Green),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Yellow),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Red),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Violet),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Cyan),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Orange),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Grey_1),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Grey_2),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Grey_3),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Lightblue),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Lightgreen),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Lightred),
            //    new ReplacementColor(0, 0, 0, C64.C64Colors.Brown)
            //};
            //processorCharacters.ProcessAllBitmapsInFolder("Input\\Characters", "OutputCharacters", list);


            ////ReplaceColorsForSoldier("Input\\Characters",
            ////"OutputCharacters", new StandardReplacementColorProvider());

        }

        private static void ReplaceColorsForSoldier(string soldierInputPath, string soldierName, IReplacementColorProvider replacementColorProvider)
        {
            ColorReplacementProcessor processor = new ColorReplacementProcessor(new BitmapColorReplacer());

            Console.WriteLine(soldierInputPath);

            foreach (Scenario scenario in Enum.GetValues(typeof(Scenario)))
            {
                List<IReplacementColor> list = replacementColorProvider.GetListC64(scenario);

                Console.WriteLine(scenario.ToString());

                processor.ProcessAllBitmapsInFolder(soldierInputPath, "Output\\" + scenario.ToString() + "\\" + soldierName, list);
            }
        }

        private static void ReplaceColorsForSoldierWithoutScenario(string soldierInputPath, string soldierName, IReplacementColorProvider replacementColorProvider)
        {
            ColorReplacementProcessor processor = new ColorReplacementProcessor(new BitmapColorReplacer());

            List<IReplacementColor> list = replacementColorProvider.GetListC64(Scenario.Standard);

            processor.ProcessAllBitmapsInFolder(soldierInputPath, "Output\\" + soldierName, list);  
        }
    }
}
