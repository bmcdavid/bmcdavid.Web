using System.Collections.Generic;

namespace bmcdavid.BlogEngine.Core
{
    public interface ITagRepository
    {
        IEnumerable<string> GetTags();
    }
}
