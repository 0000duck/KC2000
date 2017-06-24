using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace CollisionDetection.Elements
{
    public class CollisionCache
    {
        public List<IWorldElement> Elements { set; get; }

        public bool IsEmpty
        {
            get
            {
                return (Elements == null || Elements.Count == 0);
            }
        }
    }

    public class CollisionCacheTestResult
    {
        public Position3D OuterPositionOfCollision { set; get; }

        public IWorldElement CollidedElement { set; get; }

        public bool IsEmpty
        {
            get
            {
                return CollidedElement == null;
            }
        }
    }
}
