using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;


namespace FrameworkImplementations
{
    public class PressedKeyEncapsulator : IKeyPressedOnceDetector
    {
        private bool WasPressedLastTime;

        private Keys _key;
        private IPressedKeyDetector _pressedKeyDetector;

        public PressedKeyEncapsulator(Keys key, IPressedKeyDetector pressedKeyDetector)
        {
            _key = key;
            _pressedKeyDetector = pressedKeyDetector;
        }

        public bool KeyWasPressedOnce()
        {
            bool wasPressed = false;

            if (!WasPressedLastTime)
            {
                wasPressed = _pressedKeyDetector.IsKeyDown(_key);
            }
            WasPressedLastTime = _pressedKeyDetector.IsKeyDown(_key);

            return wasPressed;
        }
    }
}
