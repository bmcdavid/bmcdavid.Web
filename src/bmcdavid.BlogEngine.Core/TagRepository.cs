using System.Collections.Generic;
using System.Linq;

namespace bmcdavid.BlogEngine.Core
{
    public class TagRepository : ITagRepository
    {
        private readonly IBlogRepository _blogRepository;

        private List<string> _tags;

        public TagRepository(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
            _tags = new List<string>();
        }

        public IEnumerable<string> GetTags()
        {
            if (_tags.Any()) return _tags;

            _tags =_blogRepository
                .GetAllBlogs()
                .SelectMany(b => b.Tags)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            return _tags;
        }
    }
}
