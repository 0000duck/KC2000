using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using CollisionDetection;
using CollisionDetection.Elements;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;

namespace ElementImplementations.ComplexElementImplementations
{
    public class ElementComposition : StandardWorldElement, IComposition, IVisualAppearance
    {
        private double LowestX { set; get; }
        private double HighestX { set; get; }
        private double LowestY { set; get; }
        private double HighestY { set; get; }
        private double LowestZ { set; get; }
        private double HighestZ { set; get; }

        public ElementTheme ElementTheme { set; get; }

        public Degree Orientation { set; get; }

        public bool IsMarked { set; get; }

        public ElementComposition()
        {
            Children = new List<IGroupElement>();
            MyCollisionModel = new LargePositionOnRoomFieldModel();

            ResetComparisonValues();
            Position = new Position3D();
        }

        public IList<IGroupElement> Children { get; private set; }

        public void RegisterMovementOfChild(IGroupElement child)
        {
            UpdateBordersByChild(child);
        }

        public void AddChild(IGroupElement child)
        {
            Children.Add(child);
            child.Parent = this;
            RegisterMovementOfChild(child);
        }

        public void RemoveChild(IGroupElement child)
        {
            if (!Children.Contains(child))
                return;

            Children.Remove(child);
            child.Parent = null;
            RecalculateBordersByAllChildren();
        }

        private void ResetComparisonValues()
        {
            LowestX = double.MaxValue;
            LowestY = double.MaxValue;
            HighestX = double.MinValue;
            HighestY = double.MinValue;
            LowestZ = double.MaxValue;
            HighestZ = double.MinValue;
        }

        private void RecalculateBordersByAllChildren()
        {
            ResetComparisonValues();
            foreach (IGroupElement child in Children)
            {
                UpdateBordersByChild(child);
            }
        }

        private void UpdateBordersByChild(IWorldElement child)
        {
            double lowestX = child.Position.PositionX - (child.LengthX / 2.0);
            double highestX = child.Position.PositionX + (child.LengthX / 2.0);
            double lowestY = child.Position.PositionY - (child.LengthY / 2.0);
            double highestY = child.Position.PositionY + (child.LengthY / 2.0);
            double lowestZ = child.Position.PositionZ;
            double highestZ = child.Position.PositionZ + child.Height;

            bool sizeChanged = false;

            if (lowestX < LowestX)
            {
                LowestX = lowestX;
                sizeChanged = true;
            }

            if (lowestY < LowestY)
            {
                LowestY = lowestY;
                sizeChanged = true;
            }

            if (highestX > HighestX)
            {
                HighestX = highestX;
                sizeChanged = true;
            }

            if (highestY > HighestY)
            {
                HighestY = highestY;
                sizeChanged = true;
            }

            if (lowestZ < LowestZ)
            {
                LowestZ = lowestZ;
                sizeChanged = true;
            }

            if (highestZ > HighestZ)
            {
                HighestZ = highestZ;
                sizeChanged = true;
            }

            if (sizeChanged)
            {
                Position.PositionX = (LowestX + HighestX) / 2.0;
                Position.PositionY = (LowestY + HighestY) / 2.0;
                Position.PositionZ = LowestZ;

                SetPhysicalAppearance(Shape.Rectangle, Weight, HighestX - LowestX, HighestY - LowestY, HighestZ - LowestZ);
            }

            if (Parent != null && Parent is IComposition)
                ((IComposition)Parent).RegisterMovementOfChild(this);
        }
    }
}