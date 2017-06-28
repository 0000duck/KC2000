using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using FrameworkContracts;
using IOInterface;
using IOImplementation;

namespace FrameworkImplementations.Player
{
    public class PlayerInstructionMapper : IPlayerInstructionProvider
    {
        private IPressedKeyDetector PressedKeyDetector { set; get; }
        private IMouseController MouseController { set; get; }
        private PressedKeyEncapsulator One { set; get; }
        private PressedKeyEncapsulator Two { set; get; }
        private PressedKeyEncapsulator Three { set; get; }
        private PressedKeyEncapsulator Four { set; get; }
        private PressedKeyEncapsulator Five { set; get; }
        private PressedKeyEncapsulator Six { set; get; }
        private PressedKeyEncapsulator Seven { set; get; }
        private PressedKeyEncapsulator Eight { set; get; }
        private PressedKeyEncapsulator Nine { set; get; }
        private PressedKeyEncapsulator Zero { set; get; }
        private PressedKeyEncapsulator OpenDoor { set; get; }
        private PressedKeyEncapsulator OpenDoorAlt { set; get; }
        private double _mouseSensitivity;

        public PlayerInstructionMapper(IPressedKeyDetector pressedKeyDetector, IMouseController mouseController, int mouseSensitivity)
        {
            PressedKeyDetector = pressedKeyDetector;
            MouseController = mouseController;
            One = new PressedKeyEncapsulator(Keys.Num1, pressedKeyDetector);
            Two = new PressedKeyEncapsulator(Keys.Num2, pressedKeyDetector);
            Three = new PressedKeyEncapsulator(Keys.Num3, pressedKeyDetector);
            Four = new PressedKeyEncapsulator(Keys.Num4, pressedKeyDetector);
            Five = new PressedKeyEncapsulator(Keys.Num5, pressedKeyDetector);
            Six = new PressedKeyEncapsulator(Keys.Num6, pressedKeyDetector);
            Seven = new PressedKeyEncapsulator(Keys.Num7, pressedKeyDetector);
            Eight = new PressedKeyEncapsulator(Keys.Num8, pressedKeyDetector);
            Nine = new PressedKeyEncapsulator(Keys.Num9, pressedKeyDetector);
            Zero = new PressedKeyEncapsulator(Keys.Num0, pressedKeyDetector);
            OpenDoor = new PressedKeyEncapsulator(Keys.Enter, pressedKeyDetector);
            OpenDoorAlt = new PressedKeyEncapsulator(Keys.E, pressedKeyDetector);
            _mouseSensitivity = mouseSensitivity;
        }

        public IPlayerInstruction GetInput()
        {
            PlayerInstruction instruction = new PlayerInstruction();

            //keyboard
            if (PressedKeyDetector.IsKeyDown(Keys.Up))
            {
                instruction.WalkForward = true;
            }
            if (PressedKeyDetector.IsKeyDown(Keys.Down))
            {
                instruction.WalkBackward = true;
            }
            if (PressedKeyDetector.IsKeyDown(Keys.Left))
            {
                instruction.WalkLeft = true;
            }
            if (PressedKeyDetector.IsKeyDown(Keys.Right))
            {
                instruction.WalkRight = true;
            }

            if (OpenDoor.KeyWasPressedOnce() || OpenDoorAlt.KeyWasPressedOnce())
            {
                instruction.OpenDoor = true;
            }

            if (PressedKeyDetector.IsKeyDown(Keys.F6))
            {
                instruction.Save = true;
            }

            instruction.Duck = PressedKeyDetector.IsKeyDown(Keys.ControlRight) || PressedKeyDetector.IsKeyDown(Keys.Space);

            MouseEvents mouseEvents = MouseController.GetMouseEvents();

            int wheelDifference = mouseEvents.WheelDelta;

            if (wheelDifference > 0)
            {
                instruction.NextWeapon = true;
            }

            if (wheelDifference < 0)
            {
                instruction.PreviousWeapon = true;
            }

            //mouse position
            double differenceX = mouseEvents.PositionXRelativeToCenter;
            double differenceY = mouseEvents.PositionYRelativeToCenter;

            instruction.ViewXChange = -differenceX * _mouseSensitivity;
            instruction.ViewYChange = differenceY * _mouseSensitivity;

            //mouse buttons
            instruction.FiredPressed = mouseEvents.LeftButtonPressed;

            MouseController.Reset();

            //numbers
            if (One.KeyWasPressedOnce())
                instruction.Number = 1;
            if (Two.KeyWasPressedOnce())
                instruction.Number = 2;
            if (Three.KeyWasPressedOnce())
                instruction.Number = 3;
            if (Four.KeyWasPressedOnce())
                instruction.Number = 4;
            if (Five.KeyWasPressedOnce())
                instruction.Number = 5;
            if (Six.KeyWasPressedOnce())
                instruction.Number = 6;
            if (Seven.KeyWasPressedOnce())
                instruction.Number = 7;
            if (Eight.KeyWasPressedOnce())
                instruction.Number = 8;
            if (Nine.KeyWasPressedOnce())
                instruction.Number = 9;
            if (Zero.KeyWasPressedOnce())
                instruction.Number = 0;

            return instruction;
        }
    }
}
