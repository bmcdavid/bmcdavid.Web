using bmcdavid.BlogEngine.Core;
using CommonMark;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bmcdavid.BlogEngine.FileRepository
{
    public class BlogJsonFileStore : IBlogFileStore, IBlogSourceFileStore
    {
        private const string BlogExtension = "json";
        private const string BlogFolder = "Data\\Blogs";
        private readonly IHostingEnvironment _hostingEnvironment;
        private List<IBlogArticleWithBodyFile> _blogArticles;

        public BlogJsonFileStore(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _blogArticles = new List<IBlogArticleWithBodyFile>();
        }

        public virtual string BlogsBodySourceFolder => $"{_hostingEnvironment.ContentRootPath}\\{BlogFolder}\\source\\";

        public virtual string BlogsFolder => $"{_hostingEnvironment.ContentRootPath}\\{BlogFolder}";

        protected virtual Type BlogArticleFileImplementation { get; set; } = typeof(BlogArticleFile);

        public string GetBlogBody(IBlogArticleWithBodyFile blogArticle, string physicalPath)
        {
            var fileInfo = new FileInfo(physicalPath);
            var sourceName = $"{fileInfo.Name.Replace(fileInfo.Extension, string.Empty)}";
            var sourcePath = $"{BlogsBodySourceFolder}{sourceName}{GetSourceExtensions(blogArticle.SourceType)}";

            if (!File.Exists(sourcePath))
            {
                //todo: logging
                blogArticle.SetStatus(BlogStatus.NotFound);
                return null;
            }

            var text = File.ReadAllText(sourcePath);

            if (blogArticle.SourceType == BlogSourceType.Markdown)
            {
                //todo: make this injectable via IMarkdownService.Process
                return CommonMarkConverter.Convert(text);
            }

            return text;
        }

        public IList<IBlogArticleWithBodyFile> GetBlogs()
        {
            if (_blogArticles.Count > 0) return _blogArticles;
            var blogs = _hostingEnvironment.ContentRootFileProvider.GetDirectoryContents(BlogFolder);

            foreach (var b in blogs)
            {
                if (b.IsDirectory) continue;
                if (!b.PhysicalPath.EndsWith(BlogExtension)) continue;
                var blog = JsonConvert.DeserializeObject(File.ReadAllText(b.PhysicalPath), BlogArticleFileImplementation) as IBlogArticleWithBodyFile;

                if (blog == null) continue;
                blog.SetBlogSourceFileStore(this, b.PhysicalPath);

                _blogArticles.Add(blog);
            }

            _blogArticles = _blogArticles.OrderBy(x => x.Date).ToList();

            return _blogArticles;
        }

        public void ReloadBlogs()
        {
            _blogArticles.Clear();
        }

        private static string GetSourceExtensions(BlogSourceType blogSourceType)
        {
            return blogSourceType == BlogSourceType.Markdown ? ".md" : ".html";
        }
    }
}
