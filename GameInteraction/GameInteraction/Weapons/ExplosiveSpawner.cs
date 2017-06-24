using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using IOInterface;

namespace GameInteraction.Weapons
{
    public class ExplosiveSpawner : IExplosiveSpawner
    {
        private IElementCreator _elementCreator;
        private Vector3D _directionVector;
        private ElementTheme _explosiveTheme;
        private double _metersPerSecond;

        public ExplosiveSpawner(IElementCreator elementCreator, ElementTheme explosiveTheme, double metersPerSecond)
        {
            _elementCreator = elementCreator;
            _explosiveTheme = explosiveTheme;
            _metersPerSecond = metersPerSecond;
        }

        void IExplosiveSpawner.CreateNewExplosive(Position3D position, VectorWithDegree directionVector)
        {
            _directionVector = directionVector.Vector;
            _elementCreator.EnqueueNewElement(new SimpleElement { ElementTheme = _explosiveTheme, StartPosition = position }, StartExplosive);
        }

        private void StartExplosive(IWorldElement explosive)
        {
            ((IStraightMovingElement)explosive).StartMovement(_directionVector, _metersPerSecond);
        }
    }
}
