using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace DrawableElements
{
    public class FrameCounter : IDrawable
    {
        private IMessageRenderer MessageRenderer { set; get; }
        private DateTime LastSecond { set; get; }
        private int FrameCount { set; get; }

        public FrameCounter(IMessageRenderer messageRenderer)
        {
            MessageRenderer = messageRenderer;
            LastSecond = DateTime.Now;
        }

        public void Draw()
        {
            UpdateMessage();

            if (MessageRenderer is IDrawable)
                (MessageRenderer as IDrawable).Draw();
        }

        private void UpdateMessage()
        {
            FrameCount++;

            DateTime now = DateTime.Now;

            if ((now - LastSecond).TotalMilliseconds > 1000)
            {
                MessageRenderer.RenderMessage(FrameCount.ToString("d"));

                LastSecond = now;
                FrameCount = 0;
            }
        }
    }
}
