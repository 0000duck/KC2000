using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseContracts
{
    public interface IListProvider<T>
    {
        IEnumerable<T> GetList();
    }
}
