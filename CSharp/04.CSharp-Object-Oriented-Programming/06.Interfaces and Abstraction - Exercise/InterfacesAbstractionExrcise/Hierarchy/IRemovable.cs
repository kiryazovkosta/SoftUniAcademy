using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchy
{
    public interface IRemovable<out T>
    {
        T Remove();
    }
}
