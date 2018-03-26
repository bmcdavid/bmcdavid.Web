using bmcdavid.BlogEngine.Core;

namespace bmcdavid.BlogEngine.FileRepository
{

    public interface IBlogArticleWithBodyFile : IBlogArticle
    {
        BlogSourceType SourceType { get; }

        void SetBlogSourceFileStore(IBlogSourceFileStore blogFSourceFileStore, string blogPhysicalPath);

        void SetStatus(BlogStatus status);
    }
}