using Ixq.Soft.Core.Ioc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            var loggerFactory = IocResolver.Current.GetService<ILoggerFactory>();
            Logger = loggerFactory.CreateLogger(GetType());
        }

        protected ILogger Logger { get; }
    }

    [Area("Admin")]
    public class AdminBaseController : BaseController
    {
    }
}