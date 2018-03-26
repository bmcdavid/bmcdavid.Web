using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace bmcdavid.BlogEngine.Core
{
    public static class BlogRewriteMiddlewareExtensions
    {
        /// <summary>
        /// Maps incoming urls to blog controller 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="path">Route to blog controller</param>
        /// <param name="ignorePaths"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlogRewrite(this IApplicationBuilder app, string path, string[] ignorePaths = null)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            return app.UseBlogRewrite(new BlogRewriteMiddlewareOptions()
            {
                ControllerRoute = new PathString(path.TrimEnd('/') + "/"),
                IgnoreRoutes =  ignorePaths?.Select(i => new PathString(i))
            });
        }

        /// <summary>
        /// Maps incoming urls to blog controller 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlogRewrite(this IApplicationBuilder app, BlogRewriteMiddlewareOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<BlogRewriteMiddleware>(Options.Create(options));
        }
    }
}