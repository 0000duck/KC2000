using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations
{
    public class ScenarioProvider : IScenarioProvider
    {
        Scenario IScenarioProvider.GetScenario(int levelId)
        {
            switch (levelId)
            {
                case 12:
                case 11:
                case 13:
                case 6:
                case 7:
                case 9:
                case 8:
                    return Scenario.CityBlue;
                case 1:
                case 19:
                    return Scenario.DessertLight;
                case 3:
                case 2:
                    return Scenario.DessertDark;
                case 15:
                case 16:
                case 17:
                case 18:
                    return Scenario.JungleDark;
                case 5:
                case 14:
                case 22:
                case 20:
                    return Scenario.Snow;
                case 4:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                    return Scenario.CityBlack;
                default:
                    return Scenario.CityBlue;
            }
        }
    }
}
