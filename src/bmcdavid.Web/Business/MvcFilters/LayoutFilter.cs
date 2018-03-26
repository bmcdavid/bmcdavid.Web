using bmcdavid.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace bmcdavid.Web.Business.MvcFilters
{
    public class LayoutFilter : IResultFilter
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public LayoutFilter(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            string s = _hostingEnvironment.EnvironmentName;
            string a = _hostingEnvironment.ApplicationName;

            if (!(context.Result is ViewResult result)) return;
            if (!(result.Model is IWebPage webPage)) return;

            // todo create custom tag helpers to toggle min flag and file version
            //https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.TagHelpers/LinkTagHelper.cs
            webPage.EnvironmentName = _hostingEnvironment.EnvironmentName;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
        }
    }
}
