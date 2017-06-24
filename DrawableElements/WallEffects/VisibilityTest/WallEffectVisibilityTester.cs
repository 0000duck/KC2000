using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Render.Contracts;
using BloodEffects.Contracts;

namespace DrawableElements.WallEffects.VisibilityTest
{
    public class WallEffectVisibilityTester : IWallEffectVisibilityTester
    {
        private ISimpleTestRay _testRay;

        public WallEffectVisibilityTester(ISimpleTestRay testRay)
        {
            _testRay = testRay;
        }

        bool IWallEffectVisibilityTester.WallEffectIsVisible(IWorldElement wall, SpriteVertices spriteVertices, Position3D bloodPosition, List<IWorldElement> allWalls)
        {
            int numberOfVisibleCorners = 0;

            if (CornerIsVisible(spriteVertices.VertexOne, wall, bloodPosition, allWalls))
                numberOfVisibleCorners++;

            if (numberOfVisibleCorners > 0)
                return true;

            if (CornerIsVisible(spriteVertices.VertexTwo, wall, bloodPosition, allWalls))
                numberOfVisibleCorners++;

            if (numberOfVisibleCorners > 0)
                return true;

            if (CornerIsVisible(spriteVertices.VertexThree, wall, bloodPosition, allWalls))
                numberOfVisibleCorners++;

            if (numberOfVisibleCorners > 0)
                return true;

            if (CornerIsVisible(spriteVertices.VertexFour, wall, bloodPosition, allWalls))
                numberOfVisibleCorners++;

            return numberOfVisibleCorners > 0;
        }

        private bool CornerIsVisible(Vertex vertex, IWorldElement wall, Position3D bloodPosition, List<IWorldElement> allWalls)
        {
            Position3D endPosition = new Position3D { PositionX = vertex.Position.X, PositionY = vertex.Position.Z, PositionZ = vertex.Position.Y };

            return _testRay.FocusedElementIsHitByRay(bloodPosition, endPosition, allWalls, wall);
        }
    }
}
