using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using GameInteractionContracts;
using CollisionDetection.Contracts;
using BaseContracts;

namespace ArtificialIntelligence
{
    public class FollowDecider : IFollowDecider
    {
        private IWorldElementProvider _followerProvider;
        private IViewFieldElementProvider _viewFieldElementProvider;
        private ICollisionDetector _collisionDetector;
        private IListProvider<IWorldElement> _elementListProvider;

        public FollowDecider(IWorldElementProvider followerProvider, IViewFieldElementProvider viewFieldElementProvider, ICollisionDetector collisionDetector, IListProvider<IWorldElement> elementListProvider)
        {
            _followerProvider = followerProvider;
            _viewFieldElementProvider = viewFieldElementProvider;
            _collisionDetector = collisionDetector;
            _elementListProvider = elementListProvider;
        }

        bool IFollowDecider.GotToFollow()
        {
            IWorldElement follower = _followerProvider.GetElement();
            IAnimatable animatableFollower = (IAnimatable)follower;
            IWorldElement testElement = _viewFieldElementProvider.GetViewFieldElement(follower.Position, animatableFollower.Orientation);

            return !_collisionDetector.SimpleCollisionTakesPlace(testElement, testElement.MyCollisionModel, _elementListProvider.GetList());
        }
    }
}
