using Microsoft.AspNetCore.Mvc;

namespace MapDynamicControllerRouteTest.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Foo(string seName)
        {
            return Content("it works!");
        }
        
        public IActionResult Bar(string seName)
        {
            return Content("it still works!");
        }
    }
}