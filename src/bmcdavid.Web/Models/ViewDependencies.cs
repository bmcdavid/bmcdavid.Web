using Microsoft.AspNetCore.Hosting;

namespace bmcdavid.Web.Models
{
    public class ViewDependencies
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ViewDependencies(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string BrowserTitleBase => "bmcdavid.Web";

        public string BrowserTitleSeperator => ": ";

        public bool IsProduction => _hostingEnvironment.IsProduction();

        public bool IsDevelopment => _hostingEnvironment.IsDevelopment();

        public string EnvironmentName => _hostingEnvironment.EnvironmentName;
    }
}
