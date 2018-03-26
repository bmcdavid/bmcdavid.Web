using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace bmcdavid.BlogEngine.Core
{
    public class BlogRewriteMiddlewareOptions
    {
        /// <summary>
        /// Ex: /blog/article/{id:guid}
        /// </summary>
        public PathString ControllerRoute { get; set; }

        /// <summary>
        /// Paths to Ignore when rewriting paths
        /// </summary>
        public IEnumerable<PathString> IgnoreRoutes { get; set; }
    }
}