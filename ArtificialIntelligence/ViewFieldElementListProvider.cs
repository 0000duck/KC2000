using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseContracts;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;
using CollisionDetection.Contracts;

namespace ArtificialIntelligence
{
    public class ViewFieldElementListProvider : IListProvider<IWorldElement>
    {
        private IWorldElementProvider _viewerProvider;
        private Degree _lastUpdatedDegree;
        private Position3D _lastUpdatedPosition;
        private IList<IWorldElement> _worldElementList;
        private double _maxSquareDistanceForUpdate;
        private IViewFieldElementProvider _viewFieldElementProvider;
        private ICollidingElementFinder _collisionDetector;
        private IListProvider<IWorldElement> _listProvider;
        private IUpdateTimer _timer;

        public ViewFieldElementListProvider(IWorldElementProvider viewerProvider, IListProvider<IWorldElement> listProvider,  IUpdateTimer timer, ICollidingElementFinder collisionDetector, IViewFieldElementProvider viewFieldElementProvider, double maxDistanceForUpdate)
        {
            _viewerProvider = viewerProvider;
            _viewFieldElementProvider = viewFieldElementProvider;
            _collisionDetector = collisionDetector;
            _listProvider = listProvider;
            _maxSquareDistanceForUpdate = maxDistanceForUpdate * maxDistanceForUpdate;
            _timer = timer;
        }

        IEnumerable<IWorldElement> IListProvider<IWorldElement>.GetList()
        {
            if (UpdateOfListIsNecessary())
            {
                UpdateList();
            }

            return _worldElementList;
        }

        private void UpdateList()
        {
            IWorldElement viewer = _viewerProvider.GetElement();
            IAnimatable viewerAnimatable = (IAnimatable)viewer;

            _lastUpdatedPosition = viewer.Position.Clone();
            _lastUpdatedDegree = viewerAnimatable.Orientation;

            IWorldElement testElement = _viewFieldElementProvider.GetViewFieldElement(_lastUpdatedPosition, _lastUpdatedDegree);

            _worldElementList = _collisionDetector.FindCollidingElements(testElement, testElement.MyCollisionModel, _listProvider.GetList());

            if (_worldElementList.Contains(viewer))
                _worldElementList.Remove(viewer);
        }

        private bool UpdateOfListIsNecessary()
        {
            if(_lastUpdatedPosition == null)
                return true;

            if (_timer.UpdateIsNecessary())
                return true;

            IWorldElement viewer = _viewerProvider.GetElement();
            IAnimatable viewerAnimatable = (IAnimatable)viewer;

            if (_lastUpdatedDegree != viewerAnimatable.Orientation)
                return true;

            DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(viewer.Position, _lastUpdatedPosition);

            return distance.SquareDistanceXY > _maxSquareDistanceForUpdate;
        }
    }
}
