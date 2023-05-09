using Microsoft.AspNetCore.Mvc;

namespace HelthFundMVC.Controllers
{
    public class VaccinesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
