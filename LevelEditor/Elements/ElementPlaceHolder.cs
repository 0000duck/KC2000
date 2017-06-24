using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using CollisionDetection;
using BaseTypes;
using LevelEditor.Contracts;
using FrameworkContracts;
using BaseContracts;
using CollisionDetection.Contracts;

namespace LevelEditor.Elements
{
    public class ElementPlaceHolder : ImpulseProcessingAnimatableElement, ITranslatable, IRotateble
    {
        public ElementPlaceHolder(IListProvider<IWorldElement> listProvider, IComplexElementFinder complexElementFinder)
            : base(listProvider, complexElementFinder)
        {

        }

        void ITranslatable.Move(bool up, bool down, bool left, bool right, bool forward, bool backward, bool slow)
        {

            double distance = slow ? Constants.PositionChangeSmall : Constants.PositionChange;
            if (up)
            {
                MoveIntoGivenDirection(BaseTypes.Direction.FromFloorToCeiling, distance);
            }

            if (down)
            {
                MoveIntoGivenDirection(BaseTypes.Direction.FromCeilingToFloor, distance);
            }

            if (left)
            {
                MoveIntoGivenDirection(BaseTypes.Direction.FromRightToLeft, distance);
            }

            if (right)
            {
                MoveIntoGivenDirection(BaseTypes.Direction.FromLeftToRight, distance);
            }

            if (forward)
            {
                MoveIntoGivenDirection(BaseTypes.Direction.FromTopToBottom, distance);
            }

            if (backward)
            {
                MoveIntoGivenDirection(BaseTypes.Direction.FromBottomToTop, distance);
            }
        }

        void ITranslatable.BindToFloor()
        {
            if (Position.PositionZ == 0.0)
                return;

            if (Position.PositionZ > 0.0)
            {
                MoveIntoGivenDirection(BaseTypes.Direction.FromCeilingToFloor, Position.PositionZ);
            }

            if (Position.PositionZ < 0.0)
            {
                MoveIntoGivenDirection(BaseTypes.Direction.FromFloorToCeiling, -Position.PositionZ);
            }
        }

        public void RotateLeft(bool degree90 = false)
        {
            if (degree90)
            {
                Orientation += 2;
                if (Orientation > Degree.Degree_315)
                    Orientation = Degree.Degree_0;
                Update();
                return;
            }

            switch (Shape)
            {
                case BaseTypes.Shape.Circle:
                    Orientation++;
                    if (Orientation > Degree.Degree_315)
                        Orientation = Degree.Degree_0;
                    break;
                case BaseTypes.Shape.Rectangle:
                    Orientation+=2;
                    if (Orientation > Degree.Degree_315)
                        Orientation = Degree.Degree_0;
                    break;
            }
            Update();
        }

        public void RotateRight(bool degree90 = false)
        {
            if (degree90)
            {
                Orientation -= 2;
                if (Orientation < Degree.Degree_0)
                    Orientation = Degree.Degree_270;
                Update();
                return;
            }

            switch (Shape)
            {
                case BaseTypes.Shape.Circle:
                    Orientation--;
                    if (Orientation < Degree.Degree_0)
                        Orientation = Degree.Degree_315;
                    break;
                case BaseTypes.Shape.Rectangle:
                    Orientation -= 2;
                    if (Orientation < Degree.Degree_0)
                        Orientation = Degree.Degree_270;
                    break;
            }
            Update();
        }

        private void Update()
        {
            if(Shape == BaseTypes.Shape.Rectangle)
                SetPhysicalAppearance(Shape, Weight, LengthY, LengthX, Height, Radius);

            if (CommunicationElement is IEditorCommunicationElement)
            {
                IVisualParameters currenParameter = (CommunicationElement as IVisualParameterized).GetParameters();
                (CommunicationElement as IEditorCommunicationElement).Update(currenParameter, Orientation);
            }
        }
    }
}
