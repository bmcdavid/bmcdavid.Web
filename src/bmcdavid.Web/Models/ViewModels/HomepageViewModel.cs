using bmcdavid.BlogEngine.Core;

namespace bmcdavid.Web.Models.ViewModels
{
    public class HomepageViewModel : IWebPage
    {
        private readonly ViewDependencies _viewDependencies;
        private IBlogPublicRepository _blogPublicRepository;

        public HomepageViewModel(ViewDependencies viewDependencies, IBlogPublicRepository blogPublicRepository)
        {
            _viewDependencies = viewDependencies;
            _blogPublicRepository = blogPublicRepository;
            EnvironmentName = _viewDependencies.EnvironmentName;
        }

        public string BrowserTitle { get; set; }

        public string PageTitle { get; set; }

        public string EnvironmentName { get; set; }
    }
}
