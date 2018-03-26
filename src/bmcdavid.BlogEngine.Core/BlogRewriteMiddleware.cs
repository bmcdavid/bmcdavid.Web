using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace bmcdavid.BlogEngine.Core
{
    /// <summary>
    /// Maps Canonical urls to blog controller path, ex: /blog/article/{id:guid}
    /// </summary>
    public class BlogRewriteMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IBlogPublicRepository _blogRepository;
        private readonly BlogRewriteMiddlewareOptions _options;

        public BlogRewriteMiddleware(RequestDelegate next, IBlogPublicRepository blogRepository, IOptions<BlogRewriteMiddlewareOptions> options)
        {
            _next = next;
            _blogRepository = blogRepository?? throw new ArgumentNullException(nameof(blogRepository));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));            
        }

        public async Task Invoke(HttpContext context)
        {
            if (_options.IgnoreRoutes?.Any(x => x.StartsWithSegments(context.Request.Path, StringComparison.OrdinalIgnoreCase)) != true)
            {
                if (_blogRepository.IsCanonicalRequestForBlog(context.Request, out var blog))
                {
                    context.Items[blog.Id] = blog; // todo, should this be set as route data
                    context.Request.Path = _options.ControllerRoute + blog.Id;
                }
            }

            await _next(context);
        }
    }
}