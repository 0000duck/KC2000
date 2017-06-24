using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using EnvironmentAnalysis.RayTest.Rays;
using BaseContracts;
using CollisionDetection.Elements;

namespace ArtificialIntelligence
{
    public class VisibilityTester : IVisibilityTester
    {
        private CollisionRay _ray;
        private double _maxVisibilityTestDistance;
        private IWorldElement _visibilityTestElement;
        private bool _elementIsVisible;

        public VisibilityTester(double maxVisibilityTestDistance)
        {
            _maxVisibilityTestDistance = maxVisibilityTestDistance;
        }

        void IVisibilityTester.StartVisibilityTest(IWorldElement viewingElement, IWorldElement visibilityTestElement, IListProvider<IWorldElement> listProvider)
        {
            if (viewingElement == null || visibilityTestElement == null)
                return;

            _visibilityTestElement = visibilityTestElement;

            if (ViewerIsAboveElement(viewingElement, visibilityTestElement))
            {
                _ray = null;
                _elementIsVisible = false;
                return;
            }

            Position3D startPosition = viewingElement.Position.Clone();
            startPosition.PositionZ += viewingElement.Height;

            Position3D lookAtPosition = _visibilityTestElement.Position.Clone();
            lookAtPosition.PositionZ += _visibilityTestElement.Height;

            _ray = CollisionRayFactory.GenerateRay(startPosition, lookAtPosition, TestQuality.Low, listProvider, viewingElement, _maxVisibilityTestDistance);
        }

        private bool ViewerIsAboveElement(IWorldElement viewingElement, IWorldElement visibilityTestElement)
        {
            if (viewingElement.Position.PositionZ > visibilityTestElement.Position.PositionZ + visibilityTestElement.Height)
            {
                DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(viewingElement.Position, visibilityTestElement.Position);

                if (distance.SquareDistanceXY < viewingElement.Radius * viewingElement.Radius)
                    return true;
            }
            return false;
        }

        bool IVisibilityTester.Testing()
        {
            if (_ray == null)
                return false;

            if (_ray.TestIsFinished())
            {
                _elementIsVisible = false;
                List<CollisionCacheTestResult>  result = _ray.GetCollisionResults();
                foreach (CollisionCacheTestResult cacheResult in result)
                {
                    if (cacheResult.CollidedElement != null)
                    {
                        if (cacheResult.CollidedElement == _visibilityTestElement)
                            _elementIsVisible = true;
                    }
                }
                _ray = null;
                return false;
            }
            else
            {
                _ray.CalculateNextSegment();
                return true;
            }
        }

        bool IVisibilityTester.ElementIsVisible()
        {
            return _elementIsVisible;
        }
    }
}
