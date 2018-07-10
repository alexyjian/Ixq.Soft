using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ixq.Soft.Mvc
{
    /// <summary>
    ///     <see cref="DataRequestModelBinder"/> 提供者。
    /// </summary>
    public class DataRequestModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var modelType = context.Metadata.ModelType;

            if (typeof(DataRequest).IsAssignableFrom(modelType))
            {
                //BUG：循环调用导致 StackOverflowException.
                var modelBiner = context.CreateBinder(context.Metadata);
                var appConfig = context.Services.GetRequiredService<IOptions<AppConfig>>();
                return new DataRequestModelBinder(modelBiner, appConfig);
            }

            return null;
        }
    }
}
