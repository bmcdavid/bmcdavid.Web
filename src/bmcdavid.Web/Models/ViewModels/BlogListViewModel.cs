using bmcdavid.BlogEngine.Core;
using System.Collections.Generic;

namespace bmcdavid.Web.Models.ViewModels
{
    public class BlogListViewModel : IWebPage
    {
        public string Tag { get; set; }

        public IEnumerable<IBlogArticle> Blogs { get; set; }

        public string BrowserTitle { get; set;}

        public string PageTitle { get; set; }

        public string EnvironmentName { get; set; }
    }
}
