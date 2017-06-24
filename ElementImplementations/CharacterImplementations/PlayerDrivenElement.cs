using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using CollisionDetection;
using GameInteraction.Weapons;
using ElementImplementations.CharacterImplementations.DTOs;
using GameInteraction;
using GameInteraction.BaseImplementations;
using GameInteractionContracts;
using BaseContracts;
using ArtificialIntelligence.Contracts;
using CollisionDetection.Elements;
using CollisionDetection.Contracts;

namespace ElementImplementations.CharacterImplementations
{
    public class PlayerDrivenElement : ImpulseProcessingElement, IVulnerable, IExplosionVulnerable, IExecuteble, IElementGroup, IVisualAppearance
    {
        private IPlayerInstruction CurrentInstructions { set; get; }
        private PercentFader StepPercentFader { set; get; }
        private bool StepIsFinished { set; get; }
        private Vector2D StepVector { set; get; }
        private double _fullHeight;
        private double MaxSpeed { set; get; }
        private double Speed { set; get; }
        private IImpulseConverter DegreeToImpulseConverter { set; get; }
        private ISoundObserver _soundObserver;
        private IElementGroup _equipment;
        private IComplexWeaponFirerer _complexWeaponFirerer;
        private IPlayerObserver _playerObserver;
        private IPlayerInstructionProvider _playerInstructionProvider;
        private IFullVulnerable _playerVulnerability;

        ElementTheme IVisualAppearance.ElementTheme { get; set; }

        Degree IVisualAppearance.Orientation { get; set; }

        bool IVisualAppearance.IsMarked { get; set; }

        private ICameraParameterCalculator _cameraParameterCalculator;
        private ICameraParameters _cameraParameters;
        private IBodyHeightCalculator _bodyHeightCalculator;

        public PlayerDrivenElement(double speed, double fullHeight,
            IListProvider<IWorldElement> listProvider,
            IImpulseConverter degreeToImpulseConverter,
            ISoundObserver soundObserver, IElementGroup equipment, IComplexWeaponFirerer complexWeaponFirerer, IPlayerObserver playerObserver,
            IPlayerInstructionProvider playerInstructionProvider, IFullVulnerable playerVulnerability, IComplexElementFinder complexElementFinder,
            ICameraParameterCalculator cameraParameterCalculator, IBodyHeightCalculator bodyHeightCalculator)
            : base(listProvider, complexElementFinder)
        {
            _soundObserver = soundObserver;
            DegreeToImpulseConverter = degreeToImpulseConverter;
            Speed = speed;
            StepPercentFader = new PercentFader(0.1);
            StepIsFinished = true;
            MaxSpeed = speed;
            _equipment = equipment;
            _complexWeaponFirerer = complexWeaponFirerer;
            _playerObserver = playerObserver;
            _fullHeight = fullHeight;
            _playerInstructionProvider = playerInstructionProvider;
            _playerVulnerability = playerVulnerability;
            _cameraParameterCalculator = cameraParameterCalculator;
            _bodyHeightCalculator = bodyHeightCalculator;
        }

        public void ExecuteLogic()
        {
            CurrentInstructions = _playerInstructionProvider.GetInput();
            InterpretPlayerCommands();

            _playerObserver.InterpretPlayerInformation(new PlayerInformation
            {
                PlayerCameraInformation = _cameraParameters
            });
        }

        private void SetCameraParameters()
        {
            double currentHeight = _bodyHeightCalculator.CalculateBodyHeight(Position, CurrentInstructions.Duck);
            SetPhysicalAppearance(Shape, Weight, LengthX, LengthY, currentHeight, Radius);

            Speed = MaxSpeed * (1 - (_fullHeight - Height));

            _cameraParameters = _cameraParameterCalculator.CalculateCameraParameters(Position, Height, CurrentInstructions.ViewXChange, CurrentInstructions.ViewYChange);
        }

        private void InterpretPlayerCommands()
        {
            SetCameraParameters();

            if (StepIsFinished)
            {
                InterpretMovementCommands();
            }

            double percent = StepPercentFader.GetPercent();

            if (!StepIsFinished)
            {
                foreach (Impulse impulse in DegreeToImpulseConverter.ConvertVectorToImplse(StepVector, Weight, Speed))
                    AddImpulse(impulse); 

                if (percent > 0.99999)
                {
                    StepIsFinished = true;
                }
            }

            InterpretWeaponCommands();
        }

        private void InterpretWeaponCommands()
        {
            Position3D positionOfWeapon = Position.Clone();
            positionOfWeapon.PositionZ += Height;

            _complexWeaponFirerer.SetInstructions(CurrentInstructions, positionOfWeapon, _cameraParameters.ViewVector);
        }

        private void InterpretMovementCommands()
        {
            if (CurrentInstructions.WalkForward && CurrentInstructions.WalkBackward)
            {
                CurrentInstructions.WalkForward = false;
                CurrentInstructions.WalkBackward = false;
            }

            if (CurrentInstructions.WalkLeft && CurrentInstructions.WalkRight)
            {
                CurrentInstructions.WalkLeft = false;
                CurrentInstructions.WalkRight = false;
            }

            //StepVector = MathHelper.ConvertDegreeToVector(_cameraParameters.ViewVector.DegreeXY);
            //if (CurrentInstructions.WalkForward)
            //{
            //    StartNewStep();
            //}
            //if (CurrentInstructions.WalkBackward)
            //{
            //    StepVector = StepVector.Clone(Degree.Degree_180);
            //    StartNewStep();
            //}
            //if (CurrentInstructions.WalkRight)
            //{
            //    StepVector = StepVector.Clone(Degree.Degree_90);
            //    StartNewStep();
            //}
            //if (CurrentInstructions.WalkLeft)
            //{
            //    StepVector = StepVector.Clone(Degree.Degree_270);
            //    StartNewStep();
            //}

            Vector2D mouseDirection = MathHelper.ConvertDegreeToVector(_cameraParameters.ViewVector.DegreeXY);

            Vector2D forwardMovement = null;
            Vector2D sidewardMovement = null;

            if (CurrentInstructions.WalkForward)
            {
                forwardMovement = mouseDirection;
            }
            else if (CurrentInstructions.WalkBackward)
            {
                forwardMovement = mouseDirection.Clone(Degree.Degree_180);
            }

            if (CurrentInstructions.WalkRight)
            {
                sidewardMovement = mouseDirection.Clone(Degree.Degree_90);
            }
            else if (CurrentInstructions.WalkLeft)
            {
                sidewardMovement = mouseDirection.Clone(Degree.Degree_270);
            }

            if (forwardMovement != null && sidewardMovement != null)
            {
                StepVector = new Vector2D
                {
                    X = (forwardMovement.X * 0.7070106) + (sidewardMovement.X * 0.7070106),
                    Y = (forwardMovement.Y * 0.7070106) + (sidewardMovement.Y * 0.7070106)
                };
                StartNewStep();
            }
            else if (forwardMovement != null)
            {
                StepVector = forwardMovement;
                StartNewStep();
            }
            else if (sidewardMovement != null)
            {
                StepVector = sidewardMovement;
                StartNewStep();
            }
        }

        private void StartNewStep()
        {
            StepPercentFader.Start();
            _soundObserver.SetSoundNotfication(CurrentInstructions.Duck ? NoiseLevel.Low : NoiseLevel.Medium, Position);
            StepIsFinished = false;
        }

        IList<IGroupElement> IElementGroup.Children
        {
            get { return _equipment.Children; }
        }

        void IElementGroup.AddChild(IGroupElement child)
        {
            _equipment.AddChild(child);
        }

        void IElementGroup.RemoveChild(IGroupElement child)
        {
            _equipment.RemoveChild(child);
        }

        void IVulnerable.YouGotHit(Position3D position, double destructionStrength, Vector3D directionVector)
        {
            _playerVulnerability.YouGotHit(position, destructionStrength, directionVector);
        }

        void IExplosionVulnerable.YouGotHit(Position3D explosionPosition, double destructionStrength)
        {
            _playerVulnerability.YouGotHit(explosionPosition, destructionStrength);
        }
    }
}
