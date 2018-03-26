using bmcdavid.Web.Business.Services;
using bmcdavid.Web.Models;
using bmcdavid.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmcdavid.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SkillRepository _skillRepository;
        private readonly ViewDependencies _viewDependencies;

        //private readonly Func<HomepageViewModel> _homeViewFactory;

        public HomeController(SkillRepository skillRepository, ViewDependencies viewDependencies)
        {
            _skillRepository = skillRepository;
            _viewDependencies = viewDependencies;
            //_homeViewFactory = homeViewFactory;
        }

        public IActionResult Index()
        {
            //var model2 = base.HttpContext.RequestServices.GetService(typeof(HomepageViewModel));// _homeViewFactory.Invoke();

            var model = new SimpleWebPage()
            {
                BrowserTitle = _viewDependencies.BrowserTitleBase + _viewDependencies.BrowserTitleSeperator + "Home",
                PageTitle = "About me"
            };

            return View(model);
        }
    }
}
