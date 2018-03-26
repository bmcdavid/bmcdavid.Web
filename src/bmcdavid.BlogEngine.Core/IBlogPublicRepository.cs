using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace bmcdavid.BlogEngine.Core
{
    public interface IBlogPublicRepository
    {
        IBlogArticle GetBlogById(Guid id);

        bool IsCanonicalRequestForBlog(HttpRequest httpRequest, out IBlogArticle blogArticle);

        IEnumerable<IBlogArticle> GetRecentBlogs(int page, int pageSize);

        IEnumerable<IBlogArticle> GetBlogsWithTag(string tag, int page, int pageSize);
    }
}