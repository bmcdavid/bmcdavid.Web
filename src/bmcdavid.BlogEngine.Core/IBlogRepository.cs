using System;
using System.Collections.Generic;

namespace bmcdavid.BlogEngine.Core
{
    public interface IBlogRepository
    {
        IBlogArticle GetBlogById(Guid id);

        IEnumerable<IBlogArticle> GetAllBlogs();
    }
}