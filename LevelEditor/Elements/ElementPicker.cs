using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection;
using EnvironmentAnalysis.RayTest.Rays;
using BaseTypes;
using CollisionDetection.Elements;
using LevelEditor.Contracts;
using BaseContracts;

namespace LevelEditor.Elements
{
    public class ElementPicker
    {
        private bool FirePressedLastTime { set; get; }

        public IWorldElement FindSelectedElement(Position3D pickerPosition, VectorWithDegree vector, IWorldElement excludableElement, IListProvider<IWorldElement> listProvider)
        {
            CollisionRay ray = CollisionRayFactory.GenerateRay(pickerPosition, vector, TestingPurpose.SingleRay, TestQuality.High, listProvider, excludableElement);

            while(!ray.TestIsFinished())
            {
                ray.CalculateNextSegment();
            }

            List<CollisionCacheTestResult> resultList = ray.GetCollisionResults();

            foreach (CollisionCacheTestResult result in resultList)
            {
                if (result.CollidedElement != null)
                {
                    return result.CollidedElement;
                }
            }

            return null;
        }

        public bool ItemIsClicked(ILevelEditorInstruction currentInstructions)
        {
            if (currentInstructions.FiredPressed == false)
            {
                FirePressedLastTime = false;
                return false;
            }

            if (currentInstructions.FiredPressed && FirePressedLastTime == false)
            {
                FirePressedLastTime = true;
                return true;
            }
            return false;
        }
    }
}
