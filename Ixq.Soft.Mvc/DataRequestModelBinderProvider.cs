using System;
using System.Collections.Generic;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
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
                var complexTypeProvider = new ComplexTypeModelBinderProvider();
                var modelBiner = complexTypeProvider.GetBinder(context);

                var appConfig = context.Services.GetRequiredService<IOptions<AppConfig>>();
                return new DataRequestModelBinder(modelBiner, appConfig);
            }

            return null;
        }
    }
}
