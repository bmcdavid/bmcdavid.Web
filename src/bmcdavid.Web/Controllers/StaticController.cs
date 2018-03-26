using bmcdavid.Web.Models;
using bmcdavid.Web.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace bmcdavid.Web.Controllers
{
    public class StaticController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ViewDependencies _viewDependencies;

        public StaticController(IHostingEnvironment hostingEnvironment, ViewDependencies viewDependencies)
        {
            _hostingEnvironment = hostingEnvironment;
            _viewDependencies = viewDependencies;
        }

        public IActionResult StaticContent(string page)
        {
            var view = $"Views\\Pages\\{page}.cshtml";
            var file = _hostingEnvironment.ContentRootFileProvider.GetFileInfo(view);
            if (!file.Exists) return StatusCode(404);

            var model = new SimpleWebPage()
            {
                BrowserTitle = _viewDependencies.BrowserTitleBase + _viewDependencies.BrowserTitleSeperator + page,
            };

            return View(view, model);
        }
    }
}
