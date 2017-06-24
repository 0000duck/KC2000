using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseContracts
{
    public interface IListProviderProvider<T>
    {
        IListProvider<T> GetProvider();
    }
}
