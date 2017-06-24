using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseContracts
{
    public interface IListFilter<T>
    {
        List<T> Apply(IEnumerable<T> list);
    }
}
