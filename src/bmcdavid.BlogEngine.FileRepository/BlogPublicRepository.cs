using bmcdavid.BlogEngine.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace bmcdavid.BlogEngine.FileRepository
{
    public class BlogPublicRepository : IBlogPublicRepository
    {
        private readonly IBlogRepository _blogRepository;
        private readonly BlogRepositoryFilterForPublic _publicFilter;

        public BlogPublicRepository(IBlogRepository blogRepository, BlogRepositoryFilterForPublic publicBlogFilter)
        {
            _blogRepository = blogRepository;
            _publicFilter = publicBlogFilter;
        }

        public IBlogArticle GetBlogById(Guid id)
        {
            var blog = _blogRepository.GetBlogById(id);

            return _publicFilter.Filter(blog) ? null : blog;
        }

        public IEnumerable<IBlogArticle> GetBlogsWithTag(string tag, int page, int pageSize)
        {
            Func<IBlogArticle, object> sort = b => b.Date;
            //Expression<Func<IBlogArticle, bool>> filter;

            page = page < 1 ? 1 : page;
            var blogs = _blogRepository
                .GetAllBlogs()
                .Where(x => x.Tags?.Contains(tag, StringComparer.OrdinalIgnoreCase) == true)
                .Where(_publicFilter.Filter)
                .OrderByDescending(sort)
                .ToList();

            return blogs.Skip(page - 1).Take(pageSize);
        }

        public IEnumerable<IBlogArticle> GetRecentBlogs(int page, int pageSize)
        {
            page = page < 1 ? 1 : page;
            var blogs = _blogRepository
                .GetAllBlogs()
                .OrderByDescending(b => b.Date)
                .Where(_publicFilter.Filter)
                .ToList();

             return blogs.Skip(page - 1).Take(pageSize);
        }

        public bool IsCanonicalRequestForBlog(HttpRequest httpRequest, out IBlogArticle blogArticle)
        {
            string path = httpRequest?.Path.Value?.TrimStart('/');

            blogArticle = _blogRepository
                .GetAllBlogs()?
                .FirstOrDefault(x => string.Compare(x.CanonicalUrl, path, StringComparison.OrdinalIgnoreCase) == 0);

            if (!_publicFilter.Filter(blogArticle)) return false;

            return true;
        }


        /// <summary>
        /// hack: converts the interface expression to entity model for base class to fullful contract
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private Expression<Func<BlogArticleFile, bool>> ConvertExpression(Expression<Func<IBlogArticle, bool>> exp)
        {
            if (exp == null)
                return null;

            return Expression.Lambda<Func<BlogArticleFile, bool>>(exp.Body, exp.Parameters);
        }
    }
}