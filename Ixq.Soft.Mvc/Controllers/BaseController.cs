using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Mvc.Controllers
{
    public class BaseController : Controller
    {
    }

    [Area("Admin")]
    public class AdminBaseController : BaseController
    {
    }
}