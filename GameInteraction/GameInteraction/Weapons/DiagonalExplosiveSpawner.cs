using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using IOInterface;
using BaseTypes;

namespace GameInteraction.Weapons
{
    public class DiagonalExplosiveSpawner: IExplosiveSpawner
    {
        private IElementCreator _elementCreator;
        private Vector3D _directionVector;
        private ElementTheme _explosiveTheme;
        private double _metersPerSecond;
        private double _verticalDegree;
        private double _horizontalTranslation;
        private double _additionalDirectionDegree;
        private double _maxVerticalDegree;

        public DiagonalExplosiveSpawner(IElementCreator elementCreator, ElementTheme explosiveTheme, double metersPerSecond, double verticalDegree, double maxVerticalDegree, double horizontalTranslation, double additionalDirectionDegree)
        {
            _elementCreator = elementCreator;
            _explosiveTheme = explosiveTheme;
            _metersPerSecond = metersPerSecond;
            _verticalDegree = verticalDegree;
            _horizontalTranslation = horizontalTranslation;
            _additionalDirectionDegree = additionalDirectionDegree;
            _maxVerticalDegree = maxVerticalDegree;
        }

        void IExplosiveSpawner.CreateNewExplosive(Position3D position, VectorWithDegree directionVector)
        {
            double fullVerticalDegree = directionVector.DegreeZ + _verticalDegree;
            if (fullVerticalDegree > _maxVerticalDegree)
                fullVerticalDegree = _maxVerticalDegree;

            VectorWithDegree newVector = new VectorWithDegree(directionVector.DegreeXY + _additionalDirectionDegree, fullVerticalDegree);
            _directionVector = newVector.Vector;

            Vector2D translationVector = _directionVector.Clone2D(Degree.Degree_270);
            position.PositionX += translationVector.X * _horizontalTranslation;
            position.PositionY += translationVector.Y * _horizontalTranslation;

            _elementCreator.EnqueueNewElement(new SimpleElement { ElementTheme = _explosiveTheme, StartPosition = position }, StartExplosive);
        }

        private void StartExplosive(IWorldElement explosive)
        {
            ((IStraightMovingElement)explosive).StartMovement(_directionVector, _metersPerSecond);
        }
    }
}
