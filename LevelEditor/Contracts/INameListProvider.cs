using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Contracts
{
    public interface INameListProvider
    {
        List<string> GetList();
    }
}
