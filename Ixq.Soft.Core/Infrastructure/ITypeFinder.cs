using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ixq.Soft.Core.Infrastructure
{
    public interface ITypeFinder
    {
        IEnumerable<Type> FindTypes<T>();
        IEnumerable<Type> FindTypes(Type type);
        IEnumerable<Type> FindTypes(Type type, IEnumerable<Assembly> assemblies);
    }
}