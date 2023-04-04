using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    public class ApiControllerBaseCrud : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
