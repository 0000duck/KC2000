using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using OpenTK.Input;
using System.Drawing;
using Render.Contracts;

namespace OpenTKPortation.Implementations
{
    public class MouseController : IMouseController
    {
        private MouseDevice MouseDevice { set; get; }

        private IScreen Screen { set; get; }

        private bool LeftButtonPressedLastTime { set; get; }
        private bool RightButtonPressedLastTime { set; get; }

        private const int FixPixelCountForMouseCenter = 200;
        private bool _invertMouse;

        public MouseController(MouseDevice device, IScreen screen, bool invertMouse)
        {
            MouseDevice = device;
            Screen = screen;
            _invertMouse = invertMouse;
        }

        public MouseEvents GetMouseEvents()
        {
            MouseEvents mouseEvents = new MouseEvents();

            mouseEvents.LeftButtonPressed = MouseDevice[MouseButton.Left];
            mouseEvents.RightButtonPressed = MouseDevice[MouseButton.Right];

            if (LeftButtonPressedLastTime && !mouseEvents.LeftButtonPressed)
                mouseEvents.LeftButtonReleased = true;

            if (RightButtonPressedLastTime && !mouseEvents.RightButtonPressed)
                mouseEvents.RightButtonReleased = true;

            LeftButtonPressedLastTime = mouseEvents.LeftButtonPressed;
            RightButtonPressedLastTime = mouseEvents.RightButtonPressed;

            mouseEvents.PositionX = ((double)MouseDevice.X) / ((double)Screen.CurrentResolution.X);
            mouseEvents.PositionY = ((double)Screen.CurrentResolution.Y - MouseDevice.Y) / ((double)Screen.CurrentResolution.Y);
            mouseEvents.PositionX = (mouseEvents.PositionX * Screen.AspectRatio) - ((Screen.AspectRatio - 1) / 2.0f);

            mouseEvents.PositionXRelativeToCenter = System.Windows.Forms.Cursor.Position.X - FixPixelCountForMouseCenter;
            mouseEvents.PositionYRelativeToCenter = FixPixelCountForMouseCenter - System.Windows.Forms.Cursor.Position.Y;

            if (_invertMouse)
                mouseEvents.PositionYRelativeToCenter = mouseEvents.PositionYRelativeToCenter * (-1);

            mouseEvents.WheelDelta = MouseDevice.WheelDelta;

            return mouseEvents;
        }

        public void Reset()
        {
            System.Windows.Forms.Cursor.Position = new Point(FixPixelCountForMouseCenter, FixPixelCountForMouseCenter);
        }
    }
}
