using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Ixq.Soft.Core.Infrastructure
{
    /// <summary>
    /// appDomain 类型查找器。
    /// </summary>
    public class AppDomainTypeFinder : ITypeFinder
    {
        public string AssemblySkipLoadingPattern { get; set; } =
            "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";

        public string AssemblyRestrictToLoadingPattern { get; set; } = ".*";
        public bool LoadAppDomainAssemblies { get; set; } = true;
        public bool IgnoreReflectionErrors { get; set; } = true;

        public IEnumerable<Type> FindTypes<T>()
        {
            return FindTypes(typeof(T));
        }

        public IEnumerable<Type> FindTypes(Type type)
        {
            return FindTypes(type, GetAppDomainAssembly());
        }

        public IEnumerable<Type> FindTypes(Type type, IEnumerable<Assembly> assemblies)
        {
            var result = new List<Type>();
            try
            {
                foreach (var a in assemblies)
                {
                    Type[] types = null;
                    try
                    {
                        types = a.GetTypes();
                    }
                    catch
                    {
                        //Entity Framework 6 doesn't allow getting types (throws an exception)
                        if (!IgnoreReflectionErrors)
                            throw;
                    }
                    if (types != null)
                        foreach (var t in types)
                            if (type.IsAssignableFrom(t) ||
                                type.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(t, type))
                                if (!t.IsInterface && !t.IsAbstract)
                                    result.Add(t);
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var msg = string.Empty;
                foreach (var e in ex.LoaderExceptions)
                    msg += e.Message + Environment.NewLine;

                var fail = new Exception(msg, ex);

                throw fail;
            }
            return result;
        }


        protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    var isMatch =
                        genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return isMatch;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        protected List<Assembly> GetAppDomainAssembly()
        {
            var assemblies = new List<Assembly>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (Matches(assembly.FullName))
                    assemblies.Add(assembly);

            GetBinAssembly(assemblies);

            return assemblies;
        }

        private void GetBinAssembly(List<Assembly> assemblies)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            var files = Directory.GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                .Concat(Directory.GetFiles(path, "*.exe", SearchOption.TopDirectoryOnly))
                .ToArray();

            var binAssemblies = files.Select(Assembly.LoadFrom).Distinct()
                .Where(x => !assemblies.Contains(x) && Matches(x.FullName))
                .ToArray();

            foreach (var assembly in binAssemblies)
                if (Matches(assembly.FullName))
                {
                    AppDomain.CurrentDomain.Load(assembly.GetName());
                    assemblies.Add(assembly);
                }
        }

        protected virtual bool Matches(string assemblyFullName, string pattern)
        {
            return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        private bool Matches(string assemblyFullName)
        {
            return !Matches(assemblyFullName, AssemblySkipLoadingPattern)
                   && Matches(assemblyFullName, AssemblyRestrictToLoadingPattern);
        }
    }
}