using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public class MouseEvents
    {
        public double PositionX { set; get; }

        public double PositionY { set; get; }

        public int WheelDelta { get; set; }

        public double PositionXRelativeToCenter { get; set; }

        public double PositionYRelativeToCenter { get; set; }

        public bool LeftButtonPressed { get; set; }

        public bool RightButtonPressed { get; set; }

        public bool LeftButtonReleased { get; set; }

        public bool RightButtonReleased { get; set; }
    }
}
