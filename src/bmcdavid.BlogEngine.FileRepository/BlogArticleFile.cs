using bmcdavid.BlogEngine.Core;

namespace bmcdavid.BlogEngine.FileRepository
{
    public class BlogArticleFile : BlogArticle, IBlogArticleWithBodyFile
    {
        private IBlogSourceFileStore _blogFileStore;
        private string _body;
        private string _bodyFromSource;
        private bool _bodyReadFromSource;

        public override string Body
        {
            get => GetBody();
            set => _body = value;
        }

        private string _filePath;

        public BlogSourceType SourceType { get; set; }

        public void SetBlogSourceFileStore(IBlogSourceFileStore blogFileStore, string blogPhysicalPath)
        {
            _blogFileStore = blogFileStore;
            _filePath = blogPhysicalPath;
        }

        public void SetStatus(BlogStatus status)
        {
            Status = status;
        }

        private string GetBody()
        {
            if (_bodyReadFromSource) return _bodyFromSource;

            _bodyFromSource = _blogFileStore.GetBlogBody(this, _filePath);
            _bodyReadFromSource = true;

            return _bodyFromSource;
        }
    }
}