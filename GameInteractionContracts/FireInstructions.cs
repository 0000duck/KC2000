using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using CollisionDetection;
using BaseContracts;

namespace GameInteractionContracts
{
    public class FireInstructions
    {
        public Position3D Position { set; get; }
        public Vector3D DirectionVector { set; get; }
        public VectorWithDegree DirectionVectorWithDegree { set; get; }
        public IWorldElement BulletproofSource { set; get; }
        public double CollectedStrength { set; get; }
        public bool InfiniteAmmo { set; get; }
        public TestQuality TestQuality { set; get; }
        public IListProvider<IWorldElement> CustomicedListProvider { set; get; }
    }
}
