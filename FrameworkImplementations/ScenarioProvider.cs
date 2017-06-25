using FrameworkContracts;

namespace FrameworkImplementations
{
    public class ScenarioProvider : IScenarioProvider
    {
        Scenario IScenarioProvider.GetScenario(int levelId)
        {
            return Scenario.CityBlue;
        }
    }
}
