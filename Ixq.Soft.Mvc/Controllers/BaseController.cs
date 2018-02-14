using Microsoft.AspNetCore.Mvc;

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