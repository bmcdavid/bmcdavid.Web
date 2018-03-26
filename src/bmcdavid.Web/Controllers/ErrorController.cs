using bmcdavid.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bmcdavid.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error")]
        public IActionResult Index()
        {
            HttpContext.Response.StatusCode = 500;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            HttpContext.Response.StatusCode = 404;
            return View("PageNotFound", new SimpleWebPage() { BrowserTitle = "Page Not Found" });
        }

        [Route("error/{code:int}")]
        public IActionResult Error(int code)
        {
            // handle different codes or just return the default error view
            return Content("Error " + code);
        }

    }
}
