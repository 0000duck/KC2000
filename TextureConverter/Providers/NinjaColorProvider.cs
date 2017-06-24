using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextureConverter.Contracts;
using TextureConverter.Implementations;
using TextureConverter.C64;

namespace TextureConverter.Providers
{
    class NinjaColorProvider : IReplacementColorProvider
    {
        List<IReplacementColor> IReplacementColorProvider.GetListC64(Scenario scenario)
        {
            List<IReplacementColor> list = new List<IReplacementColor>();
            list.Add(new TransparencyDeleter());
            list.Add(new WhiteToTransparencyChanger());

            switch (scenario)
            {
                case Scenario.Standard:
                    list.Add(new ReplacementColor(120, 120, 120, C64Colors.Black));//pumpgun grey
                    list.Add(new ReplacementColor(229, 170, 122, C64Colors.Black));//pants filling
                    list.Add(new ReplacementColor(245, 228, 156, C64Colors.Yellow));//skincolor
                    list.Add(new ReplacementColor(156, 90, 60, C64Colors.Black));//pants edge
                    list.Add(new ReplacementColor(153, 0, 48, C64Colors.Black));//torso edge
                    list.Add(new ReplacementColor(255, 163, 177, C64Colors.Black));//torso filling
                    list.Add(new ReplacementColor(47, 54, 153, C64Colors.Blue));//eyes
                    list.Add(new ReplacementColor(168, 230, 29, C64Colors.Black));//helm filling
                    list.Add(new ReplacementColor(34, 177, 76, C64Colors.Black));//helm edge
                    list.Add(new ReplacementColor(237, 28, 36, C64Colors.Red));//blood
                    break;
            
            }

            return list;
        }
    }
}
