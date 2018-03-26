using bmcdavid.BlogEngine.Core;

namespace bmcdavid.Web.Models.ViewModels
{
    public class BlogArticleViewModel : IWebPage
    {
        private readonly IBlogArticle _blogArticle;

        public BlogArticleViewModel(IBlogArticle blogArticle)
        {
            _blogArticle = blogArticle;
        }

        public string BrowserTitle => _blogArticle.Title;

        public string PageTitle => _blogArticle.Title;

        public IBlogArticle Blog => _blogArticle;

        public string EnvironmentName { get; set; }
    }
}
