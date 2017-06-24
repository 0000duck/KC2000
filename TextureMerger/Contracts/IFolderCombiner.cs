using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextureMerger.Contracts
{
    public interface IFolderCombiner
    {
        void CombineFolder(string lowerBodyFolder, string upperBodyFolder, string targetFolder);
    }
}
