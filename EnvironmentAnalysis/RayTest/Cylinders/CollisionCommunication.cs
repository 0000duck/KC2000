using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection.Elements;
using CollisionDetection;

namespace EnvironmentAnalysis.RayTest.Cylinder
{
    public class CylinderCollisionTestResult
    {
        public BesetPosition UncollidedPositions { set; get; }
        public List<CollisionCacheTestResult> CollisionResults { set; get; }
    }

    public struct CircleInitInfo
    {
        public BesetPosition BesetPositions;
        public int RadiusDivider;
    }

    [Flags]
    public enum BesetPosition
    {
        FirstPosition = 1,
        SecondPosition = 2,
        ThirdPosition = 4
    }
}
