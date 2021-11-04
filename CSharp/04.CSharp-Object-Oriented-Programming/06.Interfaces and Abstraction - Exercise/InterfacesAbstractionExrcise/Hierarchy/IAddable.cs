using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchy
{
    public interface IAddable<in T>
    {
        int Add(T element);
    }
}
