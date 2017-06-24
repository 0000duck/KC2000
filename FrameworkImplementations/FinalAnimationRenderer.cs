using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;
using BaseTypes;
using System.Threading;

namespace FrameworkImplementations
{
    public class FinalAnimationRenderer
    {
        private Action _swapBuffer;
        private IDrawable _image;
        private IBackgroundColor _bgColor;
        private IDrawable _faderImage;
        private  IFader _fader;
        private bool _fadedOut;

        public FinalAnimationRenderer(Action swapBuffer, IDrawable image, IBackgroundColor bgColor, IDrawable faderImage, IFader fader)
        {
            _swapBuffer = swapBuffer;
            _image = image;
            _bgColor = bgColor;
            _faderImage = faderImage;
            _fader = fader;
        }

        public void RenderAnimation()
        {
            TimeAndSpeedManager.Reset();

            for (int i = 0; i < 450; i++)
            {
                _bgColor.SetColor();
                _image.Draw();
                _faderImage.Draw();
                _swapBuffer();
                Thread.Sleep(25);
                TimeAndSpeedManager.AddGameTimeInSeconds(0.025);

                if (!_fadedOut && TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds > 8)
                {
                    _fader.FadeOut();
                    _fadedOut = true;
                }
            }

            TimeAndSpeedManager.Reset();
        }
    }
}
