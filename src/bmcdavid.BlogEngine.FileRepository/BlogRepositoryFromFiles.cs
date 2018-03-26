using bmcdavid.BlogEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bmcdavid.BlogEngine.FileRepository
{
    public class BlogRepositoryFromFiles : IBlogRepository
    {
        private readonly IBlogFileStore _blogFileStore;

        public BlogRepositoryFromFiles(IBlogFileStore blogFileStore)
        {
            _blogFileStore = blogFileStore;
        }

        public IEnumerable<IBlogArticle> GetAllBlogs()
        {
            return _blogFileStore.GetBlogs();
        }

        public IBlogArticle GetBlogById(Guid id)
        {
            var blog = GetAllBlogs().FirstOrDefault(x => x.Id == id);

            return blog;
        }        
    }
}