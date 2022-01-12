using Microsoft.AspNetCore.Mvc;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
