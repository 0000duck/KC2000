using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using BaseContracts;

namespace IOInterface
{
    public interface IBulletManager
    {
        void AddNewBullet(Position3D position, IWorldElement excludebleSource, VectorWithDegree directionVector, bool upsplittingAmmo, double destructionStrength, TestQuality testQuality, IListProvider<IWorldElement> listProvider);
    }
}
