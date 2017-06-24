using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IRectangle
    {
        void DrawAnimation(double percentOfAnimation);

        void Draw();

        void SetPosition(double leftCornerX, double leftCornerY);
    }
}
