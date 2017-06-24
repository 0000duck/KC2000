using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using ElementImplementations.CharacterImplementations;
using IOInterface;
using ElementImplementations.CharacterImplementations.DTOs;
using BaseTypes;
using CollisionDetection;
using GameInteractionContracts;
using LevelEditor.Contracts;
using BaseContracts;
using CollisionDetection.Contracts;

namespace LevelEditor.Elements
{
    public class GhostPlayer : ImpulseProcessingAnimatableElement, IExecuteble, IElementGroup
    {
        private ILevelEditorInstruction CurrentInstructions { set; get; }
        private Position3D CameraPosition { set; get; }
        private Position3D LookAtPosition { set; get; }
        private double CameraDegreeX { set; get; }
        private double CameraDegreeY { set; get; }
        private WorldEditor WorldEditor { set; get; }
        private IPlayerInstructionProvider _playerInstructionProvider;

        public GhostPlayer(WorldEditor worldEditor, IListProvider<IWorldElement> listProvider,
            IPlayerInstructionProvider playerInstructionProvider, IComplexElementFinder complexElementFinder, double cameraDegreeX)
            : base(listProvider, complexElementFinder)
        {
            WorldEditor = worldEditor;
            _playerInstructionProvider = playerInstructionProvider;
            CameraDegreeX = cameraDegreeX;
        }

        public override void Render()
        {
            ((IPlayerObserver)CommunicationElement).InterpretPlayerInformation(new PlayerInformation
            {
                PlayerCameraInformation = new CameraParameters
                {
                    CameraPosition = CameraPosition,
                    ViewVector = new VectorWithDegree(CameraDegreeX, CameraDegreeY, true)
                }
            }
             );
        }

        public virtual void ExecuteLogic()
        {
            SetPlayerCommands(_playerInstructionProvider.GetInput());
            InterpretPlayerCommands();

            Orientation = (Degree)(((int)CameraDegreeX / 45) + 1);
        }
        private void InterpretPlayerCommands()
        {
            InterpretMovementCommands();

            SetCameraParameters();
        }

        private void InterpretMovementCommands()
        {
            if (CurrentInstructions.FlyUp)
            {
                Position.PositionZ += TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * 4;
            }

            if (CurrentInstructions.FlyDown)
            {
                Position.PositionZ -= TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * 4;
            }

            Vector2D stepVector = MathHelper.ConvertDegreeToVector(CameraDegreeX);

            if (!CurrentInstructions.WalkForward && !CurrentInstructions.WalkBackward &&
                !CurrentInstructions.WalkLeft && !CurrentInstructions.WalkRight)
                return;
            
            if (CurrentInstructions.WalkBackward)
            {
                stepVector = stepVector.Clone(Degree.Degree_180);
            }
            if (CurrentInstructions.WalkRight)
            {
                stepVector = stepVector.Clone(Degree.Degree_90);
            }
            if (CurrentInstructions.WalkLeft)
            {
                stepVector = stepVector.Clone(Degree.Degree_270);
            }

            stepVector.X *= TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * 8;
            stepVector.Y *= TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond * 8;

            Position.PositionX += stepVector.X;
            Position.PositionY += stepVector.Y;
        }

        private void SetCameraParameters()
        {
            CameraPosition = Position.Clone();
            CameraPosition.PositionZ += Height;

            CameraDegreeX -= CurrentInstructions.ViewXChange * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;

            if (CurrentInstructions.ViewXChange != 0.0)
            { }

            if (CameraDegreeX > 360)
                CameraDegreeX -= 360;
            else if (CameraDegreeX < 0)
                CameraDegreeX += 360;

            CameraDegreeY += CurrentInstructions.ViewYChange * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;

            if (CameraDegreeY > 80)
                CameraDegreeY = 80;
            else if (CameraDegreeY < -80)
                CameraDegreeY = -80;

            Vector3D vector = MathHelper.ConvertDegreeToVector(CameraDegreeX, CameraDegreeY);

            LookAtPosition = CameraPosition.Clone();
            LookAtPosition.PositionX += vector.X;
            LookAtPosition.PositionY += vector.Y;
            LookAtPosition.PositionZ += vector.Z;
        }

        private void SetPlayerCommands(IPlayerInstruction playerInstruction)
        {
            CurrentInstructions = (ILevelEditorInstruction)playerInstruction;
            WorldEditor.EditWorld(CurrentInstructions, CameraPosition,
                    new VectorWithDegree(MathHelper.ConvertDegreeToVector(CameraDegreeX, CameraDegreeY)), this, ListProvider);
        }

        private List<IGroupElement> _children = new List<IGroupElement>();

        IList<IGroupElement> IElementGroup.Children
        {
            get { return _children; }
        }

        void IElementGroup.RemoveChild(IGroupElement child)
        {
            _children.Remove(child);
        }

        void IElementGroup.AddChild(IGroupElement child)
        {
            _children.Add(child);
        }
    }
}
