using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace Ixq.Soft.Mvc
{
    /// <summary>
    /// <see cref="DataRequest"/> 模型绑定器。继承自 <see cref="DataRequest"/> 的类型都将会使用此绑定器进行绑定。
    /// </summary>
    public class DataRequestModelBinder : IModelBinder
    {
        private readonly IModelBinder _binder;
        private readonly AppConfig _appConfig;

        public DataRequestModelBinder(IModelBinder binder, IOptions<AppConfig> appConfig)
        {
            if (appConfig == null)
            {
                throw new ArgumentNullException(nameof(appConfig));
            }

            _appConfig = appConfig.Value;
            _binder = binder ?? throw new ArgumentNullException(nameof(binder));
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            await _binder.BindModelAsync(bindingContext);

            if (bindingContext.Model is DataRequest dataRequest)
            {
                if (bindingContext.ValueProvider is IEnumerableValueProvider enumerableValueProvider)
                {
                    var keys = enumerableValueProvider.GetKeysFromPrefix(_appConfig.DataQueryParamKeyPrefix);
                    foreach (var thisKey in keys)
                    {
                        var valueResult = enumerableValueProvider.GetValue(thisKey.Value);
                        var thsiValue = valueResult.Values.ToString();
                        if (!string.IsNullOrWhiteSpace(thsiValue)) dataRequest.QueryParam[thisKey.Key] = thsiValue;
                    }

                }
            }
        }
    }
}