using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace GameInteractionContracts
{
    public class EnemyInformation
    {
        public IAnimatable Enemy { set; get; }

        public DistanceBetweenTwoPositions Distance { set; get; }
    }

    public interface IEnemyManager
    {
        List<EnemyInformation> FindEnemies(IAnimatable volitionDrivenElement);

        bool CharactersAreEnemies(ElementTheme themeOne, ElementTheme themeTwo);
    }
}
