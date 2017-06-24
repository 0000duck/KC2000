using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;


namespace LevelEditor
{
    public class PressedKeyEncapsulator
    {
        private bool WasPressedLastTime { set; get; }

        private Keys Key { set; get; }

        public PressedKeyEncapsulator(Keys key)
        {
            Key = key;
        }

        public bool KeyWasPressedOnce(IPressedKeyDetector keyboardState)
        {
            bool wasPressed = false;

            if (!WasPressedLastTime)
            {
                wasPressed = keyboardState.IsKeyDown(Key);
            }
            WasPressedLastTime = keyboardState.IsKeyDown(Key);

            return wasPressed;
        }
    }
}
