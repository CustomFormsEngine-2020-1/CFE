using Microsoft.AspNetCore.Mvc;

namespace CFE.WebUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
