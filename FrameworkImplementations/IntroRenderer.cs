using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using FrameworkContracts;
using System.Threading;

namespace FrameworkImplementations
{
    public class IntroRenderer
    {
        private Action _swapBuffer;
        private IPercentDrivenSprite _image;

        public IntroRenderer(Action swapBuffer, IPercentDrivenSprite image)
        {
            _swapBuffer = swapBuffer;
            _image = image;
        }

        public void RenderAnimation()
        {
            for (int i = 0; i < 150; i++)
            {
                _image.SetPercent(i / 150.0);
                _image.Draw();
                _swapBuffer();
                Thread.Sleep(1);
            }

            TimeAndSpeedManager.Reset();
        }
    }
}
