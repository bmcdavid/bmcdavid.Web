using System.Collections.Generic;

namespace bmcdavid.BlogEngine.FileRepository
{
    public interface IBlogFileStore
    {
        string BlogsFolder { get; }

        IList<IBlogArticleWithBodyFile> GetBlogs();

        void ReloadBlogs();
    }
}
