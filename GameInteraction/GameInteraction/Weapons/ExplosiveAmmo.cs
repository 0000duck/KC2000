using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace GameInteraction.Weapons
{
    public class ExplosiveAmmo : StandardWorldElement, IVisualAppearance, IComplexAmmo
    {
        private int _count;
        private IExplosiveSpawner _explosiveSpawner;

        public ExplosiveAmmo(IExplosiveSpawner explosiveSpawner, int count)
        {
            _count = count;
            _explosiveSpawner = explosiveSpawner;
        }

        int IComplexAmmo.Count
        {
            get { return _count; }
        }

        AmmoFireResult IComplexAmmo.Fire(Position3D position, VectorWithDegree directionVector)
        {
            if (_count > 0)
            {
                _explosiveSpawner.CreateNewExplosive(position, directionVector);
                _count--;
                return AmmoFireResult.SuccessfullyFired;
            }
            return AmmoFireResult.OutOfAmmo;
        }

        ElementTheme IVisualAppearance.ElementTheme { set; get; }

        Degree IVisualAppearance.Orientation { set; get; }

        bool IVisualAppearance.IsMarked { set; get; }
    }
}
