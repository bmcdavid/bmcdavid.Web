using bmcdavid.BlogEngine.Core;
using bmcdavid.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace bmcdavid.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPublicRepository _blogRepo;
        private readonly ITagRepository _tagRepository;

        public BlogController(IBlogPublicRepository blogRepo, ITagRepository tagRepository)
        {
            _blogRepo = blogRepo;
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            var model = new BlogListViewModel
            {
                Tag = "Latest Articles",
                Blogs = _blogRepo.GetRecentBlogs(1, 10)
            };
            return View(model);
        }

        public IActionResult Tag(string id)
        {
            var tag = _tagRepository.GetTags().FirstOrDefault(t => string.Compare(id, t, true) == 0);

            if (tag == null)
            {
                return StatusCode(404);
            }

            var model = new BlogListViewModel
            {
                Tag = $"{tag} Articles",
                Blogs = _blogRepo.GetBlogsWithTag(id, 1, 100)
            };

            return View(nameof(Index), model);
        }

        public IActionResult Article(Guid id)
        {
            var blog = HttpContext.Items[id] as IBlogArticle ?? _blogRepo.GetBlogById(id);

            if (blog == null)
            {
                return StatusCode(404);
            }

            return View(new BlogArticleViewModel(blog));
        }
    }
}