using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureConverter.Contracts;
using TextureConverter.Implementations;
using TextureConverter.C64;

namespace TextureConverter.Providers
{
    public class GiantReplacementColorProvider : IReplacementColorProvider
    {
        List<IReplacementColor> IReplacementColorProvider.GetListC64(Scenario scenario)
        {
            List<IReplacementColor> list = new List<IReplacementColor>();
            list.Add(new TransparencyDeleter());
            list.Add(new WhiteToTransparencyChanger());

            switch (scenario)
            {
                case Scenario.Standard:
                    list.Add(new ReplacementColor(120, 120, 120, C64Colors.White));//eye grey
                    list.Add(new ReplacementColor(229, 170, 122, C64Colors.Green));//pants filling
                    list.Add(new ReplacementColor(245, 228, 156, C64Colors.Yellow));//skincolor
                    list.Add(new ReplacementColor(156, 90, 60, C64Colors.Grey_1));//pants edge
                    list.Add(new ReplacementColor(153, 0, 48, C64Colors.Grey_1));//torso edge
                    list.Add(new ReplacementColor(255, 163, 177, C64Colors.Green));//torso filling
                    list.Add(new ReplacementColor(47, 54, 153, C64Colors.Blue));//glasses
                    list.Add(new ReplacementColor(168, 230, 29, C64Colors.Yellow));//hellgrün
                    list.Add(new ReplacementColor(237, 28, 36, C64Colors.Red));//blood
                    break;
                case Scenario.DessertLight:
                    list.Add(new ReplacementColor(120, 120, 120, C64Colors.White));//eye grey
                    list.Add(new ReplacementColor(229, 170, 122, C64Colors.Orange));//pants filling
                    list.Add(new ReplacementColor(245, 228, 156, C64Colors.Yellow));//skincolor
                    list.Add(new ReplacementColor(156, 90, 60, C64Colors.Brown));//pants edge
                    list.Add(new ReplacementColor(153, 0, 48, C64Colors.Brown));//torso edge
                    list.Add(new ReplacementColor(255, 163, 177, C64Colors.Orange));//torso filling
                    list.Add(new ReplacementColor(47, 54, 153, C64Colors.Blue));//glasses
                    list.Add(new ReplacementColor(168, 230, 29, C64Colors.Yellow));//hellgrün
                    list.Add(new ReplacementColor(237, 28, 36, C64Colors.Red));//blood
                    break;
                case Scenario.DessertDark:
                    list.Add(new ReplacementColor(120, 120, 120, C64Colors.White));//eye grey
                    list.Add(new ReplacementColor(229, 170, 122, C64Colors.Orange));//pants filling
                    list.Add(new ReplacementColor(245, 228, 156, C64Colors.Brown));//skincolor
                    list.Add(new ReplacementColor(156, 90, 60, C64Colors.Grey_1));//pants edge
                    list.Add(new ReplacementColor(153, 0, 48, C64Colors.Grey_1));//torso edge
                    list.Add(new ReplacementColor(255, 163, 177, C64Colors.Orange));//torso filling
                    list.Add(new ReplacementColor(47, 54, 153, C64Colors.Blue));//glasses
                    list.Add(new ReplacementColor(168, 230, 29, C64Colors.Yellow));//hellgrün
                    list.Add(new ReplacementColor(237, 28, 36, C64Colors.Red));//blood
                    break;
                case Scenario.Snow:
                    list.Add(new ReplacementColor(120, 120, 120, C64Colors.White));//eye grey
                    list.Add(new ReplacementColor(229, 170, 122, C64Colors.White));//pants filling
                    list.Add(new ReplacementColor(245, 228, 156, C64Colors.Yellow));//skincolor
                    list.Add(new ReplacementColor(156, 90, 60, C64Colors.Grey_1));//pants edge
                    list.Add(new ReplacementColor(153, 0, 48, C64Colors.Grey_1));//torso edge
                    list.Add(new ReplacementColor(255, 163, 177, C64Colors.Grey_3));//torso filling
                    list.Add(new ReplacementColor(47, 54, 153, C64Colors.Blue));//glasses
                    list.Add(new ReplacementColor(168, 230, 29, C64Colors.Yellow));//hellgrün
                    list.Add(new ReplacementColor(237, 28, 36, C64Colors.Red));//blood
                    break;
                case Scenario.JungleDark:
                    list.Add(new ReplacementColor(120, 120, 120, C64Colors.White));//eye grey
                    list.Add(new ReplacementColor(229, 170, 122, C64Colors.Green));//pants filling
                    list.Add(new ReplacementColor(245, 228, 156, C64Colors.Brown));//skincolor
                    list.Add(new ReplacementColor(156, 90, 60, C64Colors.Grey_1));//pants edge
                    list.Add(new ReplacementColor(153, 0, 48, C64Colors.Grey_1));//torso edge
                    list.Add(new ReplacementColor(255, 163, 177, C64Colors.Green));//torso filling
                    list.Add(new ReplacementColor(47, 54, 153, C64Colors.Blue));//glasses
                    list.Add(new ReplacementColor(168, 230, 29, C64Colors.Yellow));//hellgrün
                    list.Add(new ReplacementColor(237, 28, 36, C64Colors.Red));//blood
                    break;
                case Scenario.CityBlue:
                    list.Add(new ReplacementColor(120, 120, 120, C64Colors.White));//eye grey
                    list.Add(new ReplacementColor(229, 170, 122, C64Colors.Blue));//pants filling
                    list.Add(new ReplacementColor(245, 228, 156, C64Colors.Yellow));//skincolor
                    list.Add(new ReplacementColor(156, 90, 60, C64Colors.Black));//pants edge
                    list.Add(new ReplacementColor(153, 0, 48, C64Colors.Black));//torso edge
                    list.Add(new ReplacementColor(255, 163, 177, C64Colors.Blue));//torso filling
                    list.Add(new ReplacementColor(47, 54, 153, C64Colors.Blue));//glasses
                    list.Add(new ReplacementColor(168, 230, 29, C64Colors.Yellow));//hellgrün
                    list.Add(new ReplacementColor(237, 28, 36, C64Colors.Red));//blood
                    break;
                case Scenario.CityBlack:
                    list.Add(new ReplacementColor(120, 120, 120, C64Colors.White));//eye grey
                    list.Add(new ReplacementColor(229, 170, 122, C64Colors.Black));//pants filling
                    list.Add(new ReplacementColor(245, 228, 156, C64Colors.Yellow));//skincolor
                    list.Add(new ReplacementColor(156, 90, 60, C64Colors.Black));//pants edge
                    list.Add(new ReplacementColor(153, 0, 48, C64Colors.Black));//torso edge
                    list.Add(new ReplacementColor(255, 163, 177, C64Colors.Red));//torso filling
                    //list.Add(new ReplacementColor(255, 163, 177, C64Colors.Grey_1));//torso filling
                    list.Add(new ReplacementColor(47, 54, 153, C64Colors.Blue));//glasses
                    list.Add(new ReplacementColor(168, 230, 29, C64Colors.Yellow));//hellgrün
                    list.Add(new ReplacementColor(237, 28, 36, C64Colors.Red));//blood
                    break;
            }

            return list;
        }
    }
}
