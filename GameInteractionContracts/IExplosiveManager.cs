using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public class ExplosiveInformation
    {
        public IAmmo Explosive { set; get; }

        public DistanceBetweenTwoPositions Distance { set; get; }
    }

    public interface IExplosiveManager
    {
        List<Position3D> FindPositionOfAllActivatedExplosives();

        List<ExplosiveInformation> FindAllActivatedExplosives(Position3D position);
    }
}
