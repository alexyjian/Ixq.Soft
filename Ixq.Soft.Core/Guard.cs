using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ixq.Soft.Core.Extensions;

namespace Ixq.Soft.Core
{
    internal static class Guard
    {
        public static T ArgumentNotNull<T>(T argumentValue, string argumentName)
        {
            if (null == argumentValue)
            {
                throw new ArgumentNullException(argumentName, "参数值不能为空。");
            }
            return argumentValue;
        }

        public static string ArgumentNotNullOrEmpty(string argumentValue, string argumentName)
        {
            ArgumentNotNull(argumentValue, argumentName);
            if (string.IsNullOrEmpty(argumentValue))
            {
                throw new ArgumentException("参数值不能为空。", argumentName);
            }
            return argumentValue;
        }

        public static Guid ArgumentNotNullOrEmpty(Guid argumentValue, string argumentName)
        {
            if (argumentValue == Guid.Empty)
            {
                throw new ArgumentException("参数值不能为空。", argumentName);
            }
            return argumentValue;
        }

        public static IEnumerable<T> ArgumentNotNullOrEmpty<T>(IEnumerable<T> argumentValue, string argumentName)
        {
            ArgumentNotNull(argumentValue, argumentName);
            if (!argumentValue.Any())
            {
                throw new ArgumentException("参数值不能为空集合。", argumentName);
            }
            return argumentValue;
        }

        public static string ArgumentNotNullOrWhiteSpace(string argumentValue, string argumentName)
        {
            ArgumentNotNull(argumentValue, argumentName);
            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException("参数值不能为空字符串。", argumentName);
            }

            return argumentValue;
        }

        public static Type ArgumentAssignableTo<T>(Type argumentValue, string argumentName)
        {
            Guard.ArgumentNotNull(argumentValue, argumentName);
            if (!typeof(T).GetTypeInfo().IsAssignableFrom(argumentValue))
            {
                throw new ArgumentException("指定的类型 \"{0}\" 不能分配给类型 \"{1}\".".Fill(
                    argumentValue.FullName,
                    typeof(T).FullName), argumentName);
            }
            return argumentValue;
        }

        public static Type ArgumentAssignableTo(Type targetType, Type argumentValue, string argumentName)
        {
            Guard.ArgumentNotNull(targetType, nameof(targetType));
            Guard.ArgumentNotNull(argumentValue, argumentName);
            if (!targetType.GetTypeInfo().IsAssignableFrom(argumentValue))
            {
                throw new ArgumentException("指定的类型 \"{0}\" 不能分配给类型 \"{1}\".".Fill(
                    argumentValue.FullName,
                    targetType.FullName), argumentName);
            }
            return argumentValue;
        }
    }
}
