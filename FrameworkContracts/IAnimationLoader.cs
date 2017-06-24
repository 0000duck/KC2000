using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IAnimationLoader
    {
        IAnimation LoadAnimation(string folderName);

        bool TryLoadAnimation(string animationPath, out IAnimation animation);
    }
}
