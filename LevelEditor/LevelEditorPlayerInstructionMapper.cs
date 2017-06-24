using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using IOImplementation;
using IOInterface;
using FrameworkContracts;

namespace LevelEditor
{
    public class LevelEditorPlayerInstructionMapper : IPlayerInstructionProvider
    {
        private IPlayerInstructionProvider InstructionMapper { set; get; }
        private IPressedKeyDetector PressedKeyDetector { set; get; }
        private IMouseController MouseController { set; get; }

        private PressedKeyEncapsulator RotationLeft { set; get; }
        private PressedKeyEncapsulator RotationRight { set; get; }
        private PressedKeyEncapsulator Group { set; get; }
        private PressedKeyEncapsulator Ungroup { set; get; }
        private PressedKeyEncapsulator SingleUngroup { set; get; }
        private PressedKeyEncapsulator Copy { set; get; }
        private PressedKeyEncapsulator Paste { set; get; }
        private PressedKeyEncapsulator Create { set; get; }
        private PressedKeyEncapsulator Delete { set; get; }

        private PressedKeyEncapsulator MoveUp { set; get; }
        private PressedKeyEncapsulator MoveDown { set; get; }
        private PressedKeyEncapsulator MoveLeft { set; get; }
        private PressedKeyEncapsulator MoveRight { set; get; }
        private PressedKeyEncapsulator MoveBackward { set; get; }
        private PressedKeyEncapsulator MoveForward { set; get; }
        private PressedKeyEncapsulator NextOptionSelection { set; get; }

        private PressedKeyEncapsulator TextureIncreaseX { set; get; }
        private PressedKeyEncapsulator TextureIncreaseY { set; get; }
        private PressedKeyEncapsulator TextureDecreaseX { set; get; }
        private PressedKeyEncapsulator TextureDecreaseY { set; get; }

        private PressedKeyEncapsulator MirrorX { set; get; }
        private PressedKeyEncapsulator MirrorY { set; get; }

        private PressedKeyEncapsulator SlowMotion { set; get; }

        public LevelEditorPlayerInstructionMapper(IPlayerInstructionProvider playerInstructionMapper, IPressedKeyDetector pressedKeyDetector, IMouseController mouseController)
        {
            InstructionMapper = playerInstructionMapper;
            PressedKeyDetector = pressedKeyDetector;
            MouseController = mouseController;

            RotationLeft = new PressedKeyEncapsulator(Keys.R);
            RotationRight = new PressedKeyEncapsulator(Keys.T);
            Group = new PressedKeyEncapsulator(Keys.G);
            Ungroup = new PressedKeyEncapsulator(Keys.U);
            SingleUngroup = new PressedKeyEncapsulator(Keys.I);
            Copy = new PressedKeyEncapsulator(Keys.C);
            Paste = new PressedKeyEncapsulator(Keys.V);
            Create = new PressedKeyEncapsulator(Keys.Enter);
            Delete = new PressedKeyEncapsulator(Keys.Delete);

            MoveUp = new PressedKeyEncapsulator(Keys.Q);
            MoveDown = new PressedKeyEncapsulator(Keys.E);
            MoveLeft = new PressedKeyEncapsulator(Keys.A);
            MoveRight = new PressedKeyEncapsulator(Keys.D);
            MoveBackward = new PressedKeyEncapsulator(Keys.S);
            MoveForward = new PressedKeyEncapsulator(Keys.W);

            NextOptionSelection = new PressedKeyEncapsulator(Keys.Space);
            TextureIncreaseX = new PressedKeyEncapsulator(Keys.J);
            TextureIncreaseY = new PressedKeyEncapsulator(Keys.O);
            TextureDecreaseX = new PressedKeyEncapsulator(Keys.L);
            TextureDecreaseY = new PressedKeyEncapsulator(Keys.K);

            MirrorX = new PressedKeyEncapsulator(Keys.N);
            MirrorY = new PressedKeyEncapsulator(Keys.M);

            SlowMotion = new PressedKeyEncapsulator(Keys.ShiftRight);
        }

        public IPlayerInstruction GetInput()
        {
            LevelEditorPlayerInstruction levelEditorPlayerInstruction =
                new LevelEditorPlayerInstruction((PlayerInstruction)InstructionMapper.GetInput());

            levelEditorPlayerInstruction.FlyUp = PressedKeyDetector.IsKeyDown(Keys.X);
            levelEditorPlayerInstruction.FlyDown = PressedKeyDetector.IsKeyDown(Keys.Z);

            if (PressedKeyDetector.IsKeyDown(Keys.ControlLeft) || PressedKeyDetector.IsKeyDown(Keys.ControlRight))
                levelEditorPlayerInstruction.MultiSelect = true;

            levelEditorPlayerInstruction.MoveUp = MoveUp.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.MoveDown = MoveDown.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.MoveLeft = MoveLeft.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.MoveRight = MoveRight.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.MoveBackward = MoveBackward.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.MoveForward = MoveForward.KeyWasPressedOnce(PressedKeyDetector);

            levelEditorPlayerInstruction.RotateLeft = RotationLeft.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.RotateRight = RotationRight.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.CreateElement = Create.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.Group = Group.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.Ungroup = Ungroup.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.SingleUngroup = SingleUngroup.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.Copy = Copy.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.Paste = Paste.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.Delete = Delete.KeyWasPressedOnce(PressedKeyDetector);

            levelEditorPlayerInstruction.TextureDecreaseX = TextureDecreaseX.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.TextureDecreaseY = TextureDecreaseY.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.TextureIncreaseX = TextureIncreaseX.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.TextureIncreaseY = TextureIncreaseY.KeyWasPressedOnce(PressedKeyDetector);

            levelEditorPlayerInstruction.NextOptionSelection = NextOptionSelection.KeyWasPressedOnce(PressedKeyDetector);

            levelEditorPlayerInstruction.MirrorX = MirrorX.KeyWasPressedOnce(PressedKeyDetector);
            levelEditorPlayerInstruction.MirrorY = MirrorY.KeyWasPressedOnce(PressedKeyDetector);

            levelEditorPlayerInstruction.SlowMotion = PressedKeyDetector.IsKeyDown(Keys.ShiftRight);

            if (levelEditorPlayerInstruction.NextWeapon)
            {
                levelEditorPlayerInstruction.NextOption = true;
                levelEditorPlayerInstruction.NextWeapon = false;
            }

            if (levelEditorPlayerInstruction.PreviousWeapon)
            {
                levelEditorPlayerInstruction.PreviousOption = true;
                levelEditorPlayerInstruction.PreviousWeapon = false;
            }

            return levelEditorPlayerInstruction;
        }
    }
}
